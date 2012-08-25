using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace ShopRunner
{
    public class Routes : IRouteProvider
    {
        #region IRouteProvider Members

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (RouteDescriptor routeDescriptor in GetRoutes())
            {
                routes.Add(routeDescriptor);
            }
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[]
                   {
                       new RouteDescriptor
                       {
                           Name = "ShopRunnerSettings",
                           Priority = 5,
                           Route = new Route(
                               "ShopRunner/Settings",
                               new RouteValueDictionary
                               {
                                   {"area", "Arana.ShopRunner"},
                                   {"controller", "ShopRunner"},
                                   {"action", "Settings"}
                               },
                               null,
                               new RouteValueDictionary
                               {
                                   {"area", "Arana.ShopRunner"}
                               },
                               new MvcRouteHandler())
                       }
                   };
        }

        #endregion
    }
}