using Budget.Domain.Entities;
using Budget.Domain.Entities.Enum;
using System.Collections.Generic;

namespace Budget.Infrastructure.Stub
{
    public static class OrcamentoStub
    {

        public static List<Orcamento> OrcamentoCompleto()
        {
            var orcamentos = new List<Orcamento>();
            orcamentos.AddRange(OrcamentoStub.Receitas());
            orcamentos.AddRange(OrcamentoStub.Despesas());

            return orcamentos;
        }

        public static Orcamento NovaReceita()
        {
            return new Orcamento()
            {
                ID = 992,
                Descricao = "Nova Receita",
                Fixa = false,
                TipoPessoa = ETipoPessoa.PessoaJuridica,
                TipoPagamento = ETipoPagamento.Cheque,
                TipoOrcamento = ETipoOrcamento.Receita,
                TaxaPorcentagem = 2.5M,
                Valores = ItemValorStub.ItemValores()
            };
        }

        public static Orcamento Receita()
        {
            return new Orcamento()
            {
                ID = 1,
                Descricao = "Ideal",
                Fixa = true,
                TipoPessoa = ETipoPessoa.PessoaJuridica,
                TipoPagamento = ETipoPagamento.Deposito,
                TipoOrcamento = ETipoOrcamento.Receita,
                TaxaPorcentagem = 6,
                Valores = ItemValorStub.ItemValores()
            };
        }

        public static List<Orcamento> Receitas()
        {
            var receitas = new List<Orcamento>();

            receitas.Add(
                Receita()
            );

            receitas.Add(
                new Orcamento()
                {
                    ID = 2,
                    Descricao = "Débora",
                    Fixa = false,
                    TipoPessoa = ETipoPessoa.PessoaFisica,
                    TipoPagamento = ETipoPagamento.Boleto,
                    TipoOrcamento = ETipoOrcamento.Receita,
                    TaxaPorcentagem = 0,
                    Valores = ItemValorStub.ItemValores()
                }
            );

            return receitas;
        }

        public static Orcamento NovaDespesa()
        {
            return new Orcamento()
            {
                ID = 991,
                Descricao = "Nova Despesa",
                TipoPessoa = ETipoPessoa.PessoaFisica,
                TipoPagamento = ETipoPagamento.Saque,
                TipoOrcamento = ETipoOrcamento.Despesa,
                Fixa = false,
                Valores = ItemValorStub.ItemValores()
            };
        }

        public static Orcamento Despesa()
        {
            return new Orcamento()
            {
                ID = 1,
                Descricao = "Carro",
                Fixa = true,
                TipoPessoa = ETipoPessoa.PessoaFisica,
                TipoPagamento = ETipoPagamento.Boleto,
                TipoOrcamento = ETipoOrcamento.Despesa,
                Valores = ItemValorStub.ItemValores()
            };
        }

        public static List<Orcamento> Despesas()
        {
            var despesas = new List<Orcamento>();

            despesas.Add(
                Despesa()
            );

            despesas.Add(
                new Orcamento()
                {
                    ID = 2,
                    Descricao = "Casa",
                    Fixa = true,
                    TipoPessoa = ETipoPessoa.PessoaFisica,
                    TipoPagamento = ETipoPagamento.DebitoAutomatico,
                    TipoOrcamento = ETipoOrcamento.Despesa,
                    Valores = ItemValorStub.ItemValores()
                }
            );

            return despesas;
        }

    }
}
