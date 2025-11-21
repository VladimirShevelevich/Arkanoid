using System;
using UniRx;

namespace Arkanoid.Tools.Disposable
{
    public abstract class BaseDisposable : IDisposable
    {
        private CompositeDisposable _compositeDisposable;

        protected void AddDisposable(IDisposable disposable)
        {
            _compositeDisposable ??= new CompositeDisposable();
            _compositeDisposable.Add(disposable);
        }

        public virtual void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}