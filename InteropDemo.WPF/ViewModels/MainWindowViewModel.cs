namespace InteropDemo.WPF.ViewModels
{
    using InteropDemo.Shared;
    using System;

    sealed class MainWindowViewModel : IInteropCallback, IDisposable
    {
        private readonly NativeBridge.Bridge _bridge;
        private bool _disposedValue;

        public MainWindowViewModel()
        {
            _disposedValue = false;
            _bridge = new NativeBridge.Bridge(this);
        }

        ~MainWindowViewModel()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _disposedValue = true;

                if (disposing)
                {
                }

                _bridge.Dispose();
            }
        }
    }
}
