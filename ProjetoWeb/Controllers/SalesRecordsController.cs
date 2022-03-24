using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.Models;
using ProjetoWeb.Models.ViewModels;
using ProjetoWeb.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoWeb.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;
        private readonly SellerService _sellerService;

        public SalesRecordsController(SalesRecordService salesRecord, SellerService sellerService)
        {
            _salesRecordService = salesRecord;
            _sellerService = sellerService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var list = _salesRecordService.FindAll();
            return View(list);
        }

    }
}
