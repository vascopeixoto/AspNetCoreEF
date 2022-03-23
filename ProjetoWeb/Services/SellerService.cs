using System;
using ProjetoWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoWeb.Services
{
    public class SellerService 
    {
        private readonly ProjetoWebContext _context;

        public SellerService(ProjetoWebContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
