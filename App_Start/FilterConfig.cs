using System.Web;
using System.Web.Mvc;

namespace Assignment_3_ASP.NET_MVC_CRUD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
