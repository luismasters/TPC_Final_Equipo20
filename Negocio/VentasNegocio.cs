using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentasNegocio
    {
        public List<Ventas> Listar()
        {
            List<Ventas> lista = new List<Ventas>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select IDVenta, IDUsuario, MedioPago, PrecioTotal, Pagado, IDEnvio from Ventas");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Ventas ventas = new Ventas();
                    ventas.IDVenta = (int)datos.Lector["IDVenta"];
                    ventas.IDUsuario = (int)datos.Lector["IDUsuario"];
                    ventas.MedioPago = Convert.ToInt32(datos.Lector["MedioPago"]);
                    ventas.PrecioTotal = Convert.ToDecimal (datos.Lector["PrecioTotal"]);
                    ventas.Pagado = (bool)datos.Lector["Pagado"];
                    ventas.IDEnvio = (int)datos.Lector["IDEnvio"];
                    lista.Add(ventas);                }
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

        public void RegistrarVenta(Ventas venta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Ventas values (@IDUsuario, @MedioPago, @PrecioTotal, @Pagado, @IDEnvio)");
                datos.agregarParametro("@IDUsuario", venta.IDUsuario);
                datos.agregarParametro("@MedioPago", venta.MedioPago);
                datos.agregarParametro("@PrecioTotal", venta.PrecioTotal);
                datos.agregarParametro("@Pagado", venta.Pagado);
                datos.agregarParametro("IDEnvio", venta.IDEnvio);

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
        public int ObtenerIdVenta()
        {
            AccesoDatos datos = new AccesoDatos();
            int idVenta = 0;
            try
            {
                datos.setearConsulta("SELECT TOP 1 IDVenta FROM Ventas ORDER BY IDVenta DESC;");
                datos.ejecutarLectura();

                if (datos.Lector.HasRows) // Verificar si hay filas devueltas
                {
                    while (datos.Lector.Read())
                    {
                        idVenta = (int)datos.Lector["IDVenta"];
                    }
                return idVenta;


                }
                else { return 1; }
               

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
            public void RegistrarEnvio(int idEnvio, int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Ventas set IDEnvio = @IDEnvio where IDVenta = @IDVenta");
                datos.agregarParametro("@IDEnvio", idEnvio);
                datos.agregarParametro("IDVenta", idVenta);
                datos.ejecutarAccion();
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
