namespace Nipema.Tyonohjaus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Hylatyt")]
    public partial class Hylatty
    {
        public long Id { get; set; }

        public int Maara { get; set; }

        public int Hylkysyy { get; set; }
    }
}
