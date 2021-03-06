//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsiaLabv1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Branch
    {
        public Branch()
        {
            this.Contacts = new HashSet<Contact>();
            this.Patients = new HashSet<Patient>();
            this.UserEmployees = new HashSet<UserEmployee>();
        }
    
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchCode { get; set; }
    
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<UserEmployee> UserEmployees { get; set; }
    }
}
