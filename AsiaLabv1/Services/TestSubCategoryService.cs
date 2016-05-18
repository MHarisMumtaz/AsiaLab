
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

        public void Delete(int TestCatg)
        {
            _TestSubCatgeroryRepository.DeleteById(TestCatg);
        }
       
    }
}