namespace Nipema.Tyonohjaus.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TyoDescriptions")]
    public partial class TyoDescription
    {
        [Key]
        public int DescriptionId { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
