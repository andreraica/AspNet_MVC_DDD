using System.ComponentModel;

namespace Budget.Presentation.MVC.ViewModel.Enum
{
    public enum ETipoPessoaViewModel: int
    {
        [DescriptionAttribute("Pessoa Física")]
        PessoaFisica = 1,

        [DescriptionAttribute("Pessoa Jurídica")]
        PessoaJuridica = 2
    }
}
