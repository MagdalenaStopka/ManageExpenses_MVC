using ManageExpenses.Inftrastructure;
using ManageExpenses.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ManageExpenses
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(CreateKernel()));
		}

		private static IKernel CreateKernel()
		{
			var kernel =  new StandardKernel();
			kernel.Bind<IUserRepository>().To<UserInMemoryRepository>().InSingletonScope();
            kernel.Bind<IExpenseCategoryRepository>().To<ExpenseCategoryInMemoryRepository>()
                .InSingletonScope();
            kernel.Bind<IExpenseRepository>().To<ExpenseInMemoryRepository>()
                .InSingletonScope();


			return kernel;
		}
	}
}
