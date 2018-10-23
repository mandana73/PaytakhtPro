namespace BICT.Payetakht
{
    using System.Data.Entity.Migrations;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using BICT.Payetakht.Data;
    using BICT.Payetakht.Migrations;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            var context = new BICTDbContext();
            if (!context.Database.Exists() || !context.Database.CompatibleWithModel(false))
            {
                var configuration = new Configuration();
                var migrator = new DbMigrator(configuration);
                migrator.Update();
            }
        }
    }
}
