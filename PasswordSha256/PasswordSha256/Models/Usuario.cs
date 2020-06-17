using System;
using System.ComponentModel.DataAnnotations;

namespace PasswordSha256.Model
{
    public class Usuario
    {
        public string Chave { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string SenhaNormal { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

    }
}
