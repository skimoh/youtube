//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.Mongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace CodeBehind.Mongo.Repository
{
    public class Contexto : IDisposable
    {
        private IMongoDatabase _database;
        private IMongoClient _client;

        public Contexto(IOptions<Settings> settings)
        {
            _client = new MongoClient(settings.Value.ConnectionString);
            if (_client != null)
                _database = _client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Cliente> Clientes
        {
            get
            {
                return _database.GetCollection<Cliente>("clientes");
            }
        }

        public void Dispose()
        {
            _client = null;
            _database = null;
        }
    }

    public class Settings
    {
        public string ConnectionString;
        public string Database;
    }
}
