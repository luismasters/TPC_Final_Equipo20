<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="WebApplication1.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <h1>Bienvenido  <%#ObtenerNombreUsuario() %></h1>
    <asp:Button ID="BtnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="BtnCerrarSesion_Click" CssClass="btn btn-danger" />
    <asp:Button ID="BtnOpcionAdmin" runat="server" Text="Administrar sitio" OnClick="BtnOpcionAdmin_Click" CssClass="btn btn-info" Visible='<%# EsAdmin() %>' />   
    <asp:Button ID="BtnVerVentas" runat="server" Text="Reporte Ventas" OnClick="BtnVerVentas_Click" CssClass="btn btn-info" Visible='<%# EsAdmin() %>' />   

    </div>
</asp:Content>