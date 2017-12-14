using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Application.Interfaces;
using Budget.Domain.Services.Interfaces;
using Moq;
using Budget.Infrastructure.Stub;
using Budget.Services.WebAPI.Controllers;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Hosting;
using Budget.Application;

namespace Budget.Web.ControllersAPI.Test
{
    [TestClass]
    public class ItemSubValorControllerTest
    {
        
        IGerenciadorDeItemSubValor _gerenciadorDeItemSubValor;
        Mock<IItemSubValorService> _itemSubValorServiceMock;
        ItemSubValorController _itemValorAPI;

        [TestInitialize]
        public void Inicializa()
        {
            _itemSubValorServiceMock = new Mock<IItemSubValorService>();
            _gerenciadorDeItemSubValor = new GerenciadorDeItemSubValor(_itemSubValorServiceMock.Object);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemSubValor")]
        public void Get()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _itemValorAPI.Get();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemSubValor")]
        public void Get_Valor()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _itemValorAPI.GetByValor(1);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemSubValor")]
        public void Get_Int()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _itemValorAPI.Get(1);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemSubValor")]
        public void GetByValor()
        {
            this.InstanciarRequest(HttpMethod.Get);
            var result = _itemValorAPI.GetByValor(1);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemSubValor")]
        public void Post()
        {
            this.InstanciarRequest(HttpMethod.Post);
            var result = _itemValorAPI.Post(ItemSubValorStub.NovoItemSubValor());
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemSubValor")]
        public void Put()
        {
            this.InstanciarRequest(HttpMethod.Put);
            var result = _itemValorAPI.Put(ItemSubValorStub.ItemSubValor());
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [TestCategory("ControllerAPI/ItemSubValor")]
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
            _itemValorAPI = new ItemSubValorController(_gerenciadorDeItemSubValor)
            {
                Request = request,
            };
            _itemValorAPI.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }

    }
}
