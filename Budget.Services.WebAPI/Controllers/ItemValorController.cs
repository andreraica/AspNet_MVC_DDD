using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Budget.Services.WebAPI.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemValorController : ApiController
    {

        private readonly IGerenciadorDeItemValor _gerenciadorDeItemValor;

        public ItemValorController(IGerenciadorDeItemValor gerenciadorDeItemValor)
        {
            _gerenciadorDeItemValor = gerenciadorDeItemValor;
        }

        // GET: List
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var itemValores = _gerenciadorDeItemValor.Listar();

                response = Request.CreateResponse(HttpStatusCode.OK, itemValores);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetByOrcamento(int id)
        {
            HttpResponseMessage response;
            try
            {
                var itemValores = _gerenciadorDeItemValor.BuscaPorOrcamento(id);

                response = Request.CreateResponse(HttpStatusCode.OK, itemValores);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // GET: Details
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            try
            {
                var itemValor = _gerenciadorDeItemValor.BuscarPorId(id);

                response = Request.CreateResponse(HttpStatusCode.OK, itemValor);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // POST: Create
        public HttpResponseMessage Post(ItemValor itemValor)
        {
            HttpResponseMessage response;
            try
            {
                _gerenciadorDeItemValor.Salvar(itemValor);

                response = Request.CreateResponse(HttpStatusCode.OK, itemValor);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // POST: Edit
        public HttpResponseMessage Put(ItemValor itemValor)
        {
            HttpResponseMessage response;
            try
            {
                _gerenciadorDeItemValor.Editar(itemValor);

                response = Request.CreateResponse(HttpStatusCode.OK, itemValor);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // POST: Delete
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
            try
            {
                var itemValor = _gerenciadorDeItemValor.BuscarPorId(id);
                _gerenciadorDeItemValor.Excluir(itemValor);

                response = Request.CreateResponse(HttpStatusCode.OK, itemValor);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }
    }
}
