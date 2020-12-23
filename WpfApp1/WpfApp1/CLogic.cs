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

        public void PickUp(int i, int j) //перемещение ячеек 
        {

            if (picked == null)
            {
                picked = new Point(i, j);
            }
            else if (picked != null)
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
        
    }
}
