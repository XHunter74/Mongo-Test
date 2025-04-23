using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoTest.UnitOfWork;

public class MongoRepository<T> : IRepository<T> where T : class
{
    protected readonly IMongoCollection<T> _collection;
    protected readonly IClientSessionHandle? _session;

    public MongoRepository(IMongoDatabase database, IClientSessionHandle? session, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
        _session = session;
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
        var document = _session == null ? await _collection.Find(filter).FirstOrDefaultAsync()
            : await _collection.Find(_session, filter).FirstOrDefaultAsync();
        return document;
    }

    public async Task AddAsync(T entity)
    {
        if (_session == null)
        {
            await _collection.InsertOneAsync(entity);
        }
        else
        {
            await _collection.InsertOneAsync(_session, entity);
        }
    }

    public async Task RemoveAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
        if (_session == null)
        {
            await _collection.DeleteOneAsync(filter);
        }
        else
        {
            await _collection.DeleteOneAsync(_session, filter);
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var allDocuments = _session == null ? await _collection.Find(Builders<T>.Filter.Empty).ToListAsync()
            : await _collection.Find(_session, Builders<T>.Filter.Empty).ToListAsync();
        return allDocuments;
    }
}
