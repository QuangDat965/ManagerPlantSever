﻿using System.ComponentModel.DataAnnotations;

namespace ManagerServer.Model
{
    public class SignUpRequestModel
    {
        public string FistName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassWord { get; set; } = null!;
        public string NumberPhone { get; set; }
    }
}
