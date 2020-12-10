using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    class CLogic
    {
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

        }

        public int getCell(int i, int j)
        {
            return filed[i, j];
        }

        public void PickUp(int i, int j)
        {

            if (picked == null)
            {
                picked = new Points
                {
                    X = i,
                    Y = j
                };

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
            List<Point> res = new List<Point>();
            int color = filed[i, j];
            //смотрим ячейки слева
            for (int x = i - 1; x >= 0; x--)
            {

                if (filed[x, j] == color)
                {
                    res.Add(new Point(x, j));
                }
                else
                {
                    break;
                }
            }
            for (int x = i + 1; x <= 5; x++)
            {

                if (filed[x, j] == color)
                {
                    res.Add(new Point(x, j));
                }
                else
                {
                    break;
                }
            }
            return res;
        }

        List<Point> chainFinderY(int i, int j)
        {
            int color = filed[i, j];
            List<Point> res = new List<Point>();
            //смотрим ячейки слева
            for (int y = j - 1; y >= 0; y--)
            {

                if (filed[i, y] == color)
                {
                    res.Add(new Point(i, y));
                }
                else
                {
                    break;
                }
            }
            for (int y = j + 1; y <= 5; y++)
            {

                if (filed[i, y] == color)
                {
                    res.Add(new Point(i, y));
                }
                else
                {
                    break;
                }
            }
            return res;
        }


        public List<Point> findLargest(int i, int j)
        {
            var Horizontal = chainFinderX(i, j);
            var Vertical = chainFinderY(i, j);
            int[,] filednew = (int[,])filed.Clone();

            List<Point> largest;

            if (Horizontal.Count > Vertical.Count)
            {
                largest = Horizontal;
                //foreach (Point p in Horizontal)
                //{
                //    filednew[p.X, 0] = filed[p.X, rnd.Next(0, 5)];
                //    for (int y = 1; y <= p.Y; y++)
                //    {
                //        filednew[p.X, y] = filed[p.X, y - 1];
                //    }
                //}
                //filed = (int[,])filednew.Clone();
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
