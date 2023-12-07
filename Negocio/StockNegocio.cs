using System;
using Dominio;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Negocio
{
    public class StockNegocio
    {
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
                datos.setearConsulta("UPDATE Stock SET Cantidad = @Cantidad, Lote=@Lote WHERE IdPrenda = @IdPrenda AND Lote=@Lote");
                datos.agregarParametro("@Lote", stock.Lote);
                datos.agregarParametro("@Cantidad", stock.Cantidad);
                datos.agregarParametro("@IdPrenda", stock.IdPrenda);
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

        public Stock ObtenerStockPorPrenda(int idPrenda)
        {
            AccesoDatos datos = new AccesoDatos();
            Stock stock = null;

            try
            {
                datos.setearConsulta("SELECT Id, IdPrenda, Cantidad FROM Stock WHERE IdPrenda = @IdPrenda");
                datos.agregarParametro("@IdPrenda", idPrenda);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    stock = new Stock
                    {
                        Id = (int)datos.Lector["Id"],
                        IdPrenda = (int)datos.Lector["IdPrenda"],
                        Cantidad = (int)datos.Lector["Cantidad"]
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

        public void EliminarStock(int idPrenda)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Stock WHERE IdPrenda = @IdPrenda");
                datos.agregarParametro("@IdPrenda", idPrenda);
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

        public Stock ObtenerStockPorLote(int idPrenda, string lote)
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

        public List<Stock> ObtenerLotesPorPrenda(int idPrenda)
        {
            List<Stock> lotes = new List<Stock>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, IdPrenda, Cantidad, Talle, Lote FROM Stock WHERE IdPrenda = @IdPrenda");
                datos.agregarParametro("@IdPrenda", idPrenda);
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


