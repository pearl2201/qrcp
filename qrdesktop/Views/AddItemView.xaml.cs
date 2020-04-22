using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Qrdesktop.Views
{
    public class AddItemView : UserControl
    {
        public AddItemView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
