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
    public class ItemSubValorController : ApiController
    {

        private readonly IGerenciadorDeItemSubValor _gerenciadorDeItemSubValor;

        public ItemSubValorController(IGerenciadorDeItemSubValor gerenciadorDeItemSubValor)
        {
            _gerenciadorDeItemSubValor = gerenciadorDeItemSubValor;
        }


        // GET: List
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var itemSubValores = _gerenciadorDeItemSubValor.Listar();

                response = Request.CreateResponse(HttpStatusCode.OK, itemSubValores);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetByValor(int id)
        {
            HttpResponseMessage response;
            try
            {
                var itemSubValores = _gerenciadorDeItemSubValor.BuscaPorValor(id);

                response = Request.CreateResponse(HttpStatusCode.OK, itemSubValores);
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
                var itemSubValor = _gerenciadorDeItemSubValor.BuscarPorId(id);

                response = Request.CreateResponse(HttpStatusCode.OK, itemSubValor);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // POST: Create
        public HttpResponseMessage Post(ItemSubValor itemSubValor)
        {
            HttpResponseMessage response;
            try
            {
                _gerenciadorDeItemSubValor.Salvar(itemSubValor);

                response = Request.CreateResponse(HttpStatusCode.OK, itemSubValor);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // POST: Edit
        public HttpResponseMessage Put(ItemSubValor itemSubValor)
        {
            HttpResponseMessage response;
            try
            {
                _gerenciadorDeItemSubValor.Editar(itemSubValor);

                response = Request.CreateResponse(HttpStatusCode.OK, itemSubValor);
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
                var itemSubValor = _gerenciadorDeItemSubValor.BuscarPorId(id);
                _gerenciadorDeItemSubValor.Excluir(itemSubValor);

                response = Request.CreateResponse(HttpStatusCode.OK, itemSubValor);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

    }
}
