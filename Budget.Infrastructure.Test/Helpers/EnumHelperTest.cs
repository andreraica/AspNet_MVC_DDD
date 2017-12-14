using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Infrastructure.Helpers;
using Budget.Domain.Entities.Enum;

namespace Budget.Infrastructure.Test.Helpers
{
    [TestClass]
    public class EnumHelperTest
    {
        [TestMethod]
        [TestCategory("Infrastructure/Helpers")]
        public void Consulta_Descricao_Enum()
        {
            var result = EnumHelper.Description(ETipoOrcamento.Despesa);
            Assert.AreEqual("Despesa", result);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Helpers")]
        public void Consulta_Listagem_Enum()
        {
            var result = EnumHelper.GetList <ETipoOrcamento>(ETipoOrcamento.Despesa);
            Assert.IsNotNull(result);
        }
                
    }
}
