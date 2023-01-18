using Bogus;
using deliverybook.Infra.Entities.ItBook;

namespace deliverybook.UnitTests.Comum.Faker.Infra.Entities.ItBook
{
    public static class DetailsDAOFaker
    {
        public static Faker<DetailsDAO> GerarDetailsEstatico { get; } =
            new Faker<DetailsDAO>()
                .RuleFor(p => p.Title, f => "The Definitive Guide to MongoDB, 3rd Edition")
                .RuleFor(p => p.Subtitle, f => "A complete guide to dealing with Big Data using MongoDB")
                .RuleFor(p => p.Isbn13, f => "9781484211830")
                .RuleFor(p => p.Price, f => "$0.00")
                .RuleFor(p => p.Image, f => "https://itbook.store/img/books/9781484211830.png")
                .RuleFor(p => p.Url, f => "https://itbook.store/books/9781484211830")
                .RuleFor(p => p.Authors, "David Hows, Eelco Plugge, Peter Membrey, Tim Hawkins")
                .RuleFor(p => p.Publisher, "Apress")
                .RuleFor(p => p.Language, "English")
                .RuleFor(p => p.Isbn10, "1484211839")
                .RuleFor(p => p.Pages, f => "376")
                .RuleFor(p => p.Year, f => "2015")
                .RuleFor(p => p.Rating, f => "4")
                .RuleFor(p => p.Desc, f => "The Definitive Guide to MongoDB, Third Edition, is updated for MongoDB 3 and includes all of the latest MongoDB features, including the aggregation framework introduced in version 2.2 and hashed indexes in version 2.4. The Third Edition also now includes Node.js along with Python.MongoDB is the most...");
    }
}