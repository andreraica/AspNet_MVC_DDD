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
    public class OrcamentoController : ApiController
    {
        private readonly IGerenciadorDeOrcamento _gerenciadorDeOrcamento;

        public OrcamentoController(IGerenciadorDeOrcamento gerenciadorDeOrcamento)
        {
            _gerenciadorDeOrcamento = gerenciadorDeOrcamento;
        }

        // GET: List
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var orcamentos = _gerenciadorDeOrcamento.Listar();

                response = Request.CreateResponse(HttpStatusCode.OK, orcamentos);
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
                var orcamento = _gerenciadorDeOrcamento.BuscarPorId(id);

                response = Request.CreateResponse(HttpStatusCode.OK, orcamento);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // POST: Create
        public HttpResponseMessage Post(Orcamento orcamento)
        {
            HttpResponseMessage response;
            try
            {
                _gerenciadorDeOrcamento.Salvar(orcamento);

                response = Request.CreateResponse(HttpStatusCode.OK, orcamento);
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // POST: Edit
        public HttpResponseMessage Put(Orcamento orcamento)
        {
            HttpResponseMessage response;
            try
            {
                _gerenciadorDeOrcamento.Editar(orcamento);

                response = Request.CreateResponse(HttpStatusCode.OK, orcamento);
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
                var orcamento = _gerenciadorDeOrcamento.BuscarPorId(id);
                _gerenciadorDeOrcamento.Excluir(orcamento);

                response = Request.CreateResponse(HttpStatusCode.OK, orcamento);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            
            return response;
        }

    }
}