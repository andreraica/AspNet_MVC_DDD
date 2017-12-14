using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Domain.Services.Interfaces;
using Moq;
using Budget.Domain.Entities;
using System;

namespace Budget.Domain.Services.Test
{
    [TestClass]
    public class ItemValorTest
    {
        Mock<IItemValorService> serviceMock;

        [TestInitialize]
        public void Inicializa()
        {
            serviceMock = new Mock<IItemValorService>();
            serviceMock.Setup(x => x.GetAll());
            serviceMock.Setup(x => x.GetByOrcamento(1));
            serviceMock.Setup(x => x.FindById(1));
            serviceMock.Setup(x => x.Add(It.IsAny<ItemValor>()));
            serviceMock.Setup(x => x.Delete(It.IsAny<ItemValor>()));
            serviceMock.Setup(x => x.Edit(It.IsAny<ItemValor>()));
            serviceMock.Setup(x => x.Save());
        }

        [TestMethod]
        [TestCategory("Service/ItemValor")]
        public void Consulta_todos_ItemValor()
        {
            serviceMock.Object.GetAll();
            serviceMock.Verify(x => x.GetAll(), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemValor")]
        public void Consulta_ItemValor_por_orcamento()
        {
            serviceMock.Object.GetByOrcamento(1);
            serviceMock.Verify(x => x.GetByOrcamento(1), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemValor")]
        public void Consulta_ItemValor_por_chave_primaria()
        {
            serviceMock.Object.FindById(1);
            serviceMock.Verify(x => x.FindById(1), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemValor")]
        public void Adiciona_ItemValor()
        {
            serviceMock.Object.Add(It.IsAny<ItemValor>());
            serviceMock.Verify(x => x.Add(It.IsAny<ItemValor>()), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemValor")]
        public void Exclui_ItemValor()
        {
            serviceMock.Object.Delete(It.IsAny<ItemValor>());
            serviceMock.Verify(x => x.Delete(It.IsAny<ItemValor>()), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemValor")]
        public void Edita_ItemValor()
        {
            serviceMock.Object.Edit(It.IsAny<ItemValor>());
            serviceMock.Verify(x => x.Edit(It.IsAny<ItemValor>()), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemValor")]
        public void Salva_ItemValor()
        {
            serviceMock.Object.Save();
            serviceMock.Verify(x => x.Save(), Times.Once());
        }


    }
}
