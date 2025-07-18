using System.ComponentModel.DataAnnotations;

namespace API_REST_PROYECT.DTOs.Stock
{
    public class StockDto
    {
        [Required(ErrorMessage = "Es necesario ingresar el sku del articulo.")]
        [StringLength(50)]
        public string skuSupply { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El stock debe ser mayor a 0.")]
        public int stockQuantity { get; set; }
    }
}
