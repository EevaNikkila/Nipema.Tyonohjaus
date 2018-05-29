
namespace Nipema.Tyonohjaus.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel;

    [Table("Tyojono")]
    public partial class Tyo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Tyo()
        {
        }

        public Tyo(string nimikekoodi) {
            Nimikekoodi = nimikekoodi;
        }
        public Tyo(string nimikekoodi, string tyokoodi, int maara, string vari)
        {
            Nimikekoodi = nimikekoodi;
            Tyokoodi = tyokoodi;
            Vari = vari;
            Maara = maara;
            JaljellaLkm = maara;
            LuomisAika = DateTime.Now;
        }
        public string Nimikekoodi { get; set; }

        public string Tyokoodi { get; set; }
        
        //Tilattu Lukumaara
        public int Maara { get; set; }

        public string Vari { get; set; }

        public DateTime? LuomisAika { get; set; }
        public int JaljellaLkm { get; set; }
    }
}
