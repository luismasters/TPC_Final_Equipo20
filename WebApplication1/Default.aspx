<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
     


     <div class="container align-content-center">
    <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-center">
        <asp:Repeater ID="rptArticulos" runat="server">
            <ItemTemplate>
                <div class="card mb-4" style="width: 16rem; margin-right: 20px;">
                    <img src='<%# Eval("ImagenURL") %>' class="card-img-top" alt="Imagen del artículo" style="width: 230px; height: 250px;">
                    <div class="card-body">
                        <h6 class="card-title"><%# Eval("Descripcion") %></h6>
                        <p class="card-text">$<%# Eval("Precio") %> Stock: <%# Eval("Stock") %></p>
                        <p class="card-text">Categoria: <%# Eval("Categoria") %></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>







    </main>

</asp:Content>
