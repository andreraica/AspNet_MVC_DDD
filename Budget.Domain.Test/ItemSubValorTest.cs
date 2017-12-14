using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Domain.Entities;
using Budget.Infrastructure.Stub;

namespace Budget.Services.Test
{
    [TestClass]
    public class ItemSubValorTest
    {
        ItemSubValor itemSubValor;

        [TestInitialize]
        public void Inicializa()
        {
            itemSubValor = ItemSubValorStub.NovoItemSubValor();
        }

        [TestMethod]
        [TestCategory("Domain/ItemSubValor")]
        public void Verifica_Propriedades()
        {
            Assert.AreEqual(itemSubValor.ID, 99);
            Assert.AreEqual(itemSubValor.Valor, 78.5M);
        }

    }
}
