using Ninject;
using NNJC_CMS.Repositories;
using NNJC_CMS.Services.Customers;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace NNJC_CMS.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        void AddBindings()
        {
            _ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            _ninjectKernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            _ninjectKernel.Bind<ICustomerInfoService>().To<CustomerInfoService>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }
    }
}