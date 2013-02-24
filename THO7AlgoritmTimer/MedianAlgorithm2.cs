using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgoritmTimerApplication
{
    class MedianAlgorithm2 : VisionAlgorithm
    {
        public MedianAlgorithm2(String name) : base(name) 
        { 
        }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            unsafe
            {
                //create an empty bitmap the same size as original
                Bitmap newBitmap = new Bitmap(sourceImage.Width, sourceImage.Height);

                //lock the original bitmap in memory
                BitmapData originalData = sourceImage.LockBits(
                    new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                    ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); //ImageLockMode.ReadOnly

                /*
                //lock the new bitmap in memory
                BitmapData newData = newBitmap.LockBits(
                   new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                   ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                */

                //set the number of bytes per pixel
                int pixelSize = 3;

                int pixel = 0;

                int[] pixels = new int[9];

                /* kopie maken
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);

                    for (int x = 0; x < sourceImage.Width; x++)
                    {
                        //save B,G,R for newData
                        nRow[x * pixelSize] = oRow[x * pixelSize]; //B
                        nRow[x * pixelSize + 1] = oRow[x * pixelSize + 1]; //G
                        nRow[x * pixelSize + 2] = oRow[x * pixelSize + 2]; //R
                    }
                }
                */

                for (int y = 0; y < sourceImage.Height - 2; y++)
                {

                    //get the data from the original image
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);

                    //byte* nRow = (byte*)newData.Scan0 + ((y + 1) * newData.Stride);

                    byte* nRow = (byte*)originalData.Scan0 + ((y + 1) * originalData.Stride);

                    for (int x = 0; x < sourceImage.Width - 2; x++)
                    {

                        pixel = 0;
                        pixel = oRow[x * pixelSize];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 1];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 2];
                        pixels[0] = pixel;

                        pixel = 0;
                        pixel = oRow[x * pixelSize + 3];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 4];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 5];
                        pixels[1] = pixel;

                        pixel = 0;
                        pixel = oRow[x * pixelSize + 6];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 7];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 8];
                        pixels[2] = pixel;

                        oRow = (byte*)originalData.Scan0 + ( (y + 1) * originalData.Stride);

                        pixel = 0;
                        pixel = oRow[x * pixelSize];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 1];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 2];
                        pixels[3] = pixel;

                        pixel = 0;
                        pixel = oRow[x * pixelSize + 3];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 4];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 5];
                        pixels[4] = pixel;

                        pixel = 0;
                        pixel = oRow[x * pixelSize + 6];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 7];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 8];
                        pixels[5] = pixel;

                        oRow = (byte*)originalData.Scan0 + ((y + 2) * originalData.Stride);

                        pixel = 0;
                        pixel = oRow[x * pixelSize];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 1];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 2];
                        pixels[6] = pixel;

                        pixel = 0;
                        pixel = oRow[x * pixelSize + 3];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 4];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 5];
                        pixels[7] = pixel;

                        pixel = 0;
                        pixel = oRow[x * pixelSize + 6];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 7];
                        pixel = (pixel << 8) | oRow[x * pixelSize + 8];
                        pixels[8] = pixel;

                        Array.Sort(pixels);

                        pixel = pixels[4];

                        nRow[x * pixelSize + 3] = (byte)(pixel & 0xFF);
                        nRow[x * pixelSize + 4] = (byte)((pixel >> 8) & 0xFF);
                        nRow[x * pixelSize + 5] = (byte)((pixel >> 16) & 0xFF);


                    }

                }

                //unlock the bitmaps
                //newBitmap.UnlockBits(newData);
                sourceImage.UnlockBits(originalData);

                //return newBitmap;
                return sourceImage;
            }
        }
    }
}
