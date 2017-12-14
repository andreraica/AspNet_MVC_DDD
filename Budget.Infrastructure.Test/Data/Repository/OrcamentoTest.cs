using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Budget.Infrastructure.Data.Interface;
using Budget.Domain.Entities;
using Budget.Infrastructure.Stub;
using System.Linq;

namespace Budget.Infrastructure.Test.Data.Repository
{
    [TestClass]
    public class OrcamentoTest
    {
        IOrcamentoRepository repository;
        Mock<IOrcamentoRepository> repositoryMock;

        [TestInitialize]
        public void Inicializa()
        {
            repositoryMock = new Mock<IOrcamentoRepository>();
            repository = repositoryMock.Object;
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/Orcamento")]
        public void Consulta_Todo_Orcamento()
        {
            repositoryMock.Setup(x => x.GetAll()).Returns(OrcamentoStub.Receitas());
            var orcamentos = repository.GetAll();
            Assert.IsTrue(orcamentos.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/Orcamento")]
        public void Consulta_Orcamento_por_chave_primaria()
        {
            repositoryMock.Setup(x => x.FindById(It.IsAny<Int32>())).Returns(OrcamentoStub.Receita());
            var orcamento = repository.FindById(1);
            Assert.AreEqual(orcamento.ID, 1);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/Orcamento")]
        public void Adiciona_Orcamento()
        {
            repositoryMock.Setup(x => x.Add(It.IsAny<Orcamento>())).Returns(OrcamentoStub.NovaReceita());
            var orcamento = repository.Add(OrcamentoStub.NovaReceita());
            Assert.AreEqual(orcamento.ID, 992);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/Orcamento")]
        public void Exclui_Orcamento()
        {
            repositoryMock.Setup(x => x.Delete(It.IsAny<Orcamento>())).Returns(OrcamentoStub.Receita());
            var orcamento = repository.Delete(OrcamentoStub.Receita());
            Assert.AreEqual(orcamento.ID, 1);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/Orcamento")]
        public void Edita_Orcamento()
        {
            repositoryMock.Setup(x => x.Edit(It.IsAny<Orcamento>()));
            var orcamento = OrcamentoStub.Receita();
            orcamento.TaxaPorcentagem = 7.25M;

            repository.Edit(orcamento);

            Assert.AreEqual(orcamento.TaxaPorcentagem, 7.25M);
        }

        [TestMethod]
        [TestCategory("Infrastructure/Data/Repository/Orcamento")]
        public void Salva_Orcamento()
        {
            repositoryMock.Setup(x => x.Save());
            var orcamento = OrcamentoStub.NovaReceita();

            repository.Save();

            Assert.AreEqual(orcamento.ID, 992);
        }
    }
}
