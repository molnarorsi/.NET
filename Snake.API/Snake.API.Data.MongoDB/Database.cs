using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Snake.API.Data.Abstraction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Snake.API.Data.MongoDB
{
    

    
    public class Database : IDatabase
    {

        private readonly IMongoDatabase database;
        private readonly MongoClient client;
        public Database(IDatabaseConfiguration databaseConfiguration)
        {
            this.RegisterCustomMapper();
            this.client = new MongoClient(databaseConfiguration.ConnectionString);
            this.database = this.client.GetDatabase(databaseConfiguration.DatabaseName);
        }
        public TCollection GetCollection<TCollection, TItem>(string name) where TCollection : class
        {
            return this.database.GetCollection<TItem>(name) as TCollection;
        }

        private void RegisterCustomMapper() {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Domain.Snake)))
            {
                BsonClassMap.RegisterClassMap < Domain.Snake(m =>
                {
                    m.AutoMap();
                    m.MapIdMember(mi => mi.Id)
                     .SetIdGenerator(new StringObjectIdGenerator())
                     .SetSerializer(new StringSerializer(BsonType.ObjectId));

                    m.SetIgnoreExtraElements(true);
                });
                 
            }
        }
    }
}
