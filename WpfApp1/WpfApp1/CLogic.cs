using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class CLogic
    {
        public static int N = 6;

        int[,] filed = new int[6, 6];
        Points picked = null;
        Random rnd = new Random();
        int score = 0;
        TextBlock m_score = null;
        TextBlock Move = null;
        ListBox RecordList;
        TextBox Name;
        int MoveCount = 20;

        public CLogic(int[,] field, TextBlock m_score, TextBlock Move, ListBox RecordList, TextBox Name)
        {
            filed = field;
            this.m_score = m_score;
            this.Move = Move;
            this.RecordList = RecordList;
            this.Name = Name;
        }

        public class Points
        {
            public int X
            {
                get;
                set;
            }
            public int Y
            {
                get;
                set;
            }

            public Points(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public int getCell(int x, int y)
        {
            return filed[x, y];
        }

        public void PickUp(int x, int y) //перемещение ячеек 
        {
            if (picked == null)
            {
                picked = new Points(x, y);
            }
            else if (picked != null)
            {
                if (Math.Abs(picked.X - x) == 1 || Math.Abs(picked.Y - y) == 1)
                {
                    if (MoveCount == 0)
                    {
                        MessageBox.Show("Ходы закончились !");
                        RecordList.Items.Add(score + " очков " + " - " + Name.Text);
                    }
                    else
                    {
                        MoveCount--;
                        int color1 = filed[picked.X, picked.Y];
                        int color2 = filed[x, y];
                        filed[picked.X, picked.Y] = color2;
                        filed[x, y] = color1;
                        picked = null;
                        Move.Text = " " + MoveCount;
                    }
                }

            }
        }

        void chainFinderX(List<Point> res, int x, int y) //рекурсия
        {
            if (x + 1 >= 6) return;
            else
            {
                if (filed[x, y] == filed[x + 1, y]) //если следующая ячейка содержит такие же координаты
                {
                    if (filed[x, y] == 0)
                        return;
                    res.Add(new Point(x + 1, y));
                    chainFinderX(res, x + 1, y); //добавляем координаты ячейки в лист
                }
                else
                {
                    return;
                }

            }
        }

        void chainFinderY(List<Point> res, int x, int y)//рекурсия 
        {
            if (y + 1 >= 6) return;
            else
            {
                if (filed[x, y] == filed[x, y + 1]) //если следующая ячейка содержит такие же координаты
                {
                    if (filed[x, y] == 0)
                        return;
                    res.Add(new Point(x, y + 1));
                    chainFinderY(res, x, y + 1); //добавляем координаты ячейки в лист
                }
                else
                {
                    return;
                }

            }
        }

        public void checkChain(int minChain)
        {
            List<Point> resX = new List<Point>();
            List<Point> resY = new List<Point>();
            List<Point> res = new List<Point>();
            for (int x = 0; x < 6; x++)
                for (int y = 0; y < 6; y++)
                {
                    resX.Clear();
                    resX.Add(new Point(x, y));
                    chainFinderX(resX, x, y);


                    resY.Clear();
                    resY.Add(new Point(x, y));
                    chainFinderY(resY, x, y);

                    if (resX.Count >= minChain)
                    {
                        res.AddRange(resX);
                    }
                    if (resY.Count >= minChain)
                    {
                        res.AddRange(resY);
                    }
                }
                foreach (Point p in res)
                {
                    filed[(int)p.X, (int)p.Y] = 0;
                }
            score += 25 * res.Count;
            m_score.Text = " " + score;
        }
        public void Score()
        {
            m_score.Text = "0";
        }

        public void move()
        {
            Move.Text = "20";
        }

        public void shift()
        {
            for (int y = 5; y >= 0; y--)
                for (int x = 0; x < 6; x++)
                {
                    if (filed[x, y] == 0)
                    {
                        for (int y2 = y - 1; y2 >= 0; y2--)
                        {
                            if (filed[x, y2] != 0)
                            {
                                filed[x, y] = filed[x, y2];
                                filed[x, y2] = 0;
                                break;
                            }
                        }
                    }
                }
            fill();
        }
        //функция заполнения новыми элементами
        public void fill()
        {
            for (int x = 0; x < 6; x++)
                for (int y = 0; y < 6; y++)
                {
                    if (filed[x, y] == 0)
                        filed[x, y] = rnd.Next(1, 6);
                }
        }
        //задержка
    }
}
