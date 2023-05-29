using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected uNotesContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(uNotesContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            return objreturn.Entity;
        }

        public virtual TEntity ObterPorId(int id) => DbSet.Find(id);

        public virtual TEntity ObterPorId(Guid id) => DbSet.Find(id);
        public virtual IEnumerable<TEntity> ObterTodos() => DbSet;

        public virtual void Atualizar(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            DbSet.Update(obj);
        }

        public virtual void Remover(int id) => DbSet.Remove(DbSet.Find(id));

        public virtual void Remover(TEntity entity)
        {
            if (Db.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);
            DbSet.Remove(entity);
        }

        public IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate) => DbSet.Where(predicate);

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
    }
}
