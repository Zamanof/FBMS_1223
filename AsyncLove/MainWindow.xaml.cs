using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace AsyncLove
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string url = @"https://turbo.az/";
        WebClient webClient = new();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SimpleDownlad(object sender, RoutedEventArgs e)
        {
            var txt = webClient.DownloadString(url);           
            contentTextBox.Text = txt;
        }

        private void DontClick(object sender, RoutedEventArgs e)
        {
            var tsk = webClient.DownloadStringTaskAsync(url);
            contentTextBox.Text = tsk.Result;
        }

        private void TaskDownload(object sender, RoutedEventArgs e)
        {
            var tsk = webClient.DownloadStringTaskAsync(url)
                .ContinueWith((t) =>
                {
                    contentTextBox.Text = t.Result;
                }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void TaskContext(object sender, RoutedEventArgs e)
        {
            var context = SynchronizationContext.Current;
            var tsk = webClient.DownloadStringTaskAsync(url)
                .ContinueWith((t) =>
                {
                    context.Send(_ =>
                    {
                        contentTextBox.Text = t.Result;
                    }, null);
                });

        }

        private async void AwaitDownload(object sender, RoutedEventArgs e)
        {
            var txt = await webClient.DownloadStringTaskAsync(url);
            contentTextBox.Text = txt;
        }

        private void ClearMethod(object sender, RoutedEventArgs e)
        {
            contentTextBox.Clear();
        }
    }
}
