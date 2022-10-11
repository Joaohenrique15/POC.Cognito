using POC.Cognito.Core.Entities;
using POC.Cognito.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Cognito.Infra.Users.Repositories
{
    //TODO Criar BaseRepository no Core
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        internal readonly AuthenticationDataContext _context;
        internal readonly DbSet<T> _db;

        public BaseRepository(AuthenticationDataContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public virtual async Task AddAsync(T entity)
        {
            _db.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _db.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual Task<List<T>> FindAllAsync(bool asNoTracking = false)
        {
            if (asNoTracking)
                return _db.AsNoTracking().ToListAsync();

            return _db.ToListAsync();
        }
        public async Task<T> FindByIdAsync(Guid id, bool asNoTracking = false)
        {
            if (asNoTracking)
                return await _db.AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);

            return await _db.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var a = _db.Update(entity);
            await _context.Commit();
        }
    }
}
