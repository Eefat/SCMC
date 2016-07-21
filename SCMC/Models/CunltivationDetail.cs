using System;
using System.ComponentModel.DataAnnotations;

namespace SCMS.Models
{
    public enum CaneVariety
    {
        A, B, C, D, F
    }
    public class CunltivationDetail
    {
        public int ID { get; set; }
        public int FarmerId { get; set; }
        public Decimal LandArea { get; set; }
        public CaneVariety? CaneVariety { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Plant/Ratoon")]
        public DateTime? PlantRatoon { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Planting")]
        public DateTime DateofPlanting { get; set; }
        public Decimal EstimatedTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Deliver Date")]
        public DateTime? DeliverDate { get; set; }
        public virtual Farmer Farmer { get; set; }
    }
}
