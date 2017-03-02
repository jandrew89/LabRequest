using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;
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
    public enum DutyCycleOptionsMin
    {

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
        [Terms("Single")]
        Single = 1,
        [Terms("Two")]
        Two = 2
    }
    //public class Frame
    //{
    //    public List<int> Frames { get; }
    //    public Frame()
    //    {
    //        this.Frames = new List<int>() { 182,36,48,56};
    //    }
    //}

    [Serializable]
    public class Motor
    {
        [Optional]
        public int? ModelNumber;
        public PhaseOptions? Phase;
        public ElectricalTypeOptions? ElectricalType;

        public SpeedOptions? Speed;
        [Optional]
        [Template(TemplateUsage.NoPreference, "None")]
        public StartingSpeedOptions? StartingSpeed;
        public VoltageOptions? Voltage;
        public PoleType? Poles;
        public bool? Overload;
        public CoolingType? Cooling;

        public DutyCycleOptions? DutyCycle;
        [Optional]
        public string DutyCycleMins;
        //public int? HorsePower;
        //public EnclosureTypes? Enclosure;
        //public OverloadTypes? OverloadType;
        //public OverloadAttachments? OverloadAttachment;
        //public FrequencyValues? FrequencyValue;
        //public FrequencyTypes? FrequencyTypes;

        public static IForm<Motor> BuildForm()
        {
#pragma warning disable CS1998
            return new FormBuilder<Motor>()
                .Message("Welcome to the Motor form bot!")
                //.Field(nameof(ModelNumber))
                .Field(nameof(Phase))
                .Field(nameof(DutyCycle))
                //.Field(nameof(Speed))
                .Field(new FieldReflector<Motor>(nameof(DutyCycleMins))
                    .SetType(null)
                    .SetActive((state) => state.DutyCycle == DutyCycleOptions.Intermittent)
                    .SetDefine(async (state, field) =>
                    {
                        field
                            .AddDescription("15", "15")
                            .AddTerms("15", "15")
                            .AddDescription("20", "20")
                            .AddTerms("20", "20")
                            .AddDescription("45", "45")
                            .AddTerms("45", "45")
                            .AddDescription("60", "60")
                            .AddTerms("60", "60")
                            .AddDescription("90", "90")
                            .AddTerms("90", "90");
                        return true;
                    }))
                .Field(new FieldReflector<Motor>(nameof(ElectricalType))
                    .SetActive((state) => state.Phase == PhaseOptions.Single)
                    .SetDefine(async (state, field) =>
                    {
                        field.RemoveValue(ElectricalTypeOptions.POLY);
                        return true;
                    }))
                .AddRemainingFields()
                .Message("Thank you for filling out the motor form.")                  
                .Build();
#pragma warning restore CS1998
        }
    }

  
}