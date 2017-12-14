using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget.Domain.Services.Interfaces;
using Moq;
using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Interface;
using Budget.Infrastructure.Stub;
using Budget.Infrastructure.Data.Interface.ReadOnly;

namespace Budget.Domain.Services.Test
{
    [TestClass]
    public class OrcamentoTest
    {
        IOrcamentoService _orcamentoService;
        Mock<IOrcamentoService> _orcamentoServiceMock;
        Mock<IOrcamentoRepository> _orcamentoRepositoryMock;
        Mock<IOrcamentoReadOnlyRepository> _orcamentoReadOnlyRepositoryMock;

        [TestInitialize]
        public void Inicializa()
        {
            _orcamentoServiceMock = new Mock<IOrcamentoService>();
            _orcamentoRepositoryMock = new Mock<IOrcamentoRepository>();
            _orcamentoReadOnlyRepositoryMock = new Mock<IOrcamentoReadOnlyRepository>();
            _orcamentoService = new OrcamentoService(_orcamentoRepositoryMock.Object, _orcamentoReadOnlyRepositoryMock.Object);
        }

        [TestMethod]
        [TestCategory("Service/Orcamento")]
        public void Consulta_todas_despesas()
        {
            _orcamentoRepositoryMock.Setup(x => x.GetAll()).Returns(OrcamentoStub.Receitas);
            var despesas = _orcamentoService.GetAll();

            Assert.IsNotNull(despesas);
        }

        [TestMethod]
        [TestCategory("Service/Orcamento")]
        public void Consulta_despesa_por_chave_primaria()
        {
            _orcamentoRepositoryMock.Setup(x => x.FindById(It.IsAny<int>())).Returns(OrcamentoStub.Receita);
            var despesa = _orcamentoService.FindById(It.IsAny<int>());

            Assert.IsNotNull(despesa);
        }

        [TestMethod]
        [TestCategory("Service/Orcamento")]
        public void Adiciona_Despesa()
        {
            _orcamentoRepositoryMock.Setup(x => x.Add(It.IsAny<Orcamento>())).Returns(OrcamentoStub.NovaReceita);
            var despesa = _orcamentoService.Add(It.IsAny<Orcamento>());

            Assert.IsNotNull(despesa);
        }

        [TestMethod]
        [TestCategory("Service/Orcamento")]
        public void Exclui_Despesa()
        {
            _orcamentoRepositoryMock.Setup(x => x.Delete(It.IsAny<Orcamento>())).Returns(OrcamentoStub.Receita);
            var despesa = _orcamentoService.Delete(It.IsAny<Orcamento>());

            Assert.IsNotNull(despesa);
        }

        [TestMethod]
        [TestCategory("Service/Orcamento")]
        public void Edita_Despesa()
        {
            _orcamentoRepositoryMock.Setup(x => x.Edit(It.IsAny<Orcamento>()));
            _orcamentoService.Edit(It.IsAny<Orcamento>());
        }

        [TestMethod]
        [TestCategory("Service/Orcamento")]
        public void Salva_Despesa()
        {
            _orcamentoRepositoryMock.Setup(x => x.Save());
            _orcamentoService.Save();
        }


        [TestMethod]
        [TestCategory("Service/Orcamento")]
        public void Verificar_Dia_Medio_Vencimento()
        {
            _orcamentoServiceMock.Setup(x => x.DiaVencimentoMedio(It.IsAny<Orcamento>())).Returns(15);
            var diaVencimentoMedio = _orcamentoServiceMock.Object.DiaVencimentoMedio(It.IsAny<Orcamento>());

            Assert.AreEqual(15, diaVencimentoMedio);
        }

        [TestMethod]
        [TestCategory("Service/Orcamento")]
        public void Verificar_Quantidade_De_Parcelas()
        {
            _orcamentoServiceMock.Setup(x => x.QuantidadeParcelas(It.IsAny<Orcamento>())).Returns(8);
            var quantidadeParcelas = _orcamentoServiceMock.Object.QuantidadeParcelas(It.IsAny<Orcamento>());

            Assert.AreEqual(8, quantidadeParcelas);
        }

        [TestMethod]
        [TestCategory("Service/Orcamento")]
        public void Verificar_Quantidade_De_Parcelas_Restantes()
        {
            _orcamentoServiceMock.Setup(x => x.QuantidadeParcelasRestantes(It.IsAny<Orcamento>())).Returns(10);
            var quantidadeParcelasRestantes = _orcamentoServiceMock.Object.QuantidadeParcelasRestantes(It.IsAny<Orcamento>());

            Assert.AreEqual(10, quantidadeParcelasRestantes);
        }

        [TestMethod]
        [TestCategory("Service/Orcamento")]
        public void Verificar_Total_Valor_Restante()
        {
            _orcamentoServiceMock.Setup(x => x.TotalValorRestante(It.IsAny<Orcamento>())).Returns(123);
            var totalValorRestante = _orcamentoServiceMock.Object.TotalValorRestante(It.IsAny<Orcamento>());

            Assert.AreEqual(123, totalValorRestante);
        }
    }
}
