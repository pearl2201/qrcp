using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Qrdesktop.Views
{
    public class ReceiveView : UserControl
    {
        public ReceiveView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
