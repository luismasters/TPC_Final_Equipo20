using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ventas
    {
        public Ventas() { }
        public int IDVenta {  get; set; }
        public int IDUsuario {  get; set; }
        public int MedioPago {  get; set; }
        public decimal PrecioTotal {  get; set; }
        public bool Pagado {get; set; }
        public int IDEnvio { get; set; }
        public string Descripcion { get; set; }
        public string NombreUsuario { get; set; }
        public bool Despachado { get; set; }



    }
}
