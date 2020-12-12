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
        Point picked = null;
        Random rnd = new Random();

        public CLogic(int[,] field)
        {
            filed = field;
        }

        public class Point
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

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public int getCell(int i, int j)
        {
            return filed[i, j];
        }

        public void PickUp(int i, int j)
        {

            if (picked == null)
            {
                picked = new Point(i, j);
            }
            else if (picked != null) //условия для того чтобы по всему полю не ходить
            {
                if (Math.Abs(picked.X - i) == 1 || Math.Abs(picked.Y - j) == 1)
                {
                    int color1 = filed[picked.X, picked.Y];
                    int color2 = filed[i, j];
                    filed[picked.X, picked.Y] = color2;
                    filed[i, j] = color1;
                    picked = null;
                }

            }
        }

        List<Point> chainFinderX(int i, int j)
        {
            List<Point> left = new List<Point>();
            List<Point> right = new List<Point>();
            int color = filed[i, j];

            //смотрим ячейки слева
            for (int x = 0; x < i; x++)
            {

                if (filed[x, j] == color)
                {
                    left.Add(new Point(x, j));
                }
                else
                {
                    left.Clear();
                }
            }
            for (int x = N - 1; x > i; x--)
            {

                if (filed[x, j] == color)
                {
                    right.Add(new Point(x, j));
                }
                else
                {
                    right.Clear();
                }
            }
            List<Point> res = new List<Point>();
            res.Add(new Point(i, j));
            res.AddRange(left);
            res.AddRange(right);
            return res;
        }

        List<Point> chainFinderY(int i, int j)
        {
            int color = filed[i, j];
            List<Point> top = new List<Point>();
            List<Point> bottom = new List<Point>();
            //смотрим ячейки слева
            for (int y = 0; y < j; y++)
            {

                if (filed[i, y] == color)
                {
                    top.Add(new Point(i, y));
                }
                else
                {
                    top.Clear();
                }
            }
            for (int y = N - 1; y > j; y--)
            {

                if (filed[i, y] == color)
                {
                    bottom.Add(new Point(i, y));
                }
                else
                {
                    bottom.Clear();
                }
            }
            List<Point> res = new List<Point>();
            res.Add(new Point(i, j));
            res.AddRange(top);
            res.AddRange(bottom);
            return res;
        }

        public List<Point> findLargest(int i, int j)
        {
            var Horizontal = chainFinderX(i, j);
            var Vertical = chainFinderY(i, j);
            int[,] filednew = (int[,])filed.Clone();

            List<Point> largest;

            if (Horizontal.Count >= Vertical.Count)
            {
                largest = Horizontal;
                foreach (Point p in Horizontal)
                {
                    filednew[p.X, 0] = rnd.Next(0, 5);
                    for (int y = 1; y <= p.Y; y++)
                    {
                        filednew[p.X, y] = filed[p.X, y - 1];
                    }
                }
                filed = (int[,])filednew.Clone();
            }
            else
            {
                largest = Vertical;
            }

            if (largest.Count >= 3)
            {
                return largest;
            }
            else
            {
                return null;
            }


        }
    }
}
