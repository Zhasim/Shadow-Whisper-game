using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.Services.Disposal
{
    public class Disposer : IDisposer
    {
        private readonly List<IDisposable> _disposables = new();  
        
        public void Add(IDisposable disposable)  
        {  
            if (disposable != null) 
                _disposables.Add(disposable);
        }  
  
        public void DisposeAll()  
        {  
            foreach (var disposable in _disposables) 
                disposable.Dispose();
            
            _disposables.Clear();
        }
    }
}