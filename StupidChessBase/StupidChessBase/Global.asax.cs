using StupidChessBase.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StupidChessBase.Data.Migrations;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Data.Migrations.BestGamesContext;
using StupidChessBase.Data.Migrations.Clubs;

namespace StupidChessBase
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, DbMigrationsConfig>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BestGamesContext, Configuration>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ClubContext, SqlLiteConfig>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
