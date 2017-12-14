using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Application.Interfaces;
using Budget.Domain.Services.Interfaces;
using Moq;
using Budget.Infrastructure.Stub;
using Budget.Domain.Entities;
using Budget.Domain.Services;


namespace Budget.Application.Test
{
    [TestClass]
    public class GerenciadorDeItemValorTest
    {
        IGerenciadorDeItemValor _gerenciadorDeItemValor;
        Mock<IItemValorService> _itemValorServiceMock;

        [TestInitialize]
        public void Inicializa()
        {
            _itemValorServiceMock = new Mock<IItemValorService>();
            _gerenciadorDeItemValor = new GerenciadorDeItemValor(_itemValorServiceMock.Object);
        }

        [TestMethod]
        [TestCategory("Application/ItemValor")]
        public void Listar_Tudo()
        {
            _itemValorServiceMock.Setup(x => x.GetAll()).Returns(ItemValorStub.ItemValores);
            var despesas = _gerenciadorDeItemValor.Listar();

            Assert.IsNotNull(despesas);
        }

        [TestMethod]
        [TestCategory("Application/ItemValor")]
        public void Listar_Por_Orcamento()
        {
            _itemValorServiceMock.Setup(x => x.GetByOrcamento(It.IsAny<Int32>())).Returns(ItemValorStub.ItemValores);
            var despesas = _gerenciadorDeItemValor.BuscaPorOrcamento(1);

            Assert.IsNotNull(despesas);
        }

        [TestMethod]
        [TestCategory("Application/ItemValor")]
        public void Salvar()
        {
            _itemValorServiceMock.Setup(x => x.Add(It.IsAny<ItemValor>())).Returns(ItemValorStub.NovoItemValor());
            _itemValorServiceMock.Setup(x => x.Save());
            Assert.IsTrue(_gerenciadorDeItemValor.Salvar(It.IsAny<ItemValor>()));
        }

        [TestMethod]
        [TestCategory("Application/ItemValor")]
        public void Editar()
        {
            _itemValorServiceMock.Setup(x => x.Edit(It.IsAny<ItemValor>()));
            _itemValorServiceMock.Setup(x => x.Save());
            Assert.IsNotNull(_gerenciadorDeItemValor.Editar(ItemValorStub.ItemValor()));
        }

        [TestMethod]
        [TestCategory("Application/ItemValor")]
        public void Excluir()
        {
            _itemValorServiceMock.Setup(x => x.Delete(It.IsAny<ItemValor>()));
            _itemValorServiceMock.Setup(x => x.Save());
            _gerenciadorDeItemValor.Excluir(ItemValorStub.ItemValor());
        }

    }
}
