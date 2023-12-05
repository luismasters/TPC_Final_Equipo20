﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["carritoCheckout"] != null)
                {
                    var carrito = (DataTable)Session["carritoCheckout"];

                    gvCarritoCheckout.DataSource = carrito;
                    gvCarritoCheckout.DataBind();
                    decimal total = carrito.AsEnumerable().Sum(row => row.Field<decimal>("Precio") * row.Field<int>("Cantidad"));
                    lblTotal.Text = "Total: " + total.ToString("C");
                }
                CargarMediosPago();
            }
        }
        private decimal ObtenerPrecioTotal()
        {
                var carrito = (DataTable)Session["carritoCheckout"];
                decimal total = carrito.AsEnumerable().Sum(row => row.Field<decimal>("Precio") * row.Field<int>("Cantidad"));
                return total;           
        }

        private void CargarMediosPago()
        {
            PagoNegocio negocio = new PagoNegocio();
            List<MedioPago> mediosDePago = negocio.Listar();

            ddlMediosPago.DataSource = mediosDePago;
            ddlMediosPago.DataTextField = "Descripcion";
            ddlMediosPago.DataValueField = "IDPago";
            ddlMediosPago.DataBind();
        }

        protected void ddlMediosPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string medioPagoSeleccionado = ddlMediosPago.SelectedItem.Text;


            pnlTarjeta.Visible = false;
            pnlCuotas.Visible = false;


            if (medioPagoSeleccionado == "Debito")
            {
                pnlTarjeta.Visible = true;
            }
            else if (medioPagoSeleccionado == "Credito")
            {
                pnlTarjeta.Visible = true;
                pnlCuotas.Visible = true;
            }
        }
        private decimal CalculoCuotas(int cantCuotas)
        {
            decimal precioTotal = ObtenerPrecioTotal();
            decimal aumentoPorcentaje = 0;

            switch (cantCuotas)
            {
                case 3:
                    aumentoPorcentaje = 0.12m;
                    break;
                case 6:
                    aumentoPorcentaje = 0.18m;
                    break;
                case 12:
                    aumentoPorcentaje = 0.26m;
                    break;
            }
            decimal precioTotalConAumento = precioTotal * (1 + aumentoPorcentaje);
            return precioTotalConAumento;
        }
        protected void ddlCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cuotas = Convert.ToInt32(ddlCuotas.SelectedValue);
            decimal precioTotalConAumento = CalculoCuotas(cuotas);
            ListItem listItem = ddlCuotas.Items.FindByValue(cuotas.ToString());

            if (listItem != null)
            {
                listItem.Text = $"{cuotas} cuotas (total {precioTotalConAumento:C})";
            }
        }

    }
}