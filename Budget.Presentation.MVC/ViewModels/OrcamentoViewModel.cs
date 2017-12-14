using Budget.Presentation.MVC.ViewModel.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Budget.Presentation.MVC.ViewModels
{
    public class OrcamentoViewModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Descricao { get; set; }

        [Required]
        public ETipoPessoaViewModel TipoPessoa { get; set; }

        [Required]
        public ETipoOrcamentoViewModel TipoOrcamento { get; set; }

        [Required]
        public ETipoPagamentoViewModel TipoPagamento { get; set; }
        
        /// Indica se a conta não é em parcelas e sim sempre, exemplo: convenio medico
        [Required]
        public bool Fixa { get; set; }

        /// <summary>
        /// Somente válido para receita
        /// </summary>
        public decimal? TaxaPorcentagem { get; set; }
        
        public IEnumerable<ItemValorViewModel> Valores { get; set; }

        
    }
}
