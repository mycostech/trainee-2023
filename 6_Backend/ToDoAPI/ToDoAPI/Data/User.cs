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
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginResponse 
    { 
        public string UserName { get; set; }
        public string Token { get; set; }

        public DateTime ExpDate { get; set; }
    }
}
