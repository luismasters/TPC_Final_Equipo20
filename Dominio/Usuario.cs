using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; } // Agregada la propiedad Email
        public TipoUsuario TipoUsuario { get; set; }
        
       
        
        // Constructor existente
        public Usuario(string user, string pass, string email)
        {
            User = user;
            Pass = pass;
            Email= email;
            TipoUsuario = TipoUsuario.NORMAL; // Por defecto, el usuario es normal
        }

        // Constructor con IdRol
        public Usuario(string user, string pass, string email, bool esAdmin)
        {
            User = user;
            Pass = pass;
            Email = email;
            TipoUsuario = esAdmin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
        public Usuario() { }
        
    }

}
