namespace MyDynastyHomesAuth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RepairMultiplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public decimal BathroomSink { get; set; }

        public decimal Toilet { get; set; }

        public decimal Shower { get; set; }

        public decimal Window { get; set; }

        public decimal SidingPerSQFT { get; set; }

        public decimal Roof { get; set; }

        public decimal FoundationWall { get; set; }

        public decimal ExteriorDoor { get; set; }

        public decimal TreeRemoval { get; set; }

        public decimal PaintPerRoom { get; set; }

        public decimal DrywallPerSQFT { get; set; }

        public decimal FloorsPerSQFT { get; set; }

        public decimal LightFixture { get; set; }

        public decimal Baseboards { get; set; }

        public decimal SubfloorPerSQFT { get; set; }

        public decimal Refrigerator { get; set; }

        public decimal Oven { get; set; }

        public decimal Microwave { get; set; }

        public decimal Dishwasher { get; set; }

        public decimal GarbageDisposal { get; set; }

        public decimal Cabinet { get; set; }

        public decimal CounterTopsPerSQFT { get; set; }

        public decimal KitchenSink { get; set; }

        public decimal FurnacePerStory { get; set; }

        public decimal AirConditioningUnitPerStory { get; set; }

        public decimal HotWaterHeater { get; set; }

        public decimal Electric { get; set; }

        public decimal Plumbing { get; set; }

        public decimal Sewer { get; set; }


    }
}
