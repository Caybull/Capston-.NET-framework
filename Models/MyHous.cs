namespace MyDynastyHomesAuth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MyHouses")]
    public partial class MyHous
    {
       


        [Required]
        [StringLength(50)]
        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Display(Name = "Lot Size (SQFT)")]
        public decimal? LotSize { get; set; }

        [Display(Name = "Square Footage")]
        public decimal? SquareFootage { get; set; }

        public decimal? Stories { get; set; }
        [Display(Name = "Number Of Bedrooms")]
        public decimal? BedroomCount { get; set; }
        [Display(Name = "Number Of Bathrooms")]
        public decimal? BathroomCount { get; set; }
        [Display(Name = "Total Rooms")]
        public decimal? RoomCount { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
       public int ID { get; set; }
        [Display(Name = "House Renovation Cost")]
        public decimal RenovationCost { get; set; }
        [Display(Name = "Bathrooms Cost")]
        public decimal? BathroomCost { get; set; }
        [Display(Name = "Exterior Cost")]
        public decimal? ExteriorCost { get; set; }
        [Display(Name = "Interior Cost")]
        public decimal? InteriorCost { get; set; }
        [Display(Name = "Kitchen Cost")]
        public decimal? KitchenCost { get; set; }
        [Display(Name = "Utility Costs")]
        public decimal? UtilitiesCost { get; set; }

        public virtual Bathroom Bathroom { get; set; }

        public virtual Exterior Exterior { get; set; }

        public virtual Interior Interior { get; set; }

        public virtual Kitchen Kitchen { get; set; }

        public virtual Utility Utility { get; set; }

        
        [ForeignKey("AspNetUser")]
        [Column(Order = 2)]
       public string UserId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
