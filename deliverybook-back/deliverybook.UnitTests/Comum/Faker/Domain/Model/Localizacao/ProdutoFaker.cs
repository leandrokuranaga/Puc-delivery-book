using deliverybook.Domain.Model.Localizacao;
using System;
using System.Collections.Generic;

namespace deliverybook.UnitTests.Comum.Faker.Domain.Model.Localizacao
{
    public static class ProdutoFaker
    {
        public static List<Produto> GerarProdutosListaEstatica()
        {
            return new List<Produto>()
            {
                new Produto
                    {
                        Id = new Guid("c5559fe9-9680-4f86-8abc-0e965d221d95"),
                        Titulo = "Mindset: A nova psicologia do sucesso",
                        Descricao = "Carol S. Dweck, ph.D., professora de psicologia na Universidade Stanford e especialista internacional em sucesso e motivação, desenvolveu, ao longo de décadas de pesquisa, um conceito fundamental: a atitude mental com que encaramos a vida, que ela chama de “mindset”, é crucial para o sucesso. Dweck revela de forma brilhante como o sucesso pode ser alcançado pela maneira como lidamos com nossos objetivos. O mindset não é um mero traço de personalidade, é a explicação de por que somos otimistas ou pessimistas, bem-sucedidos ou não. Ele define nossa relação com o trabalho e com as pessoas e a maneira como educamos nossos filhos. É um fator decisivo para que todo o nosso potencial seja explorado.",
                        Autores = "Carol S. Dweck",
                        LocalProdutos = new List<LocalProduto>() {
                            new LocalProduto()
                            {
                                Id = new Guid(),
                                ProdutoId = new Guid("c5559fe9-9680-4f86-8abc-0e965d221d95"),
                                LocalId = new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5")
                            },
                        }
                    },
                new Produto
                {
                    Id = new Guid("533468aa-edd3-4aff-ae82-344c97c2d53e"),
                    Titulo = "O poder da ação",
                    Descricao = "Acorde para os objetivos que quer conquistar. Já aconteceu a você de se olhar no espelho e não gostar daqueles quilos a mais? De observar seu momento profissional somente com frustração? De se sentir desconectado dos seus familiares, dos seus amigos? Se você acha que essas são situações normais, pense de novo! Só porque isso acontece com várias pessoas não quer dizer que a vida deva ser assim. Só porque algo se torna comum, não significa que seja normal! Neste livro, Paulo Vieira lhe convida a quebrar o ciclo vicioso e iniciar um caminho de realização. Para isso, ele apresenta o método responsável por impactar 250 mil pessoas ao longo de sua carreira - e que pode ser a chave para o que você tanto procura. No decorrer destas páginas, o autor lhe entrega uma bússola. E para conseguir se guiar por ela você terá de assumir um compromisso com a mudança. Preparado? Aproveite todas as provocações e os desafios propostos nesta obra para conseguir, de fato, fazer o check-up completo sobre si mesmo. Acorde, creia, comunique, tenha foco, AJA! Pare de adiar sua vida e seja quem quer ser a partir de agora. Não existe outra opção. E está em suas mãos reescrever seu futuro.",
                    Autores = "Paulo Vieira",
                    LocalProdutos = new List<LocalProduto>() {
                            new LocalProduto()
                            {
                                Id = new Guid(),
                                ProdutoId = new Guid("533468aa-edd3-4aff-ae82-344c97c2d53e"),
                                LocalId = new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5")
                            },
                        }
                }
            };
        }

        public static Produto GerarProdutoEstatico()
        {
            return new Produto
            {
                Id = new Guid("e4480af6-bfce-41ce-b225-b6f47e74077c"),
                Titulo = "Refatoração: Aperfeiçoando o design de códigos existentes",
                Descricao = @"Por mais de vinte anos, programadores experientes no mundo inteiro contaram com o livro Refatoração de Martin Fowler para aperfeiçoar o design de códigos existentes e melhorar a manutenibilidade do software, assim como para deixar o código existente mais fácil de entender.
                    Essa nova edição ansiosamente esperada foi atualizada por completo para refletir mudanças vitais no domínio da programação.Refatoraçã 2ª edição contém um catálogo atualizado das refatorações e inclui exemplos de código JavaScript bem como novos exemplos funcionais que demonstram a refatoração sem classes.
                    Assim como na edição original,
                este livro explica o que é refatoração,
                por que você deve refatorar,
                como reorganizar um código que precise de refatoração e como fazer isso de forma bem - sucedida,
                independentemente da linguagem usada.",
                Autores = "Martin Fowler",
                LocalProdutos = new List<LocalProduto>() {
                            new LocalProduto()
                            {
                                Id = new Guid(),
                                ProdutoId = new Guid("e4480af6-bfce-41ce-b225-b6f47e74077c"),
                                LocalId = new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5")
                            },
                        }
            };
        }

        public static Produto GerarProdutoBusca()
        {
            return new Produto
            {
                Id = new Guid("c5559fe9-9680-4f86-8abc-0e965d221d95"),
                Titulo = "Mindset: A nova psicologia do sucesso",
                Descricao = "Carol S. Dweck, ph.D., professora de psicologia na Universidade Stanford e especialista internacional em sucesso e motivação, desenvolveu, ao longo de décadas de pesquisa, um conceito fundamental: a atitude mental com que encaramos a vida, que ela chama de “mindset”, é crucial para o sucesso. Dweck revela de forma brilhante como o sucesso pode ser alcançado pela maneira como lidamos com nossos objetivos. O mindset não é um mero traço de personalidade, é a explicação de por que somos otimistas ou pessimistas, bem-sucedidos ou não. Ele define nossa relação com o trabalho e com as pessoas e a maneira como educamos nossos filhos. É um fator decisivo para que todo o nosso potencial seja explorado.",
                Autores = "Carol S. Dweck"
            };
        }

        public static Produto GerarProdutoExclusao()
        {
            return new Produto
            {
                Id = new Guid("533468aa-edd3-4aff-ae82-344c97c2d53e"),
                Titulo = "O poder da ação",
                Descricao = "Acorde para os objetivos que quer conquistar. Já aconteceu a você de se olhar no espelho e não gostar daqueles quilos a mais? De observar seu momento profissional somente com frustração? De se sentir desconectado dos seus familiares, dos seus amigos? Se você acha que essas são situações normais, pense de novo! Só porque isso acontece com várias pessoas não quer dizer que a vida deva ser assim. Só porque algo se torna comum, não significa que seja normal! Neste livro, Paulo Vieira lhe convida a quebrar o ciclo vicioso e iniciar um caminho de realização. Para isso, ele apresenta o método responsável por impactar 250 mil pessoas ao longo de sua carreira - e que pode ser a chave para o que você tanto procura. No decorrer destas páginas, o autor lhe entrega uma bússola. E para conseguir se guiar por ela você terá de assumir um compromisso com a mudança. Preparado? Aproveite todas as provocações e os desafios propostos nesta obra para conseguir, de fato, fazer o check-up completo sobre si mesmo. Acorde, creia, comunique, tenha foco, AJA! Pare de adiar sua vida e seja quem quer ser a partir de agora. Não existe outra opção. E está em suas mãos reescrever seu futuro.",
                Autores = "Paulo Vieira",
            };
        }

        public static Produto GerarProdutoBuscaPorLocalId()
        {
            return new Produto
            {
                Id = new Guid("1fa248ce-2c9e-4de5-9327-b340b7c1325b"),
                Titulo = "HOOKED (ENGAJADO): Como construir produtos e serviços formadores de hábitos",
                Descricao = $"Por que alguns produtos capturam totalmente a atenção do usuário, enquanto outros fracassam? O que nos faz interagir com certos produtos por puro hábito? Existe um padrão subjacente de como as tecnologias nos atrapalham? Nir Eyal responde a essas perguntas (e a muitas outras) explicando o Modelo Hooked (Modelo Gancho) - um processo de quatro etapas incorporado aos produtos de muitas empresas de sucesso para estimular sutilmente o comportamento do cliente. Com base na profundidade da psicologia e da ciência do comportamento humano explicando em quatro passos (Gatilho, Ação, Investimento e Recompensa) como hábitos podem ser formados. Por meio de \"Ciclos de Gancho\" consecutivos, esses produtos atingem o objetivo final de levar os usuários de volta e de novo, sem depender de publicidade dispendiosa ou de mensagens agressivas. Hooked é baseado nos anos de pesquisa, consultoria e experiência prática de Eyal. Ele escreveu o livro que desejava que estivesse disponível para ele como fundador de startups - não uma teoria abstrata, mas um guia prático para criar produtos melhores.",
                Autores = "NIR EYAL",
                LocalProdutos = new List<LocalProduto>() {
                                new LocalProduto()
                                {
                                    Id = new Guid(),
                                    ProdutoId = new Guid("1fa248ce-2c9e-4de5-9327-b340b7c1325b"),
                                    LocalId = new Guid("9794c136-0184-499d-b4e5-971d804991a5"),
                                Disponivel = true
                                },
                            }
            };
        }

        public static Produto GerarProdutoIndisponivel()
        {
            return new Produto
            {
                Id = new Guid("c5559fe9-9680-4f86-8abc-0e965d221d95"),
                Titulo = "Mindset: A nova psicologia do sucesso",
                Descricao = "Carol S. Dweck, ph.D., professora de psicologia na Universidade Stanford e especialista internacional em sucesso e motivação, desenvolveu, ao longo de décadas de pesquisa, um conceito fundamental: a atitude mental com que encaramos a vida, que ela chama de “mindset”, é crucial para o sucesso. Dweck revela de forma brilhante como o sucesso pode ser alcançado pela maneira como lidamos com nossos objetivos. O mindset não é um mero traço de personalidade, é a explicação de por que somos otimistas ou pessimistas, bem-sucedidos ou não. Ele define nossa relação com o trabalho e com as pessoas e a maneira como educamos nossos filhos. É um fator decisivo para que todo o nosso potencial seja explorado.",
                Autores = "Carol S. Dweck",
                LocalProdutos = new List<LocalProduto>() {
                            new LocalProduto()
                            {
                                Id = new Guid(),
                                ProdutoId = new Guid("c5559fe9-9680-4f86-8abc-0e965d221d95"),
                                LocalId = new Guid("b90f84a6-bdb4-4815-9ea2-a55a97a94be5"),
                                Disponivel = false
                            },
                        }
            };
        }
    }
}