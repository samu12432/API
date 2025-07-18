namespace API_REST_PROYECT.Models
{
    public class SupplyNecesary
    {
        public Supply supply { get; set; }
        public int supplyQuantity {  get; set; }

        public SupplyNecesary(Supply supplyCode, int supplyQuantity)
        {
            this.supply = supplyCode;
            this.supplyQuantity = supplyQuantity;
        }
    }
}
