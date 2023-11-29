using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MedioPago
    {
        public MedioPago() { }
        public MedioPago(int ID, string descripcion) {
            IDPago = ID;
            Descripcion = descripcion;
        }
        public int IDPago { get; set; }
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
