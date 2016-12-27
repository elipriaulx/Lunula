using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace Lunula.Core.Converters
{
    public class ActionICommandConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var action = value as Action;

            return action != null ? new ActionICommand(action) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public class ActionICommand : ICommand
        {
            private readonly Action _action;
            public event EventHandler CanExecuteChanged;

            public ActionICommand(Action action)
            {
                _action = action;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                _action?.Invoke();
            }
        }
    }
}
