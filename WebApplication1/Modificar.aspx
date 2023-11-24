<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" Inherits="WebApplication1.Modificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-white">
    <div class="container">
        <asp:Label Text="Buscar Por Nombre" runat="server" ID="lblDescripcion" />
        <asp:TextBox runat="server" ID="TxtDescripcion" CssClass="form-control" />
        <asp:Button Text="Buscar" runat="server" OnClick="Buscar_Click" />


    </div>

    <div class="container text-center">
        <div class="row">
            <div class="col-md-3">
                <asp:Repeater ID="rptArticulos" runat="server">
                    <ItemTemplate>
                        <div class="card mb-3" style="width: 300px;">
                            <div class="row  ">
                                <div class="col-md-6">
                                    <img src='<%# Eval("ImagenURL") %>' class="img-fluid rounded-start" alt="...">
                                </div>
                                <div class="col-md-6">
                                    <div class="card-body">
                                        <h6 class="card-title" style="font-size:12px;" ><%# Eval("Descripcion") %></h6>
                                        <p class="card-text m-0"  style="font-size:12px;">Codigo: <%# Eval("ID") %></p>
                         <p class="card-text m-0"  style="font-size:12px";>Precio<%#FormatearPrecio(Eval("Precio")) %></p>
                          <p class="card-text m-0"  style="font-size:12px;">Talle: <%# Eval("Talle") %></p>
                          <p class="card-text m-0"  style="font-size:12px;">Stock: <%# Eval("Stock") %></p>
                        <p class="card-text m-0" style="font-size:12px;">Categoria: <%# Eval("Categoria.Descripcion") %></p>
                       <p class="card-text m-0" style="font-size:12px;">Linea: <%# Eval("Linea.Descripcion") %></p>
                        <p class="card-text m-0" style="font-size:12px;">Genero: <%# Eval("Genero.Descripcion") %></p>




                                        <asp:Button ID="Button1" runat="server" CommandName="MostrarDetalle" CommandArgument='<%# Eval("ID") %>' Text="Seleccionar" CssClass="btn btn-primary" OnClick="Seleccionar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>




            <div class="col-md-9">


                <div class="container">
                    <h4 class="text-center col-md-6">Modificar</h4>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="mb-2">
                                <asp:Label Text="Descripcion" runat="server" ID="Label1" />
                                <asp:TextBox CssClass="form-control" runat="server" ID="TxtDescripcionM" />

                            </div>
                            <div class="mb-2">
                                <asp:Label Text="Precio" runat="server" ID="lblPrecio" />
                                <asp:TextBox CssClass="form-control" runat="server" ID="TxtPrecio" />
                                
                              
                            </div>
                            <div class="mb-2">
                                <asp:Label Text="Cantidad Ingreso" runat="server" ID="lblStock" />
                                <asp:TextBox CssClass="form-control" runat="server" ID="TxtStock" type="integer" />
                            </div>
                            <div class="mb-2">
                                <asp:Label Text="Talle" runat="server" ID="lblTalle" />
                                <asp:TextBox CssClass="form-control" runat="server" ID="TxtTalle" />
                         
                            </div>
                            <div class="mb-2">
                                <asp:Label Text="Categoria" runat="server" ID="lblCategoria" />
                                <asp:DropDownList CssClass="form-control" ID="DropListCategoria" runat="server">
                                </asp:DropDownList>
                                <asp:TextBox runat="server" ID="TxtNuevaCategoria" Visible="false" placeholder="Nueva Categoría"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label Text="Linea" ID="lblLinea" runat="server" />
                                <asp:DropDownList CssClass="form-control" runat="server" ID="DropListLinea">
                                </asp:DropDownList>
                                <asp:TextBox runat="server" ID="TxtNuevaLinea" Visible="false" placeholder="Nueva Linea"></asp:TextBox>

                            </div>
                            <div class="mb-2">
                                <asp:Label Text="Genero" ID="lblGenero" runat="server" />
                                <asp:DropDownList CssClass="form-control" runat="server" ID="DropListGenero">
                                    <asp:ListItem Text="Masculino" />
                                    <asp:ListItem Text="Femenino" />
                                </asp:DropDownList>
                            </div>
                                <asp:Button ID="BtnModificar" Text="Modificar" runat="server" CssClass="btn btn-primary" OnClientClick="return confirmarAlta();" OnClick="Modificar_Click" Visible="false" />

                        </div>

                        <div class="col-md-8">
    <div class="mb-2"><asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>

        <asp:Label CssClass="form-label" Text="Imagen: carga una imagen desde tu equipo" runat="server" />
        <div class="input-group">
            <input type="file" id="txtImage" runat="server" class="form-control"  />
            <span class="input-group-btn">
                <asp:Button Text="Ver Imagen Seleccionada" runat="server" onclick="Ver_Click" CssClass="btn btn-secondary" />    <asp:Button Text="Guardar Imagen" runat="server" onclick="GuardarImg_Click" CssClass="btn btn-success" />

            </span>
        </div>
        <asp:Image ID="imgNueva" ImageUrl="https://img.freepik.com/vector-premium/foto-blanco-icono-simple-azul-plano-sombra-larga-xa_159242-10176.jpg?w=360" runat="server" CssClass="img-fluid mb-2" />
    </div>
    <script>
        function confirmarAlta() {
            return confirm("¿Estás seguro de Modificar esta prenda?");
        }
    </script>
</div>

                    </div>
                    <div class="d-flex justify-content-end">
                        <a href="Default.aspx" class="mb-2">Salir</a>
                    </div>
                </div>




            </div>
        </div>
    </div>

</div>
</asp:Content>
