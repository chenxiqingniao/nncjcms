using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNJC_CMS.Models.Customers;
using NNJC_CMS.Infrastructure;
using NNJC_CMS.Repositories;
using System.Diagnostics;
using NNJC_CMS.Services.Customers;
using System.Linq;

namespace NNJC_CMS.集成测试
{
    [TestClass]
    public class CustomerInfoServiceTest : DbTestBase
    {
        CustomerRepository _customerRepository;
        CustomerInfoService _customerInfoService;
        public CustomerInfoServiceTest()
        {
            var unitOfWork = new UnitOfWork();
            _customerRepository = new CustomerRepository(unitOfWork);
            _customerInfoService = new CustomerInfoService(unitOfWork, _customerRepository);
        }

        [TestMethod]
        public void Add_CustomerEntity_ToBeSuccess()
        {
            RollBack(() =>
            {
                var entity = GetAddedCustomer();
                Assert.IsTrue(entity.Id > 0);
                Trace.WriteLineIf(entity.Id > 0, "添加客户信息成功...");
            });
        }

        private Customer GetAddedCustomer()
        {
            var entity = GetNewCustomerEntity();
            _customerInfoService.Add(entity);
            return entity;
        }

        [TestMethod]
        public void GetCustomerBy_ProvideCustomerFullNameAndNoPaged_ReturnCustomerList()
        {
            RollBack(() =>
            {
                var entity = GetAddedCustomer();
                var result = _customerInfoService.GetCustomerBy(entity.CustomerFullName);
                Assert.AreEqual(entity.Id, result.First().Id);
                Assert.AreEqual(entity.CustomerFullName, result.First().CustomerFullName);
            });
        }

        private Customer GetNewCustomerEntity()
        {
            return new Customer { CustomerFullName = "富阳" };
        }

        [TestMethod]
        [Ignore]
        public void GetPagedCustomers_NoConditions_ReturnCustomers() {
            RollBack(() => {
                GetAddedCustomer();
                GetAddedCustomer();
                GetAddedCustomer();
                var customers = _customerInfoService.GetPagedCustomers();
                Assert.IsNotNull(customers);
                Assert.AreEqual(3, customers.Count());
            });
           
        }
    }
}
