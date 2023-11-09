<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




  <div>
    <h2>Gestión de Categorías</h2>
    <asp:Button ID="btnVerCategorias" runat="server" Text="Ver Categorías" OnClick="btnVerCategorias_Click" />
    <br />
    <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Visible="false">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblNuevaCategoria" runat="server" Text="Nueva Categoría:"></asp:Label>
    <asp:TextBox ID="txtNuevaCategoria" runat="server"></asp:TextBox>
    <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar Categoría" OnClick="btnAgregarCategoria_Click" />
</div>




    <div>
    <h2>Gestión de Líneas</h2>
    <asp:Button ID="btnVerLineas" runat="server" Text="Ver Líneas" OnClick="btnVerLineas_Click" />
    <br />
    <asp:GridView ID="gvLineas" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Visible="false">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblNuevaLinea" runat="server" Text="Nueva Línea:"></asp:Label>
    <asp:TextBox ID="txtNuevaLinea" runat="server"></asp:TextBox>
    <asp:Button ID="btnAgregarLinea" runat="server" Text="Agregar Línea" OnClick="btnAgregarLinea_Click" />
</div>


    <!-- Otras secciones de tu página... -->
<div>
    <h2>Gestión de Imágenes</h2>
    <!-- DropDownList para seleccionar el ID de la prenda -->
    <asp:Label ID="lblSeleccionarPrenda" runat="server" Text="Seleccionar Prenda:"></asp:Label>
    <asp:DropDownList ID="ddlPrendas" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPrendas_SelectedIndexChanged">
    </asp:DropDownList>
    
    <!-- Botón para ver imágenes por PrendaID -->
    <asp:Button ID="btnVerImagenes" runat="server" Text="Ver Imágenes" OnClick="btnVerImagenes_Click" />

    <!-- Gridview para mostrar imágenes -->
    <asp:GridView ID="gvImagenes" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Visible="false">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
            <asp:ImageField DataImageUrlField="ImagenURL" HeaderText="Imagen" SortExpression="ImagenURL" ControlStyle-Width="50" ControlStyle-Height="50" />
        </Columns>
    </asp:GridView>

    <!-- Sección para agregar nueva imagen -->
    <asp:Label ID="lblNuevaImagen" runat="server" Text="Nueva Imagen URL:"></asp:Label>
    <asp:TextBox ID="txtNuevaImagen" runat="server"></asp:TextBox>
    <asp:Button ID="btnAgregarImagen" runat="server" Text="Agregar Imagen" OnClick="btnAgregarImagen_Click" />
</div>








</asp:Content>
