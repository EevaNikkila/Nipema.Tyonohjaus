namespace Nipema.Tyonohjaus.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductPropertyValues")]
    public partial class ProductPropertyValue : INotifyPropertyChanged, IComparable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        [Key, Column(Order = 0)]
        public string Nimikekoodi { get; set; }
        public string Kuvaus { get; set; }
        [Key, Column(Order = 1)]
        public int PropertyId { get; set; }

        public string PropertyValue { get; set; }
        public ProductPropertyValue() { }
        public ProductPropertyValue(string nimikekoodi, ProductPropertyDescription ppd, string value) : this()
        {
            Nimikekoodi = nimikekoodi;
            PropertyId = ppd != null ? ppd.Id : 0;
            PropertyValue = value;
        }
        public override string ToString()
        {
            return this.PropertyValue;
        }

        /// <summary>
        /// Tää on ihan vaan debuggausta varten.
        /// </summary>
        /// <returns>Tiedot pötkössä</returns>
        public string AsCoolString()
        {
            return string.Format("Nimike = {0} :: OminaisuusId = {1}, Arvo = {2}", Nimikekoodi, PropertyId, PropertyValue);
        }

        public int CompareTo(object obj)
        {
            if (string.IsNullOrEmpty(PropertyValue)) return -1;
            if (string.IsNullOrEmpty(obj.ToString())) return 1;

            return PropertyValue.CompareTo(obj.ToString());
        }
    }
}
