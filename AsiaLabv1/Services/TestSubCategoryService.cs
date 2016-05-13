<<<<<<< HEAD
﻿using AsiaLabv1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AsiaLabv1.Repositories;
>>>>>>> 272ac4b7d367d9bca94f85c3f274ef8afd575b00

namespace AsiaLabv1.Services
{
    public class TestSubCategoryService
    {
<<<<<<< HEAD
        Repository<TestSubcategory> _TestSubCatRepository = new Repository<TestSubcategory>();

        public void 
=======
        Repository<TestSubcategory> _TestSubCatgeroryRepository = new Repository<TestSubcategory>();

        public void Add(TestSubcategory TestCatg)
        {
            _TestSubCatgeroryRepository.Insert(TestCatg);
        }

        public void Delete(TestSubcategory TestCatg)
        {
            _TestSubCatgeroryRepository.Delete(TestCatg);
        }

>>>>>>> 272ac4b7d367d9bca94f85c3f274ef8afd575b00
    }
}