namespace Nipema.Tyonohjaus.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TrolleyLocation : IComparable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationIndex { get; set; }

        public int TrolleyNumber { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is TrolleyLocation)
            {
                var tl = obj as TrolleyLocation;
                int compareResult = tl.LocationIndex.CompareTo(LocationIndex);
                if (tl.LocationIndex == LocationIndex)
                {
                    compareResult = tl.TrolleyNumber.CompareTo(TrolleyNumber);
                }
                return compareResult;
            }
            return -1;
        }
    }
}
