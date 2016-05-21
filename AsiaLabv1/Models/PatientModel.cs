using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsiaLabv1.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int BranchId { get; set; }

        public IEnumerable<int> PatientTestIds { get; set; }
        public int ReferredId { get; set; }
        public List<SelectListItem> ReferredDoctors { get; set; }
        public int GenderId { get; set; }
        public List<SelectListItem> Genders { get; set; }
        public int DeptId { get; set; }
        public List<SelectListItem> Departments { get; set; }

        public PatientModel()
        {
            this.PatientTestIds = new List<int>();
            this.ReferredDoctors = new List<SelectListItem>();
            this.Genders = new List<SelectListItem>();
            this.Departments = new List<SelectListItem>();
        }
    }
}