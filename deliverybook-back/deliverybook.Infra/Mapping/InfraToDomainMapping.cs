using AutoMapper;
using deliverybook.Domain.Model;
using deliverybook.Domain.Model.ItBook;
using deliverybook.Domain.Model.Spotify;
using deliverybook.Infra.Entities.ItBook;
using deliverybook.Infra.Entities.Spotify;
using System.Collections.Generic;

namespace deliverybook.Infra.Mapping
{
    public class InfraToDomainMapping : Profile
    {
        public InfraToDomainMapping()
        {
            CreateMap<DetailsDAO, Detalhes>()
                .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => int.Parse(src.Year)))
                .ForMember(dest => dest.Avaliacao, opt => opt.MapFrom(src => int.Parse(src.Rating)))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Desc))
                .ForMember(dest => dest.Erro, opt => opt.MapFrom(src => src.Error))
                .ForMember(dest => dest.Isbn10, opt => opt.MapFrom(src => src.Isbn10))
                .ForMember(dest => dest.Paginas, opt => opt.MapFrom(src => int.Parse(src.Pages)))
                .ForMember(dest => dest.Isbn13, opt => opt.MapFrom(src => src.Isbn13))
                .ForMember(dest => dest.SubTitulo, opt => opt.MapFrom(src => src.Subtitle))
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.Autores, opt => opt.MapFrom(src => src.Authors))
                .ForMember(dest => dest.Editora, opt => opt.MapFrom(src => src.Publisher))
                .ForMember(dest => dest.Lingua, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.UrlImagem, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Capitulos, opt => opt.MapFrom(src => src.Pdf))
                .ForMember(dest => dest.Cap, opt => opt.MapFrom(src => src.Pdf.Values))
                .ReverseMap();

            CreateMap<BookDAO, Livro>()
                 .ForMember(dest => dest.Isbn13, opt => opt.MapFrom(src => src.Isbn13))
                 .ForMember(dest => dest.SubTitulo, opt => opt.MapFrom(src => src.Subtitle))
                 .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Title))
                 .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                 .ForMember(dest => dest.UrlImagem, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Price))
                 .ReverseMap();

            CreateMap<PageDAO, Paginacao>()
                .ForMember(dest => dest.Erro, opt => opt.MapFrom(src => src.Error))
                .ForMember(dest => dest.Pagina, opt => opt.MapFrom(src => int.Parse(src.Page)))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => int.Parse(src.Total)))
                .ForPath(dest => dest.Livros, opt => opt.MapFrom(src => src.Books))
                .ReverseMap();

            CreateMap<Metadata, Audios>()
              .ConvertUsing(new ConvertMetadataToAudiosMapping());

            CreateMap<Items, Podcasts>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Media_type))
               .ForMember(dest => dest.Autores, opt => opt.MapFrom(src => src.Publisher))
               .ForMember(dest => dest.TotalEpisodios, opt => opt.MapFrom(src => src.Total_episodes))
               .ForMember(dest => dest.Imagem, opt => opt.MapFrom(src => src.Images))
               .ForPath(dest => dest.LinkExterno, opt => opt.MapFrom(src => src.External_urls.Spotify))
               .ReverseMap();

            CreateMap<Shows, Pagination>()
                .ForMember(dest => dest.Anterior, opt => opt.MapFrom(src => src.Previous))
                .ForMember(dest => dest.Limite, opt => opt.MapFrom(src => src.Limit))
                .ForMember(dest => dest.Offset, opt => opt.MapFrom(src => src.Offset))
                .ForMember(dest => dest.Atual, opt => opt.MapFrom(src => src.Current))
                .ForMember(dest => dest.Proximo, opt => opt.MapFrom(src => src.Next))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                .ReverseMap();

            CreateMap<List<Images>, Imagem>()
               .ConvertUsing(new ConvertImagesToImagemMapping());
        }
    }
}