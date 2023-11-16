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
                        User = datos.Lector["NombreUsuario"].ToString(),
                        Pass = datos.Lector["Contraseña"].ToString(),
                        TipoUsuario = (int)(datos.Lector["IdRol"]) == 1 ? TipoUsuario.NORMAL : TipoUsuario.ADMIN
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
                datos.setearConsulta("INSERT INTO Usuario (NombreUsuario, Contraseña, IdRol, Email) VALUES (@NombreUsuario, @Contraseña, @IdRol, @Email)");
                datos.agregarParametro("@NombreUsuario", usuario.User);
                datos.agregarParametro("@Contraseña", usuario.Pass);
                datos.agregarParametro("@IdRol", usuario.TipoUsuario);
                datos.agregarParametro("@Email", usuario.Email);
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
