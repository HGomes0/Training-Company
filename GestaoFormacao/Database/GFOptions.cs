using System.Drawing.Printing;
using MongoDB.Driver;

namespace GestaoFormacao.Database
{
    public class GFOption : GFMongoEntity
    {
        private static readonly string collection_name = "options";
        private static readonly IMongoCollection<GFOption> collection = GFMongoDBClient.Database.GetCollection<GFOption>(collection_name);
        public uint NextIDFuncionario { get; set; }
        public uint NextIDFormacao { get; set; }

        public static uint GetNextIDUtilizador()
        {
            var options = GetOptions();
            var nextID = options.NextIDFuncionario;
            options.NextIDFuncionario++;
            UpdateOptions(options);
            return nextID;
        }

        public static uint GetNextIDFormacao()
        {
            var options = GetOptions();
            var nextID = options.NextIDFormacao;
            options.NextIDFormacao++;
            UpdateOptions(options);
            return nextID;
        }

        public static GFOption CriarDefault()
        {
            var options = new GFOption
            {
                NextIDFuncionario = 1,
                NextIDFormacao = 1
            };
            collection.InsertOne(options);
            return options;
        }

        public static GFOption GetOptions()
        {
            var options = collection.Find(FilterDefinition<GFOption>.Empty).FirstOrDefault();
            if (options == null)
            {
                CriarDefault();
                options = collection.Find(FilterDefinition<GFOption>.Empty).FirstOrDefault();
            }
            return options;
        }

        public static void UpdateOptions(GFOption options)
        {
            collection.ReplaceOne(o => o.Id == options.Id, options);
        }
    }
}