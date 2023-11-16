using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public Usuario Loguear(string username, string password)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, NombreUsuario, Contraseña, IdRol from Usuario Where NombreUsuario=@user and Contraseña=@pass");
                datos.agregarParametro("@user", username);
                datos.agregarParametro("@pass", password);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new Usuario
                    {
                        Id = (int)datos.Lector["Id"],
                        User = datos.Lector["Usuario"].ToString(),
                        Pass = datos.Lector["Pass"].ToString(),
                        TipoUsuario = (int)(datos.Lector["EsAdmin"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Registrar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Usuario (NombreUsuario, Email, Pass, IdRol) VALUES (@NombreUsuario,@Email, @Pass, @IdRol)");
                datos.agregarParametro("@NombreUsuario", usuario.User);
                datos.agregarParametro("@Email", usuario.Email);
                datos.agregarParametro("@Pass", usuario.Pass);
                datos.agregarParametro("@IdRol", usuario.TipoUsuario == TipoUsuario.ADMIN ? 1 : 0);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
