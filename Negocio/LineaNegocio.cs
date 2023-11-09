using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LineaNegocio
    {

        public List<Linea> ObtenerLineas()
        {
            List<Linea> lineas = new List<Linea>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM Linea");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Linea linea = new Linea
                    {
                        Id = Convert.ToInt32(datos.Lector["Id"]),
                        Descripcion = datos.Lector["Descripcion"].ToString()
                    };
                    lineas.Add(linea);
                }

                return lineas;
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
        public void AgregarLinea(string nuevaLinea)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("INSERT INTO Linea (Descripcion) VALUES (@descripcion)");
                datos.agregarParametro("@descripcion", nuevaLinea);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades.
                // Puedes lanzarla nuevamente si deseas que el controlador de eventos la maneje.
                throw ex;
            }






        }










    }
}
