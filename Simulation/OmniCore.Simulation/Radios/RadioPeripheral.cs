﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OmniCore.Model.Enumerations;
using OmniCore.Model.Interfaces;

namespace OmniCore.Simulation.Radios
{
    public class RadioPeripheral : IRadioPeripheral
    {
        public void Dispose()
        {
        }

        public Guid Uuid { get; }

        public string Name
        {
            get;
            set;
        }
        public Task<IRadioPeripheralLease> Lease(CancellationToken cancellationToken)
        {
            return Task.FromResult((IRadioPeripheralLease)new RadioPeripheralLease());
        }

        public TimeSpan? RssiUpdateTimeSpan { get; set; }
        public int? Rssi { get; set; }
        public DateTimeOffset? RssiDate { get; }
        
        public PeripheralState State { get; }
        public DateTimeOffset? ConnectionStateDate { get; }
        public DateTimeOffset? DisconnectDate { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
