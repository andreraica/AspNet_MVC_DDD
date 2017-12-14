using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Domain.Entities;
using Budget.Infrastructure.Stub;

namespace Budget.Services.Test
{
    [TestClass]
    public class ItemValorTest
    {
        ItemValor itemValor;

        [TestInitialize]
        public void Inicializa()
        {
            itemValor = ItemValorStub.NovoItemValor();
        }

        [TestMethod]
        [TestCategory("Domain/ItemValor")]
        public void Verifica_Propriedades()
        {
            Assert.AreEqual(itemValor.ID, 99);
            Assert.IsNotNull(itemValor.Vencimento);
            Assert.IsNotNull(itemValor.SubValores);
        }

        [TestMethod]
        [TestCategory("Domain/ItemValor")]
        public void Consulta_Total_de_SubValor()
        {
            decimal totalSubValor = itemValor.TotalSubValor(itemValor);
            Assert.IsTrue(totalSubValor >= 0);
        }

    }
}
