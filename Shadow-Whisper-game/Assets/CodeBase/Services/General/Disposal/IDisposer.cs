using System;

namespace CodeBase.Infrastructure.Services.Disposal
{
    public interface IDisposer
    {
        void Add(IDisposable disposable);
        void DisposeAll();
    }
}