using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        void Atualizar(TEntity obj);
        void Remover(int id);
        void Remover(Guid id);

    }
}
