using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Interface;
using Budget.Domain.Services.Interfaces;
using System.Collections.Generic;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data.Interface.ReadOnly;

namespace Budget.Domain.Services
{
    public class OrcamentoService : IOrcamentoService
    {
        IOrcamentoRepository _orcamentoRepository;
        IOrcamentoReadOnlyRepository _orcamentoReadOnlyRepository;

        public OrcamentoService(IOrcamentoRepository receitaRepository, IOrcamentoReadOnlyRepository orcamentoReadOnlyRepository)
        {
            _orcamentoRepository = receitaRepository;
            _orcamentoReadOnlyRepository = orcamentoReadOnlyRepository;
        }

        public IEnumerable<Orcamento> GetAll()
        {
            return _orcamentoReadOnlyRepository.GetAll();
        }

        public Orcamento FindById(int id)
        {
            return _orcamentoReadOnlyRepository.FindById(id);
        }

        public Orcamento Add(Orcamento entity)
        {
            return _orcamentoRepository.Add(entity);
        }

        public Orcamento Delete(Orcamento entity)
        {
            return _orcamentoRepository.Delete(entity);
        }

        public void Edit(Orcamento entity)
        {
            _orcamentoRepository.Edit(entity);
        }

        public void Save()
        {
            _orcamentoRepository.Save();
        }

        public int DiaVencimentoMedio(Orcamento orcamento)
        {
            return orcamento.DiaVencimentoMedio(orcamento);
        }

        public int QuantidadeParcelas(Orcamento orcamento)
        {
            return orcamento.QuantidadeParcelas(orcamento);
        }

        public int QuantidadeParcelasRestantes(Orcamento orcamento)
        {
            return orcamento.QuantidadeParcelasRestantes(orcamento);
        }

        public decimal TotalValorRestante(Orcamento orcamento)
        {
            return orcamento.TotalValorRestante(orcamento);
        }
    }
}
