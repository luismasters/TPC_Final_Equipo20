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
    }
}
