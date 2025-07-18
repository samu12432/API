using System.ComponentModel.DataAnnotations;

namespace API_REST_PROYECT.DTOs.Product
{
    public class SupplyNecesaryDto
    {
        [Required]
        public int SupplyCode { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
