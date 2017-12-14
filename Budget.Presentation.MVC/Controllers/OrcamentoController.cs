using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.Presentation.MVC.ViewModel.Enum;
using Budget.Presentation.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Budget.Presentation.MVC.Controllers
{
    [Authorize]
    public class OrcamentoController : Controller
    {
        private readonly IGerenciadorDeOrcamento _gerenciadorDeOrcamento;

        public OrcamentoController(IGerenciadorDeOrcamento gerenciadorDeOrcamento)
        {
            _gerenciadorDeOrcamento = gerenciadorDeOrcamento;
        }

        // GET: Orcamento Angular
        public ActionResult Angular()
        {
            return View();
        }

        // GET: Orcamento
        public ActionResult Index()
        {
            var orcamentos = _gerenciadorDeOrcamento.Listar();
            var orcamentoViewModel = Mapeador.Mapear<IEnumerable<Orcamento>, IEnumerable<OrcamentoViewModel>>(orcamentos);

            return View(orcamentoViewModel);
        }

        // GET: Orcamento/Details/5
        public ActionResult Details(int id)
        {
            var orcamento = _gerenciadorDeOrcamento.BuscarPorId(id);
            var orcamentoViewModel = Mapeador.Mapear<Orcamento, OrcamentoViewModel>(orcamento);

            return View(orcamentoViewModel);
        }

        // GET: Orcamento/Create
        public ActionResult Create()
        {
            var orcamentoViewModel = new OrcamentoViewModel();
            PreparaViewData(orcamentoViewModel);
            return View();
        }

        // POST: Orcamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrcamentoViewModel orcamentoViewModel)
        {
            try
            {
                var orcamento = Mapeador.Mapear<OrcamentoViewModel, Orcamento>(orcamentoViewModel);
                _gerenciadorDeOrcamento.Salvar(orcamento);

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
            var orcamento = _gerenciadorDeOrcamento.BuscarPorId(id);
            var orcamentoViewModel = Mapeador.Mapear<Orcamento, OrcamentoViewModel>(orcamento);

            PreparaViewData(orcamentoViewModel);
            return View(orcamentoViewModel);
        }

        // POST: Orcamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrcamentoViewModel orcamentoViewModel)
        {
            try
            {
                var orcamento = Mapeador.Mapear<OrcamentoViewModel, Orcamento>(orcamentoViewModel);
                _gerenciadorDeOrcamento.Editar(orcamento);

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
            var orcamento = _gerenciadorDeOrcamento.BuscarPorId(id);
            var orcamentoViewModel = Mapeador.Mapear<Orcamento, OrcamentoViewModel>(orcamento);

            return View(orcamentoViewModel);
        }

        // POST: Orcamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OrcamentoViewModel orcamentoViewModel)
        {
            try
            {
                var orcamento = _gerenciadorDeOrcamento.BuscarPorId(id);
                _gerenciadorDeOrcamento.Excluir(orcamento);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orcamento/Delete/5
        public ActionResult ItemValor(int id)
        {
            return RedirectToAction("Index", "ItemValor", new { id = id });
        }

        private void PreparaViewData(OrcamentoViewModel orcamentoViewModel)
        {
            if (orcamentoViewModel != null)
            {
                ViewBag.TipoPessoa = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoPessoaViewModel>(orcamentoViewModel.TipoPessoa);
                ViewBag.TipoOrcamento = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoOrcamentoViewModel>(orcamentoViewModel.TipoOrcamento);
                ViewBag.TipoPagamento = Budget.Infrastructure.Helpers.EnumHelper.GetList<ETipoPagamentoViewModel>(orcamentoViewModel.TipoPagamento);
            }
            else
            {
                throw new ArgumentNullException("OrcamentoViewModel");
            }
        }
    }
}
