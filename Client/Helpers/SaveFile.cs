using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Tyonohjaus.Classes.Helpers
{
    public static class FileHandler
    {
        const string folderPath = "C:\\Nipema\\tuotekuvat\\";
        public static bool SaveFile(string nimikekoodi, byte[] bytes)
        {

            var filePath = "";

            System.IO.File.WriteAllBytes(filePath, bytes);
            /*
            int desired_x_dpi = 96;
            int desired_y_dpi = 96;
            using (var ms = new MemoryStream())
            {
                using (var rasterizer = new GhostscriptRasterizer())
                {
                    rasterizer.Open(fullPath);

                    var img = rasterizer.GetPage(desired_x_dpi, desired_y_dpi, 1);
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    var newPath = fullPath.Replace(".pdf", ".png");

                    File.WriteAllBytes(newPath, ms.ToArray());
                }
                BitmapImage myBitmap = new BitmapImage();
                myBitmap.BeginInit();
                myBitmap.StreamSource = ms;
                myBitmap.EndInit();
                return myBitmap;
            }*/
                return true;
        }
    }
}
