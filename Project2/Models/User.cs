using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    [Table("user")] //, Schema = "cardb_jwt")]
    public partial class User
    {
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "password")]
        public string Password { get; set; }

        //[Column(name: "role")]
        //public string Role { get; set; } = "USER";

        [Column(name: "username")]
        public string UserName { get; set; }    
    }
}
