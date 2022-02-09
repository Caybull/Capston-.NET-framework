namespace MyDynastyHomesAuth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Interior")]
    public partial class Interior
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Display(Name = "Rooms to be painted")]
        public decimal Paint_Number_Of_Rooms { get; set; }
        [Display(Name = "Drywall (SQFT)")]
        public decimal Drywall_SQFT { get; set; }
        [Display(Name = "Floors (SQFT")]
        public decimal Floors_SQFT { get; set; }
        [Display(Name = "Light Fixtures")]
        public decimal Number_Of_Light_Fixtures { get; set; }
        [Display(Name = "Baseboard (linear FT)")]
        public decimal Baseboard_Linear_Foot { get; set; }
        [Display(Name = "Subfloor (SQFT)")]
        public decimal Subfloor_SQFT { get; set; }
        [Display(Name = "Cost")]
        public decimal? RepairCost { get; set; }

     

        public virtual MyHous MyHous { get; set; }

       
    }
}
