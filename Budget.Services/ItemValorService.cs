using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Interface;
using Budget.Domain.Services.Interfaces;
using System.Collections.Generic;
using Budget.Infrastructure.Data.Interface.ReadOnly;

namespace Budget.Domain.Services
{
    public class ItemValorService : IItemValorService
    {
        IItemValorRepository _itemValorRepository;
        IItemValorReadOnlyRepository _itemValorReadOnlyRepository;

        public ItemValorService(IItemValorRepository itemValorRepository, IItemValorReadOnlyRepository itemValorReadOnlyRepository)
        {
            _itemValorRepository = itemValorRepository;
            _itemValorReadOnlyRepository = itemValorReadOnlyRepository;
        }

        public IEnumerable<ItemValor> GetAll()
        {
            return _itemValorReadOnlyRepository.GetAll();
        }

        public ItemValor FindById(int id)
        {
            return _itemValorReadOnlyRepository.FindById(id);
        }

        public ItemValor Add(ItemValor entity)
        {
            return _itemValorRepository.Add(entity);
        }

        public ItemValor Delete(ItemValor entity)
        {
            return _itemValorRepository.Delete(entity);
        }

        public void Edit(ItemValor entity)
        {
            _itemValorRepository.Edit(entity);
        }

        public void Save()
        {
            _itemValorRepository.Save();
        }
        
        public IEnumerable<ItemValor> GetByOrcamento(int orcamentoId)
        {
            return _itemValorRepository.GetByOrcamento(orcamentoId);
        }
    }
}
