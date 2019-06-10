﻿using OmniCore.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmniCore.Model.Interfaces
{
    public interface IPodFault
    {
        long? Id { get; set; }
        long ResultId { get; set; }

        int? FaultCode { get; set; }
        int? FaultRelativeTime { get; set; }
        bool? FaultedWhileImmediateBolus { get; set; }
        uint? FaultInformation2LastWord { get; set; }
        int? InsulinStateTableCorruption { get; set; }
        int? InternalFaultVariables { get; set; }
        PodProgress? ProgressBeforeFault { get; set; }
        PodProgress? ProgressBeforeFault2 { get; set; }
        int? TableAccessFault { get; set; }
    }
}
