using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPaperAsort
{
    class OMR
    {
        Bitmap bitmapPerspective;
        public String getExamineeNumber(String path)
        {
            OpenCvSharp.Point wh = getOMRImage(path);
            return getOMRString(wh);
        }

        private string getOMRString(OpenCvSharp.Point wh)
        {
            String[] chars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            String res = "";

            const int SMALL_OBJECT_MIN_AREA = 12;
            const int SMALL_OBJECT_THREADHOLD = 7;
            Mat src, gray, binary, canny;
            src = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmapPerspective);
            gray = new Mat();
            binary = new Mat();
            canny = new Mat();

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(gray, binary, 150, 255, ThresholdTypes.Binary);
            Cv2.Canny(binary, canny, 0, 0, 3);

            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(canny, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            List<OpenCvSharp.Point> smallObjectList = new List<OpenCvSharp.Point>();
            List<int> yList = new List<int>();
            List<OpenCvSharp.Point[]> rectObjectList = new List<OpenCvSharp.Point[]>();

            foreach (OpenCvSharp.Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                double area = Cv2.ContourArea(p, true);

                if (length < 100 && area < 1000 || p.Length < 5) continue;

                OpenCvSharp.Point[] hull = Cv2.ConvexHull(p, true);
                OpenCvSharp.Point[] pp = Cv2.ApproxPolyDP(p, 0.02 * length, true);
                if (pp.Length > SMALL_OBJECT_THREADHOLD && Math.Abs(area) < SMALL_OBJECT_MIN_AREA)
                {
                    OpenCvSharp.Point ppCenter = Util.getCenterPoint(pp);
                    smallObjectList.Add(ppCenter);

                    bool isExist = false;
                    foreach (int y in yList)
                    {
                        if (Math.Abs(y - ppCenter.Y) < SMALL_OBJECT_MIN_AREA * 2)
                        {
                            isExist = true;
                        }
                    }
                    if (isExist == false)
                    {
                        yList.Add(ppCenter.Y);
                    }
                }
            }

            int minExamineeRectX = 0;       
            int maxExamineeRectX = wh.X;    
            int maxExamineeRectY = wh.Y;    
            int widthExamineeRectItem = (maxExamineeRectX - minExamineeRectX) / 6;

                
            try
            {
                for (int i = 0; i < 6; i++)
                {
                    int minIndex = 0, minCount = int.MaxValue;
                    for (int k = 0; k < 10; k++)
                    {
                        int x = minExamineeRectX + widthExamineeRectItem * i + widthExamineeRectItem / 2;
                        int y = yList[k];
                        OpenCvSharp.Rect rect = new OpenCvSharp.Rect(x - 12, y - 12, 24, 24); // x, y, width, height

                        Mat matCircle = binary.SubMat(rect);
                        int nonzeroCount = Cv2.CountNonZero(matCircle);
                        matCircle.Dispose();

                        if (nonzeroCount < minCount)
                        {
                            minCount = nonzeroCount;
                            minIndex = 9 - k;
                        }
                    }
                    if (i == 0)
                    {
                        res = chars[minIndex];
                    }
                    else
                    {
                        res += minIndex;
                    }
                    //Console.WriteLine("i" + i + " index:" + minIndex);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                res = null;
            }
            finally
            {
                if (bitmapPerspective != null)
                    bitmapPerspective.Dispose();
            }

            
            return res;
        }

        private OpenCvSharp.Point getOMRImage(String path)
        {
            int offset = 100;

            Mat src, gray, binary, canny;

            src = Cv2.ImRead(path);
            Rect rect = new Rect(offset, offset, src.Width - offset * 2, src.Height - offset * 2);
            src = src.SubMat(rect);

            gray = new Mat();
            binary = new Mat();
            canny = new Mat();

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(gray, binary, 150, 255, ThresholdTypes.Binary);
            Cv2.Canny(binary, canny, 0, 0, 3);

            // width, height
            OpenCvSharp.Point pt = projectPerspective(src, canny);
            src.Dispose();
            gray.Dispose();
            binary.Dispose();
            canny.Dispose();

            return pt;
        }


        private OpenCvSharp.Point projectPerspective(Mat src, Mat canny)
        {

            OpenCvSharp.Point[] alignedPoints = Util.getCCWList(findMostOuterBoxCorner(canny));
            int width = (int)Util.distance(alignedPoints[0], alignedPoints[1]);
            int height = (int)Util.distance(alignedPoints[1], alignedPoints[2]);

            Point2f[] srcs = new Point2f[4];
            srcs[0] = new Point2f(alignedPoints[0].X, alignedPoints[0].Y);
            srcs[1] = new Point2f(alignedPoints[1].X, alignedPoints[1].Y);
            srcs[2] = new Point2f(alignedPoints[2].X, alignedPoints[2].Y);
            srcs[3] = new Point2f(alignedPoints[3].X, alignedPoints[3].Y);


            Point2f[] dests = new Point2f[4];
            dests[0] = new Point2f(0, 0);
            dests[1] = new Point2f(width, 0);
            dests[2] = new Point2f(width, height);
            dests[3] = new Point2f(0, height);


            Mat perspective = new Mat();
            //CvMat mapMatrix = Cv.GetPerspectiveTransform(srcPoint, dstPoint);
            //Cv.WarpPerspective(src, perspective, mapMatrix, Interpolation.Linear, CvScalar.ScalarAll(0));
            Mat matrix = Cv2.GetPerspectiveTransform(srcs, dests);
            Cv2.WarpPerspective(src, perspective, matrix, src.Size());


            bitmapPerspective = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(perspective);

            return new OpenCvSharp.Point(width, height);
        }

        private OpenCvSharp.Point[] findMostOuterBoxCorner(Mat canny)
        {
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(canny, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            int maxIndex = 0;
            double maxArea = double.MinValue;
            for (int i = 0; i < contours.Length; i++)
            {
                OpenCvSharp.Point[] p = contours[i];
                double length = Cv2.ArcLength(p, true);
                double area = Cv2.ContourArea(p, true);

                //if (Math.Abs(area) > maxArea)


                if (area > maxArea)
                {
                    maxArea = area;//maxArea = Math.Abs(area);
                    maxIndex = i;
                }
            }
            OpenCvSharp.Point[] p1 = contours[maxIndex];
            double length1 = Cv2.ArcLength(p1, true);

            OpenCvSharp.Point[] pp = Cv2.ApproxPolyDP(p1, 0.02 * length1, true);
            return pp;
        }
    }   
}
