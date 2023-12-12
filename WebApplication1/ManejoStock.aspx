<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManejoStock.aspx.cs" Inherits="WebApplication1.ManejoStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


        <asp:HiddenField ID="HiddenFieldActiveTab" runat="server" />
       
              
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
                  <li class="nav-item">
                      <a class="nav-link" id="listarStock-tab" data-toggle="tab" href="#listarStock" role="tab" aria-controls="listarStock" aria-selected="false">Listar Stock</a>
                  </li>
              </ul>


              <div class="tab-content" id="stockTabsContent">
                    <!-- Pestaña Agregar -->
                <div class="tab-pane fade show active" id="agregar" role="tabpanel" aria-labelledby="agregar-tab">
                    <h3>Agregar Nuevo Lote</h3>
                    <div class="form-group">
                        <label for="ddlPrendasAgregar">Prenda:</label>
                        <asp:DropDownList ID="ddlPrendasAgregar" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPrendasAgregar_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="txtCantidadAgregar">Cantidad:</label>
                        <asp:TextBox ID="txtCantidadAgregar" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="ddlTalles">Talle:</label>
                        <asp:DropDownList ID="ddlTalles" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregar_Click" />
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
                            <asp:DropDownList ID="ddlPrendaEliminar" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLoteEliminar_SelectedIndexChanged" ></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="lblTalleEliminar">Talle:</label>
                            <asp:DropDownList ID="ddlTalleEliminar" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLoteEliminar_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="lblCantidadEliminar">Cantidad:</label>
                            <asp:TextBox ID="txtCantidadEliminar" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLoteEliminar_SelectedIndexChanged"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClientClick="return confirm('¿Está seguro de que desea eliminar este lote?');" OnClick="btnEliminar_Click" />

                  </div>

                  <!-- Pestaña Listar Stock -->
                  <div class="tab-pane fade" id="listarStock" role="tabpanel" aria-labelledby="listarStock-tab">
                      <h3>Listado de Stock</h3>
                      <asp:Button ID="btnActualizarStock" runat="server" Text="Actualizar Stock" OnClick="btnActualizarStock_Click" CssClass="btn btn-primary" />
                      <div class="table-responsive">
                          <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="False" CssClass="table" style="color: white;">
                              <Columns>
                                  <asp:BoundField DataField="DescripcionPrenda" HeaderText="Descripción Prenda" />
                                  <asp:BoundField DataField="Talle" HeaderText="Talle" />
                                  <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                  <asp:BoundField DataField="DescripcionCategoria" HeaderText="Categoría" />
                                  <asp:BoundField DataField="Lote" HeaderText="Lote" />
                              </Columns>
                          </asp:GridView>
                      </div>
                  </div>


        </div>
    </div>


            </ContentTemplate>
        </asp:UpdatePanel>


    <script>$(document).ready(function () {
            $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
                var activeTab = $(e.target).attr('href');
                $('#<%= HiddenFieldActiveTab.ClientID %>').val(activeTab);
    });
});
    </script>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>



</asp:Content>
