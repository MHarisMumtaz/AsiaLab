using AsiaLabv1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiaLabv1.Services
{
    public class TestCategoryService
    {
        Repository<TestCategory> _TestCatgeroryRepository = new Repository<TestCategory>();
        Repository<TestDepartment> _TestDeptRepository = new Repository<TestDepartment>();

        public void Add(TestCategory TestCatg)
        {
            _TestCatgeroryRepository.Insert(TestCatg);
        }

        public List<TestCategory> GetCatgByDeptId(int DeptId)
        {
            var chkquery =(from testDept in _TestDeptRepository.Table
                           where testDept.DepartmentName == "Testing Dept"
                           select testDept.Id).ToList();

            var check=(from testCat in _TestCatgeroryRepository.Table
                           select testCat.TestName).ToList();

            var Query = (from testCat in _TestCatgeroryRepository.Table
                         join testDept in _TestDeptRepository.Table 
                         on testCat.TestDepartmentId equals testDept.Id
                         where testDept.Id == DeptId
                         select testCat).ToList();
            return Query;
        }


    }
}