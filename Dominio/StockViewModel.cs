using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class StockViewModel
    {
        public int Id { get; set; }
        public string DescripcionPrenda { get; set; }
        public string Talle { get; set; }
        public int Cantidad { get; set; }
        public string DescripcionCategoria { get; set; }
        public string Lote { get; set; }
    }
}
