using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMC.Models
{
    public class FarmerSearchModel
    {
        public string FirsName { get; set; }
        public String MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string NationalIdNo { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}