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
        BitmapImage bluePic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/blue.png", UriKind.Absolute));
        BitmapImage greenPic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/green.png", UriKind.Absolute));
        BitmapImage orangePic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/orange.png", UriKind.Absolute));
        BitmapImage purplePic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/purple.png", UriKind.Absolute));
        BitmapImage redPic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/red.png", UriKind.Absolute));

        List<BitmapImage> imgs = new List<BitmapImage>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        StackPanel getPanel(BitmapImage pic)
        {
            StackPanel sp = new StackPanel();
            Image img = new Image();
            img.Source = pic;

            sp.Children.Add(img);
            sp.Margin = new Thickness(1);
            return sp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            imgs.Add(bluePic);
            imgs.Add(greenPic);
            imgs.Add(orangePic);
            imgs.Add(purplePic);
            imgs.Add(redPic);

            Ugr.Children.Clear();
            Ugr.Rows = 6;
            Ugr.Columns = 6;

            Ugr.Width = 6 * (50 + 4);
            Ugr.Height = 6 * (50 + 4);

            Ugr.Margin = new Thickness(5, 5, 5, 5);

            Random rnd = new Random();

            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                {
                    Button btn = new Button();
                    btn.Tag = i;
                    btn.Width = 50;
                    btn.Height = 50;
                    btn.Content = " ";
                    btn.Margin = new Thickness(2);

                    btn.Click += Btn_Click;

                    StackPanel stackPnl = new StackPanel();
                    int r = rnd.Next(0, 5);
                    stackPnl = getPanel(imgs[r]);

                    btn.Content = stackPnl;
                    Ugr.Children.Add(btn);

                }
        }
    }
}
