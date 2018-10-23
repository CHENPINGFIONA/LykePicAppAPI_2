using System;

namespace LykePicApp.BAL
{
    public class BaseBAL : IDisposable
    {
        private bool disposed = false;
        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            //if (_container != null)
            //{
            //    _container.Dispose();
            //    _proxy.Dispose();
            //}

            this.disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
