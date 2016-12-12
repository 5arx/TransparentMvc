using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransparentMvcLib.Util
{
    public class Cachenames
    {
        public static readonly string AllProducts = "AllProds";
        public static readonly string AllProductTags = "AllProdsTags";
        public static readonly string AllTags = "AllTags";
    }

    public static class Cacher
    {
        public static bool IsInCache(string cachename) {
            return HttpContext.Current.Cache[cachename] != null;
        }

        public static T GetFromCache<T>(string cachename){
            return (T)HttpContext.Current.Cache[cachename];
        }
        public static void AddToCache(object o, string cachename)
        {
            HttpContext.Current.Cache[cachename] = o;
        }
    }
}
