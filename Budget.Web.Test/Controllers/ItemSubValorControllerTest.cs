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
    public class ItemSubValorControllerTest
    {

        IGerenciadorDeItemValor _gerenciadorDeItemValor;
        Mock<IItemValorService> _itemValorServiceMock;

        IGerenciadorDeItemSubValor _gerenciadorDeItemSubValor;
        Mock<IItemSubValorService> _itemSubValorServiceMock;
        ItemSubValorController _itemSubValor;

        [TestInitialize]
        public void Inicializa()
        {
            _itemValorServiceMock = new Mock<IItemValorService>();
            _gerenciadorDeItemValor = new GerenciadorDeItemValor(_itemValorServiceMock.Object);

            _itemSubValorServiceMock = new Mock<IItemSubValorService>();
            _gerenciadorDeItemSubValor = new GerenciadorDeItemSubValor(_itemSubValorServiceMock.Object);
        }

        [TestMethod]
        [TestCategory("Controller/ItemSubValor")]
        public void Exibir_View_Index()
        {
            _itemSubValor = new ItemSubValorController(_gerenciadorDeItemSubValor, _gerenciadorDeItemValor);
            var result = _itemSubValor.Index(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/ItemSubValor")]
        public void Exibir_View_Details()
        {
            _itemSubValor = new ItemSubValorController(_gerenciadorDeItemSubValor, _gerenciadorDeItemValor);
            var result = _itemSubValor.Details(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/ItemSubValor")]
        public void Exibir_View_Create()
        {
            _itemSubValor = new ItemSubValorController(_gerenciadorDeItemSubValor, _gerenciadorDeItemValor);
            var result = _itemSubValor.Create(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/ItemSubValor")]
        public void Enviar_Create()
        {
            _itemSubValor = new ItemSubValorController(_gerenciadorDeItemSubValor, _gerenciadorDeItemValor);
            var itemSubValorViewModel = Mapeador.Mapear<ItemSubValor, ItemSubValorViewModel>(ItemSubValorStub.NovoItemSubValor());
            var result = _itemSubValor.Create(itemSubValorViewModel) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        [TestCategory("Controller/ItemSubValor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Exibir_View_Edit()
        {
            _itemSubValor = new ItemSubValorController(_gerenciadorDeItemSubValor, _gerenciadorDeItemValor);
            var result = _itemSubValor.Edit(1) as ViewResult;
        }

        [TestMethod]
        [TestCategory("Controller/ItemSubValor")]
        public void Enviar_Edit()
        {
            _itemSubValor = new ItemSubValorController(_gerenciadorDeItemSubValor, _gerenciadorDeItemValor);
            var itemSubValorViewModel = Mapeador.Mapear<ItemSubValor, ItemSubValorViewModel>(ItemSubValorStub.ItemSubValor());
            var result = _itemSubValor.Edit(1, itemSubValorViewModel) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        [TestCategory("Controller/ItemSubValor")]
        public void Exibir_View_Delete()
        {
            _itemSubValor = new ItemSubValorController(_gerenciadorDeItemSubValor, _gerenciadorDeItemValor);
            var result = _itemSubValor.Delete(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/ItemSubValor")]
        public void Enviar_Delete()
        {
            _itemSubValor = new ItemSubValorController(_gerenciadorDeItemSubValor, _gerenciadorDeItemValor);
            var itemSubValorViewModel = Mapeador.Mapear<ItemSubValor, ItemSubValorViewModel>(ItemSubValorStub.ItemSubValor());
            var result = _itemSubValor.Delete(1, itemSubValorViewModel) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

    }
}
