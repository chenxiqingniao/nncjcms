using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

namespace NNJC_CMS.集成测试
{
    [TestClass]
    public class DbTestBase
    {
        private TransactionScope _scope;
        [TestInitialize]
        public void SetUp()
        {
            _scope = new TransactionScope();
        }
        [TestCleanup]
        public void TearDown()
        {
            _scope.Dispose();
        }
    }
}
