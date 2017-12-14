using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Domain.Entities;
using Budget.Infrastructure.Stub;
using Budget.Domain.Entities.Enum;

namespace Budget.Services.Test
{
    [TestClass]
    public class ReceitaTest
    {
        Orcamento orcamento;

        [TestInitialize]
        public void Inicializa()
        {
            orcamento = new Orcamento();
        }

        [TestMethod]
        [TestCategory("Domain/ItemValor")]
        public void Verifica_Propriedades()
        {
            orcamento = OrcamentoStub.NovaDespesa();

            Assert.AreEqual(orcamento.ID, 991);
            Assert.AreEqual(orcamento.Descricao, "Nova Despesa");
            Assert.AreEqual(orcamento.TipoPessoa, ETipoPessoa.PessoaFisica);
            Assert.AreEqual(orcamento.TipoPagamento, ETipoPagamento.Saque);
            Assert.AreEqual(orcamento.TipoOrcamento, ETipoOrcamento.Despesa);
            Assert.IsFalse(orcamento.Fixa);
            Assert.IsNotNull(orcamento.Valores);
        }

        [TestMethod]
        [TestCategory("Domain/Orcamento")]
        public void Consulta_Dia_Vencimento_Medio()
        {
            var diaVencimentoMedio = orcamento.DiaVencimentoMedio(OrcamentoStub.Receita());
            Assert.IsTrue(diaVencimentoMedio == 17);
        }

        [TestMethod]
        [TestCategory("Domain/Orcamento")]
        public void Calcula_Quantidade_De_Parcelas_Desde_Inicio_Ate_O_Fim()
        {
            var totalParcelas = orcamento.QuantidadeParcelas(OrcamentoStub.Receita());
            Assert.IsTrue(totalParcelas == 3);
        }

        [TestMethod]
        [TestCategory("Domain/Orcamento")]
        public void Calcula_Quantidade_De_Parcelas_Restantes_De_Hoje_Ate_O_Fim()
        {
            var totalParcelas = orcamento.QuantidadeParcelasRestantes(OrcamentoStub.Receita());
            Assert.IsTrue(totalParcelas == 0);
        }

        [TestMethod]
        [TestCategory("Domain/Orcamento")]
        public void Calcula_Valor_Total_Restante_De_Hoje_Ate_O_Fim()
        {
            var totalParcelas = orcamento.TotalValorRestante(OrcamentoStub.Receita());
            Assert.IsTrue(totalParcelas == 0);
        }

    }
}
