using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Qrdesktop.Utils;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Qrdesktop.ViewModels
{
    public class SendViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> Stop { get; }

       
        public string UriPath { get; private set; }

        public Bitmap Bitmap { get; set; }

        public Image qrImage;

        public string URL { get; set; }

        public Thread thread;

        private string ipAddress;
        private int port;
        private string token;
        private string path;

        public SendViewModel(string path, string ipAddress, int port, string token)
        {
            this.path = path;
            this.ipAddress = ipAddress;
            this.port = port;
            this.token = token;

            Stop = ReactiveCommand.Create(() => { });

            UriPath = string.Format("http://{0}:{1}", ipAddress, port);
            URL = string.Format("http://{0}:{1}/send/{2}", ipAddress, port, token);

            var bytes = QrHelper.GenPngByteFromUrl(URL);

            using (MemoryStream stream = new MemoryStream(bytes))
            {
                Bitmap = new Bitmap(stream);
            }
            Stop.Subscribe(_ =>
            {
                StopServer();
            });

            StartServer();
        }

        public async void StartServer()
        {
            string[] args = new string[0];
            await qrserver.Program.RunServerAtPort(args, new string[1] { UriPath }, token, path, qrserver.ProgramAction.SEND);
        }

        public async void StopServer()
        {
            await qrserver.Program.StopServer();

        }
    }
}

