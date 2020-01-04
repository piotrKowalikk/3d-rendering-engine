using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    static public class ScanLine
    {
        //mesh is needed for colors - it resolves one mesh per time
        static public Bitmap GetBitmap(Color[,] newPhoto, List<Triangle> t, Mesh m)
        {

            var triangles2 = t;
            //TODO:
            Color [] colors = new Color[] { Color.Black, Color.Yellow, Color.Green, Color.Red, Color.Blue, Color.Pink, Color.DarkViolet, Color.Silver, Color.Cyan, Color.Crimson };
            int i = 0;
            foreach (var triangle in triangles2)
            {
                if ((triangle.A.X > 0 && triangle.A.Y > 0 && triangle.B.X > 0 && triangle.B.Y > 0 && triangle.C.X > 0 && triangle.C.Y > 0) && (triangle.A.X < newPhoto.GetLength(0) && triangle.A.Y < newPhoto.GetLength(1) && triangle.B.X < newPhoto.GetLength(0) && triangle.B.Y < newPhoto.GetLength(1) && triangle.C.X < newPhoto.GetLength(0) && triangle.C.Y < newPhoto.GetLength(1)))
                    ScanLine.FillPolygonNormal(triangle, colors[i / 2], newPhoto);
                i++;
            }

            Bitmap processedBitmap = new Bitmap(newPhoto.GetLength(0), newPhoto.GetLength(1));
            unsafe
            {
                BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        currentLine[x] = newPhoto[x / 4, y].B;
                        currentLine[x + 1] = newPhoto[x / 4, y].G;
                        currentLine[x + 2] = newPhoto[x / 4, y].R;
                        currentLine[x + 3] = newPhoto[x / 4, y].A;
                    }
                });
                processedBitmap.UnlockBits(bitmapData);
            }
            return processedBitmap;
        }

        static public void FillPolygonNormal(Triangle t, Color color, Color[,] newPhoto)
        {
            List<Edge> edges = t.GetEdges();
            List<Edge>[] ET = EdgeBucketSort(edges, newPhoto.GetLength(1));
            int edgesCounter = edges.Count;
            int y = 0;
            while (ET[y] == null)
                y++;

            List<(double yMax, double xMin, double m)> AET = new List<(double, double, double)>();

            while (edgesCounter != 0 || AET.Any())
            {
                if (ET.Length == y)
                    break;
                AET.RemoveAll(x => x.yMax == y);

                if (ET[y] != null)
                {
                    foreach (Edge edge in ET[y])
                    {
                        double mx = ((double)edge.p2.X - (double)edge.p1.X) / ((double)edge.p2.Y - (double)edge.p1.Y);
                        if (edge.p1.Y != edge.p2.Y)
                            AET.Add((edge.p2.Y, edge.p1.X, mx));
                        edgesCounter--;
                    }
                }

                AET.Sort((a, b) => a.xMin.CompareTo(b.xMin));

                for (int i = 0; i < AET.Count; i += 2)
                    for (int j = (int)(AET[i].xMin); j < (int)(AET[i + 1].xMin); j++)
                        newPhoto[j, y] = color;

                y++;
                for (int i = 0; i < AET.Count; i++)
                    AET[i] = (AET[i].yMax, AET[i].xMin + AET[i].m, AET[i].m);
            }
        }

        static private List<Edge>[] EdgeBucketSort(List<Edge> edges, int height)
        {
            List<Edge>[] result = new List<Edge>[height];

            foreach (Edge edge in edges)
            {
                int index = (int)(edge.p1.Y < edge.p2.Y ? edge.p1.Y : edge.p2.Y);

                if (result[index] == null)
                    result[index] = new List<Edge>();

                result[index].Add(edge);
            }

            return result;
        }


    }
}
