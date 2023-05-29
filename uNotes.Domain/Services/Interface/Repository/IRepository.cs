using System.Linq.Expressions;

namespace uNotes.Domain.Services.Interface.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(int id);
        void Remover(TEntity entity);
        void Remover(Guid id);
        IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}
