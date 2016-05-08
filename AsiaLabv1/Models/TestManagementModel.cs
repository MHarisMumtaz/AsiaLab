using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsiaLabv1.Models
{
    public class TestManagementModel
    {
        public int deptId { get; set; }
        public string deptName { get; set; }
      
        public List<SelectListItem> departments { get; set; }
        public string testCategoryName { get; set; }
        public int testCategoryId { get; set; }



        public TestManagementModel()
        {
            departments = new List<SelectListItem>();
        }


    }
}