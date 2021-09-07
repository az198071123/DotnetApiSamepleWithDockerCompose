using System.Collections.Generic;
using System.Linq;
using DotNetApiTest.Models;
using MongoDB.Driver;

namespace DotNetApiTest.Services
{
    public class PttService
    {
        private readonly IMongoCollection<Articles> _books;

        public PttService(IPttDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Articles>(settings.CollectionName);
        }

        public List<Articles> Get() =>
            _books.Find(book => true).Limit(100).ToList();


        public Articles GetFirst() =>
            _books.Find(book => true).SortByDescending(book => book.Id).FirstOrDefault();

        public Articles Get(string id) =>
            _books.Find<Articles>(book => book.Id == id).FirstOrDefault();

        public Articles Create(Articles book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Articles bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Articles bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}