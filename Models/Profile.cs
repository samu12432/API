namespace API_REST_PROYECT.Models
{
    public class Profile : Supply
    {
        public double  profileWeigth { get; set; } //Peso
        public double profileHeigth { get; set; }//Largo
        public double weigthMetro { get; set; }//PorMetro
        public string profileColor { get; set; } = string.Empty; //Color
    }
}
