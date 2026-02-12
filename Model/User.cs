using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPro.Model
{
    public class User
    {
        public Guid Id { get; set; }

        public string Correo { get; set; }

        public string Nombre { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public User(string correo, string nombre, string userName, string password)
        {
            Id = Guid.NewGuid();
            Correo = correo;
            Nombre = nombre;
            UserName = userName;
            Password = password;
        }
    }
}
