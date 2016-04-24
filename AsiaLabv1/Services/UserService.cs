﻿using AsiaLabv1.Models;
using AsiaLabv1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiaLabv1.Services
{
    public class UserService
    {
        //these repositories are used to access database tables
        //some common CRUD of database methods have the repository are insert,update,delete,deletebyid,deleteall
        Repository<UserEmployee> UserEmp = new Repository<UserEmployee>();
        Repository<UserType> UserTypes = new Repository<UserType>();
        Repository<Address> UserAddresses = new Repository<Address>();
        Repository<Branch> Branches = new Repository<Branch>();
        Repository<Gender> Genders = new Repository<Gender>();

        public UserModel ValidateLogin(string UserName, string Password)
        {
            var Query = (from user in UserEmp.Table
                         join branch in Branches.Table on user.BranchId equals branch.Id
                         join addr in UserAddresses.Table on user.Id equals addr.UserEmployeeId
                         join usertype in UserTypes.Table on addr.UserTypeId equals usertype.Id
                         where (user.Username == UserName && user.Password == Password)
                         select new
                         {
                             UserId = user.Id,
                             UserName = user.Name,
                             BranchName = branch.BranchName,
                             BranchAddress = branch.BranchAddress,
                             UserRole = usertype.TypeDescription
                         }).FirstOrDefault();
            var model = new UserModel();
            if (Query != null)
            {
                model.Id = Query.UserId;
                model.Name = Query.UserName;
                model.BranchName = Query.BranchName;
                model.BranchAddress = Query.BranchAddress;
                model.UserRole = Query.UserRole;
                return model;
            }
            return null;
        }

        public void AddUser()
        {
            //var f = Genders.GetAll();
            //Genders.Insert(new Gender
            //{
            //    GenderDescription = "Male"
            //});
            //Genders.Insert(new Gender
            //{
            //    GenderDescription = "Female"
            //});

            var useremp = new UserEmployee()
            {
                Name="Hassan Reciptionist",
                Username = "testtechnician",
                Password = "techniciantest2016",
                BranchId = 1
            };
           
            UserEmp.Insert(useremp);
            UserAddresses.Insert(new Address
            {
                UserEmployeeId = useremp.Id,
                UserTypeId = 4,
                ContactNo = "0345-6789654",
                Email = "test@gmail.com",
                GenderId = 1,
                Qualification = "MBA",
                AddressDetail = "H block test address karachi",
                CNIC = "42101-test"
            });

        }

        public void AddUserType(string UserRole)
        {
            UserTypes.Insert(new UserType
            {
                TypeDescription = UserRole
            });
        }
    }
}