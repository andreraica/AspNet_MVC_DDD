using Budget.Application;
using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.Domain.Services.Interfaces;
using Budget.Infrastructure.Stub;
using Budget.Presentation.MVC;
using Budget.Presentation.MVC.Controllers;
using Budget.Presentation.MVC.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;

namespace Budget.Web.Controllers.Test
{
    [TestClass]
    public class ItemValorControllerTest
    {

        IGerenciadorDeItemValor _gerenciadorDeItemValor;
        Mock<IItemValorService> _itemValorServiceMock;
        ItemValorController _itemValor;

        [TestInitialize]
        public void Inicializa()
        {
            _itemValorServiceMock = new Mock<IItemValorService>();
            _gerenciadorDeItemValor = new GerenciadorDeItemValor(_itemValorServiceMock.Object);
        }

        [TestMethod]
        [TestCategory("Controller/ItemValor")]
        public void Exibir_View_Index()
        {
            _itemValor = new ItemValorController(_gerenciadorDeItemValor);
            var result = _itemValor.Index(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/ItemValor")]
        public void Exibir_View_Details()
        {
            _itemValor = new ItemValorController(_gerenciadorDeItemValor);
            var result = _itemValor.Details(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/ItemValor")]
        public void Exibir_View_Create()
        {
            _itemValor = new ItemValorController(_gerenciadorDeItemValor);
            var result = _itemValor.Create(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/ItemValor")]
        public void Enviar_Create()
        {
            _itemValor = new ItemValorController(_gerenciadorDeItemValor);
            var itemValorViewModel = Mapeador.Mapear<ItemValor, ItemValorViewModel>(ItemValorStub.NovoItemValor());
            var result = _itemValor.Create(itemValorViewModel) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        [TestCategory("Controller/ItemValor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Exibir_View_Edit()
        {
            _itemValor = new ItemValorController(_gerenciadorDeItemValor);
            var result = _itemValor.Edit(1) as ViewResult;
        }

        [TestMethod]
        [TestCategory("Controller/ItemValor")]
        public void Enviar_Edit()
        {
            _itemValor = new ItemValorController(_gerenciadorDeItemValor);
            var itemValorViewModel = Mapeador.Mapear<ItemValor, ItemValorViewModel>(ItemValorStub.ItemValor());
            var result = _itemValor.Edit(1, itemValorViewModel) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        [TestCategory("Controller/ItemValor")]
        public void Exibir_View_Delete()
        {
            _itemValor = new ItemValorController(_gerenciadorDeItemValor);
            var result = _itemValor.Delete(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/ItemValor")]
        public void Enviar_Delete()
        {
            _itemValor = new ItemValorController(_gerenciadorDeItemValor);
            var itemValorViewModel = Mapeador.Mapear<ItemValor, ItemValorViewModel>(ItemValorStub.ItemValor());
            var result = _itemValor.Delete(1, itemValorViewModel) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        [TestCategory("Controller/ItemValor")]
        public void Redirect_View_ItemSubValor()
        {
            _itemValor = new ItemValorController(_gerenciadorDeItemValor);
            var result = _itemValor.ItemSubValor(1) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("ItemSubValor", result.RouteValues["controller"]);
        }

    }
}
