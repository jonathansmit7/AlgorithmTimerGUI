using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace THO7AlgoritmTimerApplication
{
    class BlackFilterAlgorithm : VisionAlgorithm
    {
        public BlackFilterAlgorithm(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            //create new bitmap from argument sourceImage
            Bitmap returnImage = new Bitmap(sourceImage);
            //get the width and height
            int w = returnImage.Width, h = returnImage.Height;
            //loop through every row (y) 
            for (int y = 0; y < h; y++)
            {
                //loop through every column (x)
                for (int x = 0; x < w; x++)
                {
                    //color every x
                    returnImage.SetPixel(x, y, Color.Black);
                }
            }  
            //return the bitmap
            return returnImage;
        }
    }

}
