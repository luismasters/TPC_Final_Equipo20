<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" class="container">


  <div class="container">
    <h2>Agregar Nueva Prenda</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-2">
     <asp:Label Text="Descripcion" runat="server" ID="lblDescripcion" />   
     <asp:TextBox CssClass="form-control" runat="server" ID="TxtDescripcion"/>  </div>
            <div class="mb-2">
     <asp:Label Text="Precio" runat="server" ID="lblPrecio" />   
     <asp:TextBox CssClass="form-control" runat="server" ID="TxtPrecio"/>  </div>
            <div class="mb-2">
    <asp:Label Text="Cantidad Ingreso" runat="server" ID="lblStock" />   
    <asp:TextBox CssClass="form-control" runat="server" ID="TxtStock"/> </div>  
            <div class="mb-2">
    <asp:Label Text="Talle" runat="server" ID="lblTalle" />   
   <asp:TextBox CssClass="form-control" runat="server" ID="TxtTalle"/>  </div>
            <div class="mb-2">
    <asp:Label Text="Categoria" runat="server" ID="lblCategoria" />   
    <asp:DropDownList CssClass="form-control" ID="DropListCategoria" runat="server">  
    </asp:DropDownList>
    <asp:Button runat="server" ID="BtnAgregarCategoria" Text="Agregar Nueva Categoría" OnClick="BtnAgregarCategoria_Click" />
    <asp:TextBox runat="server" ID="TxtNuevaCategoria" Visible="false" placeholder="Nueva Categoría"></asp:TextBox>
    <asp:Button runat="server" ID="BtnNuevaCategoria" Text="Enviar" OnClick="BtnEnviarCategoria_Click" Visible="false"  OnClientClick="return confirm('¿Estás seguro de querer enviar la nueva categoría?');" /></div>
    <div class="mb-2">
            <asp:Label Text="Linea" ID="lblLinea" runat="server" />
    <asp:DropDownList CssClass="form-control" runat="server" ID="DropListLinea" >
    </asp:DropDownList>
    <asp:Button Text="Agregar Nueva Linea" runat="server" ID="BtnAgregarLinea" OnClick="BtnAgregarLinea_Click" />
    <asp:TextBox runat="server" ID="TxtNuevaLinea" Visible="false" placeholder="Nueva Linea"></asp:TextBox>
    <asp:Button runat="server" ID="BtnNuevaLinea" Text="Enviar" OnClick="BtnEnviarLinea_Click" Visible="false"  OnClientClick="return confirm('¿Estás seguro de querer enviar la nueva Linea?');" /></div>
   <div class="mb-2">
    <asp:Label Text="Genero" ID="lblGenero" runat="server" />
    <asp:DropDownList CssClass="form-control" runat="server" ID="DropListGenero">
        <asp:ListItem Text="Masculino" />
        <asp:ListItem Text="Femenino" />
    </asp:DropDownList></div>
    </div>

        <div class="col-md-4">
            <div class="mb-2">
                <asp:Label CssClass="form-label" Text ="Imagen Prenda" runat="server" />
                <input type="file" name="txtImage" runat="server" class="form-control"  />
                <asp:Image ID="imgNueva" ImageUrl="https://w7.pngwing.com/pngs/666/274/png-transparent-image-pictures-icon-photo-thumbnail.png" runat="server"  CssClass="img-fluid mb-2" />
            </div>

        </div>

   </div>

  </div>
</asp:Content>

