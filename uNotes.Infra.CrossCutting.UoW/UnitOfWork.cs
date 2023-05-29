using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.CrossCutting.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly uNotesContext _context;

        public UnitOfWork(uNotesContext context)
        {
            _context = context;
        }

        public void Commit() => _context.SaveChanges();
        
        public async Task CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }

    }
}
