using Bogus;
using deliverybook.Infra.Entities.ItBook;
using System.Collections.Generic;

namespace deliverybook.UnitTests.Comum.Faker.Infra.Entities.ItBook
{
    public static class BookDAOFaker
    {
        public static Faker<BookDAO> GerarBookEstatico { get; } =
            new Faker<BookDAO>()
                .RuleFor(p => p.Title, f => "The Definitive Guide to MongoDB, 3rd Edition")
                .RuleFor(p => p.Subtitle, f => "A complete guide to dealing with Big Data using MongoDB")
                .RuleFor(p => p.Isbn13, f => "9781484211830")
                .RuleFor(p => p.Price, f => "$0.00")
                .RuleFor(p => p.Image, f => "https://itbook.store/img/books/9781484211830.png")
                .RuleFor(p => p.Url, f => "https://itbook.store/books/9781484211830");

        public static List<BookDAO> GerarBookListaEstatica()
        {
            return new List<BookDAO>() {
                    new BookDAO() {
                     Title ="The Vue.js Handbook",
                     Subtitle ="",
                     Isbn13 ="1001615902053",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001615902053.png",
                     Url ="https://itbook.store/books/1001615902053"
                  },
                  new BookDAO() {
                     Title ="The Node.js Handbook",
                     Subtitle ="",
                     Isbn13 ="1001614599609",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001614599609.png",
                     Url ="https://itbook.store/books/1001614599609"
                  },
                  new BookDAO() {
                     Title ="Azure Tips and Tricks",
                     Subtitle ="",
                     Isbn13 ="9781732704121",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/9781732704121.png",
                     Url ="https://itbook.store/books/9781732704121"
                  },
                  new BookDAO() {
                     Title ="Learn Programming",
                     Subtitle ="Your Guided Tour Through the Programming Jungle",
                     Isbn13 ="9781722834920",
                     Price ="$16.83",
                     Image ="https://itbook.store/img/books/9781722834920.png",
                     Url ="https://itbook.store/books/9781722834920"
                  },
                  new BookDAO() {
                     Title ="Graph Databases For Beginners",
                     Subtitle ="The #1 Platform for Connected Data",
                     Isbn13 ="1001606307637",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001606307637.png",
                     Url ="https://itbook.store/books/1001606307637"
                  },
                  new BookDAO() {
                     Title ="Elementary Algorithms",
                     Subtitle ="",
                     Isbn13 ="1001606307729",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001606307729.png",
                     Url ="https://itbook.store/books/1001606307729"
                  },
                  new BookDAO() {
                     Title ="Windows PowerShell Networking Guide",
                     Subtitle ="",
                     Isbn13 ="1001606307964",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001606307964.png",
                     Url ="https://itbook.store/books/1001606307964"
                  },
                  new BookDAO() {
                     Title ="Operating Systems= From 0 to 1",
                     Subtitle ="",
                     Isbn13 ="1001606140658",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001606140658.png",
                     Url ="https://itbook.store/books/1001606140658"
                  },
                  new BookDAO() {
                     Title ="Java Web Scraping Handbook",
                     Subtitle ="Learn advanced Web Scraping techniques",
                     Isbn13 ="1001606140805",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001606140805.png",
                     Url ="https://itbook.store/books/1001606140805"
                  },
                  new BookDAO() {
                     Title ="Coffee Break Python Slicing",
                     Subtitle ="24 Workouts to Master Slicing in Python, Once and for All",
                     Isbn13 ="1001605784161",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001605784161.png",
                     Url ="https://itbook.store/books/1001605784161"
                  },
                  new BookDAO() {
                     Title ="The Basics of User Experience Design",
                     Subtitle ="",
                     Isbn13 ="1001601301730",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001601301730.png",
                     Url ="https://itbook.store/books/1001601301730"
                  },
                  new BookDAO() {
                     Title ="3D Game Development with LWJGL 3",
                     Subtitle ="Learn the main concepts involved in writing 3D games using the Lighweight Java Gaming Library",
                     Isbn13 ="1001601302020",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001601302020.png",
                     Url ="https://itbook.store/books/1001601302020"
                  },
                  new BookDAO() {
                     Title ="DevOps= WTF?",
                     Subtitle ="",
                     Isbn13 ="1001592565453",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001592565453.png",
                     Url ="https://itbook.store/books/1001592565453"
                  },
                  new BookDAO() {
                     Title ="Full Speed Python",
                     Subtitle ="",
                     Isbn13 ="1001592395975",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001592395975.png",
                     Url ="https://itbook.store/books/1001592395975"
                  },
                  new BookDAO() {
                     Title ="How To Code in Python 3",
                     Subtitle ="",
                     Isbn13 ="9780999773017",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/9780999773017.png",
                     Url ="https://itbook.store/books/9780999773017"
                  },
                  new BookDAO() {
                     Title ="Operating System Concepts, 10th Edition",
                     Subtitle ="",
                     Isbn13 ="9781119456339",
                     Price ="$90.08",
                     Image ="https://itbook.store/img/books/9781119456339.png",
                     Url ="https://itbook.store/books/9781119456339"
                  },
                  new BookDAO() {
                     Title ="Neural Networks and Deep Learning",
                     Subtitle ="A Textbook",
                     Isbn13 ="9783319944623",
                     Price ="$33.99",
                     Image ="https://itbook.store/img/books/9783319944623.png",
                     Url ="https://itbook.store/books/9783319944623"
                  },
                  new BookDAO() {
                     Title ="Fundamentals of C++ Programming",
                     Subtitle ="",
                     Isbn13 ="1001590483252",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001590483252.png",
                     Url ="https://itbook.store/books/1001590483252"
                  },
                  new BookDAO() {
                     Title ="Fundamentals of Python Programming",
                     Subtitle ="",
                     Isbn13 ="1001590485785",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001590485785.png",
                     Url ="https://itbook.store/books/1001590485785"
                  },
                  new BookDAO() {
                     Title ="Machine Learning Yearning",
                     Subtitle ="Technical Strategy for AI Engineers, In the Era of Deep Learning",
                     Isbn13 ="1001590486081",
                     Price ="$0.00",
                     Image ="https://itbook.store/img/books/1001590486081.png",
                     Url ="https://itbook.store/books/1001590486081"
                  }
            };
        }
    }
}