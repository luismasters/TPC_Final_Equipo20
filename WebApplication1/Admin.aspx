<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" class="container">



    <div class="container" >
        <h1 class="mb-5 text-center" style="margin-bottom:300px">Administrador </h1>
        <div class="row">
            <div class="col-md-4">
                <asp:ImageButton ImageUrl="~/Content/Imagenes/registro.jpg" runat="server" Width="200px" Height="150px"  OnClick="Alta_Click"/>
                <p> Agregar Nueva Prenda</p>

            </div>
            <div class="col-md-4">
                <asp:ImageButton ImageUrl="~/Content/Imagenes/modificar.png" runat="server" Width="200px" Height="150px" OnClick="Modificar_Click" />

                <p>Actualizar Registro de una prenda</p>            </div>
            <div class="col-md-4">            
                <asp:ImageButton ImageUrl="~/Content/Imagenes/Captura de pantalla 2023-11-15 222842.png" runat="server" Width="200px" Height="150px" OnClick="Unnamed_Click" />
                <p>Dar de baja una Prenda</p>            </div>
        </div>
    </div>

</asp:Content>