using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Infrastructure
{
    public abstract class Disposable : IDisposable
    {
        bool isDisposed = false;
        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();

            }
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeCore()
        {

        }
        public void Dispose()
        {
            Dispose(true);
            isDisposed = true;
        }
    }
}
