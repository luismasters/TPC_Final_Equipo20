<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="WebApplication1.Checkout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalles de su compra</h1>
    <asp:GridView ID="gvCarritoCheckout" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="Precio" HeaderText="Precio unitario" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblTotal" runat="server" Text="Total: "></asp:Label>
    <br />
    <br />
    <asp:Panel ID="pnlMedioPago" runat="server">
        <asp:Label ID="lblMedioPago" runat="server" Text="Seleccione Medio de Pago: "></asp:Label>
        <asp:DropDownList ID="ddlMediosPago" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMediosPago_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
    </asp:Panel>
    <asp:Panel ID="pnlTarjeta" runat="server" Visible="false">
        <div>
            <label>Número de Tarjeta:</label>
            <asp:TextBox ID="txtNumTarjeta" runat="server" oninput="formatoTarjeta(this);" MaxLength="19"></asp:TextBox>
        </div>
        <div>
            <label>Fecha de Vencimiento:</label>
            <asp:TextBox ID="txtFechaVencimiento" runat="server" placeholder="MM/YY" oninput="formatoFechaVencimiento(this);" MaxLength="5"></asp:TextBox>
        </div>
        <div>
            <label>Código de Seguridad:</label>
            <asp:TextBox ID="txtCodigoSeguridad" runat="server" TextMode="Password" MaxLength="3"></asp:TextBox>
        </div>

    </asp:Panel>

    <asp:Panel ID="pnlCuotas" runat="server" Visible="false">
        <div>
            <label>Cuotas:</label>
            <asp:DropDownList ID="ddlCuotas" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCuotas_SelectedIndexChanged">
                <asp:ListItem Text="1 cuota" Value="1"></asp:ListItem>
                <asp:ListItem Text="3 cuotas" Value="3"></asp:ListItem>
                <asp:ListItem Text="6 cuotas" Value="6"></asp:ListItem>
                <asp:ListItem Text="12 cuotas" Value="12"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </asp:Panel>
    <br />
    <asp:CheckBox ID="chkEnvioDomicilio" runat="server" Text="Envio a domicilio" AutoPostBack="true" OnCheckedChanged="chkEnvioDomicilio_CheckedChanged" />
    <br />
    <asp:Panel ID="pnlDatosEnvio" runat="server" Visible="false">
        <label for="txtDireccion">Dirección:</label>
        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        <br />
        <label for="txtCiudad">Ciudad:</label>
        <asp:DropDownList ID="ddlCiudades" runat="server"></asp:DropDownList>
        <br />
        <label for="txtTelefono">Teléfono de contacto:</label>
        <asp:TextBox ID="txtTelefono" runat="server" onkeypress="return soloNumeros(event);" MaxLength="12" />
    </asp:Panel>
    <br />
    <asp:Label ID="lblTotalConRecargo" runat="server" Text="Total con recargos: " AutoPostBack="true"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnCancelarCompra" runat="server" Text="Cancelar Compra" CssClass="btn btn-danger"
        OnClientClick="return confirm('¿Estás seguro de que deseas cancelar la compra?');" OnClick="btnCancelarCompra_Click" />


    <script type="text/javascript">
        function formatoTarjeta(input) {
            var numTarjeta = input.value.replace(/\D/g, '');
            numTarjeta = numTarjeta.replace(/(\d{4})(?=\d)/g, '$1 ');
            input.value = numTarjeta;
        }
    </script>
    <script type="text/javascript">
        function formatoFechaVencimiento(input) {
            var valor = input.value.replace(/\D/g, ''); // Eliminar caracteres no numéricos
            var mes = valor.slice(0, 2);
            var anio = valor.slice(2, 4);

            if (mes.length === 2) {
                if (parseInt(mes) < 1 || parseInt(mes) > 12) {
                    mes = '01'; // Ajustar el mes si está fuera del rango
                }
            }

            if (anio.length === 2) {
                if (parseInt(anio) < 23) {
                    anio = '23'; // Ajustar el año si está fuera del rango
                }
            }

            var fechaFormateada = mes + '/' + anio;
            input.value = fechaFormateada;
        }

        function validarEntradaFechaVencimiento(event) {
            // Permitir las teclas de navegación (flechas, inicio, fin) y la tecla de retroceso
            if (event.keyCode == 8 || event.keyCode == 37 || event.keyCode == 39 || event.keyCode == 36 || event.keyCode == 35) {
                return true;
            }

            // Convertir el código de tecla a carácter
            var ch = String.fromCharCode(event.keyCode);

            // Verificar si el carácter es numérico
            if (!/^\d$/.test(ch)) {
                event.preventDefault();  // Cancelar la entrada no válida
            }
        }
    </script>
    <script type="text/javascript">
        function soloNumeros(e) {
            var charCode = (e.which) ? e.which : event.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
</asp:Content>


