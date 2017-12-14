using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Interface;
using Budget.Domain.Services.Interfaces;
using System.Collections.Generic;
using Budget.Infrastructure.Data.Interface.ReadOnly;

namespace Budget.Domain.Services
{
    public class ItemSubValorService : IItemSubValorService
    {
        IItemSubValorRepository _itemSubValorRepository;
        IItemSubValorReadOnlyRepository _itemSubValorReadOnlyRepository;

        public ItemSubValorService(IItemSubValorRepository itemSubValorRepository, IItemSubValorReadOnlyRepository itemSubValorReadOnlyRepository)
        {
            _itemSubValorRepository = itemSubValorRepository;
            _itemSubValorReadOnlyRepository = itemSubValorReadOnlyRepository;
        }

        public IEnumerable<ItemSubValor> GetAll()
        {
            return _itemSubValorReadOnlyRepository.GetAll();
        }

        public ItemSubValor FindById(int id)
        {
            return _itemSubValorReadOnlyRepository.FindById(id);
        }

        public ItemSubValor Add(ItemSubValor entity)
        {
            return _itemSubValorRepository.Add(entity);
        }

        public ItemSubValor Delete(ItemSubValor entity)
        {
            return _itemSubValorRepository.Delete(entity);
        }

        public void Edit(ItemSubValor entity)
        {
            _itemSubValorRepository.Edit(entity);
        }

        public void Save()
        {
            _itemSubValorRepository.Save();
        }
        
        public IEnumerable<ItemSubValor> GetByValor(int valorId)
        {
            return _itemSubValorRepository.GetByValor(valorId);
        }
    }
}
