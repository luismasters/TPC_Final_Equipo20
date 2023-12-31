﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PagoNegocio
    {
        public List<MedioPago> Listar()
        {
            List<MedioPago> lista = new List<MedioPago>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select IDPago, Descripcion from MedioPago");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    MedioPago medioPago = new MedioPago();
                    medioPago.IDPago = Convert.ToInt32(datos.Lector["IDPago"]);
                    medioPago.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    lista.Add(medioPago);
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
    }
}
