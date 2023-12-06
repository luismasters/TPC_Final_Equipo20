using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    ventas.MedioPago = (int)datos.Lector["MedioPago"];
                    ventas.PrecioTotal = (decimal)datos.Lector["PrecioTotal"];
                    ventas.Pagado = (bool)datos.Lector["Pagado"];
                    ventas.IDEnvio = (int)datos.Lector["IDEnvio"];
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
        
    }
}
