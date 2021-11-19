using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCorporativos
{
    class Provincia
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Region { get; set; }

        public Provincia()
        {

        }

        public Provincia(string linea)
        {
            var datos = linea.Split('-');
            Codigo = int.Parse(datos[0]);
            Nombre = datos[1];
            Region = datos[2];
        }

        public static Provincia CrearModeloBusqueda(int codigo, string nombre, string region)
        {
            var modelo = new Provincia();

            modelo.Codigo = codigo;
            modelo.Nombre = nombre;
            modelo.Region = region;

            return modelo;
        }
    }
}
