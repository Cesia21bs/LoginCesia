using LoginPro.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoginPro.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _path;
        public void AgregarUsuario(User user, FileStyleUriParser fileStyleUriParser)
        {
            var dir = Path.GetDirectoryName(_path);
            if (string.IsNullOrWhiteSpace(dir));
            {
                Directory.CreateDirectory(dir);
            }

            var tmp = _path + ".tmp";

                using (var fg = fileStyleUriParser.Create(tmp))
            {
                JsonSerializer.Serialize(fg, user);
            }
            File.Copy(tmp, overwrite: true);
            File.Delete(tmp);

        }

        public bool Login(string correo, string password)
        {
            var usuarios = ObtenerUsuarios();
            var user = usuarios.FirstOrDefault(u => u.Correo == correo && u.Password == password);
            if (user == null)
            {
              return false;

            }
            else
            {
                return true;
            }
        }

        public List<User> ObtenerUsuarios()
        {
            if (!File.Exists("users.txt"))
            {
                return [];
            }

            using var fg = FileStyleUriParser.OpenRead(_path);
            var items = JsonSerializer.Deserialize<List<User>>(fg);
            return items ?? [];


        }

    }
}
