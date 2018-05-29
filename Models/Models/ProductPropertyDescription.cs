namespace Nipema.Tyonohjaus.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductPropertyDescriptions")]
    public partial class ProductPropertyDescription
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
