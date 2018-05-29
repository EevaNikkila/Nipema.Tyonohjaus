namespace Nipema.Tyonohjaus.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("Ripustetut")]
    public partial class LoadedItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int VaunuId { get; set; }

        public DateTime? RipustusAika { get; set; }

        public string Nimikekoodi { get; set; }
        public string Tyokoodi { get; set; }

        public int RipustettavaMaara { get; set; }
        public int TyoId { get; set; }
        public string Vari { get; set; }
        public string Pesupaine { get; set; }
        public double Uunitusaika { get; set; }
        public int Maalauskierto { get; set; }
        public int Maalausresepti { get; set; }

        public DateTime? UuniinMenoAika { get; set; }
        public DateTime? UunistaTuloAika { get; set; }

        public string KeratytTiedot { get; set; }

        public bool IsValid()
        {
            if (Nimikekoodi != null)
            {
                if ((VaunuId > 0) && (Nimikekoodi.Length > 0) && (RipustettavaMaara >= 0))
                {
                    return true;
                }
                return false;
            }
            else return false;
        }
    }
}
