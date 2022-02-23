using Challenge.Backend.Domain.ICommands;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Backend.AccessData.Commands
{
    public class GenericRepository : IGenericsRepository
    {
        private readonly DisneyDbContext _context;
        public GenericRepository (DisneyDbContext dbContext)
        {
            _context = dbContext;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public T Exists<T>(int id) where T : class
        {
            var x = _context.Find<T>(id);
            return x;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
