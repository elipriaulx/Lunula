using System.Windows;
using Lunula.Application.ViewModels;

namespace Lunula.Application.Shells
{
    /// <summary>
    /// Interaction logic for ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        public ApplicationWindow()
        {
            InitializeComponent();
        }

        public ApplicationWindow(ApplicationWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
