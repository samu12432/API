using System.ComponentModel.DataAnnotations;

namespace API_REST_PROYECT.DTOs.Supply
{
    public class ProfileDTO
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
        [Range(0.01, double.MaxValue, ErrorMessage = "El peso debe ser mayor que cero.")]
        public double profileWeigth { get; set; }


        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El largo debe ser mayor que cero.")]
        public double profileHeigth { get; set; }


        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El peso por metro debe ser mayor que cero.")]
        public double weigthMetro { get; set; }


        [Required(ErrorMessage = "Es necesario ingresar el nombre del proveedor.")]
        [StringLength(20)]
        public string profileColor { get; set; } = string.Empty;
    }
}
