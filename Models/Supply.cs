using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_REST_PROYECT.Models
{
    [Table("Supply")]
    public class Supply
    {
        [Key]
        public int idSupply { get; set; }
        public string codeSupply { get; set; }
        public string nameSupply { get; set; } = string.Empty;
        public string descriptionSupply { get; set; } = string.Empty;

        public string nameSupplier {  get; set; } = string.Empty;
        public double priceSupply { get; set; }


    }
}
