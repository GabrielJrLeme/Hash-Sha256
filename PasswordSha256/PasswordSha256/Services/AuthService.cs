using PasswordSha256.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PasswordSha256.Services
{
    public class AuthService
    {
        private CacheService _cache;

        public AuthService(CacheService cache)
        {
            _cache = cache;
        }


        public List<Usuario> ListUsers()
            => _cache.Cache["key"].Usuarios.ToList();



        public bool LoginUser(Usuario usuario)
        {

            Usuario user = _cache.Cache["key"].Usuarios.Where(x => x.Email.Equals(usuario.Email) || x.Name.Equals(usuario.Name)).FirstOrDefault();

            if (user == null)
                return false;

            var passHash = CriptografiSha256(user.Email, usuario.Password);

            return passHash.Equals(user.Password);

        }


        public Usuario GenerationPassword(Usuario model)
        {
            model.Password = CriptografiSha256(model.Password, model.Email);

            _cache.Cache["key"].Usuarios.Add(model);

            return model;
        }

        private string CriptografiSha256(string password, string email)
        {
            string valor = $"{password}:{email}";

            byte[] HashValue, MessageBytes = Encoding.ASCII.GetBytes(valor);
            SHA256Managed SHhash = new SHA256Managed();
            string strHex = "";

            HashValue = SHhash.ComputeHash(MessageBytes);

            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }

 
    }
}
