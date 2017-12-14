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
using System.Collections.Generic;
using System.Web.Mvc;

namespace Budget.Web.Controllers.Test
{
    [TestClass]
    public class OrcamentoControllerTest
    {
        
        IGerenciadorDeOrcamento _gerenciadorDeOrcamento;
        Mock<IOrcamentoService> _orcamentoServiceMock;
        OrcamentoController _orcamento;

        [TestInitialize]
        public void Inicializa()
        {
            _orcamentoServiceMock = new Mock<IOrcamentoService>();
            _gerenciadorDeOrcamento = new GerenciadorDeOrcamento(_orcamentoServiceMock.Object);
        }

        [TestMethod]
        [TestCategory("Controller/Orcamento")]
        public void Exibir_View_Index()
        {
            _orcamento = new OrcamentoController(_gerenciadorDeOrcamento);
            var result = _orcamento.Index() as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/Orcamento")]
        public void Exibir_View_Details()
        {
            _orcamento = new OrcamentoController(_gerenciadorDeOrcamento);
            var result = _orcamento.Details(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/Orcamento")]
        public void Exibir_View_Create()
        {
            _orcamento = new OrcamentoController(_gerenciadorDeOrcamento);
            var result = _orcamento.Create() as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/Orcamento")]
        public void Enviar_Create()
        {
            _orcamento = new OrcamentoController(_gerenciadorDeOrcamento);
            var orcamentoViewModel = Mapeador.Mapear<Orcamento, OrcamentoViewModel>(OrcamentoStub.NovaDespesa());
            var result = _orcamento.Create(orcamentoViewModel) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        [TestCategory("Controller/Orcamento")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Exibir_View_Edit()
        {
            _orcamento = new OrcamentoController(_gerenciadorDeOrcamento);
            var result = _orcamento.Edit(1) as ViewResult;
        }

        [TestMethod]
        [TestCategory("Controller/Orcamento")]
        public void Enviar_Edit()
        {
            _orcamento = new OrcamentoController(_gerenciadorDeOrcamento);
            var orcamentoViewModel = Mapeador.Mapear<Orcamento, OrcamentoViewModel>(OrcamentoStub.Despesa());
            var result = _orcamento.Edit(1, orcamentoViewModel) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        [TestCategory("Controller/Orcamento")]
        public void Exibir_View_Delete()
        {
            _orcamento = new OrcamentoController(_gerenciadorDeOrcamento);
            var result = _orcamento.Delete(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [TestCategory("Controller/Orcamento")]
        public void Enviar_Delete()
        {
            _orcamento = new OrcamentoController(_gerenciadorDeOrcamento);
            var orcamentoViewModel = Mapeador.Mapear<Orcamento, OrcamentoViewModel>(OrcamentoStub.Despesa());
            var result = _orcamento.Delete(1, orcamentoViewModel) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        [TestCategory("Controller/Orcamento")]
        public void Redirect_View_ItemValor()
        {
            _orcamento = new OrcamentoController(_gerenciadorDeOrcamento);
            var result = _orcamento.ItemValor(1) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("ItemValor", result.RouteValues["controller"]);
        }

    }
}
