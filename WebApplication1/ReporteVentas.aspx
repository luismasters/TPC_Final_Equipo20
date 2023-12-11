<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteVentas.aspx.cs" Inherits="WebApplication1.ReporteVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mb-4">
        <div class="row">
            <div class="col-2"></div>
            <div class="col-8">

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

                                <h6 class="card-title">Monto de la Venta: <%# (Eval("PrecioTotal")) %></h6>

                                <p class="card-text">
                                    Tipo de pago:  
                            <asp:Literal runat="server" Text='<%# ObtenerDescripcionMedioPago(Eval("MedioPago")) %>'></asp:Literal>
                                </p>

                                <p class="card-text">
                                    Direccion Envio:  
                            <asp:Literal runat="server" Text='<%# ObtenerDireccion(Eval("IDEnvio")) %>'></asp:Literal>
                                </p>


                                <div style="text-align: right;">
                                    <asp:Button Text="Ver Detalle" runat="server" class="btn btn-warning" OnClick="VerDetalle_Click" CommandName="VerDetalle" CommandArgument='<%# Eval("idVenta") %>' />
                                </div>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <div class="col-2"></div>


        </div>
    </div>
    <div style="height:100px"></div>
</asp:Content>
