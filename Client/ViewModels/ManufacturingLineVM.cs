using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;

namespace Nipema.Tyonohjaus.Client.ViewModels
{
    public class ManufacturingLineVM : NotifyPropertyChangedImplementor, IManufacturingLineVM
    {
        public class LinjaItem : NotifyPropertyChangedImplementor
        {
            #region Datajäsenet
            private string _nimikekoodi, _tyokoodi, _vari;
            private int _vaunuId, _lokaatio, _maara;

            public string Nimikekoodi { get { return _nimikekoodi; } set { _nimikekoodi = value; NotifyPropertyChanged("Nimikekoodi"); } }
            public int VaunuId { get { return _vaunuId; } set { _vaunuId = value; NotifyPropertyChanged("VaunuId"); } }
            public int Lokaatio { get { return _lokaatio; } set { _lokaatio = value; NotifyPropertyChanged("Lokaatio"); } }
            public int Maara { get { return _maara; } set { _maara = value; NotifyPropertyChanged("Maara"); } }
            public string Tyokoodi { get { return _tyokoodi; } set { _tyokoodi = value; NotifyPropertyChanged("Tyokoodi"); } }
            public string Vari { get { return _vari; } set { _vari = value; NotifyPropertyChanged("Vari"); } }
            public DateTime? _ripustusAika;
            public long id { get; set; }
            public string Pesupaine { get; set; }
            public double Uunitusaika { get; set; }

            public string RipustusAika
            {
                get
                {
                    if (_ripustusAika != null)
                    {
                        return _ripustusAika.GetValueOrDefault().ToString();
                    }
                    return "??";
                }
            }
            public string SaapumisAika
            {
                get
                {
                    DateTime x = _ripustusAika ?? DateTime.Now;
                    string duration = Helpers.Queries.GetSetting("Duration");
                    double minutes = Convert.ToDouble(duration) + Convert.ToDouble(Uunitusaika);

                    // AddMinutesin sisällä on arvioitu linjan kesto minuutteina
                    return _ripustusAika != null ? x.AddMinutes(minutes).ToString() : "??";
                }
            }
            #endregion Datajäsenet
        }

        public ManufacturingLineVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;
            
            ToggleHideableColumns();
        }
        private Double _usePressure = double.NaN;
        /// <summary>
        /// Tällä piilotetaan Uunitusaika, mikäli sitä ei haluta näyttää
        /// </summary>
        public Double UunitusAikaWidth
        {
            get {
                return _usePressure;
            }
            set {
                _usePressure = value; NotifyPropertyChanged("UunitusAikaWidth");
            }
        }
        private Double _useOvenTime = double.NaN;
        /// <summary>
        /// Tällä piilotetaan Pesupaine, mikäli sitä ei haluta näyttää
        /// </summary>
        public Double PesupaineWidth {
            get {
                return _useOvenTime;
            }
            set {
                _useOvenTime = value; NotifyPropertyChanged("PesupaineWidth");
            }
        }

        ObservableCollectionEx<LinjaItem> _items = new ObservableCollectionEx<LinjaItem>();
        public ObservableCollectionEx<LinjaItem> Items
        {
            get { return _items; }
        }
        /// <summary>
        /// Piilotetaan tai näytetään Pesupaine- ja Uunitusaika-sarakkeet
        /// </summary>
        public void ToggleHideableColumns()
        {
            PesupaineWidth = Helpers.Queries.GetUsePressure() ? double.NaN : 0;
            UunitusAikaWidth = Helpers.Queries.GetUseOvenTime() ? double.NaN : 0;
        }

        /// <summary>
        /// Luodaan sarakkeet
        /// </summary>
        public void GenerateItems()
        {
            _items.Clear();
            try
            {
                //var result_ripustetut = new List<Ripustettu>();
                //using (var db = new MyDbContext())
                //{
                //    // Haetaan tietokannasta ripustetut
                //    var result_ripustetut_tmp = (from r in db.Ripustetut
                //                                    select r);

                //    if (result_ripustetut_tmp.Count() > 0)
                //        result_ripustetut = result_ripustetut_tmp.ToList();
                //}
                // Jos löytyi
                //if (result_ripustetut.Count > 0)
                //{
                //    // Käydään ripustetut läpi
                //    foreach (var rip in result_ripustetut)
                //    {
                //        var lokaatio = -1;
                //        //if (TrolleyLocations.Instance.Items.Count > 0)
                //        //{
                //        //    // Haetaan vaunun paikkatieto
                //        //    var loytynyt_vaunu_lokaatio = TrolleyLocations.Instance.Items.Where(tl => tl.trolleyNumber == rip.VaunuId).FirstOrDefault();
                //        //    if (loytynyt_vaunu_lokaatio != null)
                //        //    {
                //        //        lokaatio = loytynyt_vaunu_lokaatio.locationIndex;
                //        //    }
                //        //}

                //        //_items.Add(new LinjaItem(rip)
                //        //{
                //        //    Lokaatio = lokaatio
                //        //});
                //    } //foreach
                //} //if
            } //try
            catch (Exception)
            {
            }
        }
    }
}
