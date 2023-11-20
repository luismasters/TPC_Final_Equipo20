<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
                        <img src="Content/Imagenes/providence-team-merchandising-ropa.jpg" alt="Imagen 1" class="d-block w-100">
                    </div>
                    <div class="carousel-item">
                        <img src="Content/Imagenes/Ropa-Gamer.jpg" alt="Imagen 2" class="d-block w-100">
                    </div>
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

        <main>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container">     
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
             </ContentTemplate>
            </asp:UpdatePanel>
            </main>>
            </main>
</asp:Content>
