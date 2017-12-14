using System.ComponentModel;

namespace Budget.Presentation.MVC.ViewModel.Enum
{
    public enum ETipoOrcamentoViewModel : int
    {
        [DescriptionAttribute("Receita")]
        Receita = 1,

        [DescriptionAttribute("Despesa")]
        Despesa = 2
    }
}
