using System;
using ProjetoWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoWeb.Services
{
    public class SalesRecordService
    {
        private readonly ProjetoWebContext _context;

        public SalesRecordService(ProjetoWebContext context)
        {
            _context = context;
        }

        public List<SalesRecord> FindAll()
        {
            return _context.SalesRecord.ToList();
        }

        public void Insert(SalesRecord obj)
        {
            obj.Seller = _context.Seller.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
