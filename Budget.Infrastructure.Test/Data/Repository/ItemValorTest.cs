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
    public class ItemValorTest
    {
        IItemValorRepository repository;

        [TestInitialize]
        public void Inicializa()
        {
            var repositoryMock = new Mock<IItemValorRepository>();
            repositoryMock.Setup(x => x.GetAll()).Returns(ItemValorStub.ItemValores());
            repositoryMock.Setup(x => x.FindById(It.IsAny<Int32>())).Returns(ItemValorStub.ItemValor());
            repositoryMock.Setup(x => x.Add(It.IsAny<ItemValor>())).Returns(ItemValorStub.NovoItemValor());
            repositoryMock.Setup(x => x.Delete(It.IsAny<ItemValor>())).Returns(ItemValorStub.ItemValor());
            repositoryMock.Setup(x => x.Edit(It.IsAny<ItemValor>()));
            repositoryMock.Setup(x => x.GetByOrcamento(It.IsAny<Int32>())).Returns(ItemValorStub.ItemValores());
            repositoryMock.Setup(x => x.Save());

            repository = repositoryMock.Object;
        }


        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemValor")]
        public void Consulta_todos_Valores()
        {
            var valores = repository.GetAll();
            Assert.IsTrue(valores.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemValor")]
        public void Consulta_Valores_Por_Orcamento()
        {
            var valores = repository.GetByOrcamento(1);
            Assert.IsTrue(valores.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemValor")]
        public void Consulta_valor_por_chave_primaria()
        {
            var itemValor = repository.FindById(1);
            Assert.AreEqual(itemValor.SubValores.Sum(x=>x.Valor), 100);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemValor")]
        public void Adiciona_valor()
        {
            var itemValor = repository.Add(ItemValorStub.NovoItemValor());
            Assert.IsTrue(itemValor.SubValores.Sum(x => x.Valor) >= 0);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemValor")]
        public void Exclui_valor()
        {
            var itemValor = repository.Delete(ItemValorStub.ItemValor());
            Assert.AreEqual(itemValor.SubValores.Sum(x => x.Valor), 100);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemValor")]
        public void Edita_valor()
        {
            var itemValor = ItemValorStub.ItemValor();

            itemValor.SubValores = new List<ItemSubValor>();            
            itemValor.SubValores.Add(new ItemSubValor(){ ID = 1, Valor = 321.5M });

            repository.Edit(itemValor);

            Assert.AreEqual(itemValor.SubValores.Sum(x => x.Valor), 321.5M);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/ItemValor")]
        public void Salva_valor()
        {
            var itemValor = ItemValorStub.NovoItemValor();

            itemValor.SubValores = new List<ItemSubValor>();
            itemValor.SubValores.Add(new ItemSubValor() { ID = 1, Valor = 123.45M });

            repository.Save();

            Assert.AreEqual(itemValor.SubValores.Sum(x => x.Valor), 123.45M);
        }
    }
}
