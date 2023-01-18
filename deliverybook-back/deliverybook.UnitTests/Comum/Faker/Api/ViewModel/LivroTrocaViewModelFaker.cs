using deliverybook.API.ViewModel;
using System;
using System.Collections.Generic;

namespace deliverybook.UnitTests.Comum.Faker.Api.ViewModel
{
    public class LivroTrocaViewModelFaker
    {
        public static List<LivroTrocaViewModel> GerarLivroTrocaListaEstatica()
        {
            return new List<LivroTrocaViewModel>()
            {
                new LivroTrocaViewModel
                    {
                        Id = new Guid("c5559fe9-9680-4f86-8abc-0e965d221d95"),
                        Titulo = "Mindset: A nova psicologia do sucesso",
                        Descricao = "Carol S. Dweck, ph.D., professora de psicologia na Universidade Stanford e especialista internacional em sucesso e motivação, desenvolveu, ao longo de décadas de pesquisa, um conceito fundamental: a atitude mental com que encaramos a vida, que ela chama de “mindset”, é crucial para o sucesso. Dweck revela de forma brilhante como o sucesso pode ser alcançado pela maneira como lidamos com nossos objetivos. O mindset não é um mero traço de personalidade, é a explicação de por que somos otimistas ou pessimistas, bem-sucedidos ou não. Ele define nossa relação com o trabalho e com as pessoas e a maneira como educamos nossos filhos. É um fator decisivo para que todo o nosso potencial seja explorado.",
                        Autores = "Carol S. Dweck",
                        LocalLivros = new List<LocalLivroViewModel>() {
                            new LocalLivroViewModel()
                            {
                                Id = new Guid(),
                                ProdutoId = new Guid("c5559fe9-9680-4f86-8abc-0e965d221d95"),
                                LocalId = new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5")
                            },
                        }
                    },
                new LivroTrocaViewModel
                {
                    Id = new Guid("533468aa-edd3-4aff-ae82-344c97c2d53e"),
                    Titulo = "O poder da ação",
                    Descricao = "Acorde para os objetivos que quer conquistar. Já aconteceu a você de se olhar no espelho e não gostar daqueles quilos a mais? De observar seu momento profissional somente com frustração? De se sentir desconectado dos seus familiares, dos seus amigos? Se você acha que essas são situações normais, pense de novo! Só porque isso acontece com várias pessoas não quer dizer que a vida deva ser assim. Só porque algo se torna comum, não significa que seja normal! Neste livro, Paulo Vieira lhe convida a quebrar o ciclo vicioso e iniciar um caminho de realização. Para isso, ele apresenta o método responsável por impactar 250 mil pessoas ao longo de sua carreira - e que pode ser a chave para o que você tanto procura. No decorrer destas páginas, o autor lhe entrega uma bússola. E para conseguir se guiar por ela você terá de assumir um compromisso com a mudança. Preparado? Aproveite todas as provocações e os desafios propostos nesta obra para conseguir, de fato, fazer o check-up completo sobre si mesmo. Acorde, creia, comunique, tenha foco, AJA! Pare de adiar sua vida e seja quem quer ser a partir de agora. Não existe outra opção. E está em suas mãos reescrever seu futuro.",
                    Autores = "Paulo Vieira",
                    LocalLivros = new List<LocalLivroViewModel>() {
                            new LocalLivroViewModel()
                            {
                                Id = new Guid(),
                                ProdutoId = new Guid("533468aa-edd3-4aff-ae82-344c97c2d53e"),
                                LocalId = new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5")
                            },
                        }
                }
            };
        }
    }
}