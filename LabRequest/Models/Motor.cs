using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LabRequest.Models
{
    public enum OverloadAttachments
    {
        OnWinding,
        OffWinding
    }
    public enum OverloadTypes
    {
        Automatic,
        Manual
    }
    public enum EnclosureTypes
    {
        AO,
        Self
    }
    public enum VoltageType
    {
        Single,
        Spread,
        Dual,
        DualSpread

    }
    public enum PoleType
    {
        Two,
        Four,
        Eight,
        Twelve
    }
    public enum StartingSpeedOptions
    {
        High,
        Low,
        Both
    }
    public enum DutyCycleOptions
    {
        Intermittent,
        Continuous
    }
    public enum CoolingType
    {
        AO,
        Self
    }
    public enum PhaseOptions
    {
        Single,
        Three,
    }
    public enum VoltageOptions
    {
        Single,
        Spread,
        Dual,
        DualSpread
    }
    public enum FrequencyValues
    {
        Fifty,
        Sixty,
        FiftyOverSixty 
    }
    public enum FrequencyTypes
    {
        Single,
        Double
    }
    public enum ElectricalTypeOptions
    {
        CSCR,
        CSIR,
        POLY,
        PSC,
        SP,
        SPCR,
        PMDC,
        PMAC,
        ECM

    }
    public enum SpeedOptions
    {
        Single,
        Two
    }

    [Serializable]
    public class Motor
    {
        public int? ModelNumber;
        public ElectricalTypeOptions? ElectricalType;
        public SpeedOptions? Speed; 
        public VoltageOptions? Voltage;
        public PhaseOptions? Phase;
        public PoleType? Poles;
        public bool? Overload;
        public CoolingType? Cooling;
        public DutyCycleOptions? DutyCycle;
        public StartingSpeedOptions? StartingSpeed;
        public int? HorsePower;
        public EnclosureTypes? Enclosure;
        public OverloadTypes? OverloadType;
        public OverloadAttachments? OverloadAttachment;
        public FrequencyValues? FrequencyValue;
        public FrequencyTypes? FrequencyTypes;

        public static IForm<Motor> BuildForm()
        {
            return new FormBuilder<Motor>()
                .Message("Welcome to the Motor form bot!")
                .Build();
        }
    }

  
}