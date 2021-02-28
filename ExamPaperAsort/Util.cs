using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPaperAsort
{
    class Util
    {
        public static string getTimeString(int timeSec)
        {
            int hour = timeSec / 3600;
            int min = (timeSec - 3600 * hour) / 60;
            int seconds = timeSec % 60;

            return hour.ToString("D2") + ":" + min.ToString("D2") + ":" + seconds.ToString("D2");
        }

        public static OpenCvSharp.Point getCenterPoint(OpenCvSharp.Point[] pp)
        {
            int totalX = 0, totalY = 0;
            for (int i = 0; i < pp.Length; i++)
            {
                totalX += pp[i].X;
                totalY += pp[i].Y;
            }

            return new OpenCvSharp.Point(totalX / pp.Length, totalY / pp.Length);
        }

        public static double distance(OpenCvSharp.Point pt1, OpenCvSharp.Point pt2)
        {
            double x = Math.Pow(pt2.X - pt1.X, 2);
            double y = Math.Pow(pt2.Y - pt1.Y, 2);
            double length = Math.Sqrt(x + y);
            //Console.WriteLine(length);
            return length;
        }

        public static OpenCvSharp.Point[] getCCWList(OpenCvSharp.Point[] pp)
        {
            OpenCvSharp.Point[] alignedList = new OpenCvSharp.Point[4];
            OpenCvSharp.Point center = new OpenCvSharp.Point();
            for (int i = 0; i < pp.Length; i++)
            {
                center.X += pp[i].X;
                center.Y += pp[i].Y;
            }
            center.X = center.X / pp.Length;
            center.Y = center.Y / pp.Length;


            for (int i = 0; i < pp.Length; i++)
            {
                // left top
                if (pp[i].X < center.X && pp[i].Y < center.Y)
                {
                    alignedList[0] = pp[i];
                }
                // right top
                if (pp[i].X > center.X && pp[i].Y < center.Y)
                {
                    alignedList[1] = pp[i];
                }
                // right  bottom
                if (pp[i].X > center.X && pp[i].Y > center.Y)
                {
                    alignedList[2] = pp[i];
                }
                // left bottom
                if (pp[i].X < center.X && pp[i].Y > center.Y)
                {
                    alignedList[3] = pp[i];
                }
            }

            return alignedList;
        }
    }
}
