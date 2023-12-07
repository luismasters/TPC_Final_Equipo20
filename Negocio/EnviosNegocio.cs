using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EnviosNegocio
    {
        public List<Envios> Listar()
        {
            List<Envios> lista = new List<Envios>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select IDEnvio, IDVenta, IDUsuario, Direccion, Telefono, Observaciones, Entregado, IDCiudad from Envios");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Envios envio = new Envios();
                    envio.IDEnvio = (int)datos.Lector["IDEnvio"];
                    envio.IDVenta = (int)datos.Lector["IDVenta"];
                    envio.IDUsuario = (int)datos.Lector["IDUsuario"];
                    envio.Direccion = (string)datos.Lector["Direccion"];
                    envio.Telefono = (string)datos.Lector["Telefono"];
                    envio.Observaciones = (string)datos.Lector["Observaciones"];
                    envio.Entregado = (bool)datos.Lector["Entregado"];
                    envio.IDCiudad = (int)datos.Lector["IDCiudad"];

                    lista.Add(envio);
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

        public void RegistrarEnvio(Envios envio)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Envios values (@IDVenta, @IDUsuario, @Direccion, @Telefono, @Observaciones, @Entregado, @IDCiudad)");
                datos.agregarParametro("@IDVenta", envio.IDVenta);
                datos.agregarParametro("@IDUsuario", envio.IDUsuario);
                datos.agregarParametro("@Direccion", envio.Direccion);
                datos.agregarParametro("@Telefono", envio.Telefono);
                datos.agregarParametro("@Observaciones", envio.Observaciones);
                datos.agregarParametro("@Entregado", envio.Entregado);
                datos.agregarParametro("@IDCiudad", envio.IDCiudad);

                datos.ejecutarLectura();
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
        public int ObtenerIdEnvio()
        {
            AccesoDatos datos = new AccesoDatos();
            int idEnvio = 0;
            try
            {
                datos.setearConsulta("SELECT TOP 1 IDEnvio FROM Envios ORDER BY IDVenta DESC;");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    idEnvio = (int)datos.Lector["IDEnvio"];
                }
                return idEnvio;
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
