using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace THO7AlgoritmTimerApplication
{
    class MedianAlgorithm : VisionAlgorithm
    {
        public MedianAlgorithm(String name) : base(name) 
        { 
        }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            Bitmap returnImage = new Bitmap(sourceImage);
            //get the width and height
            int nx = returnImage.Width - 2, ny = returnImage.Height - 2;
            //make int-array
            int[] k = new int[9];
            //loop through every row (y) 
            for (int y = 0; y < ny; y++)
            {
                //loop through every column (x)
                for (int x = 0; x < nx; x++)
                {
                    k[0] = returnImage.GetPixel(x, y).ToArgb();
                    k[1] = returnImage.GetPixel(x + 1, y).ToArgb();
                    k[2] = returnImage.GetPixel(x + 2, y).ToArgb();
                    //regel 2
                    k[3] = returnImage.GetPixel(x, y + 1).ToArgb();
                    k[4] = returnImage.GetPixel(x + 1, y + 1).ToArgb();
                    k[5] = returnImage.GetPixel(x + 2, y + 1).ToArgb();
                    //regel 3
                    k[6] = returnImage.GetPixel(x, y + 2).ToArgb();
                    k[7] = returnImage.GetPixel(x + 1, y + 2).ToArgb();
                    k[8] = returnImage.GetPixel(x + 2, y + 2).ToArgb();

                    Array.Sort(k);

                    //color every x
                    returnImage.SetPixel(x, y, Color.FromArgb(k[4]));
                }
            }  
            return returnImage;
        }
    }
}
