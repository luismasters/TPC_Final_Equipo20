using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CiudadNegocio
    {
        public List<CiudadEnvio> Listar()
        {
            List<CiudadEnvio> lista = new List<CiudadEnvio>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select IDCiudad, Descripcion, PrecioEnvio from CiudadEnvio");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    CiudadEnvio ciudadEnvio = new CiudadEnvio();
                    ciudadEnvio.IDCiudad = Convert.ToInt32(datos.Lector["IDCiudad"]);
                    ciudadEnvio.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    ciudadEnvio.PrecioEnvio = Convert.ToInt32(datos.Lector["PrecioEnvio"]);
                    lista.Add(ciudadEnvio);
                }
                return lista;
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
        public CiudadEnvio ObtenerCiudadPorId(int idCiudad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IDCiudad, Descripcion, PrecioEnvio FROM CiudadEnvio WHERE IDCiudad = @IDCiudad");
                datos.agregarParametro("@IDCiudad", idCiudad);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    CiudadEnvio ciudad = new CiudadEnvio();
                    ciudad.IDCiudad = (int)datos.Lector["IDCiudad"];
                    ciudad.Descripcion = datos.Lector["Descripcion"].ToString();
                    ciudad.PrecioEnvio = (int)datos.Lector["PrecioEnvio"];
                    return ciudad;
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
    }
}
