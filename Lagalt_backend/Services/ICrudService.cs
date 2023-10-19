using System.Security.Cryptography;

namespace Lagalt_backend.Services {

    /// <summary>
    /// Basic crud-operations to fetch, add, change and delete from the database
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface ICrudService<TEntity, TId> {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TId id);
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> UpdateAsync(TEntity obj);
        Task DeleteByIdAsync(TId id);
    }
}
