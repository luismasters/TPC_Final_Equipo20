<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row">
            <!-- Formulario de Inicio de Sesión -->
            <div class="col-md-6">
                <h2>Iniciar Sesión</h2>

                <div class="form-group">
                    <label for="loginUser">Nombre de usuario</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="loginUser" placeholder="Ingrese su nombre de usuario" />
                </div>

                <div class="form-group">
                    <label for="loginPassword">Contraseña</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="loginPassword" TextMode="Password" placeholder="Ingrese su contraseña" />
                </div>

                <asp:Button Text="Iniciar sesión" runat="server" CssClass="btn btn-primary" ID="BtnIngresar" OnClick="Btn_IniciarSesion_Click" />

                <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
            </div>

            <!-- Botón para mostrar el formulario de registro -->
            <div class="col-md-6">
                <button type="button" class="btn btn-link" onclick="mostrarFormularioRegistro()">¿No tienes cuenta? Regístrate aquí</button>

                <!-- Formulario de Registro (Oculto Inicialmente) -->
                <div id="formularioRegistro" style='<%# MostrarFormularioRegistro ? "display:block;": "display:none;" %>'>
                    <h2>Registrarse</h2>

                    <div class="form-group">
                        <label for="registerName">Nombre de Usuario</label>
                        <asp:TextBox runat="server" class="form-control" ID="registerName" placeholder="Ingrese su nombre de usuario" />
                    </div>

                    <div class="form-group">
                        <label for="registerEmail">Correo Electrónico</label>
                        <asp:TextBox runat="server" class="form-control" ID="registerEmail" placeholder="Ingrese su correo electrónico" />
                    </div>

                    <div class="form-group">
                        <label for="registerPassword">Contraseña</label>
                        <asp:TextBox runat="server" class="form-control" ID="registerPassword" TextMode="Password" placeholder="Ingrese su contraseña" />
                    </div>
                    <div class="form-check">
                        <input type="checkbox" runat="server" class="form-check-input" id="chkEsAdmin" />
                        <label class="form-check-label" for="chkEsAdmin">Soy Admin</label>
                    </div>

                    <div>
                        <asp:Label ID="lblErrorRegistro" runat="server" CssClass="text-danger"></asp:Label>
                    </div>

                    <div>
                        <asp:Button ID="BtnRegistrarse" runat="server" CssClass="btn btn-success" Text="Registrarse" OnClick="Btn_Registrarse_Click" />
                    </div>

                </div>
            </div>
        </div>
    </div>

    <script>
        function mostrarFormularioRegistro() {
            document.getElementById("formularioRegistro").style.display = "block";
        }

        function limpiarCamposRegistro() {
            document.getElementById('<%= registerName.ClientID %>').value = '';
            document.getElementById('<%= registerEmail.ClientID %>').value = '';
            document.getElementById('<%= registerPassword.ClientID %>').value = '';
        }
    </script>
</asp:Content>
