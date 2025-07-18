namespace API_REST_PROYECT.Models
{
    public class InvoiceLine
    {
        public int Id { get; set; }
        public string CodigoProducto { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public decimal Descuento { get; private set; }
        public decimal TotalLinea => (PrecioUnitario * Cantidad) - Descuento;

        protected InvoiceLine() { }
        public InvoiceLine(string codigoProducto, int cantidad, decimal precioUnitario, decimal descuento)
        {
            CodigoProducto = codigoProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Descuento = descuento;
        }
    }
}
