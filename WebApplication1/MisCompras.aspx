<%@ Page Title="MisCompras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="WebApplication1.MisCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater runat="server" ID="rptCompras" OnItemDataBound="rptCompras_ItemDataBound">
        <ItemTemplate>
            <div class="card text-black mb-4">
                <div class="card-header">
                    <asp:Label runat="server" ID="lblContador"></asp:Label>
                </div>
                <h6 class="card-title">Descripción: <%# (Eval("Descripcion")) %></h6>
                <h6 class="card-title">Monto total: $<%# (Eval("PrecioTotal")) %></h6>
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
            </div>
        </ItemTemplate>
    </asp:Repeater>


</asp:Content>
