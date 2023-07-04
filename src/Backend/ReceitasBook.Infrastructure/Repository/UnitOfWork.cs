using ReceitasBook.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Infrastructure.Repository
{
    public sealed class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ReceitaBookContext _Context;
        private bool _disposed;
        public UnitOfWork(ReceitaBookContext context)
        {
            _Context = context;
        }

        public async Task Commit()
        {
            await _Context.SaveChangesAsync();
        }
        private void Dispose(bool disposing)
        {
            if(!_disposed && disposing)
            {
                _Context.Dispose();
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
