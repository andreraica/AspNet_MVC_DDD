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
    public class GerenciadorDeItemSubValorTest
    {
        IGerenciadorDeItemSubValor _gerenciadorDeItemSubValor;
        Mock<IItemSubValorService> _itemSubValorServiceMock;

        [TestInitialize]
        public void Inicializa()
        {
            _itemSubValorServiceMock = new Mock<IItemSubValorService>();
            _gerenciadorDeItemSubValor = new GerenciadorDeItemSubValor(_itemSubValorServiceMock.Object);
        }

        [TestMethod]
        [TestCategory("Application/ItemSubValor")]
        public void Listar_Tudo()
        {
            _itemSubValorServiceMock.Setup(x => x.GetAll()).Returns(ItemSubValorStub.ItemSubValores);
            var despesas = _gerenciadorDeItemSubValor.Listar();

            Assert.IsNotNull(despesas);
        }

        [TestMethod]
        [TestCategory("Application/ItemSubValor")]
        public void Listar_Por_Valor()
        {
            _itemSubValorServiceMock.Setup(x => x.GetByValor(It.IsAny<Int32>())).Returns(ItemSubValorStub.ItemSubValores);
            var despesas = _gerenciadorDeItemSubValor.BuscaPorValor(1);

            Assert.IsNotNull(despesas);
        }

        [TestMethod]
        [TestCategory("Application/ItemSubValor")]
        public void Salvar()
        {
            _itemSubValorServiceMock.Setup(x => x.Add(It.IsAny<ItemSubValor>())).Returns(ItemSubValorStub.NovoItemSubValor());
            _itemSubValorServiceMock.Setup(x => x.Save());
            Assert.IsTrue(_gerenciadorDeItemSubValor.Salvar(It.IsAny<ItemSubValor>()));
        }

        [TestMethod]
        [TestCategory("Application/ItemSubValor")]
        public void Editar()
        {
            _itemSubValorServiceMock.Setup(x => x.Edit(It.IsAny<ItemSubValor>()));
            _itemSubValorServiceMock.Setup(x => x.Save());
            Assert.IsNotNull(_gerenciadorDeItemSubValor.Editar(ItemSubValorStub.ItemSubValor()));
        }

        [TestMethod]
        [TestCategory("Application/ItemSubValor")]
        public void Excluir()
        {
            _itemSubValorServiceMock.Setup(x => x.Delete(It.IsAny<ItemSubValor>()));
            _itemSubValorServiceMock.Setup(x => x.Save());
            _gerenciadorDeItemSubValor.Excluir(ItemSubValorStub.ItemSubValor());
        }

    }
}
