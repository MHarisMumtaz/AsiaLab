using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiaLabv1.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string UserRole { get; set; }
    }
}