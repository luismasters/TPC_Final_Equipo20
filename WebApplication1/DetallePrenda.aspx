<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePrenda.aspx.cs" Inherits="WebApplication1.DetallePrenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container py-5 bg-ca" style="border-radius: 10px">
        <h2 class="text-center mb-5">Detalle del Producto</h2>
        <div class="row">
            <div class="col-md-1 text-center "></div>
            <div class="col-md-4 bg-con text-center" style="border-radius: 10px">

                <% if (Session["IDArt"] != null)
                    { %>
                <% foreach (Dominio.Prenda prenda in (List<Dominio.Prenda>)Session["ArticuloList"])
                    { %>
                <% if (prenda.Id == (int)Session["IDArt"])
                    { %>
                <div class="m-4">
                    <h3><%: prenda.Descripcion %></h3>
                    <p><strong>Precio:</strong> $<%= prenda.Precio.ToString() %></p>
                    <p><strong>Categoria:</strong> <%= prenda.Categoria%></p>
                    <p><strong>Linea:</strong> <%= prenda.Linea%></p>
                    <p><strong>Stock:</strong> <%= prenda.Stock%></p>



                    <div class="quantity align-items-center">
                        <asp:Button ID="btnDecrement" runat="server" Text="-" CssClass="btn btn-sm btn-warning" OnClick="btnDecrement_Click" UseSubmitBehavior="false" />
                        <asp:TextBox ID="quantity" runat="server" CssClass="custom-form-control text-center" Text="1" />
                        <asp:Button ID="btnIncrement" runat="server" Text="+" CssClass="btn btn-sm btn-warning" OnClick="btnIncrement_Click" UseSubmitBehavior="false" />
                    </div>
                    <p></p>
                    <asp:Button ID="btnAgregarCarrito" runat="server" CssClass="btn btn-warning btn-sm" Text="Agregar al carrito" OnClick="btnAgregarCarrito_Click" />
                </div>
                <% } %>
                <% } %>
                <a href="Default.aspx" class="btn btn-secondary btn-sm">Volver</a>
            </div>
            <div class="col-md-6 text-center bg-ca">
                <% foreach (Dominio.Prenda prenda in (List<Dominio.Prenda>)Session["ArticuloList"])
                    { %>
                <% if (prenda.Id == (int)Session["IDArt"])
                    { %>
                <div>
                    <% string imagenUrl = prenda.Imagenes[0].ImagenURL; %>
                    <img id="imagenProducto" src="<%= imagenUrl %>" class="custom-img" alt="Imagen del artículo" style="height: 450px; width: 500px; border-radius: 10px" />
                </div>
                <div class="additional-images">
                    <!-- Mostrar imágenes adicionales -->
                    <% for (int i = 0; i < prenda.Imagenes.Count; i++)
                        { %>
                    <img src="<%= prenda.Imagenes[i].ImagenURL %>" class="additional-img" alt="Imagen adicional del artículo" style="height: 100px; width: 100px; margin: 5px; cursor: pointer; border-radius: 10px" onclick="cambiarImagen('<%= prenda.Imagenes[i].ImagenURL %>')" />
                    <% } %>
                </div>

                <script>
                    var imagenes = [
                    <% foreach (Dominio.Imagen imagen in (List<Dominio.Imagen>)Session["ListImagenes"])
                    { %>
                        "<%= imagen.ImagenURL %>",
                    <% } %>
                    ];
                    var imagenActual = 0;
                    var imagenProducto = document.getElementById('imagenProducto');

                    function mostrarImagen() {
                        if (imagenes.length > 0) {
                            imagenProducto.src = imagenes[imagenActual];
                        } else {
                            imagenProducto.src = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Imagen_no_disponible.svg/1200px-Imagen_no_disponible.svg.png";
                        }
                    }

                    mostrarImagen(); // Mostrar la primera imagen al cargar la página

                    document.getElementById('btnAnterior').addEventListener('click', function () {
                        imagenActual = (imagenActual - 1 + imagenes.length) % imagenes.length;
                        mostrarImagen();
                    });

                    document.getElementById('btnSiguiente').addEventListener('click', function () {
                        imagenActual = (imagenActual + 1) % imagenes.length;
                        mostrarImagen();
                    });
                </script>
                <% } %>
                <% } %>
                <% } %>
            </div>
            <div class="col-md-1 text-center"></div>
        </div>
        <script>
            function cambiarImagen(nuevaImagenUrl) {
                var imagenProducto = document.getElementById('imagenProducto');
                imagenProducto.src = nuevaImagenUrl;
            }
        </script>
    </div>
















</asp:Content>
