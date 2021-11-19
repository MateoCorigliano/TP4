using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCorporativos
{
    class Pais
    {
        public int CodigoPais { get; set; }
        public int CodigoCont { get; set; }
        public string Nombre { get; set; }

        public Pais()
        {

        }

        public Pais(string linea)
        {
            var datos = linea.Split('-');
            CodigoPais = int.Parse(datos[0]);
            CodigoCont = int.Parse(datos[1]);
            Nombre = datos[2];
        }

        public static Pais CrearModeloBusqueda(int codigoPais, int codigoCont, string nombre)
        {
            var modelo = new Pais();

            modelo.CodigoPais = codigoPais;
            modelo.CodigoCont = codigoCont;
            modelo.Nombre = nombre;

            return modelo;
        }
    }
}
