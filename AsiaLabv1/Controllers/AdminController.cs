using AsiaLabv1.Models;
using AsiaLabv1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsiaLabv1.Controllers
{
    public class AdminController : Controller
    {

        UserService UserServices = new UserService();
        BranchService BranchServices = new BranchService();
        GenderService GenderServices = new GenderService();
        TestDeptService TestDeptServices = new TestDeptService();
        TestCategoryService TestCategoryServices = new TestCategoryService();

        public ActionResult Register()
        {
            UserModel model = new UserModel();
            var branches = BranchServices.GetAllBranches();
            
            foreach (var item in branches)
            {
                model.Branches.Add(new SelectListItem
                {
                    Text = item.BranchName,
                    Value = item.Id.ToString()
                });
            }

            var Genders = GenderServices.GetAll();
            foreach (var item in Genders)
            {
                model.Genders.Add(new SelectListItem
                {
                    Text = item.GenderDescription,
                    Value = item.Id.ToString()
                });
            }
            var UserTypes = UserServices.GetAllUserTypes();
            foreach (var item in UserTypes)
            {
                model.UserTypes.Add(new SelectListItem
                {
                    Text = item.TypeDescription,
                    Value = item.Id.ToString()
                });
            }

            return View("RegisterEmployee", model);
        }

        [HttpPost]
        public ActionResult RegisterUser(UserModel usermodel)
        {
            var Employee = new UserEmployee()
            {
                Name = usermodel.Name,
                Username = usermodel.UserName,
                Password = usermodel.Password,
                BranchId = usermodel.BranchId
            };
            
            var EmployeeAddress = new Address()
            {
                UserTypeId = usermodel.UserTypeId,
                ContactNo = usermodel.ContactNo,
                Email = usermodel.Email,
                GenderId = usermodel.GenderId,
                Qualification = usermodel.Qualification,
                AddressDetail = usermodel.AddressDetails,
                CNIC = usermodel.CNIC
            };

            UserServices.RegisterUser(Employee, EmployeeAddress);
            //jo view call krna hai registration k baad wo view bna kr oska name paramter m yha pass krdena
            return View();
        }

        public ActionResult Masters()
        {
            return View();
        }
        public ActionResult TestsManagement()
        {
            TestManagementModel tManagementModel = new TestManagementModel();
            var departments = TestDeptServices.GetAllDept();

            foreach (var item in departments)
            {
                tManagementModel.departments.Add(new SelectListItem
                {
                    Text = item.DepartmentName,
                    Value = item.Id.ToString()
                });
            }

            return View("TestsManagement", tManagementModel);
        }
       
        public ActionResult AddTestDepartmentsAndCategories(TestManagementModel model)
        {
            if (model.IsNewDepartment)
            {
                TestDeptServices.Add(new TestDepartment
                {
                    DepartmentName = model.deptName
                });
            }
            else
            {
                TestCategoryServices.Add(new TestCategory
                {
                    TestDepartmentId=model.deptId,
                    TestCategoryCode=model.CatgoryCode,
                    TestName=model.testCategoryName

                });
            }

            return Json("Successfully Added",JsonRequestBehavior.AllowGet);
        }

       

        public ActionResult Accounting()
        {
            return View();
        }
        public ActionResult BranchReport()
        {
            return View();
        }
    }
}
