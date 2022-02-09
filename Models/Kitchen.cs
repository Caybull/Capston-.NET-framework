namespace MyDynastyHomesAuth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kitchen")]
    public partial class Kitchen
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Display(Name = "Refrigerators")]
        public decimal Refrigerator { get; set; }
        [Display(Name = "Ovens")]
        public decimal Oven { get; set; }
        [Display(Name = "Microwave")]
        public decimal Microwave { get; set; }
        [Display(Name = "Dishwashers")]
        public decimal Dishwasher { get; set; }
        [Display(Name = "Garbage Disposals")]
        public decimal Garbage_Disposal { get; set; }

        public decimal Cabinets { get; set; }
        [Display(Name = "Counter Tops (SQFT)")]
        public decimal Counter_Tops_SQFT { get; set; }
        [Display(Name = "Sinks")]
        public decimal Sink { get; set; }
        [Display(Name = "Cost")]
        public decimal? RepairCost { get; set; }

        

        public virtual MyHous MyHous { get; set; }

       
    }
}
