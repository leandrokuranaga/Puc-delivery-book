using deliverybook.Domain.Model.Localizacao;
using System;
using System.Collections.Generic;

namespace deliverybook.UnitTests.Comum.Faker.Domain.Model.Localizacao
{
    public static class LocalFaker
    {
        public static List<Local> GerarLocaisListaEstatica()
        {
            return new List<Local>
            {
                new Local
                    {
                        Id = new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5"),
                        Descricao = "Saber Compartilhar",
                        Latitude = "-23.6573395",
                        Longitude = "-46.5322504",
                    },
                    new Local
                    {
                        Id = new Guid("2bd335ed-db5f-4de1-aa7a-68e896447751"),
                        Descricao = "Parada Obrigatória",
                        Latitude = "-23.5506507",
                        Longitude = "-46.6333824",
                    },
                    new Local
                    {
                        Id = new Guid("9794c136-0184-499d-b4e5-971d804991a5"),
                        Descricao = "Pegue e Leve",
                        Latitude = "-23.960833",
                        Longitude = "-46.333889",
                    },
                    new Local
                    {
                        Id = new Guid("e51d3d66-2ec8-4bd7-bfc2-520aa241efaf"),
                        Descricao = "Olá Mundo",
                        Latitude = "-23.5007185",
                        Longitude = "-47.4574439",
                    }
            };
        }

        public static Local GerarLocalBusca()
        {
            return GerarLocaisListaEstatica()[1];
        }

        public static Local GerarLocalAlteracao()
        {
            return GerarLocaisListaEstatica()[2];
        }

        public static Local GerarLocalExclusao()
        {
            return GerarLocaisListaEstatica()[3];
        }

        public static Local GerarLocalEstatico()
        {
            return new Local
            {
                Id = new Guid("0ad74c33-23b7-4b26-aa74-1131f1ae5b01"),
                Descricao = "Encontro certo",
                Latitude = "-21.4774",
                Longitude = "-48.4318"
            };
        }

    }
}