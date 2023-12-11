<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button ID="btnMostrarFiltro" runat="server" ClientIDMode="Static" Text="Filtrar" CssClass="btn-mostrar-filtro btn-filtrar-circular" OnClientClick="toggleFiltro(); return false;" />

    <div id="filtroSidebar" class="filtro-sidebar p-3" style="display: none;">

        <div class="form-group">
            <label for="txtFiltroCategoria">Categoría</label>

            <asp:DropDownList runat="server" ID="DropListCategoria" CssClass="form-control" DataTextField=" ">
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtFiltroLinea">Linea</label>
            <asp:DropDownList runat="server" ID="DropListLinea" CssClass="form-control">
            </asp:DropDownList>
        </div>

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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%--        <input type="text" id="inputBusqueda" placeholder="Buscar productos..." class="form-control" />--%>
                <div class="container">
                    <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-center">
                        <asp:Repeater ID="rptArticulos" runat="server" OnItemCommand="RptArticulos_ItemCommand">
                            <ItemTemplate>
                                <div class="card mb-4 bg-ca" style="width: 18rem; margin-right: 10px;">
                                    <img src='<%# Eval("ImagenURL") %>' class="card-img-top" alt="Imagen del artículo" style="width: 100%; height: 250px;">
                                    <div class="card-body text-center">
                                        <h6 class="card-title" style="color: rgb(250 199 1)"><%# Eval("Descripcion") %></h6>
                                        <p class="card-text" style="font-size: 25px;">$<%# Eval("Precio") %> </p>
                                    </div>
                                    <div class="quantity d-flex justify-content-center align-items-center">
                                        <p></p>
                                        <a class="btn btn-warning btn-sm" href='<%# "DetallePrenda.aspx?id=" + Eval("Id") %>'>Ver</a>
                                        <p></p>
                                    </div>
                                    <p></p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div style="height: 50px">
        </div>
    </main>
</asp:Content>
