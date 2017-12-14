using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.Presentation.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Budget.Presentation.MVC.Controllers
{
    [Authorize]
    public class ItemValorController : Controller
    {
        private readonly IGerenciadorDeItemValor _gerenciadorDeItemValor;

        public ItemValorController(IGerenciadorDeItemValor gerenciadorDeItemValor)
        {
            _gerenciadorDeItemValor = gerenciadorDeItemValor;
        }

        // GET: Orcamento
        public ActionResult Index(int id)
        {
            var itemValores = _gerenciadorDeItemValor.BuscaPorOrcamento(id);
            var itemValorViewModel = Mapeador.Mapear<IEnumerable<ItemValor>, IEnumerable<ItemValorViewModel>>(itemValores);

            ViewBag.OrcamentoId = id;

            return View(itemValorViewModel);
        }

        // GET: Orcamento/Details/5
        public ActionResult Details(int id)
        {
            var itemValor = _gerenciadorDeItemValor.BuscarPorId(id);
            var itemValorViewModel = Mapeador.Mapear<ItemValor, ItemValorViewModel>(itemValor);

            return View(itemValorViewModel);
        }

        // GET: Orcamento/Create
        public ActionResult Create(int id)
        {
            var itemValorViewModel = new ItemValorViewModel();
            itemValorViewModel.Orcamento = new OrcamentoViewModel() { Id = id };
            PreparaViewData(itemValorViewModel);
            return View(itemValorViewModel);
        }

        // POST: Orcamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemValorViewModel itemValorViewModel)
        {
            try
            {
                var itemValor = Mapeador.Mapear<ItemValorViewModel, ItemValor>(itemValorViewModel);
                _gerenciadorDeItemValor.Salvar(itemValor);

                return RedirectToAction("Index", new { id = itemValorViewModel.Orcamento.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Orcamento/Edit/5
        public ActionResult Edit(int id)
        {
            var itemValor = _gerenciadorDeItemValor.BuscarPorId(id);
            var itemValorViewModel = Mapeador.Mapear<ItemValor, ItemValorViewModel>(itemValor);

            PreparaViewData(itemValorViewModel);
            return View(itemValorViewModel);
        }

        // POST: Orcamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ItemValorViewModel itemValorViewModel)
        {
            try
            {
                var itemValor = Mapeador.Mapear<ItemValorViewModel, ItemValor>(itemValorViewModel);
                _gerenciadorDeItemValor.Editar(itemValor);

                return RedirectToAction("Index", new { id = itemValorViewModel.Orcamento.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Orcamento/Delete/5
        public ActionResult Delete(int id)
        {
            var itemValor = _gerenciadorDeItemValor.BuscarPorId(id);
            var itemValorViewModel = Mapeador.Mapear<ItemValor, ItemValorViewModel>(itemValor);

            return View(itemValorViewModel);
        }

        // POST: Orcamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ItemValorViewModel itemValorViewModel)
        {
            try
            {
                var itemValor = _gerenciadorDeItemValor.BuscarPorId(id);
                _gerenciadorDeItemValor.Excluir(itemValor);

                return RedirectToAction("Index", new { id = itemValorViewModel.Orcamento.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Orcamento/Delete/5
        public ActionResult ItemSubValor(int id)
        {
            return RedirectToAction("Index", "ItemSubValor", new { id = id });
        }

        private void PreparaViewData(ItemValorViewModel itemValorViewModel)
        {
            if(itemValorViewModel == null)
                throw new ArgumentNullException("ItemValorViewModel");
            
            //ViewBag.TipoPessoa = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoPessoaViewModel>(orcamentoViewModel.TipoPessoa);
            //ViewBag.TipoOrcamento = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoOrcamentoViewModel>(orcamentoViewModel.TipoOrcamento);
            //ViewBag.TipoPagamento = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoPagamentoViewModel>(orcamentoViewModel.TipoPagamento);
        }
    }
}
