using MongoDB.Driver;
using MongoTest.Models.Entities;

namespace MongoTest.UnitOfWork;

public class MongoUnitOfWork : IMongoUnitOfWork
{
    private readonly IClientSessionHandle? _session;
    private bool _disposed;

    public IRepository<SeasonModel> Seasons { get; }

    public MongoUnitOfWork(IMongoClient client, string databaseName)
    {
        if (!string.IsNullOrEmpty(client.Settings.ReplicaSetName))
        {
            _session = client.StartSession();
            _session.StartTransaction();
        }
        var database = client.GetDatabase(databaseName);

        Seasons = new MongoRepository<SeasonModel>(database, _session, "got_seasons_collection");
    }

    public async Task CommitAsync()
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(MongoUnitOfWork));

        if (_session == null)
            throw new InvalidOperationException("Session is not initialized.");

        await _session.CommitTransactionAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _session?.Dispose();
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~MongoUnitOfWork()
    {
        Dispose(false);
    }
}
