using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AsiaLabv1.Repositories;

namespace AsiaLabv1.Services
{
    public class TestSubCategoryService
    {
        Repository<TestSubcategory> _TestSubCatgeroryRepository = new Repository<TestSubcategory>();

        public void Add(TestSubcategory TestCatg)
        {
            _TestSubCatgeroryRepository.Insert(TestCatg);
        }

    }
}