namespace InteropDemo.WPF.ViewModels
{
    using InteropDemo.Shared;
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Windows.Input;

    sealed class MainWindowViewModel : IInteropCallback, IDisposable
    {
        private readonly NativeBridge.Bridge _bridge;
        private readonly ICommand _doNativeThing;
        private readonly ICommand _callMeBack;
        private bool _disposedValue;

        private sealed class Command : ICommand
        {
            private readonly Action _action;

            public Command(Action action)
            {
                Contract.Assert(null != action);
                Contract.Ensures(null != _action);
                _action = action;
            }

            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter) { return true; }
            public void Execute(object parameter) { _action(); }
        }

        public MainWindowViewModel()
        {
            _disposedValue = false;
            _bridge = new InteropDemo.NativeBridge.Bridge(this);
            _doNativeThing = new Command(this.ExecuteDoNativeThing);
            _callMeBack = new Command(this.ExecuteCallMeBack);
        }

        public ICommand DoNativeThing
        {
            get { return _doNativeThing; }
        }

        public ICommand CallMeBack
        {
            get { return _callMeBack; }
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

        private void ExecuteDoNativeThing()
        {
            int product = _bridge.DoNativeThing(100, 200);
        }

        private void ExecuteCallMeBack()
        {
            _bridge.CallMeBack("Not Without a String!");
        }

        void IInteropCallback.CallBack(string parameter)
        {
            Trace.WriteLine(string.Format("Called back: \"{0}\"", parameter));
        }
    }
}
