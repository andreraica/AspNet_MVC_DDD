using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Application.Interfaces;
using Budget.Domain.Services.Interfaces;
using Moq;
using Budget.Infrastructure.Stub;
using Budget.Domain.Entities;


namespace Budget.Application.Test
{
    [TestClass]
    public class GerenciadorDeOrcamentoTest
    {
        IGerenciadorDeOrcamento _gerenciadorDeOrcamento;
        Mock<IOrcamentoService> _orcamentoServiceMock;

        [TestInitialize]
        public void Inicializa()
        {
            _orcamentoServiceMock = new Mock<IOrcamentoService>();
            _gerenciadorDeOrcamento = new GerenciadorDeOrcamento(_orcamentoServiceMock.Object);
        }

        [TestMethod]
        [TestCategory("Application/Orcamento")]
        public void Listar_Tudo()
        {
            _orcamentoServiceMock.Setup(x => x.GetAll()).Returns(OrcamentoStub.OrcamentoCompleto());
            var despesas = _gerenciadorDeOrcamento.Listar();

            Assert.IsNotNull(despesas);
        }

        [TestMethod]
        [TestCategory("Application/Orcamento")]
        public void Salvar()
        {
            _orcamentoServiceMock.Setup(x => x.Add(It.IsAny<Orcamento>())).Returns(OrcamentoStub.NovaDespesa());
            _orcamentoServiceMock.Setup(x => x.Save());
            Assert.IsTrue(_gerenciadorDeOrcamento.Salvar(It.IsAny<Orcamento>()));
        }

        [TestMethod]
        [TestCategory("Application/Orcamento")]
        public void Editar()
        {
            _orcamentoServiceMock.Setup(x => x.Edit(It.IsAny<Orcamento>()));
            _orcamentoServiceMock.Setup(x => x.Save());
            Assert.IsNotNull(_gerenciadorDeOrcamento.Editar(OrcamentoStub.Despesa()));
        }

        [TestMethod]
        [TestCategory("Application/Orcamento")]
        public void Excluir()
        {
            _orcamentoServiceMock.Setup(x => x.Delete(It.IsAny<Orcamento>()));
            _orcamentoServiceMock.Setup(x => x.Save());
            _gerenciadorDeOrcamento.Excluir(OrcamentoStub.Despesa());
        }

    }
}
