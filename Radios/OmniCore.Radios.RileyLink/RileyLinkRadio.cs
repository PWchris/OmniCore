﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OmniCore.Model.Constants;
using OmniCore.Model.Enumerations;
using OmniCore.Model.Interfaces.Data.Entities;
using OmniCore.Model.Interfaces.Data.Repositories;
using OmniCore.Model.Interfaces.Platform;
using Unity;

namespace OmniCore.Radios.RileyLink
{
    public class RileyLinkRadio : IRadio
    {
        public IRadioPeripheral Peripheral { get; set; }
        public IRadioEntity Entity { get; set; }
        public IRadioConfiguration DefaultConfiguration { get => new RadioConfiguration(); }

        public IRadioConfiguration GetConfiguration()
        {
            var json = Entity.ConfigurationJson;
            if (string.IsNullOrEmpty(json))
                return DefaultConfiguration;
            return JsonConvert.DeserializeObject<RadioConfiguration>(json);

        }

        public async Task SetConfiguration(IRadioConfiguration configuration)
        {
            Entity.ConfigurationJson = JsonConvert.SerializeObject(configuration);
            await RadioRepository.Update(Entity, CancellationToken.None);
        }

        private readonly IRadioAdapter Adapter;
        private readonly IUnityContainer Container;
        private readonly IRadioRepository RadioRepository;
        public RileyLinkRadio(IRadioAdapter adapter,
            IUnityContainer container,
            IRadioRepository radioRepository)
        {
            Adapter = adapter;
            Container = container;
            RadioRepository = radioRepository;
        }
        public async Task<IRadioLease> Lease(CancellationToken cancellationToken)
        {
            var peripheralLease = await Peripheral.Lease(cancellationToken);
            InUse = true;
            var radioLease = Container.Resolve<IRadioLease>(RegistrationConstants.RileyLink);
            radioLease.PeripheralLease = peripheralLease;
            radioLease.Radio = this;
            return radioLease;
        }

        public bool InUse { get; set; }
        private RadioActivity ActivityInternal = RadioActivity.Idle;
        public RadioActivity Activity
        {
            get => ActivityInternal;
            set
            {
                ActivityInternal = value;
                ActivityStartDate = DateTimeOffset.UtcNow;
            }
        }
        public DateTimeOffset? ActivityStartDate { get; private set; } = DateTimeOffset.UtcNow;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
