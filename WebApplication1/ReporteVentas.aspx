<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteVentas.aspx.cs" Inherits="WebApplication1.ReporteVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mb-4">




        <div class="row">
            <div class="col-3">
                <asp:Button ID="btnVentasSinDespachar" runat="server" Text="Ver Ventas Sin Despachar" OnClick="BtnVentasSinDespachar_Click" CssClass="btn btn-primary mb-2" />
                <asp:Button ID="btnVentasDespachadas" runat="server" Text="Ver Ventas Despachadas" OnClick="BtnVentasDespachadas_Click" CssClass="btn btn-info mb-2" /> <br />
                <asp:Label Text="Buscar por N° de venta" runat="server" />
<asp:TextBox ID="txtNVenta" Text="" runat="server" CssClass="form-control mb-2" type="number" />
<asp:RegularExpressionValidator ID="regexTxtNVenta" runat="server" ControlToValidate="txtNVenta" ErrorMessage="Por favor, ingrese solo valores numéricos." ValidationExpression="^\d+$" Display="Dynamic" />            
                <asp:Button Text="Buscar" runat="server" ID="buscarV" OnClick="buscarV_Click" CssClass="btn btn-warning mb-2" />

            </div>
            <div class="col-7">

                <asp:Repeater runat="server" ID="rptVentas">
                    <ItemTemplate>

                        <div class="card text-black mb-4">
                            <div class="card-header">
                                Venta N° de Control:  <%# (Eval("idVenta")) %>
                            </div>
                            <div class="card-body">
                                <p class="card-text">
                                    Cliente/Usuario:  
                            <asp:Literal runat="server" Text='<%# ObtenerUsuario(Eval("IDUsuario")) %>'></asp:Literal>
                                </p>

                                <h6 class="card-title">Monto de la Venta: $<%# Convert.ToDecimal(Eval("PrecioTotal")).ToString("F2") %></h6>
                                <p class="card-text">
                                    Tipo de pago:  
                            <asp:Literal runat="server" Text='<%# ObtenerDescripcionMedioPago(Eval("MedioPago")) %>'></asp:Literal>
                                </p>
                                <p class="card-text">
                                    Direccion Envio:  
                            <asp:Literal runat="server" Text='<%# ObtenerDireccion(Eval("IDEnvio")) %>'></asp:Literal>
                                </p>
                                <p class="card-text">
                                    Estatus:
    <%# Eval("Despachado").ToString().ToLower() == "true" ? "Despachado" : "Por despachar" %>
                                </p>
                                <div style="text-align: right;">
                                    <asp:Button ID="btnVerDetalle" Text="Ver Detalle" runat="server" class="btn btn-warning" OnClick="VerDetalle_Click" CommandName="VerDetalle" CommandArgument='<%# Eval("idVenta") %>' />
                                    <asp:Button
                                        ID="btnDespachar" Text="Marcar como Despachado" runat="server"
                                        class="btn btn-secondary"
                                        OnClick="Despachar_Click"
                                        Visible='<%# !(bool)Eval("Despachado") %>'
                                        CommandName="BtnDespa"
                                        CommandArgument='<%# Eval("idVenta") %>' />
                                </div>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-2"></div>
        </div>
    </div>
    <div style="height: 100px"></div>
</asp:Content>
