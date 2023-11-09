using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class PrendaNegocio
    {

        public List<int> listarIDPrendas() {

            List<int> Ids=new List<int>();
            PrendaNegocio prendaNegocio = new PrendaNegocio();

            List<Dominio.Prenda>  prendas= new List<Dominio.Prenda>();

            prendas = prendaNegocio.Listar();

            foreach (Prenda prenda in prendas)
            {

                Ids.Add(prenda.Id);

            }

            return Ids; }



        public List<Prenda> Listar()
        {
            List<Prenda> lista = new List<Prenda>();
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            try
            {
                datos.setearConsulta("SELECT P.Id, P.Descripcion, P.Precio, P.Stock, P.IdCategoria, C.Descripcion AS CategoriaDescripcion, P.IdGenero, G.Descripcion AS Genero, P.IdLinea, L.Descripcion AS Linea, P.Talle\r\nFROM Prenda P\r\nINNER JOIN Categoria C ON P.IdCategoria = C.Id\r\nINNER JOIN Genero G ON P.IdGenero = G.Id\r\nINNER JOIN Linea L ON P.IdLinea = L.Id;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Prenda prenda = new Prenda();
                    prenda.Id = (int)datos.Lector["Id"];
                    prenda.Descripcion = datos.Lector["Descripcion"].ToString();
                    prenda.Precio = Math.Round((decimal)datos.Lector["Precio"], 2);
                    prenda.Talle = datos.Lector["Talle"].ToString();
                    prenda.Stock = (int)datos.Lector["Stock"];
                    prenda.Categoria = new Categoria();
                    {
                        prenda.Categoria.Id = (int)datos.Lector["IdCategoria"];
                        prenda.Categoria.Descripcion = datos.Lector["CategoriaDescripcion"].ToString();
                    };
                    prenda.Genero=new Genero();
                    {
                        prenda.Genero.Id = (int)datos.Lector["IdGenero"];
                        prenda.Genero.Descripcion = datos.Lector["Genero"].ToString();

                    };
                    prenda.Linea = new Linea();
                    {
                        prenda.Linea.Id = (int)datos.Lector["IdLinea"];
                        prenda.Linea.Descripcion = datos.Lector["Linea"].ToString();

                    };




                    { 
                    prenda.Imagenes = imagenNegocio.Listar((int)datos.Lector["Id"]);// Corregido aquí

                    lista.Add(prenda);
                }    };

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

        public void Modificar(Prenda prenda)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Prenda SET Descripcion = @descripcion, Precio = @precio, Talle = @talle, IdCategoria = @idCategoria " +
                                     "WHERE Id = @id");
                datos.agregarParametro("@descripcion", prenda.Descripcion);
                datos.agregarParametro("@precio", prenda.Precio);
                datos.agregarParametro("@talle", prenda.Talle);
                datos.agregarParametro("@idCategoria", prenda.Categoria.Id);
                datos.agregarParametro("@id", prenda.Id);

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

        public void Agregar(Prenda prenda)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Prenda (Descripcion, Precio, Talle, IdCategoria) " +
                                     "OUTPUT INSERTED.Id VALUES (@descripcion, @precio, @talle, @idCategoria)");
                datos.agregarParametro("@descripcion", prenda.Descripcion);
                datos.agregarParametro("@precio", prenda.Precio);
                datos.agregarParametro("@talle", prenda.Talle);
                datos.agregarParametro("@idCategoria", prenda.Categoria.Id);

                int prendaId = (int)datos.ejecutarAccionReturn();
                // Aquí puedes agregar el código para manejar la tabla de Stock y relacionarla con la nueva prenda.
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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Prenda WHERE Id = @id");
                datos.agregarParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
