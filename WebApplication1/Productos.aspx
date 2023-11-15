<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button ID="btnMostrarFiltro" runat="server"  ClientIDMode="Static" Text="Filtrar" CssClass="btn-mostrar-filtro btn-filtrar-circular" OnClientClick="toggleFiltro(); return false;" />

<div id="filtroSidebar" class="filtro-sidebar p-3" style="display: none;">

    <div class="form-group">
        <label for="txtFiltroCategoria">Categoría</label>

        <asp:DropDownList runat="server" ID="DropListCategoria" CssClass="form-control" DataTextField=" ">
           
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="txtFiltroLinea">Linea</label>
  <asp:DropDownList runat="server" ID="DropListLinea" CssClass="form-control">
     
  </asp:DropDownList>    </div>

    <div class="form-group">
        <label for="txtFiltroGenero">Genero</label>
        <asp:DropDownList runat="server" ID="DropListGenero" CssClass="form-control">
            <asp:ListItem Text="Masculino" />
            <asp:ListItem Text="Femenino" />
        </asp:DropDownList>
        </div>

    <div class="form-group">
        <label for="txtFiltroPrecio">Precio Máximo</label>
        <asp:TextBox ID="txtFiltroPrecio" runat="server" CssClass="form-control" Placeholder="Precio Máximo" />
    </div>

    <div class="form-group">
        <label for="txtFiltroNombre">Nombre</label>
        <asp:TextBox ID="txtFiltroNombre" runat="server" CssClass="form-control" Placeholder="Nombre" />
    </div>

    <asp:Button ID="btnFiltrar" runat="server" Text="Aplicar Filtros" OnClick="btnFiltrar_Click" CssClass="btn btn-primary btn-block mt-3" />
</div>
    
    <main>
        <div class="container">
            <div id="myCarousel" class="carousel slide banner" data-ride="carousel">
                <!-- Indicadores de carrusel (opcional) -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                </ol>
                <!-- Imágenes del carrusel -->
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="Content/Imagenes/providence-team-merchandising-ropa.jpg" alt="Imagen 1">
                    </div>
                    <div class="carousel-item">
                        <img src="Content/Imagenes/Ropa-Gamer.jpg" alt="Imagen 2">
                    </div>
                    <!-- Controles de carrusel (opcional) -->
                    <a class="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>

                    </a>
                    <a class="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>

                    </a>
                </div>
                <script>
                    $(document).ready(function () {
                        // Inicializa el carrusel
                        $('#myCarousel').carousel();
                    });
                </script>
            </div>
        </div>
        <%--<div class="container-fluid">
            <div class="row">
                <div class="col-1"></div>
                <div class="col-md-2 filter-section">
                    <!-- Caja de texto para filtrar por categoría -->
                    <h6>Busqueda por:</h6>
                    <h6>Categoría:</h6>
                    <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" Placeholder="Escribe una categoría" />
                    <!-- Caja de texto para filtrar por precio -->
                    <h6>Genero:</h6>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Placeholder="Genero" />
                    <h6>Linea:</h6>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Placeholder="Linea" />
                    <h6>Precio:</h6>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Placeholder="Escribe un precio" />
                </div>--%>
        <!-- Sección de resultados (80%) -->
        <%--<div class="col-md-9 result-section">--%>

        <div class="container">
            <p>Columna a la izquierda de las tarjetas para navegar items. Buzos, remeras, pantalones... Animé, gamer, etc   </p>
            <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-center">
                <asp:Repeater ID="rptArticulos" runat="server" OnItemCommand="RptArticulos_ItemCommand">
                    <ItemTemplate>
                        <div class="card mb-4" style="width: 18rem; margin-right: 10px;">
                            <img src='<%# Eval("ImagenURL") %>' class="card-img-top" alt="Imagen del artículo" style="width: 230px; height: 250px;">
                            <div class="card-body">
                                <h6 class="card-title"><%# Eval("Descripcion") %></h6>
                                <p class="card-text">$<%# Eval("Precio") %> Stock: <%# Eval("Stock") %></p>
                                <p class="card-text">Categoria: <%# Eval("Categoria") %></p>
                                <p class="card-text">Genero: <%# Eval("Genero") %></p>
                                <p class="card-text">Linea: <%# Eval("Linea") %></p>
                            </div>
                            <p></p>
                            <asp:Button ID="btnAgregarCarrito" runat="server" CssClass="btn btn-primary btn-sm" Text="Agregar al carrito" CommandName="Agregar" CommandArgument='<%# Eval("Id") %>' />
                            <p></p>
                            <div class="quantity d-flex justify-content-center align-items-center">
                                <asp:Button ID="BtnDecrement" runat="server" Text="-" CssClass="btn btn-sm btn-secondary" OnClick="BtnDecrement_Click" UseSubmitBehavior="false" />
                                <asp:TextBox ID="quantity" runat="server" CssClass="custom-form-control text-center" Text="1" />
                                <asp:Button ID="BtnIncrement" runat="server" Text="+" CssClass="btn btn-sm btn-secondary" OnClick="BtnIncrement_Click" UseSubmitBehavior="false" />
                            </div>
                            <p></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </main>
</asp:Content>
