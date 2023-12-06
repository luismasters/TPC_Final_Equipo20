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
                datos.setearConsulta("Select IDVenta, IDUsuario, MedioPago, PrecioTotal, Pagado from Ventas");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Ventas ventas = new Ventas();
                    ventas.IDVenta = (int)datos.Lector["IDVenta"];
                    ventas.IDUsuario = (int)datos.Lector["IDUsuario"];
                    ventas.MedioPago = (int)datos.Lector["MedioPago"];
                    ventas.PrecioTotal = (decimal)datos.Lector["PrecioTotal"];
                    ventas.Pagado = (bool)datos.Lector["Pagado"];
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

        public int RegistrarVenta(Ventas venta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Ventas values (@IDUsuario, @MedioPago, @PrecioTotal, @Pagado)");
                datos.agregarParametro("@IDUsuario", venta.IDUsuario);
                datos.agregarParametro("@MedioPago", venta.MedioPago);
                datos.agregarParametro("@PrecioTotal", venta.PrecioTotal);
                datos.agregarParametro("@Pagado", venta.Pagado);

                int ventaId = (int)datos.ejecutarAccionReturn();
                return ventaId;
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
