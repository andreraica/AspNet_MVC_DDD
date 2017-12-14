using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Services.WebAPI;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

using Microsoft.Owin.Hosting;
using Microsoft.Owin.Testing;
using Owin;
using System.Diagnostics;
using System.Web.Http;
using Budget.Services.WebAPI.Controllers;
using System.Web.Http.Hosting;
using Budget.Application.Interfaces;
using Budget.Domain.Services;
using Moq;
using Budget.Application;

namespace Budget.Web.Test.ControllersAPI.Authentication
{
    [TestClass]
    public class TokenValidation
    {
     
        [TestInitialize]
        public void Inicializa()
        {
            
        }

        [TestMethod]
        public void Token()
        {
            //TODO: Remover esse parametro chumbado, e dar um jeito de desacoplar isso
            string baseAddress = "http://localhost:63867/";  


            //isto abaixo simularia a inicialização do OWIN, mas como não consegui startar o projeto do WebAPI junto com esse teste
            //fui obrigado a comentar :(
            //1-para resolver o problema eu tenho que dar como "set start project" no MVC e logo após da play.
            //2-stop no projeto (com isso inicia o localhost:63867 e não dá 404)
            //3-rodar o teste


            //Start OWIN host     
            //using (WebApp.Start<Startup>(url: baseAddress))
            //{
                var client = new HttpClient();
                var response = client.GetAsync(baseAddress + "api/orcamento").Result;

                //Trace.WriteLine(response);

                //var authorizationHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes("rajeev:secretKey"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeader);

                var form = new Dictionary<string, string>  
               {  
                   {"grant_type", "password"},  
                   {"username", "andreraica@gmail.com"},  
                   {"password", "123456"},  
               };

                var tokenResponse = client.PostAsync(baseAddress + "Token", new FormUrlEncodedContent(form)).Result;
                var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;

                //Trace.WriteLine("Token issued is: {0}", token.AccessToken);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                var authorizedResponse = client.GetAsync(baseAddress + "api/orcamento").Result;

                //Trace.WriteLine(authorizedResponse);
                //Trace.WriteLine(authorizedResponse.Content.ReadAsStringAsync().Result);
            //}
                                    
        }
                
    }

    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }


}
