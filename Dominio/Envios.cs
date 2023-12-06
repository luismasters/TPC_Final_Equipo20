using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Envios
    {
        public Envios() { }
        public int IDEnvio { get; set; }
        public int IDVenta {  get; set; }
        public int IDUsuario {  get; set; }
        public string Direccion {  get; set; }
        public string Telefono {  get; set; }
        public string Observaciones {  get; set; }
        public bool Entregado {  get; set; }
        public int IDCiudad {  get; set; }
    }
}
