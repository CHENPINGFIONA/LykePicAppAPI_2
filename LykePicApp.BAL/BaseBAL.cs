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

            this.disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
