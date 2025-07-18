using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_REST_PROYECT.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int id { get; set; }

        //Datos personales
        [Required]
        public string name { get; set; } = string.Empty;
        [Required]
        public string userEmail { get; set; } = string.Empty;
        [Required]
        public string phoneNumber { get; set; } = string.Empty;

        //Datos para usario de uso
        [Required]
        public string userName { get; set; } = string.Empty;
        [Required]
        public byte[] passwordHash { get; set; }
        [Required]
        public byte[] passwordSalt { get; set; }


        public bool IsEmailConfirmed { get; set; } = false;

        public User(string name, string userEmail, string phoneNumber, string userName, byte[] passwordHash, byte[] passwordSalt)
        {
            this.name = name;
            this.userEmail = userEmail;
            this.phoneNumber = phoneNumber;
            this.userName = userName;
            this.passwordHash = passwordHash;
            this.passwordSalt = passwordSalt;
        }
    }
}
