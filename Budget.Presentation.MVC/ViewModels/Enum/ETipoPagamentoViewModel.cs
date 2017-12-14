using System.ComponentModel;

namespace Budget.Presentation.MVC.ViewModel.Enum
{
    public enum ETipoPagamentoViewModel : int
    {
        [DescriptionAttribute("Saque")]
        Saque = 1,

        [DescriptionAttribute("Boleto")]
        Boleto = 2,

        [DescriptionAttribute("Debito Automático")]
        DebitoAutomatico = 3,

        [DescriptionAttribute("Cheque")]
        Cheque = 4,

        [DescriptionAttribute("Depósito")]
        Deposito = 5
    }
}
