using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Domain.Entities;
using Budget.Infrastructure.Stub;
using System.Collections.Generic;

namespace Budget.Services.Test
{
    [TestClass]
    public class BalanceteTest
    {
        Balancete balancete;

        [TestInitialize]
        public void Inicializa()
        {
            balancete = new Balancete();
        }

        [TestMethod]
        [TestCategory("Domain/Balancete")]
        public void Consulta_Total_de_Receita()
        {
            var totalReceitas = balancete.Total(OrcamentoStub.Receitas());
            Assert.IsTrue(totalReceitas == 2700);
        }

        [TestMethod]
        [TestCategory("Domain/Balancete")]
        public void Consulta_Total_de_Despesa()
        {
            var totalReceitas = balancete.Total(OrcamentoStub.Despesas());
            Assert.IsTrue(totalReceitas == 2700);
        }

        [TestMethod]
        [TestCategory("Domain/Balancete")]
        public void Consulta_Saldo_Entre_Despesa_e_Receita()
        {
            var saldo = balancete.Saldo(OrcamentoStub.OrcamentoCompleto());
            Assert.IsTrue(saldo == 0);
        }

    }
}
