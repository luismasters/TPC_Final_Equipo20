function toggleFiltro() {
    var filtroSidebar = document.getElementById('filtroSidebar');
    var btnMostrarFiltro = document.getElementById('btnMostrarFiltro');


    if (filtroSidebar.style.display === 'none' || filtroSidebar.style.display === '') {
        filtroSidebar.style.display = 'block';
        filtroSidebar.style.right = '0px';
        btnMostrarFiltro.value = 'X'
    } else {
        filtroSidebar.style.display = 'none';
        filtroSidebar.style.right = '-250px';
        btnMostrarFiltro.value = 'Filtrar'
    }
}

