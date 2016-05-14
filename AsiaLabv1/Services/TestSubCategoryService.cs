
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

        public void Add(TestSubcategory TestCatg)
        {
            _TestSubCatgeroryRepository.Insert(TestCatg);
        }

        public void Delete(TestSubcategory TestCatg)
        {
            _TestSubCatgeroryRepository.Delete(TestCatg);
        }
    }
}