namespace MyDynastyHomesAuth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bathroom")]
    public partial class Bathroom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Display(Name = "Sinks")]
        public decimal Number_Of_Sinks { get; set; }
        [Display(Name = "Toilets")]
        public decimal Number_Of_Toilets { get; set; }
        [Display(Name = "Showers")]
        public decimal Number_Of_Showers { get; set; }
        [Display(Name = "Cost")]
        public decimal RepairCost { get; set; }

   
        public virtual MyHous MyHous { get; set; }

       
    }
}
