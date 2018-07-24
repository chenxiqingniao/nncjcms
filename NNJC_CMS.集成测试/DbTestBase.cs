using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

namespace NNJC_CMS.集成测试
{
    [TestClass]
    public class DbTestBase
    {
        protected void RollBack(Action action)
        {
            using (var tran = new TransactionScope())
            {
                action();               
            }
        }
    }
}
