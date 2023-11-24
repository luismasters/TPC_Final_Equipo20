<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Baja.aspx.cs" Inherits="WebApplication1.Baja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="text-white">
        <div class="container">
            <h1 class="text-center">Eliminar Prenda</h1>
            <asp:Label Text="Buscar Por Nombre" runat="server" ID="lblDescripcion" />
            <asp:TextBox runat="server" ID="TxtDescripcionB" CssClass="form-control" />
            <asp:Button Text="Buscar" runat="server" OnClick="Buscar_Click" CssClass="btn btn-warning" />
        </div>

        <div class="container text-center">
            <div class="row">
                <div class="col-md-3">
                    <asp:Repeater ID="rptArticulos" runat="server">
                        <ItemTemplate>
                            <div class="card mb-3 bg-ca text-dark" style="width: 300px;">
                                <div class="row  ">
                                    <div class="col-md-6">
                                        <img src='<%# Eval("ImagenURL") %>' class="img-fluid rounded-start" alt="...">
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card-body">
                                            <h6 class="card-title" style="font-size: 12px;"><%# Eval("Descripcion") %></h6>
                                            <p class="card-text m-0" style="font-size: 12px;">Codigo: <%# Eval("ID") %></p>
                                            <p class="card-text m-0" style="font-size: 12px;">Talle: <%# Eval("Talle") %></p>
                                            <p class="card-text m-0" style="font-size: 12px;">Stock: <%# Eval("Stock") %></p>
                                            <p class="card-text m-0" style="font-size: 12px;">Categoria: <%# Eval("Categoria.Descripcion") %></p>
                                            <p class="card-text m-0" style="font-size: 12px;">Linea: <%# Eval("Linea.Descripcion") %></p>
                                            <p class="card-text m-0" style="font-size: 12px;">Genero: <%# Eval("Genero.Descripcion") %></p>
                                            <asp:Button ID="Button1" runat="server" CommandName="MostrarDetalle" CommandArgument='<%# Eval("ID") %>' Text="Seleccionar" CssClass="btn  btn-warning" OnClick="Seleccionar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>





        <div class="container">
            <div class="col-2">
                <asp:Button ID="botonEli" Text="Eliminar Prenda" runat="server" OnClick="Eliminar_Click" CssClass="btn btn-warning" Visible="false" />
            </div>
        </div>


    </div>


</asp:Content>
