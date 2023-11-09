using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {

        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM Categoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria
                    {
                        Id = Convert.ToInt32(datos.Lector["Id"]),
                        Descripcion = datos.Lector["Descripcion"].ToString()
                    };
                    categorias.Add(categoria);
                }

                return categorias;
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
        public void AgregarCategoria(string nuevaCategoria)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("INSERT INTO Categoria (Descripcion) VALUES (@descripcion)");
                datos.agregarParametro("@descripcion", nuevaCategoria);
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
