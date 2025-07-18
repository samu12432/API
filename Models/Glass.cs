namespace API_REST_PROYECT.Models
{
    public class Glass : Supply
    {
        public double glassThickness { get; set; }
        public double glassLength { get; set; }
        public double glassWidth { get; set; }
        public GlassType glassType { get; set; }
    }
}
