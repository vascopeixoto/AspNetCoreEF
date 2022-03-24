﻿using System;
using ProjetoWeb.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProjetoWeb.Services
{
    public class SalesRecordService
    {
        private readonly ProjetoWebContext _context;

        public SalesRecordService(ProjetoWebContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x=>x.Seller)
                .Include(x=>x.Seller.Department)
                .OrderByDescending(x=>x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            var data = await result

                .Include(s => s.Seller)

                .Include(s => s.Seller.Department)

                .OrderByDescending(s => s.Date)

                .ToListAsync();

            return data.GroupBy(s => s.Seller.Department).ToList();
        }


    }
}
