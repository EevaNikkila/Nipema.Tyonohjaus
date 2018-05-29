using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nipema.Tyonohjaus.Models
{
    [Table("Ohjeet")]
    public class Ohje
    {
        [Key]
        public string NimikekoodiRef { get; set; }
        public string Ohjeteksti1 { get; set; }
        public string Ohjeteksti2 { get; set; }
        public string Ohjeteksti3 { get; set; }
        public string OhjekuvaPolku1 { get; set; }
        public string OhjekuvaPolku2 { get; set; }
        public string OhjekuvaPolku3 { get; set; }


        public System.Collections.Generic.List<string> GetFilePaths()
        {
            return new System.Collections.Generic.List<string>()
            {
                OhjekuvaPolku1, OhjekuvaPolku2, OhjekuvaPolku3
            };
        }

        public string GetOhjeteksti(int ohjetyyppi = 1)
        {
            switch (ohjetyyppi)
            {
                case 1:
                    return Ohjeteksti1;
                case 2:
                    return Ohjeteksti2;
                case 3:
                    return Ohjeteksti3;
            }
            return string.Empty;
        }
        public string GetOhjekuvaPolku(int ohjetyyppi = 1)
        {
           /* switch (ohjetyyppi)
            {
                case 1:
                    return OhjekuvaPolku1;
                case 2:
                    return OhjekuvaPolku2;
                case 3:
                    return OhjekuvaPolku3;
            }*/
           // return string.Empty;
           string tuotekuva = string.Format("C:\\Nipema\\tuotekuvat\\{0}_{1}.{2}",
                    NimikekoodiRef,
                    ohjetyyppi,
                    ".pdf");
            return tuotekuva;
        }
        public string SetOhjekuvaPolku(int ohjetyyppi, string path)
        {
            switch (ohjetyyppi)
            {
                case 1:
                    OhjekuvaPolku1 = path;
                    break;
                case 2:
                    OhjekuvaPolku2 = path;
                    break;
                case 3:
                    OhjekuvaPolku3 = path;
                    break;
            }
            return string.Empty;
        }

    }
}
