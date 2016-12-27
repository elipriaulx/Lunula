using System;
using System.ComponentModel;
using System.Windows.Media;

namespace Lunula.Extensibilitiy.Components
{
    public interface IContextAction : INotifyPropertyChanged
    {
        Guid Id { get; }
        bool Enabled { get; }

        string Name { get; }
        string Description { get; }
        
        ImageSource Image { get; }

        Action Task { get; }
    }
}