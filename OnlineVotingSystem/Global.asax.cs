using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OnlineVotingSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //AreaRegistration.RegisterAllAreas();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            using (var context = new Models.VotingDbContext())
            {
                if (!context.Candidates.Any())
                {
                    context.Candidates.Add(new Models.Candidate { Name = "Alice", Party = "Party A" });
                    context.Candidates.Add(new Models.Candidate { Name = "Bob", Party = "Party B" });
                    context.Candidates.Add(new Models.Candidate { Name = "Charlie", Party = "Party C" });

                    context.Candidates.Add(new Models.Candidate { Name = "JK", Party = "Party D" });
                    context.SaveChanges();
                }
            }
        }
    }
}
