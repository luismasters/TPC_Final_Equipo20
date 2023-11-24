<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alta.aspx.cs" Inherits="WebApplication1.Alta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container text-white">
        <h2 class="mb-5 text-center ">Agregar Nueva Prenda </h2>
        <div class="container ">
            <div class="row justify-content-center">
                <div class="col-3"></div>
                <div class="col-md-6" runat="server" id="divElemento1">
                    <div class="form-group">
                        <asp:Label Text="Descripcion" runat="server" ID="lblDescripcion" AssociatedControlID="TxtDescripcion" CssClass="mr-2" />
                        <asp:TextBox CssClass="form-control" runat="server" ID="TxtDescripcion" />
                        <asp:RequiredFieldValidator ID="ValidatorDescripcion" runat="server" ControlToValidate="TxtDescripcion" ErrorMessage="Campo requerido" Display="Dynamic" />
                    </div>

                    <div class="form-group">
                        <asp:Label Text="Precio" runat="server" ID="lblPrecio" AssociatedControlID="TxtPrecio" CssClass="mr-2" />
                        <asp:TextBox CssClass="form-control" runat="server" ID="TxtPrecio" />
                        <asp:RegularExpressionValidator ID="RegexValidatorPrecio" runat="server" ControlToValidate="TxtPrecio"
                            ErrorMessage="Debe ser un número válido" ValidationExpression="^(0|\d+(\.\d+)?)$" Display="Dynamic" />
                        <asp:RangeValidator ID="RangeValidatorPrecio" runat="server" ControlToValidate="TxtPrecio"
                            ErrorMessage="El precio debe ser mayor o igual a 0" MinimumValue="0" Type="Double" Display="Dynamic" />
                    </div>

                    <div class="form-group">
                        <asp:Label Text="Cantidad Ingreso" runat="server" ID="lblStock" AssociatedControlID="TxtStock" CssClass="mr-2" />
                        <asp:TextBox CssClass="form-control" runat="server" ID="TxtStock" type="integer" />
                    </div>

                    <div class="form-group">
                        <asp:Label Text="Talle" runat="server" ID="lblTalle" AssociatedControlID="TxtTalle" CssClass="mr-2" />
                        <asp:TextBox CssClass="form-control" runat="server" ID="TxtTalle" />
                        <asp:RegularExpressionValidator ID="RegexValidatorTalle" runat="server" ControlToValidate="TxtTalle"
                            ErrorMessage="Ingrese números o letras mayúsculas" ValidationExpression="^[A-Z0-9]+$" Display="Dynamic" />
                    </div>

                    <div class="form-group">
                        <asp:Label Text="Categoria" runat="server" ID="lblCategoria" AssociatedControlID="DropListCategoria" CssClass="mr-2" />
                        <asp:DropDownList CssClass="form-control" ID="DropListCategoria" runat="server">
                        </asp:DropDownList>
                        <asp:Button runat="server" ID="BtnAgregarCategoria" Text="Agregar Nueva" OnClick="BtnAgregarCategoria_Click" CssClass="btn btn-warning" />
                        <asp:TextBox runat="server" ID="TxtNuevaCategoria" Visible="false" placeholder="Nueva Categoría" CssClass="form-control mt-2" />
                        <asp:Button runat="server" ID="BtnNuevaCategoria" Text="Enviar" OnClick="BtnEnviarCategoria_Click" Visible="false" CssClass="btn btn-warning mt-2" OnClientClick="return confirm('¿Estás seguro de querer enviar la nueva categoría?');" />
                    </div>

                    <div class="form-group">
                        <asp:Label Text="Linea" ID="lblLinea" runat="server" AssociatedControlID="DropListLinea" CssClass="mr-2" />
                        <asp:DropDownList CssClass="form-control" runat="server" ID="DropListLinea">
                        </asp:DropDownList>
                        <asp:Button Text="Agregar Nueva" runat="server" ID="BtnAgregarLinea" OnClick="BtnAgregarLinea_Click" CssClass="btn  btn-warning" />
                        <asp:TextBox runat="server" ID="TxtNuevaLinea" Visible="false" placeholder="Nueva Línea" CssClass="form-control mt-2" />
                        <asp:Button runat="server" ID="BtnNuevaLinea" Text="Enviar" OnClick="BtnEnviarLinea_Click" Visible="false" CssClass="btn  btn-warning mt-2" OnClientClick="return confirm('¿Estás seguro de querer enviar la nueva línea?');" />
                    </div>

                    <div class="form-group">
                        <asp:Label Text="Genero" ID="lblGenero" runat="server" AssociatedControlID="DropListGenero" CssClass="mr-2" />
                        <asp:DropDownList CssClass="form-control" runat="server" ID="DropListGenero">
                            <asp:ListItem Text="Masculino" />
                            <asp:ListItem Text="Femenino" />
                        </asp:DropDownList>
                    </div>

              
                <div class="container justify-content-center">
    <div class="row">
        <div class="col-8"></div>
        <div class="col-4">

            <asp:Button runat="server" ID="BtnSiguiente" Text="Guardar y Seguir" OnClick="BtnSiguiente_Click" CssClass="btn  btn-warning" />
        </div>
    </div>
</div>
            </div>
  </div>

            <div class="container" runat="server" id="divElemento2">

                <div class="col-md-4"></div>
                <div class="col-md-4">

                    <div class="mb-2">
                        <asp:Label CssClass="form-label" Text="Imagen Prenda: carga una imagen desde tu equipo" runat="server" />
                                <div class="input-group">

                        <asp:FileUpload type="file" id="txtImage" runat="server" class="form-control" />   
                                    <span class="input-group-btn">
                                       
                        <asp:Button Text="Ver" runat="server" CssClass="btn btn-warning" OnClick="Registrar_Click" OnClientClick="return confirmarAlta();" /> 
                                        </span> </div>
                        <asp:Image ID="imgNueva" ImageUrl="https://img.freepik.com/vector-premium/foto-blanco-icono-simple-azul-plano-sombra-larga-xa_159242-10176.jpg?w=360" runat="server" CssClass="img-fluid mb-2" />
                        <div id="imageStrip" runat="server"></div>
                    </div>
                </div>

                <script>
                    // Supongamos que tienes una lista de URLs de imágenes en tu controlador o en el backend


                    // Función para generar la tira de imágenes
                    function mostrarImagenes() {
                        var imageStrip = document.getElementById('imageStrip');

                        // Recorre la lista de imágenes y crea elementos <img> para cada una
                        listaImagenes.forEach(function (imagenUrl) {
                            var img = document.createElement('img');
                            img.src = imagenUrl;
                            img.style.width = '150px'; // Define el ancho deseado para las imágenes
                            img.style.marginRight = '10px'; // Agrega margen derecho para separar las imágenes
                            imageStrip.appendChild(img); // Agrega la imagen al contenedor
                        });
                    }

                    // Llama a la función para mostrar las imágenes al cargar la página
                    window.onload = mostrarImagenes;
                </script>
                <asp:Button Text="Agregar otra img" runat="server" CssClass="btn  btn-warning" OnClick="AddImg_Click" />

                <script>
                    function confirmarAlta() {
                        return confirm("¿Estás seguro de dar de alta esta prenda?");
                    }
                </script>

            </div>
        </div>

    </div>
    
    <div class="d-flex justify-content-end">
        <a href="Default.aspx" class="mb-2">Salir</a>
    </div>








</asp:Content>
