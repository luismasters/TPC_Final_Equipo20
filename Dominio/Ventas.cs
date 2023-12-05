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

        public int IDVenta { get; set; }
        public Usuario IDUsuario { get; set; }
        public MedioPago MedioPago { get; set; }
        public int PrecioTotal { get; set; }
        public bool Pagado {  get; set; }
    }
}
