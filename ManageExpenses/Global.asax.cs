
using ManageExpenses.Inftrastructure;
using ManageExpenses.Repositories;
using Ninject;

using System.Linq;

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
            using (var ctx = new ManageExpensesContext2())
            {
                //var user = new User()
                //{

                //    FirstName = "Agnieszka",
                //    LastName = "KOwalska",
                //    Login = "a.kowalska",
                //    Password = "tajne",
                //    DateOfBirth = DateTime.Now.AddYears(-10)
                //};
                //ctx.Users.Add(user);
                //ctx.SaveChanges();

                var users = ctx.Users.ToList();
            }
        }

		private static IKernel CreateKernel()
		{
			var kernel =  new StandardKernel();
            kernel.Bind<IUserRepository>().To<UserInDbRepository>();
            //kernel.Bind<IExpenseCategoryRepository>().To<ExpenseCategoryInMemoryRepository>()
            //    .InSingletonScope();

            kernel.Bind<IExpenseCategoryRepository>().To<ExpenseCategoryInDbRepository>();

            //kernel.Bind<IExpenseRepository>().To<ExpenseInMemoryRepository>()
            //    .InSingletonScope();

            kernel.Bind<IExpenseRepository>().To<ExpenseInDbRepository>();

            kernel.Bind<ICurrentUserProvider>().To<CurrentUserProvider>();
               

            return kernel;
		}
	}
}
