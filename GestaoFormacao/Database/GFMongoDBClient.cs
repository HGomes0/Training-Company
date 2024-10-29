using System;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GestaoFormacao.Database
{
    public static class GFMongoDBClient
    {
        private static IMongoClient Instance { get; set; }
        public static IMongoDatabase Database { get; private set; }

        public static void Initialize()
        {
            Instance = new MongoClient("mongodb+srv://pedro:Atec4Code-2024@cluster0.abmelyd.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            Database = Instance.GetDatabase("GestaoFormacaoApresentacao");
            BsonSerializer.RegisterSerializer(new MyMongoDBDateTimeSerializer());
        }
    }
}