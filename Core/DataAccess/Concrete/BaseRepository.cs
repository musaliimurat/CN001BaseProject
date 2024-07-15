using Core.DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class BaseRepository<TEntiy, TContext> : IBaseRepository<TEntiy>
        where TEntiy : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntiy entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public void Delete(TEntiy entity)
        {
            throw new NotImplementedException();
        }

        public TEntiy Get(Expression<Func<TEntiy, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TEntiy> GetAll(Expression<Func<TEntiy, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntiy entity)
        {
            throw new NotImplementedException();
        }
    }
}
