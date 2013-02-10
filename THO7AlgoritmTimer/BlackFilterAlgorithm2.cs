using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace THO7AlgoritmTimerApplication
{
    class BlackFilterAlgorithm2 : VisionAlgorithm
    {
        public BlackFilterAlgorithm2(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            //create new bitmap from argument sourceImage
            Bitmap returnImage = new Bitmap(sourceImage);
            //get the width and height
            int w = returnImage.Width, h = returnImage.Height;
            //create new Graphic from returnImage
            Graphics g = Graphics.FromImage(returnImage);
            //create new rectangle with returnImage measurements
            Rectangle rect = new Rectangle(0, 0, w, h);
            //create linearbrush to fill the rectangel from right-upper to lower-left with black color
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Black, Color.Black, LinearGradientMode.BackwardDiagonal);
            //write the rectangle on the returnImage
            g.FillRectangle(brush, rect);
            //return the bitmap
            return returnImage;
        }
    }
}
