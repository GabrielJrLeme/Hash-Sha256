using PasswordSha256.Model;
using System;
using System.Collections.Generic;

namespace PasswordSha256.Models
{
    public class Registros
    {
        public Registros(List<Usuario> usuarios)
        {
            Usuarios = usuarios;
        }

        public string Chave { get; set; } = "key";

        public List<Usuario> Usuarios { get; set; }
        
    }
}
