using Bogus;
using deliverybook.Domain.Model.ItBook;
using System.Collections.Generic;

namespace deliverybook.UnitTests.Comum.Faker.Domain.Model.ItBook
{
    public static class LivroFaker
    {
        public static Faker<Livro> GerarLivroEstatico { get; } =
            new Faker<Livro>()
                .RuleFor(p => p.Titulo, f => "The Definitive Guide to MongoDB, 3rd Edition")
                .RuleFor(p => p.SubTitulo, f => "A complete guide to dealing with Big Data using MongoDB")
                .RuleFor(p => p.Isbn13, f => "9781484211830")
                .RuleFor(p => p.Valor, f => "$0.00")
                .RuleFor(p => p.UrlImagem, f => "https://itbook.store/img/books/9781484211830.png")
                .RuleFor(p => p.Url, f => "https://itbook.store/books/9781484211830");

        public static List<Livro> GerarLivroListaEstatica()
        {
            return new List<Livro>()
            {
                    new Livro() {
                        Titulo ="The Vue.js Handbook",
                        SubTitulo ="",
                        Isbn13 ="1001615902053",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001615902053.png",
                        Url ="https://itbook.store/books/1001615902053"
                    },
                    new Livro() {
                        Titulo ="The Node.js Handbook",
                        SubTitulo ="",
                        Isbn13 ="1001614599609",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001614599609.png",
                        Url ="https://itbook.store/books/1001614599609"
                    },
                    new Livro() {
                        Titulo ="Azure Tips and Tricks",
                        SubTitulo ="",
                        Isbn13 ="9781732704121",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/9781732704121.png",
                        Url ="https://itbook.store/books/9781732704121"
                    },
                    new Livro() {
                        Titulo ="Learn Programming",
                        SubTitulo ="Your Guided Tour Through the Programming Jungle",
                        Isbn13 ="9781722834920",
                        Valor ="$16.83",
                        UrlImagem ="https://itbook.store/img/books/9781722834920.png",
                        Url ="https://itbook.store/books/9781722834920"
                    },
                    new Livro() {
                        Titulo ="Graph Databases For Beginners",
                        SubTitulo ="The #1 Platform for Connected Data",
                        Isbn13 ="1001606307637",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001606307637.png",
                        Url ="https://itbook.store/books/1001606307637"
                    },
                    new Livro() {
                        Titulo ="Elementary Algorithms",
                        SubTitulo ="",
                        Isbn13 ="1001606307729",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001606307729.png",
                        Url ="https://itbook.store/books/1001606307729"
                    },
                    new Livro() {
                        Titulo ="Windows PowerShell Networking Guide",
                        SubTitulo ="",
                        Isbn13 ="1001606307964",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001606307964.png",
                        Url ="https://itbook.store/books/1001606307964"
                    },
                    new Livro() {
                        Titulo ="Operating Systems: From 0 to 1",
                        SubTitulo ="",
                        Isbn13 ="1001606140658",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001606140658.png",
                        Url ="https://itbook.store/books/1001606140658"
                    },
                    new Livro() {
                        Titulo ="Java Web Scraping Handbook",
                        SubTitulo ="Learn advanced Web Scraping techniques",
                        Isbn13 ="1001606140805",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001606140805.png",
                        Url ="https://itbook.store/books/1001606140805"
                    },
                    new Livro() {
                        Titulo ="Coffee Break Python Slicing",
                        SubTitulo ="24 Workouts to Master Slicing in Python, Once and for All",
                        Isbn13 ="1001605784161",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001605784161.png",
                        Url ="https://itbook.store/books/1001605784161"
                    },
                    new Livro() {
                        Titulo ="The Basics of User Experience Design",
                        SubTitulo ="",
                        Isbn13 ="1001601301730",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001601301730.png",
                        Url ="https://itbook.store/books/1001601301730"
                    },
                    new Livro() {
                        Titulo ="3D Game Development with LWJGL 3",
                        SubTitulo ="Learn the main concepts involved in writing 3D games using the Lighweight Java Gaming Library",
                        Isbn13 ="1001601302020",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001601302020.png",
                        Url ="https://itbook.store/books/1001601302020"
                    },
                    new Livro() {
                        Titulo ="DevOps: WTF?",
                        SubTitulo ="",
                        Isbn13 ="1001592565453",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001592565453.png",
                        Url ="https://itbook.store/books/1001592565453"
                    },
                    new Livro() {
                        Titulo ="Full Speed Python",
                        SubTitulo ="",
                        Isbn13 ="1001592395975",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001592395975.png",
                        Url ="https://itbook.store/books/1001592395975"
                    },
                    new Livro() {
                        Titulo ="How To Code in Python 3",
                        SubTitulo ="",
                        Isbn13 ="9780999773017",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/9780999773017.png",
                        Url ="https://itbook.store/books/9780999773017"
                    },
                    new Livro() {
                        Titulo ="Operating System Concepts, 10th Edition",
                        SubTitulo ="",
                        Isbn13 ="9781119456339",
                        Valor ="$90.08",
                        UrlImagem ="https://itbook.store/img/books/9781119456339.png",
                        Url ="https://itbook.store/books/9781119456339"
                    },
                    new Livro() {
                        Titulo ="Neural Networks and Deep Learning",
                        SubTitulo ="A Textbook",
                        Isbn13 ="9783319944623",
                        Valor ="$33.99",
                        UrlImagem ="https://itbook.store/img/books/9783319944623.png",
                        Url ="https://itbook.store/books/9783319944623"
                    },
                    new Livro() {
                        Titulo ="Fundamentals of C++ Programming",
                        SubTitulo ="",
                        Isbn13 ="1001590483252",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001590483252.png",
                        Url ="https://itbook.store/books/1001590483252"
                    },
                    new Livro() {
                        Titulo ="Fundamentals of Python Programming",
                        SubTitulo ="",
                        Isbn13 ="1001590485785",
                        Valor ="$0.00",
                        UrlImagem ="https://itbook.store/img/books/1001590485785.png",
                        Url ="https://itbook.store/books/1001590485785"
                    },
                    new Livro() {
                        Titulo ="Machine Learning Yearning",
                        SubTitulo ="Technical Strategy for AI Engineers, In the Era of Deep Learning",
                        Isbn13 ="1001590486081",
                        Valor ="$0.00",
                    UrlImagem ="https://itbook.store/img/books/1001590486081.png",
                    Url ="https://itbook.store/books/1001590486081"
                }
            };
        }

        public static List<Livro> GerarLivroListaSearchEstaticaP1()
        {
            return new List<Livro>()
            {
                new Livro() {
                    Titulo= "The Linux Commands Handbook",
                    SubTitulo= "",
                    Isbn13= "1001614175565",
                    Valor= "$0.00",
                    UrlImagem= "https://itbook.store/img/books/1001614175565.png",
                    Url= "https://itbook.store/books/1001614175565"
                },
                new Livro() {
                    Titulo= "The Node.js Handbook",
                    SubTitulo= "",
                    Isbn13= "1001614599609",
                    Valor= "$0.00",
                    UrlImagem= "https://itbook.store/img/books/1001614599609.png",
                    Url= "https://itbook.store/books/1001614599609"
                },
                new Livro() {
                    Titulo= "The Vue.js Handbook",
                    SubTitulo= "",
                    Isbn13= "1001615902053",
                    Valor= "$0.00",
                    UrlImagem= "https://itbook.store/img/books/1001615902053.png",
                    Url= "https://itbook.store/books/1001615902053"
                },
                new Livro() {
                    Titulo= "The JavaScript Beginner's Handbook",
                    SubTitulo= "",
                    Isbn13= "1001616146173",
                    Valor= "$0.00",
                    UrlImagem= "https://itbook.store/img/books/1001616146173.png",
                    Url= "https://itbook.store/books/1001616146173"
                },
                new Livro() {
                    Titulo= "The React Beginner's Handbook",
                    SubTitulo= "",
                    Isbn13= "1001616584103",
                    Valor= "$0.00",
                    UrlImagem= "https://itbook.store/img/books/1001616584103.png",
                    Url= "https://itbook.store/books/1001616584103"
                },
                new Livro() {
                    Titulo= "Oracle E-Business Suite Development & Extensibility Handbook",
                    SubTitulo= "",
                    Isbn13= "9780071629423",
                    Valor= "$5.00",
                    UrlImagem= "https://itbook.store/img/books/9780071629423.png",
                    Url= "https://itbook.store/books/9780071629423"
                },
                new Livro() {
                    Titulo= "Oracle Database 12c Release 2 Real Application Clusters Handbook",
                    SubTitulo= "Concepts, Administration, Tuning & Troubleshooting",
                    Isbn13= "9780071830485",
                    Valor= "$38.21",
                    UrlImagem= "https://itbook.store/img/books/9780071830485.png",
                    Url= "https://itbook.store/books/9780071830485"
                },
                new Livro() {
                    Titulo= "Handbook of Nature-Inspired and Innovative Computing",
                    SubTitulo= "Integrating Classical Models with Emerging Technologies",
                    Isbn13= "9780387277059",
                    Valor= "$149.99",
                    UrlImagem= "https://itbook.store/img/books/9780387277059.png",
                    Url= "https://itbook.store/books/9780387277059"
                },
                new Livro() {
                    Titulo= "Handbook of Usability Testing, 2nd Edition",
                    SubTitulo= "Howto Plan, Design, and Conduct Effective Tests",
                    Isbn13= "9780470185483",
                    Valor= "$37.16",
                    UrlImagem= "https://itbook.store/img/books/9780470185483.png",
                    Url= "https://itbook.store/books/9780470185483"
                },
                new Livro() {
                    Titulo= "RFID Handbook, 3rd Edition",
                    SubTitulo= "Fundamentals and Applications in Contactless Smart Cards, Radio Frequency Identification and Near-Field Communication",
                    Isbn13= "9780470695067",
                    Valor= "$123.33",
                    UrlImagem= "https://itbook.store/img/books/9780470695067.png",
                    Url= "https://itbook.store/books/9780470695067"
                }
            };
        }

        public static List<Livro> GerarLivroListaSearchEstaticaP6()
        {
            return new List<Livro>()
            {
                new Livro() {
                    Titulo = "PHP 7 Quick Scripting Reference, 2nd Edition",
                    SubTitulo = "",
                    Isbn13 = "9781484219218",
                    Valor = "$29.99",
                    UrlImagem = "https://itbook.store/img/books/9781484219218.png",
                    Url = "https://itbook.store/books/9781484219218"
                },
                new Livro() {
                    Titulo = "Securing PHP Apps",
                    SubTitulo = "",
                    Isbn13 = "9781484221198",
                    Valor = "$14.99",
                    UrlImagem = "https://itbook.store/img/books/9781484221198.png",
                    Url = "https://itbook.store/books/9781484221198"
                },
                new Livro() {
                    Titulo = "Expert Apache Cassandra Administration",
                    SubTitulo = "Install, configure, optimize, and secure Apache Cassandra databases",
                    Isbn13 = "9781484231258",
                    Valor = "$35.60",
                    UrlImagem = "https://itbook.store/img/books/9781484231258.png",
                    Url = "https://itbook.store/books/9781484231258"
                },
                new Livro()  {
                    Titulo = "Becoming a Better Programmer",
                    SubTitulo = "A Handbook for People Who Care About Code",
                    Isbn13 = "9781491905531",
                    Valor = "$8.16",
                    UrlImagem = "https://itbook.store/img/books/9781491905531.png",
                    Url = "https://itbook.store/books/9781491905531"
                },
                new Livro()  {
                    Titulo = "XenServer Administration Handbook",
                    SubTitulo = "Practical Recipes for Successful Deployments",
                    Isbn13 = "9781491935439",
                    Valor = "$25.62",
                    UrlImagem = "https://itbook.store/img/books/9781491935439.png",
                    Url = "https://itbook.store/books/9781491935439"
                },
                new Livro()  {
                    Titulo = "The Linux Programming Interface",
                    SubTitulo = "A Linux and UNIX System Programming Handbook",
                    Isbn13 = "9781593272203",
                    Valor = "$26.30",
                    UrlImagem = "https://itbook.store/img/books/9781593272203.png",
                    Url = "https://itbook.store/books/9781593272203"
                },
                new Livro()  {
                    Titulo = "AI as a Service",
                    SubTitulo = "Serverless machine learning with AWS",
                    Isbn13 = "9781617296154",
                    Valor = "$39.99",
                    UrlImagem = "https://itbook.store/img/books/9781617296154.png",
                    Url = "https://itbook.store/books/9781617296154"
                },
                new Livro()  {
                    Titulo = "Seriously Good Software",
                    SubTitulo = "Code that works, survives, and wins",
                    Isbn13 = "9781617296291",
                    Valor = "$31.99",
                    UrlImagem = "https://itbook.store/img/books/9781617296291.png",
                    Url = "https://itbook.store/books/9781617296291"
                },
                new Livro()  {
                    Titulo = "VMware vCenter Operations Manager Essentials",
                    SubTitulo = "Explore virtualization fundamentals and real-world solutions for the modern network administrator",
                    Isbn13 = "9781782176961",
                    Valor = "$33.99",
                    UrlImagem = "https://itbook.store/img/books/9781782176961.png",
                    Url = "https://itbook.store/books/9781782176961"
                },
                new Livro()  {
                    Titulo = "Python Interviews",
                    SubTitulo = "Discussions with Python Experts",
                    Isbn13 = "9781788399081",
                    Valor = "$27.99",
                    UrlImagem = "https://itbook.store/img/books/9781788399081.png",
                    Url = "https://itbook.store/books/9781788399081"
                }
            };
        }
    }
}