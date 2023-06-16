using System.ComponentModel.DataAnnotations;

namespace ManagerServer.Model
{
    public class SignInRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; } = null!;
    }
}
