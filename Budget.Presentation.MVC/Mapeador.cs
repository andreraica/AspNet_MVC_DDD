using AutoMapper;
using Budget.Domain.Entities;
using Budget.Presentation.MVC.ViewModels;
using System.Linq;

namespace Budget.Presentation.MVC
{
    public static class Mapeador
    {
        static Mapeador()
        {
            Mapper.AddProfile<MvcProfile>();
        }

        public static TDestino Mapear<TOrigem, TDestino>(TOrigem origem)
        {
            return Mapper.Map<TOrigem, TDestino>(origem);
        }

        public class MvcProfile : Profile
        {
            public MvcProfile()
            {
                #region Orcamento

                Mapper.CreateMap<Orcamento, OrcamentoViewModel>();
                Mapper.CreateMap<OrcamentoViewModel, Orcamento>();

                #endregion

                #region ItemValor

                Mapper.CreateMap<ItemValor, ItemValorViewModel>();
                Mapper.CreateMap<ItemValorViewModel, ItemValor>();
                    
                //.ForMember(o => o.SubValores, x => x.Ignore());

                //Mapper.CreateMap<Imagem, ImagemViewModel>()
                //    .ForMember(o => o.Cor, x => x.MapFrom(src => src.Cor))
                //    .ForMember(o => o.Url, x => x.MapFrom(src => src.Url)
                //);

                #endregion

                #region ItemSubValor

                Mapper.CreateMap<ItemSubValor, ItemSubValorViewModel>();
                Mapper.CreateMap<ItemSubValorViewModel, ItemSubValor>();

                #endregion
            }
        }
    }
}
