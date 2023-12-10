using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleVenta
    {
        public int IDDetalle { get; set; }
        public int IDVenta { get; set; }
        public int IDPrenda { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }




    }
}
