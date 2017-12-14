using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace Budget.Application
{
    public class GerenciadorDeItemSubValor : IGerenciadorDeItemSubValor
    {
        private readonly IItemSubValorService _itemSubValorService;

        public GerenciadorDeItemSubValor(IItemSubValorService itemSubValorService)
        {
            _itemSubValorService = itemSubValorService;
        }

        public IEnumerable<ItemSubValor> Listar()
        {
            var itemValores = _itemSubValorService.GetAll();
            return itemValores;
        }

        public bool Salvar(ItemSubValor itemValor)
        {
            _itemSubValorService.Add(itemValor);
            _itemSubValorService.Save();
            return true;
        }

        public ItemSubValor Editar(ItemSubValor itemValor)
        {
            _itemSubValorService.Edit(itemValor);
            _itemSubValorService.Save();
            return itemValor;
        }

        public void Excluir(ItemSubValor itemValor)
        {
            _itemSubValorService.Delete(itemValor);
            _itemSubValorService.Save();
        }

        public ItemSubValor BuscarPorId(int id)
        {
            var itemValor = _itemSubValorService.FindById(id);
            return itemValor;
        }

        public IEnumerable<ItemSubValor> BuscaPorValor(int valorId)
        {
            var itemValor = _itemSubValorService.GetByValor(valorId);
            return itemValor;
        }
    }
}
