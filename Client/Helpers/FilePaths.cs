using System.IO;

namespace Nipema.Tyonohjaus.Client.Helpers
{
    public class FilePaths
    {
        public static string InstallPath
        {
            get { return Path.Combine(@"C:\", "Nipema"); }
        }

        public static string ProductImagesFolder
        {
            get {
                string path = Path.Combine(InstallPath, "tuotekuvat");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return path;
            }
        }
        public static string PdfFolder
        {
            get
            {
                string path = Path.Combine(InstallPath, "pdf");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return path;
            }
        }
        public static string GetTuotekuva(string nimikekoodi)
        {
            var path = "C:\\Nipema\\tuotekuvat\\";
            foreach (var x in new[] { "jpg", "png", "pdf" })
            {
                var fullPath = $"{path}{nimikekoodi}.{x}";
                if (File.Exists(fullPath))
                {
                    path = fullPath;
                    break;
                }

            }
            return path;
        }
        public static string GetOhjekuva(int ohje, string nimikekoodi)
        {
            var path = "C:\\Nipema\\tuotekuvat\\";
            var fileExtensions = new[] { "jpg", "png", "pdf" };

            foreach (var x in fileExtensions)
            {
                var fullPath = $"{path}{nimikekoodi}_{ohje}.{x}";
                if (File.Exists(fullPath))
                {
                    path = fullPath;
                    break;
                }
            }
            if (path == "C:\\Nipema\\tuotekuvat\\")
            {
                foreach (var x in fileExtensions)
                {
                    var fullPath = $"{path}{nimikekoodi}.{x}";
                    if (File.Exists(fullPath))
                    {
                        path = fullPath;
                        break;
                    }
                    
                }
            }
            if (path == "C:\\Nipema\\tuotekuvat\\")
            {
                path = $"{path}fallback{ohje}.png";
            }
            return path;
        }
        public static string CreateProductImagePath(string productNumber, string fileExtension)
        {
            return Path.Combine(
                        ProductImagesFolder, 
                        string.Format("{0}.{1}", productNumber, fileExtension));
        }
    }
}
