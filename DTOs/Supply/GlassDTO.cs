using System.ComponentModel.DataAnnotations;
using API_REST_PROYECT.Models;

namespace API_REST_PROYECT.DTOs.Supply
{
    public class GlassDTO
    {
        [Required(ErrorMessage = "Es necesario ingresar el nombre del insumo.")]
        [StringLength(50)]
        public string nameSupply { get; set; } = string.Empty;

        [Required(ErrorMessage = "Es necesario ingresar el código del insumo.")]
        [StringLength(50)]
        public string codeSupply { get; set; } = string.Empty;

        [Required(ErrorMessage = "Es necesario ingresar una descripción del insumo.")]
        [StringLength(100)]
        public string descriptionSupply { get; set; } = string.Empty;

        [Required(ErrorMessage = "Es necesario ingresar el nombre del proveedor.")]
        [StringLength(20)]
        public string nameSupplier { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public double priceSupply { get; set; }
        //___________________________________________________//
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public double glassThickness { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public double glassLength { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public double glassWidth { get; set; }

        [Required]
        [EnumDataType(typeof(GlassType), ErrorMessage = "Tipo de vidrio no valido.")]
        public GlassType glassType { get; set; }
    }
}
