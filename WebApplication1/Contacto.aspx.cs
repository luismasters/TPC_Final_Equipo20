using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
            }
        }
        protected void Contacto_click(object sender, EventArgs e)
        {
            
            EmailService emailService = new EmailService();
            string contactoNombre = nombreContacto.Text;
            string contactoApellido = apellidoContacto.Text;
            string contactoMail = emailContacto.Text;
            string contactoTelefono = telefonoContacto.Text;
            string contactoMensaje = cuerpoMensaje.Text;
            try
            {
                if (string.IsNullOrWhiteSpace(contactoNombre) || string.IsNullOrWhiteSpace(contactoApellido) || string.IsNullOrWhiteSpace(contactoMail) || string.IsNullOrWhiteSpace(contactoMensaje))
                {
                    lblErrorRegistro.Text = "Complete los campos requeridos.";
                    return;
                }
                emailService.RecibirCorreo(contactoMail, contactoNombre, contactoApellido, contactoTelefono, contactoMensaje);
                emailService.EnviarMail();
                LimpiarFormulario();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showSuccessAlert", "showSuccessAlert();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void LimpiarFormulario()
        {
            nombreContacto.Text = string.Empty;
            apellidoContacto.Text = string.Empty;
            emailContacto.Text = string.Empty;
            telefonoContacto.Text = string.Empty;
            cuerpoMensaje.Text = string.Empty;
        }
        
        
    }
}