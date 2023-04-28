using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoAPI.Data
{
    public class User
    {

        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        //[MaxLength(20)] Max string = 20
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
