using System.Windows;
using System.Windows.Input;

namespace Lunula.Core.Styles
{
    /// <summary>
    /// Interaction logic for BaseStyles.xaml
    /// </summary>
    partial class StandardStyles : ResourceDictionary
    {
        private void OnManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }
    }
}
