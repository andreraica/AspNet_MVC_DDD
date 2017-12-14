using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Budget.Presentation.MVC.ViewModels
{
    public class ItemValorViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Vencimento { get; set; }

        public OrcamentoViewModel Orcamento { get; set; }

        public List<ItemSubValorViewModel> SubValores { get; set; }
    }
}

