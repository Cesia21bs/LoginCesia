using LoginPro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPro.Repository
{
    public interface IUserRepository
    {
        List<User> ObtenerUsuarios();

        bool Login(string correo, string password);
        
        void AgregarUsuario(User user);
    }
}
