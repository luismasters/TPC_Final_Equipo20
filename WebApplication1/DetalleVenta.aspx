<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleVenta.aspx.cs" Inherits="WebApplication1.DetalleVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



      <asp:GridView runat="server" ID="GridDetalle" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="IDPrenda" HeaderText="ID Prenda" />
        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
        <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
    </Columns>
</asp:GridView>

</asp:Content>
