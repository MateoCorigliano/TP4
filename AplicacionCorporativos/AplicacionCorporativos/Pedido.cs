using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCorporativos
{
    class Pedido
    {
        public int ID_Traqueo { get; set; }
        public string TipoServicio { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Estado { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public float Valor { get; set; }
    }
}
