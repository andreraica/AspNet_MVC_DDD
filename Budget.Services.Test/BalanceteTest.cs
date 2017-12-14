using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Domain.Services.Interfaces;
using Moq;
using Budget.Infrastructure.Stub;
using System.Collections;
using Budget.Domain.Entities;
using System.Collections.Generic;

namespace Budget.Domain.Services.Test
{
    [TestClass]
    public class BalanceteTest
    {
        Mock<IBalanceteService> serviceMock;

        [TestInitialize]
        public void Inicializa()
        {
            serviceMock = new Mock<IBalanceteService>();
            serviceMock.Setup(x => x.Total(It.IsAny<IEnumerable<Orcamento>>()));
            serviceMock.Setup(x => x.Saldo(It.IsAny<IEnumerable<Orcamento>>()));
        }

        [TestMethod]
        [TestCategory("Service/Balancete")]
        public void Consulta_Total_de_Receita()
        {
            serviceMock.Object.Total(It.IsAny<IEnumerable<Orcamento>>());
            serviceMock.Verify(x => x.Total(It.IsAny<IEnumerable<Orcamento>>()), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/Balancete")]
        public void Consulta_Total_de_Despesa()
        {
            serviceMock.Object.Total(It.IsAny<IEnumerable<Orcamento>>());
            serviceMock.Verify(x => x.Total(It.IsAny<IEnumerable<Orcamento>>()), Times.Once());
        }

        [TestMethod]
        [TestCategory("Service/Balancete")]
        public void Consulta_Saldo_Entre_Despesa_e_Receita()
        {
            serviceMock.Object.Saldo(It.IsAny<IEnumerable<Orcamento>>());
            serviceMock.Verify(x => x.Saldo(It.IsAny<IEnumerable<Orcamento>>()), Times.Once());
        }
        
    }
}
