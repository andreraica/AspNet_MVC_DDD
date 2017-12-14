using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.MVC.ViewModels;
using Marisa.Ecommerce.Web;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Budget.MVC.Controllers
{
    public class ItemSubValorController : Controller
    {

        private readonly IGerenciadorDeItemSubValor _gerenciadorDeItemSubValor;

        public ItemSubValorController(IGerenciadorDeItemSubValor gerenciadorDeItemSubValor)
        {
            _gerenciadorDeItemSubValor = gerenciadorDeItemSubValor;
        }

        // GET: Orcamento
        public ActionResult Index(int id)
        {
            var itemSubValores = _gerenciadorDeItemSubValor.Listar();
            var itemSubValorViewModel = Mapeador.Mapear<IEnumerable<ItemSubValor>, IEnumerable<ItemSubValorViewModel>>(itemSubValores);

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
        public ActionResult Create()
        {
            var itemSubValorViewModel = new ItemSubValorViewModel();
            PreparaViewData(itemSubValorViewModel);
            return View();
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

                return RedirectToAction("Index");
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

                return RedirectToAction("Index");
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void PreparaViewData(ItemSubValorViewModel itemSubValorViewModel)
        {
            //ViewBag.TipoPessoa = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoPessoaViewModel>(orcamentoViewModel.TipoPessoa);
            //ViewBag.TipoOrcamento = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoOrcamentoViewModel>(orcamentoViewModel.TipoOrcamento);
            //ViewBag.TipoPagamento = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoPagamentoViewModel>(orcamentoViewModel.TipoPagamento);
        }
    }
}
