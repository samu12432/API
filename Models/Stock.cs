using System.ComponentModel.DataAnnotations;

namespace API_REST_PROYECT.Models
{
    public class Stock
    {
        [Key]
        public int id { get; set; }
        public required Supply stockSupply { get; set; }
        public int stockQuantity { get; set; }
        public DateTime stockCreate {  get; set; }
        public DateTime stockUpdate { get; set; }
    }
}
