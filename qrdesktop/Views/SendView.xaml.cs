using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Qrdesktop.Views
{
    public class SendView : UserControl
    {
        public SendView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
