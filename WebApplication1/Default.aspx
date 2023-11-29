<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section>
        <img src="Content/ImgNegocio/Captura de pantalla 2023-11-22 171835.png" />
        <img src="Content/ImgNegocio/Captura de pantalla 2023-11-22 185249.png" />
        <img src="Content/ImgNegocio/Captura de pantalla 2023-11-22 172636.png" />
        <img src="Content/ImgNegocio/Captura de pantalla 2023-11-22 172346.png" />
    </section>

    <div class="container text-dark">
        <div class="row">   
            <div class="col-md-6" style="height: 700px; padding: 0; margin: 0;">
                <img src="Content/ImgNegocio/Captura de pantalla 2023-11-22 172756.png" class="img-fluid" style="width: 100%; height: 100%" />
            </div>
            <div class="col-md-6 bg-ca text-center" style="height: 700px;">
                <img src="Content/ImgNegocio/Captura de pantalla 2023-11-22 214053.png" style="height: 300px; width: 300px; border-radius: 50%; margin: auto; margin-top: 30px;" />
                <h5>Quiénes somos:</h5>
                <p class="mt-2
                    "
                    style="font-size: 16px;">
                    Descubre la esencia de SUPERTIENDAS.NET
                En SUPERTIENDAS.NET, nuestra pasión radica en ofrecerte una experiencia de moda versátil y dinámica. Somos una tienda dedicada a brindar 
                la mejor selección de prendas de vestir para todos los estilos y ocasiones.
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 bg-ca  text-center" style="height: 700px; display: flex; flex-direction: column; justify-content: center;">
                <h5>Nuestra Misión:</h5>
                <p class="my-5 mx-5" style="font-size: 18px;">
                    En SUPERTIENDAS.NET nos esforzamos por ofrecer una colección única que se adapte a las múltiples facetas de tu vida. Desde lo casual hasta lo formal, desde
                 lo gamer hasta lo deportivo, nos comprometemos a proporcionar ropa que refleje tu personalidad y estilo de vida.
                    <br />
                    Variedad de Categorías y Líneas:
                    <br />
                    Nuestra amplia gama de categorías incluye remeras, pantalones, camisas, buzos, camperas y mucho más. Además, ofrecemos diversas líneas 
       que abarcan desde la moda casual para el día a día hasta la elegancia formal, pasando por la frescura de la moda veraniega y la autenticidad de la moda gamer.
                </p>
            </div>
            <div class="col-md-6" style="height: 700px; padding: 0; margin: 0;">
                <img src="Content/ImgNegocio/Captura de pantalla 2023-11-22 224939.png" class="img-fluid" style="width: 100%; height: 100%;" />
            </div>
        </div>
    </div>
    <div class="bg-ca mt-2" style="height: 400px; color: rgb(39 37 37); display: flex; flex-direction: column; justify-content: center;">
        <div class="container">
            <div class="row">
                <div class="col-md-3 text-center">
                    <i class="bi bi-credit-card-2-back"></i>
                    <svg xmlns="http://www.w3.org/2000/svg" width="60" height="60" fill="currentColor" class="bi bi-credit-card" viewBox="0 0 16 16">
                        <path d="M0 4a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2zm2-1a1 1 0 0 0-1 1v1h14V4a1 1 0 0 0-1-1zm13 4H1v5a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1z" />
                        <path d="M2 10a1 1 0 0 1 1-1h1a1 1 0 0 1 1 1v1a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1z" />
                    </svg>
                    <p>Acepatmos tu Tarjeta de Credito</p>
                </div>
                <div class="col-md-3 text-center">
                    <i class="bi bi-shop"></i>
                    <svg xmlns="http://www.w3.org/2000/svg" width="60" height="60" fill="currentColor" class="bi bi-shop" viewBox="0 0 16 16">
                        <path d="M2.97 1.35A1 1 0 0 1 3.73 1h8.54a1 1 0 0 1 .76.35l2.609 3.044A1.5 1.5 0 0 1 16 5.37v.255a2.375 2.375 0 0 1-4.25 1.458A2.371 2.371 0 0 1 9.875 8 2.37 2.37 0 0 1 8 7.083 2.37 2.37 0 0 1 6.125 8a2.37 2.37 0 0 1-1.875-.917A2.375 2.375 0 0 1 0 5.625V5.37a1.5 1.5 0 0 1 .361-.976l2.61-3.045zm1.78 4.275a1.375 1.375 0 0 0 2.75 0 .5.5 0 0 1 1 0 1.375 1.375 0 0 0 2.75 0 .5.5 0 0 1 1 0 1.375 1.375 0 1 0 2.75 0V5.37a.5.5 0 0 0-.12-.325L12.27 2H3.73L1.12 5.045A.5.5 0 0 0 1 5.37v.255a1.375 1.375 0 0 0 2.75 0 .5.5 0 0 1 1 0M1.5 8.5A.5.5 0 0 1 2 9v6h1v-5a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v5h6V9a.5.5 0 0 1 1 0v6h.5a.5.5 0 0 1 0 1H.5a.5.5 0 0 1 0-1H1V9a.5.5 0 0 1 .5-.5M4 15h3v-5H4zm5-5a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v3a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1zm3 0h-2v3h2z" />
                    </svg>
                    <p>Retiro en el Local</p>
                </div>
                <div class="col-md-3 text-center">
                    <i class="bi bi-truck"></i>
                    <svg xmlns="http://www.w3.org/2000/svg" width="60" height="60" fill="currentColor" class="bi bi-truck" viewBox="0 0 16 16">
                        <path d="M0 3.5A1.5 1.5 0 0 1 1.5 2h9A1.5 1.5 0 0 1 12 3.5V5h1.02a1.5 1.5 0 0 1 1.17.563l1.481 1.85a1.5 1.5 0 0 1 .329.938V10.5a1.5 1.5 0 0 1-1.5 1.5H14a2 2 0 1 1-4 0H5a2 2 0 1 1-3.998-.085A1.5 1.5 0 0 1 0 10.5zm1.294 7.456A1.999 1.999 0 0 1 4.732 11h5.536a2.01 2.01 0 0 1 .732-.732V3.5a.5.5 0 0 0-.5-.5h-9a.5.5 0 0 0-.5.5v7a.5.5 0 0 0 .294.456M12 10a2 2 0 0 1 1.732 1h.768a.5.5 0 0 0 .5-.5V8.35a.5.5 0 0 0-.11-.312l-1.48-1.85A.5.5 0 0 0 13.02 6H12zm-9 1a1 1 0 1 0 0 2 1 1 0 0 0 0-2m9 0a1 1 0 1 0 0 2 1 1 0 0 0 0-2" />
                    </svg>
                    <p>Envios a Todo el Pais</p>
                </div>
                <div class="col-md-3 text-center">
                    <i class="bi bi-line"></i>
                    <svg xmlns="http://www.w3.org/2000/svg" width="60" height="60" fill="currentColor" class="bi bi-line" viewBox="0 0 16 16">
                        <path d="M8 0c4.411 0 8 2.912 8 6.492 0 1.433-.555 2.723-1.715 3.994-1.678 1.932-5.431 4.285-6.285 4.645-.83.35-.734-.197-.696-.413l.003-.018.114-.685c.027-.204.055-.521-.026-.723-.09-.223-.444-.339-.704-.395C2.846 12.39 0 9.701 0 6.492 0 2.912 3.59 0 8 0M5.022 7.686H3.497V4.918a.156.156 0 0 0-.155-.156H2.78a.156.156 0 0 0-.156.156v3.486c0 .041.017.08.044.107v.001l.002.002.002.002a.154.154 0 0 0 .108.043h2.242c.086 0 .155-.07.155-.156v-.56a.156.156 0 0 0-.155-.157Zm.791-2.924a.156.156 0 0 0-.156.156v3.486c0 .086.07.155.156.155h.562c.086 0 .155-.07.155-.155V4.918a.156.156 0 0 0-.155-.156h-.562m3.863 0a.156.156 0 0 0-.156.156v2.07L7.923 4.832a.17.17 0 0 0-.013-.015v-.001a.139.139 0 0 0-.01-.01l-.003-.003a.092.092 0 0 0-.011-.009h-.001L7.88 4.79l-.003-.002a.029.029 0 0 0-.005-.003l-.008-.005h-.002l-.003-.002-.01-.004-.004-.002a.093.093 0 0 0-.01-.003h-.002l-.003-.001-.009-.002h-.006l-.003-.001h-.004l-.002-.001h-.574a.156.156 0 0 0-.156.155v3.486c0 .086.07.155.156.155h.56c.087 0 .157-.07.157-.155v-2.07l1.6 2.16a.154.154 0 0 0 .039.038l.001.001.01.006.004.002a.066.066 0 0 0 .008.004l.007.003.005.002a.168.168 0 0 0 .01.003h.003a.155.155 0 0 0 .04.006h.56c.087 0 .157-.07.157-.155V4.918a.156.156 0 0 0-.156-.156h-.561Zm3.815.717v-.56a.156.156 0 0 0-.155-.157h-2.242a.155.155 0 0 0-.108.044h-.001l-.001.002-.002.003a.155.155 0 0 0-.044.107v3.486c0 .041.017.08.044.107l.002.003.002.002a.155.155 0 0 0 .108.043h2.242c.086 0 .155-.07.155-.156v-.56a.156.156 0 0 0-.155-.157H11.81v-.589h1.525c.086 0 .155-.07.155-.156v-.56a.156.156 0 0 0-.155-.157H11.81v-.589h1.525c.086 0 .155-.07.155-.156Z" />
                    </svg>
                    <p>Atencion en Linea Personalizada</p>
                </div>
            </div>
        </div>
    </div>
    <div class="mt-2 text-center" style="height: 400px; color: white;">
        <img src="Content/ImgNegocio/thank-you-doodle-quote-by-Vexels.png" style="height: 100%" />
    </div>
</asp:Content>
