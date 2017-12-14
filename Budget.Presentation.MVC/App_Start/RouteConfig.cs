using System.Web.Mvc;
using System.Web.Routing;

namespace Budget.Presentation.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Rota simplesmente para simplificar o acesso a Single Page feita em Angular
            routes.MapRoute(
                name: "Angular",
                url: "Angular",
                defaults: new { controller = "Orcamento", action = "Angular", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Orcamento", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
