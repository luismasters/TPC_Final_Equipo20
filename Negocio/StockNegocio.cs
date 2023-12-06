using System;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class StockNegocio
    {
        public void AgregarStock(Stock stock)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Stock (IdPrenda, Cantidad) VALUES (@IdPrenda, @Cantidad)");
                datos.agregarParametro("@IdPrenda", stock.IdPrenda);
                datos.agregarParametro("@Cantidad", stock.Cantidad);
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
                datos.setearConsulta("UPDATE Stock SET Cantidad = @Cantidad WHERE IdPrenda = @IdPrenda");
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
    }
}

