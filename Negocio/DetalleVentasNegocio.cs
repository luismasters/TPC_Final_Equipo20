using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DetalleVentasNegocio
    {

        public void RegistrarDetalleVenta(DetalleVenta detalle)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO DetalleVentas(IDVenta, IDPrenda, Cantidad, PrecioUnitario) VALUES (@IDVenta, @IDPrenda, @Cantidad, @PrecioUnitario)");
                datos.agregarParametro("@IDVenta", detalle.IDVenta);
                datos.agregarParametro("@IDPrenda", detalle.IDPrenda);
                datos.agregarParametro("@Cantidad", detalle.Cantidad);
                datos.agregarParametro("@PrecioUnitario", detalle.PrecioUnitario);
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

        public List<DetalleVenta> BuscarDetallePorVenta(int ID)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select IDDetalle, IDPrenda, IDVenta, Cantidad, PrecioUnitario from DetalleVentas Where IDVenta = @IdVenta");
                datos.agregarParametro("@IdVenta", ID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetalleVenta detalleVenta = new DetalleVenta();
                    detalleVenta.IDDetalle = (int)datos.Lector["IDDetalle"];
                    detalleVenta.IDPrenda = (int)datos.Lector["IDPrenda"];
                    detalleVenta.IDVenta = (int)datos.Lector["IDVenta"];
                    detalleVenta.Cantidad = (int)datos.Lector["Cantidad"];
                    detalleVenta.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];
                    lista.Add(detalleVenta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }


    }
}
