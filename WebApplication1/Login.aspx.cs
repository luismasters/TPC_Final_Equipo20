using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        public bool MostrarFormularioRegistro { get; set; } = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataBind();
                if (Session["usuario"] != null)
                {
                    Response.Redirect("Perfil.aspx");
                    return;
                }

            //// Si el usuario ya está logueado, redirige al perfil
            //if (Session["usuario"] != null)
            //{
            //    Response.Redirect("Perfil.aspx"); 
            }
        }

        protected void Btn_IniciarSesion_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                string username = loginUser.Text;
                string password = loginPassword.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    lblError.Text = "Nombre de usuario y contraseña son requeridos.";
                    return;
                }

                Usuario usuario = usuarioNegocio.Loguear(username, password);
                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    Session.Add("usuario", usuario);

                    // Redirige a la página de perfil del usuario
                    Response.Redirect("Perfil.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al iniciar sesión.";
            }
        }

        protected void Btn_Registrarse_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            EmailService emailService = new EmailService();

            try
            {
                string username = registerName.Text;
                string email = registerEmail.Text;
                string password = registerPassword.Text;
                bool rol = chkEsAdmin.Checked;

                // Validación básica
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    lblErrorRegistro.Text = "Todos los campos son requeridos.";
                    return;
                }

                // Validación de formato de corrEo
                //if (!Regex.IsMatch(email, @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"))
                //{
                //    lblErrorRegistro.Text = "El formato del correo electrónico es inválido.";
                //    return;
                //}

                // Validación de contraseña (longitud y composición)
                //if (password.Length < 8 || !Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"))
                //{
                //    lblErrorRegistro.Text = "La contraseña debe tener al menos 8 caracteres e incluir al menos una letra y un número.";
                //    return;
                //}

                // Proceso de registro
                Usuario nuevoUsuario = new Usuario(username, password, email, rol);
                bool registrado = usuarioNegocio.Registrar(nuevoUsuario);
                if (registrado)
                {
                    MostrarFormularioRegistro = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistroExitoso",
                        "alert('Registro exitoso. A continuación será redirigido a la página de inicio.'); " +
                        "limpiarCamposRegistro();", true);
                    emailService.ArmarCorreo(nuevoUsuario.Email, "Bienvenido a Prendas.Net", "Te damos la bienvenida");
                    emailService.EnviarMail();
                    if (nuevoUsuario != null)
                    {
                        FormsAuthentication.SetAuthCookie(username, false);
                        Session.Add("usuario", nuevoUsuario);
                        Response.Redirect("Default.aspx", false);
                    }
                }
                else
                {
                    MostrarFormularioRegistro = true;
                    lblErrorRegistro.Text = "No se pudo completar el registro.";
                }
                DataBind();
            }
            catch (Exception ex)
            {
                lblErrorRegistro.Text = "Ocurrió un error al registrar.";
            }
        }
    }
}