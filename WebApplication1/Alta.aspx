<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alta.aspx.cs" Inherits="WebApplication1.Alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
    <div class="container">
        <h2 class="mt-5 mb-5 text-center col-md-6">Agregar Nueva Prenda </h2>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-2">
                    <asp:Label Text="Descripcion" runat="server" ID="lblDescripcion" />
                    <asp:TextBox CssClass="form-control" runat="server" ID="TxtDescripcion"  />
                    <asp:RequiredFieldValidator ID="ValidatorDescripcion" runat="server" ControlToValidate="TxtDescripcion" ErrorMessage="Campo requerido" Display="Dynamic" />

                </div>
                <div class="mb-2">
                    <asp:Label Text="Precio" runat="server" ID="lblPrecio" />
<asp:TextBox CssClass="form-control" runat="server" ID="TxtPrecio" />
<asp:RegularExpressionValidator ID="RegexValidatorPrecio" runat="server" ControlToValidate="TxtPrecio"
    ErrorMessage="Debe ser un número válido" ValidationExpression="^(0|\d+(\.\d+)?)$" Display="Dynamic" />
<asp:RangeValidator ID="RangeValidatorPrecio" runat="server" ControlToValidate="TxtPrecio"
    ErrorMessage="El precio debe ser mayor o igual a 0" MinimumValue="0" Type="Double" Display="Dynamic" />              </div>
                <div class="mb-2">
                    <asp:Label Text="Cantidad Ingreso" runat="server" ID="lblStock" />
<asp:TextBox CssClass="form-control" runat="server" ID="TxtStock" type="integer"/>
         </div>
                <div class="mb-2">
                    <asp:Label Text="Talle" runat="server" ID="lblTalle" />
<asp:TextBox CssClass="form-control" runat="server" ID="TxtTalle" />
<asp:RegularExpressionValidator ID="RegexValidatorTalle" runat="server" ControlToValidate="TxtTalle"
    ErrorMessage="Ingrese números o letras mayúsculas" ValidationExpression="^[A-Z0-9]+$" Display="Dynamic" />
                </div>
                <div class="mb-2">
                    <asp:Label Text="Categoria" runat="server" ID="lblCategoria" />
                    <asp:DropDownList CssClass="form-control" ID="DropListCategoria" runat="server">
                    </asp:DropDownList>
                    <asp:Button runat="server" ID="BtnAgregarCategoria" Text="add Nueva" OnClick="BtnAgregarCategoria_Click" CssClass="btn btn-primary" />
                    <asp:TextBox runat="server" ID="TxtNuevaCategoria" Visible="false" placeholder="Nueva Categoría"></asp:TextBox>
                    <asp:Button runat="server" ID="BtnNuevaCategoria" Text="Enviar" OnClick="BtnEnviarCategoria_Click" Visible="false" CssClass="btn btn-primary" OnClientClick="return confirm('¿Estás seguro de querer enviar la nueva categoría?');" />
                </div>
                <div class="mb-2">
                    <asp:Label Text="Linea" ID="lblLinea" runat="server" />
                    <asp:DropDownList CssClass="form-control" runat="server" ID="DropListLinea">
                    </asp:DropDownList>
                    <asp:Button Text="add Nueva" runat="server" ID="BtnAgregarLinea" OnClick="BtnAgregarLinea_Click" CssClass="btn btn-primary" />
                    <asp:TextBox runat="server" ID="TxtNuevaLinea" Visible="false" placeholder="Nueva Linea"></asp:TextBox>
                    <asp:Button runat="server" ID="BtnNuevaLinea" Text="Enviar" OnClick="BtnEnviarLinea_Click" Visible="false" CssClass="btn btn-primary" OnClientClick="return confirm('¿Estás seguro de querer enviar la nueva Linea?');" />

                </div>
                <div class="mb-2">
                    <asp:Label Text="Genero" ID="lblGenero" runat="server" />
                    <asp:DropDownList CssClass="form-control" runat="server" ID="DropListGenero">
                        <asp:ListItem Text="Masculino" />
                        <asp:ListItem Text="Femenino" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-md-8">
                <div class="mb-2">
                    <asp:Label CssClass="form-label" Text="Imagen Prenda: carga una imagen desde tu equipo" runat="server" />
                    <input type="file" ID="txtImage" runat="server" class="form-control" /> 
                    <asp:Image ID="imgNueva" ImageUrl="https://img.freepik.com/vector-premium/foto-blanco-icono-simple-azul-plano-sombra-larga-xa_159242-10176.jpg?w=360" runat="server" CssClass="img-fluid mb-2" />
                </div>
                <asp:Button Text="Dar Alta a la prenda" runat="server" CssClass="btn btn-primary" OnClick="Registrar_Click" OnClientClick="return confirmarAlta();"/>
                <script>
                    function confirmarAlta() {
                        return confirm("¿Estás seguro de dar de alta esta prenda?");
                    }
                </script>

            </div>

        </div>
 <div class="d-flex justify-content-end">
      <a href="Default.aspx" class="mb-2">Salir</a>
    </div>
    </div>







</asp:Content>
