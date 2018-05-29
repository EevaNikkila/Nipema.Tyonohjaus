namespace Nipema.Tyonohjaus.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Varit")]
    public class Vari
    {
        [Key]
        public string code { get; set; }
        
        public string rgb_hex { get; set; }
    }
}
