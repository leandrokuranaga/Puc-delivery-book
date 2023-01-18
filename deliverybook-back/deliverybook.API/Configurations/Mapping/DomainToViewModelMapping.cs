using AutoMapper;
using deliverybook.API.ViewModel;
using deliverybook.Domain.Model;
using deliverybook.Domain.Model.Aluguel;
using deliverybook.Domain.Model.ItBook;
using deliverybook.Domain.Model.Localizacao;
using deliverybook.Domain.Model.Spotify;

namespace deliverybook.API.Configurations.Mapping
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Detalhes, DetalhesViewModel>().ReverseMap();
            CreateMap<Livro, LivroViewModel>().ReverseMap();
            CreateMap<Paginacao, PaginacaoViewModel>().ReverseMap();

            CreateMap<Audios, AudiosViewModel>().ReverseMap();
            CreateMap<Podcasts, PodcastsViewModel>().ReverseMap();
            CreateMap<Imagem, ImagemViewModel>().ReverseMap();
            CreateMap<Pagination, PaginationViewModel>().ReverseMap();

            CreateMap<LivroTrocaViewModel, Produto>()
                .ForMember(dest => dest.LocalProdutos, opt => opt.MapFrom(src => src.LocalLivros))
                .ReverseMap();

            CreateMap<LocalLivroViewModel, LocalProduto>().ReverseMap();

            CreateMap<LocalizacaoViewModel, Local>()
                .ForMember(dest => dest.LocalProdutos, opt => opt.MapFrom(src => src.LocalLivros))
                .ReverseMap();

            CreateMap<AluguelViewModel, Aluguel>().ReverseMap();
            CreateMap<ReservaViewModel, Reserva>().ReverseMap();
           
        }
    }
}