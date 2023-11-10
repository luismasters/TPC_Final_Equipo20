<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>

        <div class="container mt-5">
            <div class="row">
                <!-- Formulario de Inicio de Sesión -->
                <div class="col-md-6">
                    <h2>Iniciar Sesión</h2>
                    <form>
                        <div class="form-group">
                            <label for="loginEmail">Correo Electrónico</label>
                            <input type="email" class="form-control" id="loginEmail" placeholder="Ingrese su correo electrónico">
                        </div>
                        <div class="form-group">
                            <label for="loginPassword">Contraseña</label>
                            <input type="password" class="form-control" id="loginPassword" placeholder="Ingrese su contraseña">
                        </div>
                        <button type="submit" class="btn btn-primary">Iniciar Sesión</button>
                    </form>
                </div>

                <!-- Formulario de Registro -->
                <div class="col-md-6">
                    <h2>Registrarse</h2>
                    <form>
                        <div class="form-group">
                            <label for="registerName">Nombre Completo</label>
                            <input type="text" class="form-control" id="registerName" placeholder="Ingrese su nombre completo">
                        </div>
                        <div class="form-group">
                            <label for="registerEmail">Correo Electrónico</label>
                            <input type="email" class="form-control" id="registerEmail" placeholder="Ingrese su correo electrónico">
                        </div>
                        <div class="form-group">
                            <label for="registerPassword">Contraseña</label>
                            <input type="password" class="form-control" id="registerPassword" placeholder="Ingrese su contraseña">
                        </div>
                        <button type="submit" class="btn btn-success">Registrarse</button>
                    </form>
                </div>
            </div>
        </div>

        <!-- Scripts de Bootstrap y jQuery (asegúrate de tener una conexión a Internet para cargar estos scripts) -->
        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.1/dist/umd/popper.min.js"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    </body>
</asp:Content>
