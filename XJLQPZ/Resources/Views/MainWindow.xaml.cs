using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using XJLQPZ.Resources;
using XJLQPZ.core;
using Microsoft.Win32;
using XJLQPZ.Resources.Views;
using System.Threading;

namespace XJLQPZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void HoverAnimation(object sender, MouseEventArgs e)
        {
            ((Button)sender).Width = ((Button)sender).Width * 1.05;
            ((Button)sender).Height = ((Button)sender).Height * 1.05;
            ((Button)sender).Foreground = Brushes.Black;
            ((Button)sender).Background = Brushes.WhiteSmoke;    

        }

        private void UnHoverAnimation(object sender, MouseEventArgs e)
        {
            ((Button)sender).Width = ((Button)sender).Width - (((Button)sender).Width * .04762);
            ((Button)sender).Height = ((Button)sender).Height - (((Button)sender).Height * .04762);
            ((Button)sender).Foreground = Brushes.Black;
            ((Button)sender).Background = Brushes.Transparent;
        }

        private void ChangeView(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "Home":
                    View.Content = new Info();
                    break;
                case "workSheet":
                    Munkalap munkalap = new Munkalap(Log.filenames[Log.filenames.Count() - 1]);
                    munkalap.Show();
                    break;
                case "Payment":
                    if (Log.munkaLapok.Count > 0)
                    {
                        Fizetes fizetes = new();
                        fizetes.Show();
                    }
                    else {
                        MessageBox.Show("Please select at least one work before payemnt");
                    }
                    
                    break;
                case "Identity":
                    //View.Content = new Identity();
                    Identity identity = new();
                    identity.Show();
                    break;
            }
        }
        private void OpenFile(object sender, RoutedEventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog()
            {
                Title = "Choose the text file",
                Filter = "Text Document(.txt)|*.txt|CSV File(.csv)|*.csv"
            };
            View.Content = default;
            if (file.ShowDialog() == true)
            {
                //Clear Cache 
                Log.munkaLapok.Clear(); 
                try {
                    //To check if file is of right format or not
                    Loader<Work> loader = new();
                    loader.LoadFile(file.FileName, Parser.Parse);
                    MessageBox.Show($"{file.FileName} opened sucessfully");

                    Log.filenames.Add(file.FileName); //update log file
                    workSheet.IsEnabled = true;
                    Payment.IsEnabled = true;
                }
                catch {
                    MessageBox.Show($"{file.FileName}: Wrong Format File please try again");
                    workSheet.IsEnabled = false;
                    Payment.IsEnabled = false;
                }
                
            }
                
        }


        private void CloseProgram(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bisztosan akar kilépni?", "Exit", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else {
                App.Current.Shutdown();
            }

        }

        private void Close_program(object sender, RoutedEventArgs e)
        {
            Close();        }
    }
}
