using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class CLogic
    {
        public static int N = 6;

        int[,] filed = new int[6, 6];
        Points picked = null;
        Random rnd = new Random();

        public CLogic(int[,] field)
        {
            filed = field;
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
                    int color1 = filed[picked.X, picked.Y];
                    int color2 = filed[x, y];
                    filed[picked.X, picked.Y] = color2;
                    filed[x, y] = color1;
                    picked = null;
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

    }
}
