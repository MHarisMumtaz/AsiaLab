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
    
    public partial class Refer
    {
        public Refer()
        {
            this.PatientRefers = new HashSet<PatientRefer>();
        }
    
        public int Id { get; set; }
        public string ReferredDoctorName { get; set; }
        public string ReferredDocAddress { get; set; }
        public string ReferredDocNumber { get; set; }
        public string Remarks { get; set; }
        public double commission { get; set; }
    
        public virtual ICollection<PatientRefer> PatientRefers { get; set; }
    }
}
