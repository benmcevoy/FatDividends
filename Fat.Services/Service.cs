using System;
using Fat.Services.Models;

namespace Fat.Services
{
    public abstract class Service : IDisposable
    {
        private readonly FatDataContext _context;

        protected Service()
        {
            _context = new FatDataContext();
        }

        protected FatDataContext DataContext { get { return _context; } }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // get rid of managed resources
                _context.Dispose();
            }
            // get rid of unmanaged resources
        }
    }
}
