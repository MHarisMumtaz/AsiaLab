﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AsiaLabdb2Entities : DbContext
    {
        public AsiaLabdb2Entities()
            : base("name=AsiaLabdb2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DoctorComment> DoctorComments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientRefer> PatientRefers { get; set; }
        public DbSet<PatientTestResult> PatientTestResults { get; set; }
        public DbSet<PatientTestResult1> PatientTestResults1 { get; set; }
        public DbSet<PatientTest> PatientTests { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PayType> PayTypes { get; set; }
        public DbSet<Refer> Refers { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TestCategory> TestCategories { get; set; }
        public DbSet<TestDepartment> TestDepartments { get; set; }
        public DbSet<TestSubcategory> TestSubcategories { get; set; }
        public DbSet<UserEmployee> UserEmployees { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
