<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row">
            <!-- Formulario de Inicio de Sesión -->
            <div class="col-md-6">
                <h6>Si el usuario ya está logueado (sea usuario o admin) esta página debería llevar directo al perfil</h6>
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

            </div>

            <!-- Formulario de Registro -->
            <div class="col-md-6">
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
                <button type="submit" class="btn btn-success">Registrarse</button>

            </div>
        </div>
    </div>
</asp:Content>
