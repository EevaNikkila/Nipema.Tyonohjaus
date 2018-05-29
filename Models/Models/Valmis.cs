namespace Nipema.Tyonohjaus.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Valmiit")]
    public partial class Valmis
    {
        public long Id { get; set; }

        public DateTime RipustusAika { get; set; }

        public DateTime ValmistumisAika { get; set; }

        public string Nimikekoodi { get; set; }

        public string Tyokoodi { get; set; }

        public int Maara { get; set; }

        public int VaunuId { get; set; }

        public string KeratytTiedot { get; set; }

        public Valmis()
        {
            ValmistumisAika = DateTime.Now;
        }
        // T‰t‰ k‰ytet‰‰n esim. Datanker‰yksess‰, kun ripustettu siirret‰‰n valmiisiin
        public Valmis(LoadedItem rip) : this()
        {
            RipustusAika = (DateTime)rip.RipustusAika;
            Id = rip.Id;
            Tyokoodi = rip.Tyokoodi;
            VaunuId = rip.VaunuId;
            Nimikekoodi = rip.Nimikekoodi;
            Maara = rip.RipustettavaMaara;
            KeratytTiedot = rip.KeratytTiedot;
        }
    }
}
