<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="WebApplication1.Contacto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="well well-sm">
                        <class="form-horizontal" method="post">
                            <fieldset>
                                <legend class="text-center header">Contactate con nosotros</legend>

                                <div class="form-group">
                                    <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-user bigicon"></i></span>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" class="form-control" ID="nombreContacto" placeholder="Nombre" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-user bigicon"></i></span>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" class="form-control" ID="apellidoContacto" placeholder="Apellido" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-envelope-o bigicon"></i></span>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" class="form-control" ID="emailContacto" placeholder="Email" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-phone-square bigicon"></i></span>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" class="form-control" ID="telefonoContacto" placeholder="Telefono (opcional)" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <span class="col-md-1 col-md-offset-2 text-center"><i class="fa fa-pencil-square-o bigicon"></i></span>
                                    <div class="col-md-8">
                                        <div>
                                            <asp:Label ID="lblErrorRegistro" runat="server" CssClass="text-danger"></asp:Label>
                                        </div>
                                        <asp:TextBox ID="cuerpoMensaje" runat="server" TextMode="MultiLine" Rows="10" Columns="50"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-12 text-center">
                                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Contactanos" ID="ContactoBtn" OnClick="Contacto_click" />
                                     </div>
                                </div>
                            </fieldset>
                      </div>
                </div>
            </div>
        </div>
    </main>
    <script type="text/javascript">
    function showSuccessAlert() {
        alert("Gracias por comunicarte con nosotros!.");
    }
    </script>
</asp:Content>
