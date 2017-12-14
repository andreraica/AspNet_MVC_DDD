using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Application.Interfaces;
using Budget.Domain.Services.Interfaces;
using Moq;
using Budget.Infrastructure.Stub;
using Budget.Services.WebAPI.Controllers;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Hosting;
using Budget.Domain.Entities;
using Budget.Application;
using Budget.Services.WebAPI.Controllers.UI;


namespace Budget.Web.ControllersAPI.UI.Test
{
    [TestClass]
    public class OrcamentoUIControllerTest
    {
        OrcamentoUIController _orcamentoUIAPI;

        [TestMethod]
        [TestCategory("ControllerAPI/UI/Orcamento")]
        public void GetTipoPessoa()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _orcamentoUIAPI.GetTipoPessoa(); ;
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/UI/Orcamento")]
        public void GetTipoOrcamento()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _orcamentoUIAPI.GetTipoOrcamento(); ;
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/UI/Orcamento")]
        public void GetTipoPagamento()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _orcamentoUIAPI.GetTipoPagamento(); ;
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        private void InstanciarRequest(HttpMethod httpMethod)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(httpMethod, "");
            _orcamentoUIAPI = new OrcamentoUIController()
            {
                Request = request,
            };
            _orcamentoUIAPI.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }
    
    }
}
