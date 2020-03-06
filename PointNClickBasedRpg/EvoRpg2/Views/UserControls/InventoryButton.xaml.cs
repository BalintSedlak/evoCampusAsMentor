using System.Windows.Controls;
using EvoRpg2.ViewModels;

namespace EvoRpg2.Views.UserControls
{
    /// <summary>
    /// Interaction logic for InventoryButton.xaml
    /// </summary>
    public partial class InventoryButton : UserControl
    {
        public InventoryButton(InventoryButtonViewModel viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
