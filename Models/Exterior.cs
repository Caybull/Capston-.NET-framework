namespace MyDynastyHomesAuth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exterior")]
    public partial class Exterior
    {
        [Display(Name = "Street Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Display(Name = "Windows")]
        [Column("_Windows")]
        public decimal C_Windows { get; set; }
        [Display(Name = "Siding (SQFT)")]
        public decimal Siding_SQFT { get; set; }
        [Display(Name = "Roof (SQFT)")]
        public decimal Roof_SQFT { get; set; }
        [Display(Name = "Foundation Walls")]
        public decimal Number_Of_Foundation_Walls { get; set; }
        [Display(Name = "Exterior Doors")]
        public decimal Number_Of_Doors { get; set; }
        [Display(Name = "Tree Removals")]
        public decimal Number_Of_Trees { get; set; }
        [Display(Name = "Cost")]
        public decimal? RepairCost { get; set; }

       
        public virtual MyHous MyHous { get; set; }

       
    }
}
