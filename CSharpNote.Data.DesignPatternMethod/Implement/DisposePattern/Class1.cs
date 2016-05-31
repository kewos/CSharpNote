using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpNote.Data.DesignPattern.Implement.DisposePattern
{
    public class MyResource : IDisposable
    {
        private readonly Component component = new Component();
        private bool disposed;
        private IntPtr handle;

        public MyResource(IntPtr handle)
        {
            this.handle = handle;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    component.Dispose();
                }

                CloseHandle(handle);
                handle = IntPtr.Zero;

                disposed = true;
            }
        }

        [DllImport("Kernel32")]
        private static extern bool CloseHandle(IntPtr handle);

        ~MyResource()
        {
            Dispose(false);
        }
    }
}