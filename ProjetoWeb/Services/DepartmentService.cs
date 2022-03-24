﻿using System;
using ProjetoWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoWeb.Services
{
    public class DepartmentService
    {
        private readonly ProjetoWebContext _context;

        public DepartmentService(ProjetoWebContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x=>x.Name).ToList();
        }

    }
}
