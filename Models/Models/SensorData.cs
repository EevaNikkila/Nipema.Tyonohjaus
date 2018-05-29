namespace Nipema.Tyonohjaus.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SensorData")]
    public class SensorData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public double Value { get; set; }

        /* 
         SensorData1: {
            Description: "allasPH",
            Value: "5",
            Time: "24-01-2017"
        }
         
         */
         

        /*
         SensorData1: {
            phAllas1: "5",
            phAllas2: "10"
        }
         */
    }
}
