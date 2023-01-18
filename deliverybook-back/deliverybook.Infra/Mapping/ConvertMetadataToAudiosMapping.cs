using AutoMapper;
using deliverybook.Domain.Model;
using deliverybook.Domain.Model.Spotify;
using deliverybook.Infra.Entities.Spotify;
using System.Collections.Generic;

namespace deliverybook.Infra.Mapping
{
    public class ConvertMetadataToAudiosMapping : ITypeConverter<Metadata, Audios>
    {
        public Audios Convert(Metadata source, Audios destination, ResolutionContext context)
        {
            source.Shows.CurrentCalcule();

            return new Audios()
            {
                Requisicao = source.Shows.Href,
                Itens = context.Mapper.Map<IEnumerable<Podcasts>>(source.Shows.Items),
                Paginacao = context.Mapper.Map<Pagination>(source.Shows)
            };
        }
    }
}