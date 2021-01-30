using System.Web;
using System.Web.Mvc;

namespace VidlyApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute()); //Now the application endpoints will no longer be available on an HTTP channel.
        }
    }
}
