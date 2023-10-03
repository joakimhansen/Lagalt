using System.Security.Cryptography;

namespace Lagalt_backend.Services
{
    public interface ICrudService<TEntity, TId>
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TId id);
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> UpdateAsync(TEntity obj);
        Task DeleteByIdAsync(TId id);
    }
}
