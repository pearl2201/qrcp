using Qrdesktop.Models;
using Qrdesktop.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
namespace Qrdesktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        Process myProcess;
        public MainWindowViewModel(Database db)
        {
            Content = List = new TodoListViewModel(db.GetItems());
        }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public TodoListViewModel List { get; }

        public void AddItem()
        {
            var vm = new AddItemViewModel();

            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (TodoItem)null))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        List.Items.Add(model);
                    }

                    Content = List;
                });

            Content = vm;
        }

        public void OpenServer()
        {
            try
            {
                //{
                //    myProcess = new Process();


                //    myProcess.StartInfo.UseShellExecute = true;
                //    // You can start any process, HelloWorld is a do-nothing example.
                //    myProcess.StartInfo.FileName = @"F:\Ann\Dev\learn\csharp\qrcp\qrserver\bin\Debug\netcoreapp3.1\qrserver.exe";
                //    myProcess.StartInfo.CreateNoWindow = false;
                //    myProcess.StartInfo.Arguments = "--send F:\\Ann\\Dev\\temp\\dst_dir\\Test.cs";
                //    myProcess.Start();
                //    // This code assumes the process you are starting will terminate itself.
                //    // Given that is is started without a window so you cannot terminate it
                //    // on the desktop, it must terminate itself or you can do it programmatically
                //    // from this application using the Kill method.
                // The Work to perform on another thread 
                ThreadStart start = delegate ()
                {
                    // ... 
                    // This will throw an exception 
                    // (it's on the wrong thread) 
                    //qrserver.Program.Main("");
                    string[] args = new string[1] { "--send F:\\Ann\\Dev\\temp\\dst_dir\\Test.cs" };
                    qrserver.Program.RunServerAtPort(args, new string[1]{"http://localhost:8080"});
                };
                // Create the thread and kick it started! 
                new Thread(start).Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
