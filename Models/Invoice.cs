namespace API_REST_PROYECT.Models
{
    public class Invoice
    {
        public int Id { get; private set; }
        public string RUTCliente { get; private set; } // RUT o CUIT cliente
        public string NombreCliente { get; private set; }
        public DateTime FechaEmision { get; private set; }

        private readonly List<InvoiceLine> _detalles = new();

        public IReadOnlyCollection<InvoiceLine> Detalles => _detalles.AsReadOnly();

        public decimal Total => _detalles.Sum(d => d.TotalLinea);

        public string? CAE { get; private set; }
        public DateTime? VencimientoCAE { get; private set; }

        protected Invoice() { }

        public Invoice(string rutCliente, string nombreCliente, DateTime fechaEmision)
        {
            if (string.IsNullOrWhiteSpace(rutCliente)) throw new ArgumentException("RUT Cliente requerido.");
            if (string.IsNullOrWhiteSpace(nombreCliente)) throw new ArgumentException("Nombre Cliente requerido.");

            RUTCliente = rutCliente;
            NombreCliente = nombreCliente;
            FechaEmision = fechaEmision;
        }

        public void AgregarDetalle(string codigoProducto, int cantidad, decimal precioUnitario, decimal descuento)
        {
            if (cantidad <= 0) throw new ArgumentException("Cantidad debe ser mayor a 0.");
            if (precioUnitario <= 0) throw new ArgumentException("Precio unitario debe ser mayor a 0.");

            _detalles.Add(new InvoiceLine(codigoProducto, cantidad, precioUnitario, descuento));
        }
        public void SetCAE(string cae, DateTime vencimiento)
        {
            if (string.IsNullOrWhiteSpace(cae)) throw new ArgumentException("CAE inválido.");
            CAE = cae;
            VencimientoCAE = vencimiento;
        }
    }
}
