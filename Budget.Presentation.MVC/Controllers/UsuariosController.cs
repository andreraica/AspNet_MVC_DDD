using Budget.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Budget.Presentation.MVC.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {

        private readonly IGerenciadorDeUsuario _gerenciadorDeUsuario;

        public UsuariosController(IGerenciadorDeUsuario gerenciadorDeUsuario)
        {
            _gerenciadorDeUsuario = gerenciadorDeUsuario;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(_gerenciadorDeUsuario.ObterTodos());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            return View(_gerenciadorDeUsuario.ObterPorId(id));
        }

        public ActionResult DesativarLock(string id)
        {
            _gerenciadorDeUsuario.DesativarLock(id);
            return RedirectToAction("Index");
        }
    }
}
