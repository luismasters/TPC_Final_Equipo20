<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
     



        <div id="myCarousel" class="carousel slide banner" data-ride="carousel">
    <!-- Indicadores de carrusel (opcional) -->
    <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Imágenes del carrusel -->
    <div class="carousel-inner">
        <div class="carousel-item active">
            <img src="Content/Imagenes/providence-team-merchandising-ropa.jpg" alt="Imagen 1">
        </div>
        <div class="carousel-item">
            <img src="Content/Imagenes/Ropa-Gamer.jpg" alt="Imagen 2">
        </div>
        <div class="carousel-item">
            <img src="Content/Imagenes/imagen3.jpg" alt="Imagen 3">
        </div>
    </div>

    <!-- Controles de carrusel (opcional) -->
    <a class="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="sr-only">Anterior</span>
    </a>
    <a class="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="sr-only">Siguiente</span>
    </a>
</div>
  
   

<div class="container-fluid">
    <div class="row">
             <div class="col-md-3 filter-section">
            <!-- Caja de texto para filtrar por categoría -->
            <h5>Busqueda por Categoría:</h5>
            <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" Placeholder="Escribe una categoría" />
            
            <!-- Caja de texto para filtrar por precio -->
            <h5>Busqueda por Precio:</h5>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Placeholder="Escribe un precio" />
        </div>
        
        <!-- Sección de resultados (80%) -->
        <div class="col-md-9 result-section">
            <main>
                <div class="container align-content-center">
                    <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-center">
                        <asp:Repeater ID="rptArticulos" runat="server">
                            <ItemTemplate>
                                <div class="card mb-4" style="width: 16rem; margin-right: 20px;">
                                    <img src='<%# Eval("ImagenURL") %>' class="card-img-top" alt="Imagen del artículo" style="width: 230px; height: 250px;">
                                    <div class="card-body">
                                        <h6 class="card-title"><%# Eval("Descripcion") %></h6>
                                        <p class="card-text">$<%# Eval("Precio") %> Stock: <%# Eval("Stock") %></p>
                                        <p class="card-text">Categoria: <%# Eval("Categoria") %></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </main>
        </div>
    </div>
</div>




    </main>

</asp:Content>
