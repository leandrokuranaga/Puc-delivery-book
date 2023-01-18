using AutoMapper;
using deliverybook.Domain.Model.Spotify;
using deliverybook.Infra.Entities.Spotify;
using System.Collections.Generic;
using System.Linq;

namespace deliverybook.Infra.Mapping
{
    public class ConvertImagesToImagemMapping : ITypeConverter<List<Images>, Imagem>
    {
        public Imagem Convert(List<Images> source, Imagem destination, ResolutionContext context)
        {
            if (source == null)
                return null;

            var imagem = source.OrderByDescending(x => x.Height).FirstOrDefault();
            return new Imagem()
            {
                Altura = imagem.Height,
                Largura = imagem.Width,
                Link = imagem.Url
            };
        }
    }
}