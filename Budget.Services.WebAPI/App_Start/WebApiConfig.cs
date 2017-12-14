using Microsoft.Owin.Security.OAuth;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Budget.Services.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Formato Texto no Chrome, pois alguns objetos não são serializados em XML
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //Ativa permissão de acesso externo aos serviços
            //config.EnableCors();

            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);

            #region "Token"

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //config.Routes.MapHttpRoute(
            //    name: "Token",
            //    routeTemplate: "security/{controller}/{email}/{password}",
            //    defaults: new { controller = "token", action = "Get", email="", password = "" }
            //);

            #endregion

            #region "Geral"

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #endregion

            #region "Item Valor"

            config.Routes.MapHttpRoute(
                name: "ItemValor",
                routeTemplate: "api/itemvalor/valor/{id}",
                defaults: new { controller = "itemvalor", action = "Get" }
            );

            config.Routes.MapHttpRoute(
                name: "ItemValorOrcamento",
                routeTemplate: "api/itemvalor/orcamento/{id}",
                defaults: new { controller = "itemvalor", action = "GetByOrcamento" }
            );

            #endregion

            #region "Item Sub Valor"

            config.Routes.MapHttpRoute(
                name: "ItemSubValor",
                routeTemplate: "api/itemsubvalor/subvalor/{id}",
                defaults: new { controller = "itemsubvalor", action = "Get" }
            );

            config.Routes.MapHttpRoute(
                name: "ItemSubValor_Valor",
                routeTemplate: "api/itemsubvalor/valor/{id}",
                defaults: new { controller = "itemsubvalor", action = "GetByValor" }
            );

            #endregion

            #region "UI"

            config.Routes.MapHttpRoute(
                name: "UI_TipoPessoa",
                routeTemplate: "api/orcamento/UI/TipoPessoa",
                defaults: new { controller = "OrcamentoUI", action = "GetTipoPessoa" }
            );

            config.Routes.MapHttpRoute(
                name: "UI_TipoOrcamento",
                routeTemplate: "api/orcamento/UI/TipoOrcamento",
                defaults: new { controller = "OrcamentoUI", action = "GetTipoOrcamento" }
            );

            config.Routes.MapHttpRoute(
                name: "UI_TipoPagamento",
                routeTemplate: "api/orcamento/UI/TipoPagamento",
                defaults: new { controller = "OrcamentoUI", action = "GetTipoPagamento" }
            );

            #endregion
        }
    }
}
