using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Domain.Services.Interfaces;
using Moq;
using Budget.Domain.Entities;

namespace Budget.Domain.Services.Test
{
    [TestClass]
    public class ItemSubValorTest
    {
        Mock<IItemSubValorService> serviceMock;

        [TestInitialize]
        public void Inicializa()
        {
            serviceMock = new Mock<IItemSubValorService>();
            serviceMock.Setup(x => x.GetAll());
            serviceMock.Setup(x => x.GetByValor(1));
            serviceMock.Setup(x => x.FindById(1));
            serviceMock.Setup(x => x.Add(It.IsAny<ItemSubValor>()));
            serviceMock.Setup(x => x.Delete(It.IsAny<ItemSubValor>()));
            serviceMock.Setup(x => x.Edit(It.IsAny<ItemSubValor>()));
            serviceMock.Setup(x => x.Save());
        }

        [TestMethod]
        [TestCategory("Service/ItemSubValor")]
        public void Consulta_todos_ItemValor()
        {
            serviceMock.Object.GetAll();
            serviceMock.Verify(x => x.GetAll(), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemSubValor")]
        public void Consulta_ItemSubValor_por_valor()
        {
            serviceMock.Object.GetByValor(1);
            serviceMock.Verify(x => x.GetByValor(1), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemSubValor")]
        public void Consulta_ItemValor_por_chave_primaria()
        {
            serviceMock.Object.FindById(1);
            serviceMock.Verify(x => x.FindById(1), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemSubValor")]
        public void Adiciona_ItemValor()
        {
            serviceMock.Object.Add(It.IsAny<ItemSubValor>());
            serviceMock.Verify(x => x.Add(It.IsAny<ItemSubValor>()), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemSubValor")]
        public void Exclui_ItemValor()
        {
            serviceMock.Object.Delete(It.IsAny<ItemSubValor>());
            serviceMock.Verify(x => x.Delete(It.IsAny<ItemSubValor>()), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemSubValor")]
        public void Edita_ItemValor()
        {
            serviceMock.Object.Edit(It.IsAny<ItemSubValor>());
            serviceMock.Verify(x => x.Edit(It.IsAny<ItemSubValor>()), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/ItemSubValor")]
        public void Salva_ItemValor()
        {
            serviceMock.Object.Save();
            serviceMock.Verify(x => x.Save(), Times.Once());
        }


    }
}
