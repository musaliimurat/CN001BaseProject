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
            using TContext context = new();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Modified;
            context.SaveChanges();

        }

        public TEntiy Get(Expression<Func<TEntiy, bool>> filter)
        {
            using TContext context = new TContext();
            return context.Set<TEntiy>().SingleOrDefault(filter);
        }

        public List<TEntiy> GetAll(Expression<Func<TEntiy, bool>> filter = null)
        {
            using TContext context = new();

            return filter !=null? context.Set<TEntiy>().Where(filter).ToList() : context.Set<TEntiy>().ToList();
        }

        public void Update(TEntiy entity)
        {
            using TContext context = new TContext();
            var modifyEntity = context.Entry(entity);
            modifyEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
