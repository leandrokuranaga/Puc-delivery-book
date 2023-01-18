using deliverybook.API.ViewModel;
using System;
using System.Collections.Generic;

namespace deliverybook.UnitTests.Comum.Faker.Api.ViewModel
{
    public static class LocalizacaoViewModelFaker
    {
        public static List<LocalizacaoViewModel> GerarLocaisListaEstatica()
        {
            return new List<LocalizacaoViewModel>
            {
                new LocalizacaoViewModel
                    {
                        Id = new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5"),
                        Descricao = "Saber Compartilhar",
                        Latitude = "-23.6573395",
                        Longitude = "-46.5322504",
                    },
                    new LocalizacaoViewModel
                    {
                        Id = new Guid("2bd335ed-db5f-4de1-aa7a-68e896447751"),
                        Descricao = "Parada Obrigatória",
                        Latitude = "-23.5506507",
                        Longitude = "-46.6333824",
                    },
                    new LocalizacaoViewModel
                    {
                        Id = new Guid("9794c136-0184-499d-b4e5-971d804991a5"),
                        Descricao = "Pegue e Leve",
                        Latitude = "-23.960833",
                        Longitude = "-46.333889",
                    },
                    new LocalizacaoViewModel
                    {
                        Id = new Guid("e51d3d66-2ec8-4bd7-bfc2-520aa241efaf"),
                        Descricao = "Olá Mundo",
                        Latitude = "-23.5007185",
                        Longitude = "-47.4574439",
                    }
            };
        }
    }
}