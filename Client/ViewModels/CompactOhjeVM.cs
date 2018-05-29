using System;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Nipema.Tyonohjaus.Client.ViewModels
{
    public class CompactOhjeVM : NotifyPropertyChangedImplementor, ICompactOhjeVM
    {
        #region Yksityiset datajäsenet
        private string _ohjeteksti = string.Empty;
        private string _kuvaus = string.Empty;
        private int _ohjetyyppi = 0;
        private string _nimikekoodi = string.Empty;
        private string _ohjekuvaPolku = string.Empty;
        private string _lisateksti;
        #endregion Yksityiset datajäsenet

        #region Julkiset datajäsenet
        /// <summary>
        /// Ohjekuvan tiedostopolku stringinä
        /// </summary>
        public string OhjekuvaPolku
        {
            get
            {
                return _ohjekuvaPolku;
            }
            set { _ohjekuvaPolku = value;  NotifyPropertyChanged("OhjekuvaPolku"); }
        }
        /// <summary>
        /// Ohjeen tyyppi. 1 = Ripustus, 2 = Maalaus, 3 = Purku
        /// </summary>
        public int Ohjetyyppi
        {
            get { return _ohjetyyppi; }
            set { _ohjetyyppi = value; NotifyPropertyChanged("Ohjetyyppi"); }
        }
        
        public string Ohjeteksti
        {
            get { return _ohjeteksti; }
            set { _ohjeteksti = value; NotifyPropertyChanged("Ohjeteksti"); }
        }

        public string Nimikekoodi
        {
            get { return _nimikekoodi; }
            set
            {
                _nimikekoodi = value;
                if (string.IsNullOrEmpty(value)) return;
                //TryGetOhje();
            }
        }

        /// <summary>
        /// Nimikkeen nimi tai kuvaus
        /// </summary>
        public string Kuvaus
        {
            get { return _kuvaus; }
            set { _kuvaus = value; NotifyPropertyChanged("Kuvaus"); }
        }
       
        /// <summary>
        /// Lisäteksti voi olla esim. Vaunun numero, paikka, määrä tai väri 
        /// </summary>
        public string Lisateksti
        {
            get { return _lisateksti; }
            set { _lisateksti = value;  NotifyPropertyChanged("Lisateksti"); }
        }

        #endregion Julkiset datajäsenet

        
    }
}
