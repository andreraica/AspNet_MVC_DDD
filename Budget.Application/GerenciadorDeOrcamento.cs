using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace Budget.Application
{
    public class GerenciadorDeOrcamento : IGerenciadorDeOrcamento
    {
        private readonly IOrcamentoService _orcamentoService;

        public GerenciadorDeOrcamento(IOrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
        }

        public IEnumerable<Orcamento> Listar()
        {
            var despesas = _orcamentoService.GetAll();
            return despesas;
        }

        public bool Salvar(Orcamento orcamento)
        {
            _orcamentoService.Add(orcamento);
            _orcamentoService.Save();
            return true;
        }

        public Orcamento Editar(Orcamento orcamento)
        {
            _orcamentoService.Edit(orcamento);
            _orcamentoService.Save();
            return orcamento;
        }

        public void Excluir(Orcamento orcamento)
        {
            _orcamentoService.Delete(orcamento);
            _orcamentoService.Save();
        }

        public Orcamento BuscarPorId(int id)
        {
            var orcamento = _orcamentoService.FindById(id);
            return orcamento;
        }
    }
}
