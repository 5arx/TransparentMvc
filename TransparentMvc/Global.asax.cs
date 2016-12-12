using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TransparentMvcLib.Util;
namespace TransparentMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var pts = TransparentMvcLib.Classes.ProductTag.GetTags();
            var prods = new TransparentMvcLib.Classes.ProductDb().GetProducts();
            var tags = new TransparentMvcLib.Classes.TagDb().GetTags();
            Cacher.AddToCache(prods, Cachenames.AllProducts);
            Cacher.AddToCache(tags, Cachenames.AllTags);
            Cacher.AddToCache(pts, Cachenames.AllProductTags);
        }
    }
}
