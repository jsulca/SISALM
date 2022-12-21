using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SISALM.Repositorios
{
    public class BaseRepositorio<T> where T : class
    {
        protected SISALMContexto _contexto;

        public BaseRepositorio(SISALMContexto contexto)
        {
            _contexto = contexto;
        }

        public T? GetOne(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().SingleOrDefault(predicate);

        public Task<T?> GetOneAsync(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().SingleOrDefaultAsync(predicate);

        public List<T> GetAllBy(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().Where(predicate).ToList();

        public Task<List<T>> GetAllByAsync(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().Where(predicate).ToListAsync();

        public int CountBy(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().Count(predicate);

        public Task<int> CountByAsync(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().CountAsync(predicate);

        public List<T> GetAll() => _contexto.Set<T>().ToList();

        public Task<List<T>> GetAllAsync() => _contexto.Set<T>().ToListAsync();

        public T? First(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().FirstOrDefault(predicate);

        public Task<T?> FirstAsync(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().FirstOrDefaultAsync(predicate);


        public void Save(T entity) => _contexto.Add(entity);

        public void Save(List<T> entities) => _contexto.AddRange(entities.ToArray());

        public void Update(T entity) => _contexto.Update(entity);

        public void Update(List<T> entities) => _contexto.UpdateRange(entities.ToArray());

        public void Remove(T entity) => _contexto.Remove(entity);

        public void Remove(List<T> entities) => _contexto.RemoveRange(entities.ToArray());
    }
}
