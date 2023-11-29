<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="WebApplication1.Checkout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvCarritoCheckout" runat="server" AutoGenerateColumns="False">

        <Columns>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion del Producto" />
            <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                    <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:DropDownList ID="ddlMediosPago" runat="server" CssClass="form-control" />
    <asp:Label ID="lblTotalCheckout" runat="server" Text="Total: "></asp:Label>
</asp:Content>
