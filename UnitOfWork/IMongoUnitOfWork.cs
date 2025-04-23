using MongoTest.Models.Entities;

namespace MongoTest.UnitOfWork;

public interface IMongoUnitOfWork : IDisposable
{
    IRepository<SeasonModel> Seasons { get; }
    Task CommitAsync();
}
