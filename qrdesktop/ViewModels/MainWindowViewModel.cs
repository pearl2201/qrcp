using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using Avalonia.Controls;
using Avalonia;
using Qrdesktop.Utils;
using Avalonia.Controls.ApplicationLifetimes;
using static Qrdesktop.Utils.NetworkHelper;

namespace Qrdesktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        Process myProcess;
        public MainWindowViewModel()
        {
            Content = Menu = new MenuViewModel();
        }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public MenuViewModel Menu { get; }

        public static Mutex mutex = new Mutex();
      

        public async void OpenSendServer()
        {
            mutex.WaitOne();

            var window = GetWindow();
            var dialog = new OpenFileDialog()
            {
                AllowMultiple = false,
                Title = "Select File Sent"
            };
            var files = await dialog.ShowAsync(window);

            if (files != null && files.Length > 0)
            {
                try
                {
                    int port = NetworkHelper.GetAvailablePort(5000);
                    string ipAddress = NetworkHelper.GetLocalIPAddress();
                    var token = NetworkHelper.GetURL() + System.IO.Path.GetExtension(files[0]);
                    var vm = new SendViewModel(files[0], ipAddress, port, token);
                    Content = vm;
                    vm.Stop.Subscribe(_ =>
                    {
                        Content = Menu;
                    });
                }
                catch (NoNetworkingException ex)
                {
                    Console.WriteLine("No Networking: " + ex.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            mutex.ReleaseMutex();
        }

        public async void OpenReceiveServer()
        {
            mutex.WaitOne();

            var window = GetWindow();
            var dialog = new SaveFileDialog()
            {
               
                Title = "Select File Receive"
            };
            var file = await dialog.ShowAsync(window);

            if (file != null && !string.IsNullOrEmpty(file))
            {
                try
                {
                    int port = NetworkHelper.GetAvailablePort(5000);
                    string ipAddress = NetworkHelper.GetLocalIPAddress();
                    var token = NetworkHelper.GetURL() + System.IO.Path.GetExtension(file);
                    var vm = new ReceiveViewModel(file, ipAddress, port, token);
                    Content = vm;
                    vm.Stop.Subscribe(_ =>
                    {
                        Content = Menu;
                    });
                }
                catch (NoNetworkingException ex)
                {
                    Console.WriteLine("No Networking: " + ex.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            mutex.ReleaseMutex();
        }
    }
}
