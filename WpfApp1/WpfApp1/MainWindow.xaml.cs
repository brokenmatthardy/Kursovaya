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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage blue = new BitmapImage(new Uri(@"pack://application:,,,/Resources/blue.png", UriKind.Absolute));
        BitmapImage green = new BitmapImage(new Uri(@"pack://application:,,,/Resources/green.png", UriKind.Absolute));
        BitmapImage orange = new BitmapImage(new Uri(@"pack://application:,,,/Resources/orange.png", UriKind.Absolute));
        BitmapImage purple = new BitmapImage(new Uri(@"pack://application:,,,/Resources/purple.png", UriKind.Absolute));
        public MainWindow()
        {
            InitializeComponent();

            Ugr.Rows = 6;
            Ugr.Columns = 6;

            Ugr.Width = 6 * (50 + 4);
            Ugr.Height = 6 * (50 + 4);

            Ugr.Margin = new Thickness(5, 5, 5, 5);

            for (int i = 0; i < 6 * 6; i++)
                {
                Button btn = new Button();
                btn.Tag = i;
                btn.Width = 50;
                btn.Height = 50;
                btn.Content = " ";
                btn.Margin = new Thickness(2);
                btn.Click += Btn_Click;
                   
                Image img = new Image();
                img.Source = blue;
                StackPanel stackPnl = new StackPanel();
                stackPnl.Margin = new Thickness(1);
                stackPnl.Children.Add(img);
                btn.Content = stackPnl;
                Ugr.Children.Add(btn);

                }

        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
