﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AsiaLabv1.Repositories;
﻿using AsiaLabv1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AsiaLabv1.Services
{
    public class TestSubCategoryService
    {

        Repository<TestSubcategory> _TestSubCatgeroryRepository = new Repository<TestSubcategory>();
        Repository<TestCategory> _TestCatgeroryRepository = new Repository<TestCategory>();

        public void Add(TestSubcategory TestCatg)
        {
            _TestSubCatgeroryRepository.Insert(TestCatg);
        }

        public void Delete(int TestCatg)
        {
            _TestSubCatgeroryRepository.DeleteById(TestCatg);
        }

<<<<<<< HEAD
        public List<TestSubcategory> GetSubCategTestsByTestCategoryId(int TestCategId)
        {

            var Query = (from testSub in _TestSubCatgeroryRepository.Table
                         join testCateg in _TestCatgeroryRepository.Table on testSub.TestCategoryId equals testCateg.Id
                         where testCateg.Id == TestCategId
                         select testSub).ToList<TestSubcategory>();
            return Query;
        }
       
=======
>>>>>>> 501811f171b61f4fdb71fa9464ed3368a7903737
    }
}