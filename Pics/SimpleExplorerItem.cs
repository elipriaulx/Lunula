using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lunula.Extensibilitiy.Components;

namespace Lunula.Modules.Pics
{
    public class SimpleExplorerItem : SimpleContextAction, IExplorerAction
    {
        public List<IExplorerAction> ChildItems
        {
            get { return GetValue(() => ChildItems); }
            set { SetValue(() => ChildItems, value); }
        }

        IEnumerable<IExplorerAction> IExplorerAction.ChildItems => ChildItems;
    }
}
