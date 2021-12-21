using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;
using System.IO;

namespace WpfApp13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Random r = new Random();
        public int second = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;

            if (textbox.Text != "")
            {
                myMediaElement.IsEnabled = false;
                //myMediaElement.Stop();
                
                myMediaElement.Play();
                myMediaElement.Visibility = Visibility.Visible;
                timer.Start();
            }
            else
            {
                MessageBox.Show("Ты не ввёл вопрос( Попробуй еще раз");
            }
            while (myMediaElement.CanPause == false) { }
            int count = System.IO.File.ReadAllLines("text.txt").Length;
            int num = r.Next(0, count);
            string h = "";
            h = File.ReadLines("text.txt").ElementAt(num);
            label1.Content = "Шар ответил... " + "\n" + h;
            //myMediaElement.Visibility = Visibility.Hidden;

        }
        void timer_Tick(object sender, EventArgs e)
        {
            second++;
            if (second == 6)
            {
                myMediaElement.Visibility = Visibility.Hidden;
                textbox.Text = "";
                timer.IsEnabled = false;
            }
        }
    }
}