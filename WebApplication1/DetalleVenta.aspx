<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleVenta.aspx.cs" Inherits="WebApplication1.DetalleVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    

    <div class="container" >
        <table class="table" style="color:aqua">
  <thead>
    <tr>
      <th scope="col">Item</th>
      <th scope="col">Descripcion</th>
      <th scope="col">Cantidad</th>
      <th scope="col">Precio</th>
    </tr>

<%         int cont = 1;

    foreach(Dominio.DetalleVenta item in listaDetalle)
    {
        string descripcion = "";
        Negocio.PrendaNegocio prenda = new Negocio.PrendaNegocio();
        List<Dominio.Prenda> listaprenda = prenda.Listar();


        foreach(Dominio.Prenda p in listaprenda)
        {
            if (p.Id == item.IDPrenda)
            {
                descripcion = p.Descripcion;
                break;
            }
        }
%>
      <tbody style="color:whitesmoke" >
    <tr>
        <th scope="row"><%= cont.ToString() %></th>
         <% cont++; %>
      <td><%= descripcion %></td>
      <td><%= item.Cantidad %></td>
      <td><%= item.PrecioUnitario.ToString("0.00") %></td>
    </tr>

     </tbody> 
<%
    } 
%>

        </table>
</div>
</asp:Content>
