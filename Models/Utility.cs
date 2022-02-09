namespace MyDynastyHomesAuth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Utility
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        
        public decimal Furnaces { get; set; }

        [Display(Name ="A/C Units")]
        public decimal AirConditioning_Units { get; set; }

        [Display(Name = "Hot water heaters")]
        public decimal Hot_Water_Heater { get; set; }

        [Display(Name = "Electric")]
        public decimal Electric { get; set; }

        [Display(Name = "Plumbing")]
        public decimal Plumbing { get; set; }

        [Display(Name = "Sewer")]
        public decimal Sewer { get; set; }

        public decimal? RepairCost { get; set; }

       

     

        public virtual MyHous MyHous { get; set; }

      
    }
}
