using AsiaLabv1.Models;
using AsiaLabv1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsiaLabv1.Controllers
{
    public class ReciptionistController : Controller
    {
        PatientService PatientServices = new PatientService();
        PatientTestService PatientTestService = new PatientTestService();
        GenderService GenderServices = new GenderService();
        TestDeptService TestDeptServices = new TestDeptService();
        TestCategoryService TestCategoryServices = new TestCategoryService();

        public ActionResult RegisterPatient()
        {
            var model = new PatientModel();
            var Genders = GenderServices.GetAll();
            foreach (var item in Genders)
            {
                model.Genders.Add(new SelectListItem
                {
                    Text = item.GenderDescription,
                    Value = item.Id.ToString()
                });
            }
            var allDept = TestDeptServices.GetAllDept();
            foreach (var Dept in allDept)
            {
                model.Departments.Add(new SelectListItem
                {
                    Value = Dept.Id.ToString(),
                    Text = Dept.DepartmentName
                });
            }

            return View("RegisterPatient", model);
        }

        [HttpPost]
        public ActionResult GetSubCategory(int Id)
        {
            var TestList = TestCategoryServices.GetTestsByDeptId(Id);
            var TestsList = new List<Tests>();
            foreach (var item in TestList)
            {
                TestsList.Add(new Tests
                {
                    Id = item.Id,
                    Name = item.TestName
                });
            }
            return Json(TestsList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddPatient(PatientModel model)
        {

            //var model=new PatientModel(){
            //    BranchId=1,
            //    Name="firstTestPatient",
            //    Email="Testpatient@gmail.com",
            //    GenderId=1,
            //    DateofBirth=DateTime.Now,
            //    PhoneNumber="987987697",
            //    ReferredId=-1
            //};

            PatientServices.Add(model);

            foreach (var TestId in model.PatientTestIds)
            {
                PatientTestService.Add(new PatientTest
                {
                    PatientId = model.Id,
                    TestSubcategoryId = TestId
                });
            }
            return View();
        }

        public ActionResult PrintReport()
        {
            return View();
        }
    }
}
