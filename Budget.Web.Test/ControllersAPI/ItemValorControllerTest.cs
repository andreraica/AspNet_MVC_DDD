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
    public class ItemValorControllerTest
    {
        
        IGerenciadorDeItemValor _gerenciadorDeItemValor;
        Mock<IItemValorService> _itemValorServiceMock;
        ItemValorController _itemValorAPI;

        [TestInitialize]
        public void Inicializa()
        {
            _itemValorServiceMock = new Mock<IItemValorService>();
            _gerenciadorDeItemValor = new GerenciadorDeItemValor(_itemValorServiceMock.Object);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemValor")]
        public void Get()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _itemValorAPI.Get();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemValor")]
        public void Get_Orcamento()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _itemValorAPI.GetByOrcamento(1);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemValor")]
        public void Get_Int()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _itemValorAPI.Get(1);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemValor")]
        public void Post()
        {
            this.InstanciarRequest(HttpMethod.Post);
            var result = _itemValorAPI.Post(ItemValorStub.NovoItemValor());
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemValor")]
        public void Put()
        {
            this.InstanciarRequest(HttpMethod.Put);
            var result = _itemValorAPI.Put(ItemValorStub.ItemValor());
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemValor")]
        public void Delete()
        {
            this.InstanciarRequest(HttpMethod.Delete);
            var result = _itemValorAPI.Delete(1);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        private void InstanciarRequest(HttpMethod httpMethod)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(httpMethod, "");
            _itemValorAPI = new ItemValorController(_gerenciadorDeItemValor)
            {
                Request = request,
            };
            _itemValorAPI.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }

    }
}
