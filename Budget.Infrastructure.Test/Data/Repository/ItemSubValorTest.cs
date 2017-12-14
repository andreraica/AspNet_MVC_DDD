using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Budget.Infrastructure.Data.Interface;
using Budget.Domain.Entities;
using Budget.Infrastructure.Stub;
using System.Linq;
using System.Collections.Generic;

namespace Budget.Infrastructure.Test.Data.Repository
{
    [TestClass]
    public class ItemSubValorTest
    {
        IItemSubValorRepository repository;

        [TestInitialize]
        public void Inicializa()
        {
            var repositoryMock = new Mock<IItemSubValorRepository>();
            repositoryMock.Setup(x => x.GetAll()).Returns(ItemSubValorStub.ItemSubValores());
            repositoryMock.Setup(x => x.GetByValor(It.IsAny<Int32>())).Returns(ItemSubValorStub.ItemSubValores());
            repositoryMock.Setup(x => x.FindById(It.IsAny<Int32>())).Returns(ItemSubValorStub.ItemSubValor());
            repositoryMock.Setup(x => x.Add(It.IsAny<ItemSubValor>())).Returns(ItemSubValorStub.NovoItemSubValor());
            repositoryMock.Setup(x => x.Delete(It.IsAny<ItemSubValor>())).Returns(ItemSubValorStub.ItemSubValor());
            repositoryMock.Setup(x => x.Edit(It.IsAny<ItemSubValor>()));
            repositoryMock.Setup(x => x.Save());

            repository = repositoryMock.Object;
        }


        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemSubValor")]
        public void Consulta_todos_Valores()
        {
            var valores = repository.GetAll();
            Assert.IsTrue(valores.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemSubValor")]
        public void Consulta_SubValores_Por_Valor()
        {
            var valores = repository.GetByValor(1);
            Assert.IsTrue(valores.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemSubValor")]
        public void Consulta_valor_por_chave_primaria()
        {
            var itemValor = repository.FindById(1);
            Assert.AreEqual(itemValor.Valor, 51);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemSubValor")]
        public void Adiciona_valor()
        {
            var itemValor = repository.Add(ItemSubValorStub.NovoItemSubValor());
            Assert.IsTrue(itemValor.Valor >= 0);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemSubValor")]
        public void Exclui_valor()
        {
            var itemValor = repository.Delete(ItemSubValorStub.ItemSubValor());
            Assert.AreEqual(itemValor.Valor, 51);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemSubValor")]
        public void Edita_valor()
        {
            var itemSubValor = ItemSubValorStub.ItemSubValor();

            repository.Edit(itemSubValor);

            Assert.AreEqual(itemSubValor.Valor, 51);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemSubValor")]
        public void Salva_valor()
        {
            var itemSubValor = ItemSubValorStub.NovoItemSubValor();

            repository.Save();

            Assert.AreEqual(itemSubValor.Valor, 78.5M);
        }
    }
}
