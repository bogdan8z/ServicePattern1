using ServicePattern1.DataAccess.Interfaces;

namespace ServicePattern1.DataAccess
{
    public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly List<TEntity> _entities = [];

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(_entities.AsEnumerable());
        }

        public Task<TEntity?> GetByIdAsync(int id)
        {
            var entity = _entities.FirstOrDefault(e => ((dynamic)e).Id == id);
            return Task.FromResult(entity);
        }

        public Task AddAsync(TEntity entity)
        {
            _entities.Add(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TEntity entity)
        {
            var existingEntity = _entities.FirstOrDefault(e => ((dynamic)e).Id == ((dynamic)entity).Id);
            if (existingEntity != null)
            {
                _entities.Remove(existingEntity);
                _entities.Add(entity);
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var entity = _entities.FirstOrDefault(e => ((dynamic)e).Id == id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
            return Task.CompletedTask;
        }
    }
}