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


namespace Budget.Web.ControllersAPI.Test
{
    [TestClass]
    public class OrcamentoControllerTest
    {
        
        IGerenciadorDeOrcamento _gerenciadorDeOrcamento;
        Mock<IOrcamentoService> _orcamentoServiceMock;
        OrcamentoController _orcamentoAPI;

        [TestInitialize]
        public void Inicializa()
        {
            _orcamentoServiceMock = new Mock<IOrcamentoService>();
            _gerenciadorDeOrcamento = new GerenciadorDeOrcamento(_orcamentoServiceMock.Object);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/Orcamento")]
        public void Get()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _orcamentoAPI.Get();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/Orcamento")]
        public void Get_Int()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _orcamentoAPI.Get(1);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/Orcamento")]
        public void Post()
        {
            this.InstanciarRequest(HttpMethod.Post);
            var result = _orcamentoAPI.Post(OrcamentoStub.NovaDespesa());
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/Orcamento")]
        public void Put()
        {
            this.InstanciarRequest(HttpMethod.Put);
            var result = _orcamentoAPI.Put(OrcamentoStub.Despesa());
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/Orcamento")]
        public void Delete()
        {
            this.InstanciarRequest(HttpMethod.Delete);
            var result = _orcamentoAPI.Delete(1);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        private void InstanciarRequest(HttpMethod httpMethod)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(httpMethod, "");
            _orcamentoAPI = new OrcamentoController(_gerenciadorDeOrcamento)
            {
                Request = request,
            };
            _orcamentoAPI.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }

    }
}
