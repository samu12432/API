using System.ComponentModel.DataAnnotations;
using API_REST_PROYECT.Models;

namespace API_REST_PROYECT.DTOs.Product
{
    public class ProductDto
    {
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        [Required]
        public int ProductCategoryId { get; set; } // o string si es por nombre

        public List<SupplyNecesaryDto> ProductDetail { get; set; } = new();

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal ProductPrice { get; set; }

        public string ProductPhoto { get; set; } = string.Empty;

    }
}
