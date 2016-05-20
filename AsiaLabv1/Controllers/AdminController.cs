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
        TestSubCategoryService TestSubCategoryServices = new TestSubCategoryService();

        public static int CategId = 0;

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
            var subdepartments = TestDeptServices.GetAllDeptSD();

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
                    TestDepartmentId = model.deptId,
                    TestCategoryCode = "null",
                    TestName = model.testCategoryName

                });
            }

            return Json("Successfully Added", JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddCategories(string id)
        {
            TestManagementModel tmanagementmodel = new TestManagementModel();
            var testCategories = TestCategoryServices.GetCatgByDeptId(Convert.ToInt16(id));

            List<RequiredItem> Categ = new List<RequiredItem>();
            foreach (var item in testCategories)
            {
                Categ.Add(new RequiredItem
                {

                    Id = item.Id,
                    testName = item.TestName

                });
            }


            return Json(Categ, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddTests(TestSubCategoryModel model)
        {

            TestSubCategoryServices.Add(new TestSubcategory
            {
                TestSubcategoryName = model.TestSubcategoryName,
                UpperBound = model.UpperBound,
                LowerBound = model.LowerBound,
                Unit = model.Unit,
                Rate = model.Rate,
                TestCategoryId = model.TestCategoryId

            });


            return Json("Successfully Added", JsonRequestBehavior.AllowGet);


        }


        public ActionResult FillDropdown(string categId, string subCategId)
        {

            if (categId != "")
            {

                var testCategories = TestCategoryServices.GetCatgByDeptId(Convert.ToInt16(categId));
                List<RequiredItem> Categ = new List<RequiredItem>();
                foreach (var item in testCategories)
                {
                    Categ.Add(new RequiredItem
                    {

                        Id = item.Id,
                        testName = item.TestName

                    });
                }


                return Json(Categ, JsonRequestBehavior.AllowGet);
            }

            else if (subCategId != "")
            {
                var subCategories = TestCategoryServices.GetSubCategById(Convert.ToInt16(subCategId));

                List<RequiredTest> test = new List<RequiredTest>();
                foreach (var item in subCategories)
                {
                    test.Add(new RequiredTest
                    {

                        Id = item.Id,
                        testName = item.TestSubcategoryName

                    });
                }

                return Json(test, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FillDropdownKendo(string isFill,string subCategId)
        {
            CategId = isFill == "none" ? Convert.ToInt16(subCategId) : CategId;
            if (isFill == "" || isFill==null)
                {

                    var subCategories = TestCategoryServices.GetSubCategById(CategId);

                    List<RequiredTest> test = new List<RequiredTest>();
                    foreach (var item in subCategories)
                    {
                        test.Add(new RequiredTest
                        {

                            Id = item.Id,
                            testName = item.TestSubcategoryName,
                            upperBound = item.UpperBound,
                            lowerBound = item.LowerBound,
                            unit = item.Unit,
                            rate = item.Rate

                        });
                    }
                    return Json(test, JsonRequestBehavior.AllowGet);
                }

                return Json(null, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateKendoGrid()
        {
            return Json(null);
        }


        public ActionResult Delete(string testcategoryid)
        {
            TestSubCategoryServices.Delete(Convert.ToInt16(testcategoryid));
            return Json("Record Deleted", JsonRequestBehavior.AllowGet);
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
