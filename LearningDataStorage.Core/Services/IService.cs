using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDataStorage.Core.Services
{
    public interface IService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        
        Task<TEntity> Create(TEntity newEntity);
        
        Task Update(TEntity entityToBeUpdated, TEntity entity);
        
        Task Delete(TEntity entity);
    }
}
