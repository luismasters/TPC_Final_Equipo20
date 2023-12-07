<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="WebApplication1.Stock" %>

<!DOCTYPE html>
<html>
<head>
    <title>Gestión de Stock</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="formStock" runat="server" class="container mt-5">
        <div class="form-group">
            <label for="ddlPrendas">Prenda:</label>
                <asp:DropDownList ID="ddlPrendas" runat="server" CssClass="form-control"
                    OnSelectedIndexChanged="ddlPrendas_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

        </div>
        <div class="form-group">
            <label for="ddlTalles">Talle:</label>
            <asp:DropDownList ID="ddlTalles" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="txtCantidad">Cantidad:</label>
            <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-secondary" Text="Modificar" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>
</body>
</html>

