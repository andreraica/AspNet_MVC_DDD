
using System.ComponentModel.DataAnnotations;
namespace Budget.Presentation.MVC.ViewModels
{
    public class ItemSubValorViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public ItemValorViewModel ItemValor { get; set; }
    }
}

