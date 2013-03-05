using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgoritmTimerApplication
{
    class MedianAlgorithmUnsafe11x11 : VisionAlgorithm
    {
        public MedianAlgorithmUnsafe11x11(String name): base(name)
        {
        }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            //auteur: Jonathan Smit

            unsafe
            {
                //afbeelding vastzetten in geheugen
                BitmapData originalData = sourceImage.LockBits(
                    new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                    ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                //hoeveel bytes per pixel (voor jpg, 24-bit, is dat 24 gedeeld door 8 bit is 3 byte)
                int pixelSize = 3;

                //ipv 3x3 array gewoon een int-array van 3x3=9 waarden
                int[] pixels = new int[121];

                //voor n-keer 11x11: afbeelding hoogte en breedte - 10
                for (int y = 0; y < sourceImage.Height - 10; y++)
                {

                    //adres van de eerste pixel in elke rij van de afbeelding (scan0)
                    //adres van de eerste pixel in de rij
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);
                    //voor het opslaan van de nieuwe gegevens beginnen we nog een rij lager
                    byte* nRow = (byte*)originalData.Scan0 + ((y + 1) * originalData.Stride);

                    int pixel;

                    for (int x = 0; x < sourceImage.Width - 10; x++)
                    {

                        //eerste rij
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

                        //tweede rij
                        oRow = (byte*)originalData.Scan0 + ((y + 1) * originalData.Stride);

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

                        //derde rij
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

                        //sorteer
                        Array.Sort(pixels);
                        //nieuwe pixel
                        pixel = pixels[4];

                        //nieuwe pixel ontleden en weer invoegen
                        nRow[x * pixelSize + 3] = (byte)(pixel & 0xFF);
                        nRow[x * pixelSize + 4] = (byte)((pixel >> 8) & 0xFF);
                        nRow[x * pixelSize + 5] = (byte)((pixel >> 16) & 0xFF);


                    }

                }

                //unlock the bitmaps
                sourceImage.UnlockBits(originalData);
                return sourceImage;
            }
        }

    }
}
