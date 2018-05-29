using System;
using System.Linq;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Nipema.Tyonohjaus.Client.Helpers
{
    public static class Conversions
    {
        public static BitmapImage ImgFromBytes(byte[] bytes)
        {
            try
            {
                MemoryStream ms = new MemoryStream(bytes);
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = ms;
                img.DecodePixelWidth = 200;
                img.EndInit();
                return img;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public static BitmapImage ImgFromString(string filePath)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(filePath);
                MemoryStream ms = new MemoryStream(bytes);
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = ms;
                img.DecodePixelWidth = 200;
                img.EndInit();
                return img;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
