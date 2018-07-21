using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NNJC_CMS.Models.Customers;

namespace NNJC_CMS.Controllers
{
    public class CustomerInfoController : Controller
    {
        private ICustomerInfoService _service;

        public CustomerInfoController(ICustomerInfoService @object)
        {
            _service = @object;
        }

        // GET: CustomerInfo
        public ActionResult Index()
        {
            ViewData["Message"] = "MyHome";
            return View(_service.GetPagedCustomers());
        }
    }
}