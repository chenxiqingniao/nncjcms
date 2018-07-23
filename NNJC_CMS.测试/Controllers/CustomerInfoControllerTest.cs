using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NNJC_CMS.Models.Customers;
using NNJC_CMS.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;
using System.Collections.Specialized;
using NNJC_CMS.Services.Customers;

namespace NNJC_CMS.测试.Controllers
{
    [TestClass]
    public class CustomerInfoControllerTest
    {
        Mock<ICustomerInfoService> _mockICustomerInfoService;
        [TestInitialize]
        public void Setup()
        {
            _mockICustomerInfoService = new Mock<ICustomerInfoService>();
        }

        [TestMethod]
        public void Index_EmptyRequestParams_ReturnViewResultWithPagedCustomerList()
        {
            const string expectedCustomerFullName = "南宁财嘉";
            _mockICustomerInfoService.Setup(c => c.GetPagedCustomers()).Returns(new List<Customer> { new Customer { CustomerFullName = expectedCustomerFullName } });
            CustomerInfoController controller = new CustomerInfoController(_mockICustomerInfoService.Object);
            ViewResult result = controller.Index() as ViewResult;
            var customers = (List<Customer>)result.ViewData.Model;
            Assert.AreEqual(expectedCustomerFullName, customers[0].CustomerFullName);
        }

        [TestMethod]
        public void Index_EmptyRequestParams_ReturnViewDataWithMessageData()
        {
            const string key = "Message",value="MyHome";
            CustomerInfoController controller = new CustomerInfoController(_mockICustomerInfoService.Object);
            var httpContext = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var  queryString = new NameValueCollection();
            queryString.Add(key, value);
            request.Setup(r => r.QueryString).Returns(queryString);
            httpContext.Setup(ht => ht.Request).Returns(request.Object);
            var controllerContext = new ControllerContext();
            controllerContext.HttpContext = httpContext.Object;
            controller.ControllerContext = controllerContext;
            var result = controller.Index() as ViewResult;
            var viewData = result.ViewData;
            Assert.AreEqual(value, viewData[key]);
        }
        
    }
}
