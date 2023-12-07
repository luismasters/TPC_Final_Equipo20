<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManejoStock.aspx.cs" Inherits="WebApplication1.ManejoStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container mt-5">
        <!-- Aquí comienza el contenido de la pestaña -->
              <ul class="nav nav-tabs" id="stockTabs" role="tablist">
                  <li class="nav-item">
                      <a class="nav-link active" id="agregar-tab" data-toggle="tab" href="#agregar" role="tab" aria-controls="agregar" aria-selected="true">Agregar</a>
                  </li>
                  <li class="nav-item">
                      <a class="nav-link" id="modificar-tab" data-toggle="tab" href="#modificar" role="tab" aria-controls="modificar" aria-selected="false">Modificar</a>
                  </li>
                  <li class="nav-item">
                      <a class="nav-link" id="eliminar-tab" data-toggle="tab" href="#eliminar" role="tab" aria-controls="eliminar" aria-selected="false">Eliminar</a>
                  </li>
              </ul>


              <div class="tab-content" id="stockTabsContent">
<!-- Pestaña Agregar -->
                <div class="tab-pane fade show active" id="agregar" role="tabpanel" aria-labelledby="agregar-tab">
                    <h3>Agregar Nuevo Lote</h3>
                    <div class="form-group">
                        <label for="ddlPrendasAgregar">Prenda:</label>
                        <asp:DropDownList ID="ddlPrendasAgregar" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="txtCantidadAgregar">Cantidad:</label>
                        <asp:TextBox ID="txtCantidadAgregar" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="ddlTallesAgregar">Talle:</label>
                        <asp:DropDownList ID="ddlTalles" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregar_Click" />
                </div>

            </div>

                <!-- Pestaña Modificar -->
                    <div class="tab-pane fade" id="modificar" role="tabpanel" aria-labelledby="modificar-tab">
                        <h3>Modificar Lote Existente</h3>
                        <div class="form-group">
                            <label for="ddlLoteModificar">Lote:</label>
                            <asp:DropDownList ID="ddlLoteModificar" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLoteModificar_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlPrendasModificar">Prenda:</label>
                            <asp:DropDownList ID="ddlPrendasModificar" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlTallesModificar">Talle:</label>
                            <asp:DropDownList ID="ddlTallesModificar" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="txtCantidadModificar">Cantidad:</label>
                            <asp:TextBox ID="txtCantidadModificar" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-secondary" Text="Modificar" OnClick="btnModificar_Click" />
                    </div>




                <!-- Pestaña Eliminar -->
                <div class="tab-pane fade" id="eliminar" role="tabpanel" aria-labelledby="eliminar-tab">
                    <h3>Eliminar Lote Existente</h3>
                    <div class="form-group">
                        <label for="ddlLoteEliminar">Lote:</label>
                        <asp:DropDownList ID="ddlLoteEliminar" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLoteEliminar_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="lblPrendaEliminar">Prenda:</label>
                        <asp:Label ID="lblPrendaEliminar" runat="server" CssClass="form-control"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label for="lblTalleEliminar">Talle:</label>
                        <asp:Label ID="lblTalleEliminar" runat="server" CssClass="form-control"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label for="lblCantidadEliminar">Cantidad:</label>
                        <asp:Label ID="lblCantidadEliminar" runat="server" CssClass="form-control"></asp:Label>
                    </div>
                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClientClick="return confirm('¿Está seguro de que desea eliminar este lote?');" OnClick="btnEliminar_Click" />                 </div>
            </div>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>

</asp:Content>
