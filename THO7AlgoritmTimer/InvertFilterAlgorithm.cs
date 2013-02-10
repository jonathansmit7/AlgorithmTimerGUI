using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace THO7AlgoritmTimerApplication
{
    class InvertFilterAlgorithm : VisionAlgorithm
    {
        public InvertFilterAlgorithm(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            //create new bitmap from argument sourceImage
            Bitmap returnImage = new Bitmap(sourceImage);
            //get the width and height
            int w = returnImage.Width, h = returnImage.Height;
            //set up Alpha and RGB
            byte A, R, G, B;
            //set up max RGB (255), 0xFF
            int max = 0xFF; 
            //set up a Color for the pixel
            Color color;
            //loop trough every row(y)
            for (int y = 0; y < h; y++)  
            {
                //loop trough every row(x)
                for (int x = 0; x < w; x++)  
                {
                    //get the pixel
                    color = returnImage.GetPixel(x, y);
                    //set up the new values, without Alpha A
                    A = color.A;  
                    R = (byte)(max - color.R);  
                    G = (byte)(max - color.G);  
                    B = (byte)(max - color.B);
                    //set the new pixel
                    returnImage.SetPixel(x, y, Color.FromArgb(A, R, G, B));  
                }  
            }  
            //return the bitmap
            return returnImage;
        }
    }
}
