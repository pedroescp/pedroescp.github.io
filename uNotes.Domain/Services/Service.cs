using System.Linq.Expressions;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            return _repository.Adicionar(obj);
        }

        public virtual TEntity ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Buscar(predicate);
        }

        public virtual void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }

        public virtual void Remover(int id)
        {
            _repository.Remover(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual void Remover(Guid id)
        {
            _repository.Remover(id);
        }
    }
}
