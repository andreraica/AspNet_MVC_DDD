using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace Budget.Application
{
    public class GerenciadorDeItemValor : IGerenciadorDeItemValor
    {
        private readonly IItemValorService _itemValorService;

        public GerenciadorDeItemValor(IItemValorService itemValorService)
        {
            _itemValorService = itemValorService;
        }

        public IEnumerable<ItemValor> Listar()
        {
            var itemValores = _itemValorService.GetAll();
            return itemValores;
        }

        public bool Salvar(ItemValor itemValor)
        {
            _itemValorService.Add(itemValor);
            _itemValorService.Save();
            return true;
        }

        public ItemValor Editar(ItemValor itemValor)
        {
            _itemValorService.Edit(itemValor);
            _itemValorService.Save();
            return itemValor;
        }

        public void Excluir(ItemValor itemValor)
        {
            _itemValorService.Delete(itemValor);
            _itemValorService.Save();
        }

        public ItemValor BuscarPorId(int id)
        {
            var itemValor = _itemValorService.FindById(id);
            return itemValor;
        }

        public IEnumerable<ItemValor> BuscaPorOrcamento(int orcamentoId)
        {
            var itemValor = _itemValorService.GetByOrcamento(orcamentoId);
            return itemValor;
        }
    }
}
