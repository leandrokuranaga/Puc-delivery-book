using deliverybook.Domain.Model.Localizacao;
using deliverybook.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace deliverybook.API.Configurations
{
    public static class InitializeDatabase
    {
        public static void DataGenerator(DbContextOptionsBuilder builder)
        {
            DbContextOptions<LocalizacaoContext> teste = (DbContextOptions<LocalizacaoContext>)builder.Options;
            using (var context = new LocalizacaoContext(teste))
            {
                if (context.Locais.Any())
                {
                    return;   
                }

                context.Locais.AddRange(
                    new Local
                    {
                        Id = Guid.Parse("b90f84a6-bdb4-4815-9ea2-a55a97a94be5"),
                        Descricao = "Saber Compartilhar",
                        Latitude = "-23.6573395",
                        Longitude = "-46.5322504",
                    },
                    new Local
                    {
                        Id = Guid.Parse("2bd335ed-db5f-4de1-aa7a-68e896447751"),
                        Descricao = "Parada Obrigatória",
                        Latitude = "-23.5506507",
                        Longitude = "-46.6333824",
                    },
                    new Local
                    {
                        Id = Guid.Parse("9794c136-0184-499d-b4e5-971d804991a5"),
                        Descricao = "Pegue e Leve",
                        Latitude = "-23.960833",
                        Longitude = "-46.333889",
                    },
                    new Local
                    {
                        Id = Guid.Parse("e51d3d66-2ec8-4bd7-bfc2-520aa241efaf"),
                        Descricao = "Olá Mundo",
                        Latitude = "-23.5007185",
                        Longitude = "-47.4574439",
                    });

                context.SaveChanges();

                //var locais = context.Locais.G

                context.Produtos.AddRange(
                    new Produto
                    {
                        Id = Guid.Parse("c5559fe9-9680-4f86-8abc-0e965d221d95"),
                        Titulo = "Mindset: A nova psicologia do sucesso",
                        Descricao = "Carol S. Dweck, ph.D., professora de psicologia na Universidade Stanford e especialista internacional em sucesso e motivação, desenvolveu, ao longo de décadas de pesquisa, um conceito fundamental: a atitude mental com que encaramos a vida, que ela chama de “mindset”, é crucial para o sucesso. Dweck revela de forma brilhante como o sucesso pode ser alcançado pela maneira como lidamos com nossos objetivos. O mindset não é um mero traço de personalidade, é a explicação de por que somos otimistas ou pessimistas, bem-sucedidos ou não. Ele define nossa relação com o trabalho e com as pessoas e a maneira como educamos nossos filhos. É um fator decisivo para que todo o nosso potencial seja explorado.",
                        Autores = "Carol S. Dweck",
                        LocalProdutos = new List<LocalProduto>() {
                            new LocalProduto()
                            {
                                Id = Guid.NewGuid(),
                                ProdutoId = Guid.Parse("c5559fe9-9680-4f86-8abc-0e965d221d95"),
                                LocalId = Guid.Parse("b90f84a6-bdb4-4815-9ea2-a55a97a94be5"),
                                Disponivel = true
                            },
                        }
                    },
                    new Produto
                    {
                        Id = Guid.Parse("533468aa-edd3-4aff-ae82-344c97c2d53e"),
                        Titulo = "O poder da ação",
                        Descricao = "Acorde para os objetivos que quer conquistar. Já aconteceu a você de se olhar no espelho e não gostar daqueles quilos a mais? De observar seu momento profissional somente com frustração? De se sentir desconectado dos seus familiares, dos seus amigos? Se você acha que essas são situações normais, pense de novo! Só porque isso acontece com várias pessoas não quer dizer que a vida deva ser assim. Só porque algo se torna comum, não significa que seja normal! Neste livro, Paulo Vieira lhe convida a quebrar o ciclo vicioso e iniciar um caminho de realização. Para isso, ele apresenta o método responsável por impactar 250 mil pessoas ao longo de sua carreira - e que pode ser a chave para o que você tanto procura. No decorrer destas páginas, o autor lhe entrega uma bússola. E para conseguir se guiar por ela você terá de assumir um compromisso com a mudança. Preparado? Aproveite todas as provocações e os desafios propostos nesta obra para conseguir, de fato, fazer o check-up completo sobre si mesmo. Acorde, creia, comunique, tenha foco, AJA! Pare de adiar sua vida e seja quem quer ser a partir de agora. Não existe outra opção. E está em suas mãos reescrever seu futuro.",
                        Autores = "Paulo Vieira",
                        LocalProdutos = new List<LocalProduto>() {
                                new LocalProduto()
                                {
                                    Id = Guid.NewGuid(),
                                    ProdutoId = Guid.Parse("533468aa-edd3-4aff-ae82-344c97c2d53e"),
                                    LocalId = Guid.Parse("b90f84a6-bdb4-4815-9ea2-a55a97a94be5"),
                                Disponivel = true
                                },
                            }
                    },
                    new Produto
                    {
                        Id = Guid.Parse("1fa248ce-2c9e-4de5-9327-b340b7c1325b"),
                        Titulo = "HOOKED (ENGAJADO): Como construir produtos e serviços formadores de hábitos",
                        Descricao = $"Por que alguns produtos capturam totalmente a atenção do usuário, enquanto outros fracassam? O que nos faz interagir com certos produtos por puro hábito? Existe um padrão subjacente de como as tecnologias nos atrapalham? Nir Eyal responde a essas perguntas (e a muitas outras) explicando o Modelo Hooked (Modelo Gancho) - um processo de quatro etapas incorporado aos produtos de muitas empresas de sucesso para estimular sutilmente o comportamento do cliente. Com base na profundidade da psicologia e da ciência do comportamento humano explicando em quatro passos (Gatilho, Ação, Investimento e Recompensa) como hábitos podem ser formados. Por meio de \"Ciclos de Gancho\" consecutivos, esses produtos atingem o objetivo final de levar os usuários de volta e de novo, sem depender de publicidade dispendiosa ou de mensagens agressivas. Hooked é baseado nos anos de pesquisa, consultoria e experiência prática de Eyal. Ele escreveu o livro que desejava que estivesse disponível para ele como fundador de startups - não uma teoria abstrata, mas um guia prático para criar produtos melhores.",
                        Autores = "NIR EYAL",
                        LocalProdutos = new List<LocalProduto>() {
                                new LocalProduto()
                                {
                                    Id = Guid.NewGuid(),
                                    ProdutoId = Guid.Parse("1fa248ce-2c9e-4de5-9327-b340b7c1325b"),
                                    LocalId = Guid.Parse("9794c136-0184-499d-b4e5-971d804991a5"),
                                Disponivel = true
                                },
                            }
                    },
                    new Produto
                    {
                        Id = Guid.Parse("f2fca8fa-6a33-4627-ac96-0dd886de34ce"),
                        Titulo = "Ágil do Jeito Certo: Transformação sem caos",
                        Descricao = $"Muito se fala sobre os métodos ágeis hoje em dia e como eles têm o poder de transformar ¿ para melhor ¿ o modo como trabalhamos, trazendo inovação e avanços com mais rapidez e menor custo. Isso tudo é verdade. O problema é que, por ter se tornado uma palavra da moda, o ágil muitas vezes é aplicado de forma equivocada e repentina nas empresas, e o resultado é um grande caos: clientes nervosos, funcionários insatisfeitos e líderes colocados em xeque. Em Ágil do jeito certo, três experientes e renomados consultores da Bain & Company explicam de forma clara as principais dificuldades dos gestores na hora de adotar o ágil e todas as armadilhas que eles podem vir a enfrentar. Utilizando exemplos de grandes empresas como Bosch, Amazon, Spotify e Dell, os autores vão ajudá-lo a iniciar sua jornada ágil evitando inúmeros erros já conhecidos ¿ e vislumbrar um futuro de resultados cada vez melhores.",
                        Autores = " Darrell Rigby, Sarah Elk, Steve Berez",
                        LocalProdutos = new List<LocalProduto>() {
                                new LocalProduto()
                                {
                                    Id = Guid.NewGuid(),
                                    ProdutoId = Guid.Parse("f2fca8fa-6a33-4627-ac96-0dd886de34ce"),
                                    LocalId = Guid.Parse("9794c136-0184-499d-b4e5-971d804991a5"),
                                Disponivel = true
                                },
                            }
                    },
                    new Produto
                    {
                        Id = Guid.Parse("7504010a-9445-400f-b207-5207d0c94eff"),
                        Titulo = "A Regra é Não Ter Regras: A Netflix e a Cultura da Reinvenção",
                        Descricao = @"Nunca houve uma empresa como a Netflix. De um serviço de locação de DVDs por correio a uma superpotência de streaming, em vinte anos a companhia se tornou um dos principais nomes das indústrias de entretenimento do mundo. Com mais de 180 milhões de assinantes em 190 países e uma receita anual de bilhões de dólares, a Netflix causou uma verdadeira revolução com sua filosofia corporativa nada convencional. Cofundador, presidente e CEO da empresa, Reed Hastings se une à especialista no mundo dos negócios Erin Meyer para falar pela primeira vez sobre a cultura que transformou a marca em um exemplo inigualável de criatividade e adaptação.

                        A partir de centenas de entrevistas com funcionários da Netflix e relatos nunca antes compartilhados,
                        Hastings explica como seus princípios controversos fizeram da Netflix um exemplo de inovação e sucesso global.Uma obra fascinante sobre uma empresa que desafiou tradições e expectativas e dominou as premiações do cinema e da TV, além do imaginário de milhões de pessoas, uma tela por vez.",
                        Autores = " Reed Hastings, Erin Meyer, Alexandre Raposo",
                        LocalProdutos = new List<LocalProduto>() {
                                new LocalProduto()
                                {
                                    Id = Guid.NewGuid(),
                                    ProdutoId = Guid.Parse("7504010a-9445-400f-b207-5207d0c94eff"),
                                    LocalId = Guid.Parse("e51d3d66-2ec8-4bd7-bfc2-520aa241efaf"),
                                Disponivel = true
                                },
                            }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}