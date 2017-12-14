using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.Presentation.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace Budget.Presentation.MVC.Controllers
{
    [Authorize]
    public class ItemSubValorController : Controller
    {
        private readonly IGerenciadorDeItemSubValor _gerenciadorDeItemSubValor;
        private readonly IGerenciadorDeItemValor _gerenciadorDeItemValor;

        public ItemSubValorController(IGerenciadorDeItemSubValor gerenciadorDeItemSubValor, IGerenciadorDeItemValor gerenciadorDeItemValor)
        {
            _gerenciadorDeItemSubValor = gerenciadorDeItemSubValor;
            _gerenciadorDeItemValor = gerenciadorDeItemValor;
        }

        // GET: Orcamento
        public ActionResult Index(int id)
        {
            var itemSubValores = _gerenciadorDeItemSubValor.BuscaPorValor(id);
            var itemSubValorViewModel = Mapeador.Mapear<IEnumerable<ItemSubValor>, IEnumerable<ItemSubValorViewModel>>(itemSubValores);

            ViewBag.ItemValorId = id;
            ViewBag.OrcamentoId = (itemSubValorViewModel.Count() == 0) ? _gerenciadorDeItemValor.BuscarPorId(id).Orcamento.ID : itemSubValorViewModel.First().ItemValor.Orcamento.Id;

            return View(itemSubValorViewModel);
        }

        // GET: Orcamento/Details/5
        public ActionResult Details(int id)
        {
            var itemSubValor = _gerenciadorDeItemSubValor.BuscarPorId(id);
            var itemSubValorViewModel = Mapeador.Mapear<ItemSubValor, ItemSubValorViewModel>(itemSubValor);

            return View(itemSubValorViewModel);
        }

        // GET: Orcamento/Create
        public ActionResult Create(int id)
        {
            var itemSubValorViewModel = new ItemSubValorViewModel();
            itemSubValorViewModel.ItemValor = new ItemValorViewModel() { Id = id };
            PreparaViewData(itemSubValorViewModel);
            return View(itemSubValorViewModel);
        }

        // POST: Orcamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemSubValorViewModel itemSubValorViewModel)
        {
            try
            {
                var itemSubValor = Mapeador.Mapear<ItemSubValorViewModel, ItemSubValor>(itemSubValorViewModel);
                _gerenciadorDeItemSubValor.Salvar(itemSubValor);

                return RedirectToAction("Index", new { id = itemSubValorViewModel.ItemValor.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Orcamento/Edit/5
        public ActionResult Edit(int id)
        {
            var itemSubValor = _gerenciadorDeItemSubValor.BuscarPorId(id);
            var itemSubValorViewModel = Mapeador.Mapear<ItemSubValor, ItemSubValorViewModel>(itemSubValor);

            PreparaViewData(itemSubValorViewModel);
            return View(itemSubValorViewModel);
        }

        // POST: Orcamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ItemSubValorViewModel itemSubValorViewModel)
        {
            try
            {
                var itemSubValor = Mapeador.Mapear<ItemSubValorViewModel, ItemSubValor>(itemSubValorViewModel);
                _gerenciadorDeItemSubValor.Editar(itemSubValor);

                return RedirectToAction("Index", new { id = itemSubValorViewModel.ItemValor.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Orcamento/Delete/5
        public ActionResult Delete(int id)
        {
            var itemSubValor = _gerenciadorDeItemSubValor.BuscarPorId(id);
            var itemSubValorViewModel = Mapeador.Mapear<ItemSubValor, ItemSubValorViewModel>(itemSubValor);

            return View(itemSubValorViewModel);
        }

        // POST: Orcamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ItemSubValorViewModel itemSubValorViewModel)
        {
            try
            {
                var itemSubValor = _gerenciadorDeItemSubValor.BuscarPorId(id);
                _gerenciadorDeItemSubValor.Excluir(itemSubValor);

                return RedirectToAction("Index", new { id = itemSubValorViewModel.ItemValor.Id });
            }
            catch
            {
                return View();
            }
        }

        private void PreparaViewData(ItemSubValorViewModel itemSubValorViewModel)
        {
            if (itemSubValorViewModel == null)
                throw new ArgumentNullException("ItemSubValorViewModel");

            //ViewBag.TipoPessoa = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoPessoaViewModel>(orcamentoViewModel.TipoPessoa);
            //ViewBag.TipoOrcamento = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoOrcamentoViewModel>(orcamentoViewModel.TipoOrcamento);
            //ViewBag.TipoPagamento = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoPagamentoViewModel>(orcamentoViewModel.TipoPagamento);
        }
    }
}
