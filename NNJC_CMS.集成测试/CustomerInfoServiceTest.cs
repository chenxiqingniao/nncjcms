using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNJC_CMS.Models.Customers;
using NNJC_CMS.Infrastructure;
using NNJC_CMS.Repositories;
using System.Diagnostics;
using NNJC_CMS.Services.Customers;

namespace NNJC_CMS.集成测试
{
    [TestClass]
    public class CustomerInfoServiceTest:DbTestBase
    {
        [TestMethod]
        public void Add_CustomerEntity_ToBeSuccess()
        {
            var entity = GetNewCustomer();
            var unitOfWork = new UnitOfWork();
            var customerRepository = new CustomerRepository(unitOfWork);
            var customerInfoService = new CustomerInfoService(unitOfWork,customerRepository);
            customerInfoService.Add(entity);
            Assert.IsTrue(entity.Id > 0);
            Trace.WriteLineIf(entity.Id > 0, "添加客户信息成功...");
        }

        [TestMethod]
        public void GetCustomers_NoConditionsAndNoPaged_ReturnCustomerList()
        {

        }

        private Customer GetNewCustomer()
        {
            return new Customer { CustomerFullName = "富阳" };
        }
    }
}
