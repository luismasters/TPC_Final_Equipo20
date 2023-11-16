<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebApplication1.Error" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1>Esta página solo es accesible para administradores</h1>
        <asp:Label Text="text" ID="lblMensaje" runat="server"/>
    </main>
</asp:Content>
