using System.Linq.Expressions;
using GestaoFormacao.Database;
using GestaoFormacao.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;


// Usa c# MongoDB Driver to connect to MongoDB and perform CRUD operations
namespace GestaoFormacao.Controllers
{
    public abstract class GestaoLista<T> where T : GFMongoEntity, IIdentificavel
    {
        private readonly IMongoCollection<T> collection;
        protected GestaoLista(string collectionName)
        {
            collection = GFMongoDBClient.Database.GetCollection<T>(collectionName);
        }

        public void Adicionar(T item)
        {
            try
            {
                collection.InsertOne(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Remover(T item)
        {
            try
            {
                collection.DeleteOne(x => x.Id == item.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Atualizar(T item)
        {
            try
            {
                collection.ReplaceOne(x => x.Id == item.Id, item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public T PorNumeroInterno(uint numeroInterno)
        {
            try
            {
                return collection.Find(x => x.NumeroInterno == numeroInterno).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public T Encontrar(Expression<Func<T, bool>> filtro)
        {
            try
            {
                return collection.Find(filtro).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<T> Todos()
        {
            try
            {
                return collection.Find(x => true).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<T> Filtrar(Expression<Func<T, bool>> filtro)
        {
            try
            {
                return collection.Find(filtro).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public T PorID(ObjectId id)
        {
            try
            {
                return collection.Find(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void RemoverPorId(ObjectId id)
        {
            try
            {
                collection.DeleteOne(x => x.Id == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
