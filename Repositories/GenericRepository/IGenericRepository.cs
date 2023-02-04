using System;
namespace NewRepo.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        TEntity FindById(object id);
        Task<TEntity?> FindByIdAsync(object id);

        Task<bool> SaveAsync();
        IAsyncEnumerable<TEntity> GetAsync();
    }
}
