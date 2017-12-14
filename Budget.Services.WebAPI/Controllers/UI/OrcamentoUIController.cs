using Budget.Domain.Entities.Enum;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http.Cors;

namespace Budget.Services.WebAPI.Controllers.UI
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrcamentoUIController : ApiController
    {
        // GET: Tipo Pessoa List
        [HttpGet]
        public HttpResponseMessage GetTipoPessoa()
        {
            return GetEnumFromString<ETipoPessoa>();
        }

        // GET: Tipo Orçamento List
        [HttpGet]
        public HttpResponseMessage GetTipoOrcamento()
        {
            return GetEnumFromString<ETipoOrcamento>();
        }

        // GET: Tipo Pagamento List
        [HttpGet]
        public HttpResponseMessage GetTipoPagamento()
        {
            return GetEnumFromString<ETipoPagamento>();
        }

        public HttpResponseMessage GetEnumFromString<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T deve ser um enumerador");
            }

            HttpResponseMessage response;
            var enumeradores = new List<EnumeradorJson>();

            try
            {
                foreach (var enumerador in Enum.GetValues(typeof(T)))
                    enumeradores.Add(new EnumeradorJson((int)enumerador, enumerador.ToString()));

                response = Request.CreateResponse(HttpStatusCode.OK, enumeradores);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }
    }

    internal class EnumeradorJson
    {
        public EnumeradorJson(int _value, string _name)
        {
            this.value = _value;
            this.label = _name;
        }

        public int value { get; set; }
        public string label { get; set; }
    }

}