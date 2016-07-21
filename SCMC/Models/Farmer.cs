using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCMS.Models
{
    public class Farmer
    {
        public int ID { get; set; }
        public string FirsName { get; set; }
        public String MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string NationalIdNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<CunltivationDetail> CunltivationDetails { get; set; }
    }
}
