using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Processes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Process.Start("calc");
            //Process.Start("notepad");
            //Process.Start("mspaint");
            //Process.Start("cmd");
            //Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");
            //processTextBox.Text = Process.GetCurrentProcess().ProcessName.ToString();
            //processTextBox.Text = Process.GetCurrentProcess().Id.ToString();
            //processTextBox.Text = Process.GetCurrentProcess().PriorityClass.ToString();

            //for (int i = 0; i < 5; i++)
            //{
            //    Process.Start("notepad");
            //    Thread.Sleep(100);
            //}
            //var message = new StringBuilder();
            //var proc = Process.GetProcessesByName("notepad");
            //foreach (var procInfo in proc)
            //{
            //    message.Append($"{procInfo.Id} ");
            //    procInfo.Kill();
            //    Thread.Sleep(500);
            //}
            //processTextBox.Text = message.ToString();


            //var processes = Process.GetProcesses();

            //foreach (var process in processes)
            //{
            //    processLstBox.Items.Add(process.ProcessName);
            //}
            //
            //    Process.Start("calc").WaitForExit();
            //    Thread.Sleep(100);
            //    Process.Start("notepad").WaitForExit();
            //    Thread.Sleep(100);
            //    Process.Start("mspaint").WaitForExit();
        }
    }
}
