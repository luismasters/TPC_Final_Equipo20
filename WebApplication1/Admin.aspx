<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" class="container">


    <div class="container mt-4">

  <div class="mt-4">
    <h2>Gestión de Categorías</h2>
    <asp:Button ID="btnVerCategorias" runat="server" Text="Ver Categorías" OnClick="btnVerCategorias_Click" />
          <asp:Button ID="btnLimpiarLista" runat="server" Text="Limpiar Listas" OnClick="btnLimpiarLista_Click" />

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




    <div class="mt-4">
    <h2>Gestión de Líneas</h2>
    <asp:Button ID="btnVerLineas" runat="server" Text="Ver Líneas" OnClick="btnVerLineas_Click" />
            <asp:Button ID="Button1" runat="server" Text="Limpiar Listas" OnClick="btnLimpiarLista_Click" />

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
<div class="mt-4">
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
            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" Visible="false" />
            <asp:ImageField DataImageUrlField="ImagenURL" HeaderText="Imagen" SortExpression="ImagenURL" ControlStyle-Width="200" ControlStyle-Height="200" />
        </Columns>
    </asp:GridView>

    <!-- Sección para agregar nueva imagen -->
    <asp:Label ID="lblNuevaImagen" runat="server" Text="Nueva Imagen URL:"></asp:Label>
    <asp:TextBox ID="txtNuevaImagen" runat="server"></asp:TextBox>
    <asp:Button ID="btnAgregarImagen" runat="server" Text="Agregar Imagen" OnClick="btnAgregarImagen_Click" />
                <asp:Button ID="Button2" runat="server" Text="Limpiar Listas" OnClick="btnLimpiarLista_Click" />

</div>

         <h2>Agregar Nueva Prenda</h2>
    
    <div>
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
    </div>
    
    <div>
        <asp:Label ID="lblPrecio" runat="server" Text="Precio:"></asp:Label>
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
    </div>
    
    <div>
        <asp:Label ID="lblTalle" runat="server" Text="Talle:"></asp:Label>
        <asp:TextBox ID="txtTalle" runat="server"></asp:TextBox>
    </div>
    
    <div>
        <asp:Label ID="lblCategoria" runat="server" Text="Categoría:"></asp:Label>
        <!-- Agrega aquí un DropDownList con las categorías disponibles -->
        <asp:DropDownList ID="ddlCategorias" runat="server">
        </asp:DropDownList>
    </div>
    
   <div>
    <asp:Label ID="lblGenero" runat="server" Text="Género:"></asp:Label>
    <asp:DropDownList ID="ddlGeneros" runat="server">
        <asp:ListItem Text="Masculino" Value="1"></asp:ListItem>
        <asp:ListItem Text="Femenino" Value="2"></asp:ListItem>
    </asp:DropDownList>
</div>
    <div>
        <asp:Label ID="lblLinea" runat="server" Text="Línea:"></asp:Label>
        <!-- Agrega aquí un DropDownList con las líneas disponibles -->
        <asp:DropDownList ID="ddlLineas" runat="server">
        </asp:DropDownList>
    </div>
    
    <div>
        <asp:Button ID="btnAgregarPrenda" runat="server" Text="Agregar Prenda" OnClick="btnAgregarPrenda_Click" />
    </div>













</div>




</asp:Content>
