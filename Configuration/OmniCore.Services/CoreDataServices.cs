﻿using System;
using System.Collections.Generic;
using System.Text;
using OmniCore.Model.Constants;
using OmniCore.Model.Interfaces.Data;
using OmniCore.Model.Interfaces.Services;
using Unity;

namespace OmniCore.Services
{
    public class CoreDataServices : ICoreDataServices
    {
        [Dependency(RegistrationConstants.OmnipodEros)]
        public IPodService OmnipodErosService { get; set; }

        [Dependency(RegistrationConstants.RileyLink)]
        public IRadioService RileyLinkRadioService { get; set; }

        [Dependency]
        public IRepositoryService RepositoryService { get; set; }
    }
}
