using NNJC_CMS.Services.Customers;
using System.Web.Mvc;

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