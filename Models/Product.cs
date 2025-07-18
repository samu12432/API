using System.ComponentModel.DataAnnotations;

namespace API_REST_PROYECT.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; } = string.Empty;
        public string productDescription { get; set; } = string.Empty;
        public ProductCategory productCategory { get; set; }

        public  readonly List<SupplyNecesary> productDetail = new();
        public decimal productPrice { get; set; }
        public string productPhoto { get; set; } = string.Empty;


        public void AddSupply(Supply supply, int quantity)
        {
            if (quantity <= 0) throw new ArgumentException("Cantidad inválida.");

            productDetail.Add(new SupplyNecesary(supply, quantity));
        }
    }
}
