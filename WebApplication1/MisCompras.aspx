<%@ Page Title="MisCompras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="WebApplication1.MisCompras" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container mb-">
        <div class="row">
            <div class="col-2"></div>

            <div class="col-8">
                <asp:Repeater runat="server" ID="rptCompras" OnItemDataBound="rptCompras_ItemDataBound">
                    <ItemTemplate>
                        <div class="card text-black mb-4">
                            <div class="card-header">
                                <asp:Label runat="server" ID="lblContador"></asp:Label>
                            </div>
                            <p class="card-title">Monto total: $<%#Convert.ToDecimal(Eval("PrecioTotal")).ToString("F2") %></p>
                            <p class="card-text">
                                Medio de pago:  
                    <asp:Literal runat="server" Text='<%# ObtenerDescripcionMedioPago(Eval("MedioPago")) %>'></asp:Literal>
                            </p>
                            <p class="card-text">
                                Dirección de Envío:  
                    <asp:Literal runat="server" Text='<%# ObtenerDireccion(Eval("IDEnvio")) %>'></asp:Literal>
                            </p>
                            <p class="card-text">
                                <asp:Literal runat="server" Text='<%# ObtenerEnviado(Eval("IDEnvio")) %>'></asp:Literal>
                            </p>
                            <p class="card-text">
                                <asp:Literal runat="server" Text='<%# Convert.ToBoolean(Eval("Pagado")) ? "Pagado" : "A pagar" %>'></asp:Literal>
                            </p>
                            <div style="text-align: right;">
                                <asp:Button Text="Detalle de Mi compra" runat="server" class="btn btn-warning" OnClick="VerDetalle_Click" CommandName="VerDetalle" CommandArgument='<%# Eval("idVenta") %>' />
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
