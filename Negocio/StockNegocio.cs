using System;
using Dominio;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;

namespace Negocio
{
    public class StockNegocio
    {

        public List<StockViewModel> ListarStock()
        {
            List<StockViewModel> lotes = new List<StockViewModel>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT S.Id, P.Descripcion AS DescripcionPrenda, S.Talle, S.Cantidad, C.Descripcion AS DescripcionCategoria, S.Lote FROM STOCK AS S INNER JOIN PRENDA AS P ON S.IdPrenda=P.Id INNER JOIN Categoria AS C ON P.IdCategoria=C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lotes.Add(new StockViewModel
                    {
                        Id = (int)datos.Lector["Id"],
                        DescripcionPrenda = datos.Lector["DescripcionPrenda"].ToString(),
                        Talle = datos.Lector["Talle"].ToString(),
                        Cantidad = (int)datos.Lector["Cantidad"],
                        DescripcionCategoria = datos.Lector["DescripcionCategoria"].ToString(),
                        Lote = datos.Lector["Lote"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                datos.cerrarConexion();
            }

            return lotes;
        }

    

        public void AgregarStock(Stock stock)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) VALUES (@IdPrenda, @Cantidad, @Talle, @Lote)");
                datos.agregarParametro("@IdPrenda", stock.IdPrenda);
                datos.agregarParametro("@Cantidad", stock.Cantidad);
                datos.agregarParametro("@Talle", stock.Talle);
                datos.agregarParametro("@Lote", stock.Lote);

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

        public void ActualizarStock(Stock stock)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Stock SET Cantidad = @Cantidad, Talle = @Talle, IdPrenda =@IdPrenda WHERE Lote = @Lote");
                datos.agregarParametro("@Cantidad", stock.Cantidad);
                datos.agregarParametro("@Talle", stock.Talle);
                datos.agregarParametro("@IdPrenda", stock.IdPrenda);
                datos.agregarParametro("@Lote", stock.Lote);
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
        
        public int ObtenerCategoriaPrenda(string lote)
        {
            AccesoDatos datos = new AccesoDatos();
            int categoria = -1;
            try
            {
                datos.setearConsulta("SELECT c.Id FROM Categoria AS c INNER JOIN Prenda AS p ON c.Id = p.IdCategoria INNER JOIN Stock AS s ON s.IdPrenda = p.Id WHERE s.Lote = @lote");
                datos.agregarParametro("@lote", lote);
                datos.ejecutarLectura();

                if (datos.Lector.Read()) 
                {
                    categoria = (int)datos.Lector["Id"];
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

            return categoria;
        }

        public List<Stock> ObtenerStockPrenda(int idPrenda)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Stock> listaStock = new List<Stock>();

            try
            {
                datos.setearConsulta("SELECT COALESCE(Cantidad, 'Sin Stock') AS Cantidad, COALESCE(Talle, 'Sin Stock') AS Talle FROM Stock WHERE IdPrenda = @IdPrenda");
                datos.agregarParametro("IdPrenda", idPrenda);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Stock stock = new Stock();
                    stock.Cantidad = (int)datos.Lector["Cantidad"];
                    stock.Talle = datos.Lector["Talle"].ToString();
                    listaStock.Add(stock);
                }
                return listaStock;
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
        
        public void EliminarStock(string lote)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Stock WHERE Lote = @Lote");
                datos.agregarParametro("@Lote", lote);
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
        public void ActualizarStockVenta(int idPrenda, string talle, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Stock SET Cantidad = Cantidad - @Cantidad WHERE IDPrenda = @IdPrenda AND Talle = @Talle");
                datos.agregarParametro("@IdPrenda", idPrenda);
                datos.agregarParametro("@Talle", talle);
                datos.agregarParametro("@Cantidad", cantidad);
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
        public List<Stock> ObtenerLotes()
        {
            List<Stock> lotes = new List<Stock>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT * FROM Stock");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    lotes.Add(new Stock
                    {
                        Id = (int)datos.Lector["Id"],
                        IdPrenda = (int)datos.Lector["IdPrenda"],
                        Cantidad = (int)datos.Lector["Cantidad"],
                        Talle = datos.Lector["Talle"].ToString(),
                        Lote = datos.Lector["Lote"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                datos.cerrarConexion();
            }

            return lotes;
        }
        
      
        public void EliminarStockPorLote(string lote)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Stock WHERE Lote = @Lote");
                datos.agregarParametro("@Lote", lote);
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

        public Stock ObtenerStockPorLote(string lote)
        {
            AccesoDatos datos = new AccesoDatos();
            Stock stock = null;

            try
            {
                datos.setearConsulta("SELECT Id, IdPrenda, Cantidad, Talle, Lote FROM Stock WHERE Lote = @Lote");
                datos.agregarParametro("@Lote", lote);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    stock = new Stock
                    {
                        Id = (int)datos.Lector["Id"],
                        IdPrenda = (int)datos.Lector["IdPrenda"],
                        Cantidad = (int)datos.Lector["Cantidad"],
                        Talle = datos.Lector["Talle"].ToString(),
                        Lote = datos.Lector["Lote"].ToString()
                    };
                }
                return stock;
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