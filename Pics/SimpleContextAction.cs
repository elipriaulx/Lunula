using System;
using System.Windows.Media;
using Lunula.Extensibilitiy.Components;
using Lunula.Extensibilitiy.ViewModels;

namespace Lunula.Modules.Pics
{
    public class SimpleContextAction : BaseViewModel, IContextAction
    {
        public Guid Id
        {
            get { return GetValue(() => Id); }
            set { SetValue(() => Id, value); }
        }

        public bool Enabled
        {
            get { return GetValue(() => Enabled); }
            set { SetValue(() => Enabled, value); }
        }

        public string Name
        {
            get { return GetValue(() => Name); }
            set { SetValue(() => Name, value); }
        }

        public string Description
        {
            get { return GetValue(() => Description); }
            set { SetValue(() => Description, value); }
        }

        public ImageSource Image
        {
            get { return GetValue(() => Image); }
            set { SetValue(() => Image, value); }
        }

        public Action Task
        {
            get { return GetValue(() => Task); }
            set { SetValue(() => Task, value); }
        }
    }
}
