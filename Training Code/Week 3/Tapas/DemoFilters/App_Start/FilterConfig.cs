using System.Web;
using System.Web.Mvc;

namespace DemoFilters
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomActionAttribute());
            filters.Add(new CustomAuthorisationAttribute());
            filters.Add(new CustomErrorAttribute());
            filters.Add(new CustomResultAttribute());
        }
    }
}
