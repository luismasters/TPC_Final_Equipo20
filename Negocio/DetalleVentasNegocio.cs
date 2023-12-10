using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
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







    }
}
