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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage voidPic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/void.png", UriKind.Absolute));
        BitmapImage bluePic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/blue.png", UriKind.Absolute));
        BitmapImage greenPic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/green.png", UriKind.Absolute));
        BitmapImage orangePic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/orange.png", UriKind.Absolute));
        BitmapImage purplePic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/purple.png", UriKind.Absolute));
        BitmapImage redPic = new BitmapImage(new Uri(@"pack://application:,,,/Resources/red.png", UriKind.Absolute));

        List<BitmapImage> imgs = new List<BitmapImage>();
        Random rnd = new Random();
        DispatcherTimer timer = new DispatcherTimer();
        CLogic CL = null;
        Button[,] filed = new Button[6, 6];
        public static int N = 6; //размер поля

        public MainWindow()
        {
            InitializeComponent();
        }

        StackPanel getPanel(BitmapImage pic)//функция для добавления картинок
        {
            StackPanel sp = new StackPanel();
            Image img = new Image();
            img.Source = pic;

            sp.Children.Add(img);
            sp.Margin = new Thickness(1);
            return sp;
        }

        void updateFiled()//функция обновления поля
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    int color = CL.getCell(i, j);
                    StackPanel stackPnl = getPanel(imgs[color]);

                    if (CL.getCell(i, j) == 1)
                    {

                    }

                    filed[i, j].Content = stackPnl;

                }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)//Кнопки в ячейках
        {
            int ind = ((int)((Button)sender).Tag);
            int x = ind % N;
            int y = ind / N;

            if (namebox.Text == "")
            {
                MessageBox.Show("Введите имя !");
            }
            else
            {
                CL.PickUp(x, y);
                updateFiled();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) //генерация поля
        {
            start.Content = "Restart";

            imgs.Add(voidPic);
            imgs.Add(bluePic);
            imgs.Add(greenPic);
            imgs.Add(orangePic);
            imgs.Add(purplePic);
            imgs.Add(redPic);
            Ugr.Children.Clear();
            Ugr.Rows = 6;
            Ugr.Columns = 6;

            Ugr.Width = N * (50 + 4);
            Ugr.Height = N * (50 + 4);

            Ugr.Margin = new Thickness(5, 5, 5, 5);
            int[,] mast = new int[N, N];

            for (int y = 0; y < N; y++)
                for (int x = 0; x < N; x++)
                {
                    filed[x, y] = new Button();
                    filed[x, y].Tag = x + y * 6;
                    filed[x, y].Width = 50;
                    filed[x, y].Height = 50;
                    filed[x, y].Content = " ";
                    filed[x, y].Margin = new Thickness(2);
                    filed[x, y].Click += Btn_Click;
                    StackPanel stackPnl = new StackPanel();

                    int r = rnd.Next(1, 6);
                    mast[x, y] = r;

                    Ugr.Children.Add(filed[x, y]);
                    stackPnl = getPanel(imgs[r]);

                    filed[x, y].Content = stackPnl;
                }
            CL = new CLogic(mast, score, Move, scorelist, namebox);
            CL.Score();
            CL.move();
        }

        private void Falled(object sender, EventArgs args)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                updateFiled();
            });
        }
    }
}
