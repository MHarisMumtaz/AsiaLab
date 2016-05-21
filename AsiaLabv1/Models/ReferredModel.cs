using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiaLabv1.Models
{
    public class ReferredModel
    {
        public int Id { get; set; }
        public string ReferredDoctorName { get; set; }
        public string ReferredDocAddress { get; set; }
        public string ReferredDocNumber { get; set; }
        public string Remarks { get; set; }
    }

}