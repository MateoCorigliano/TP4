using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCorporativos
{
    public class Continente
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public Continente()
        {

        }

        public Continente(string linea)
        {
            var datos = linea.Split(';');
            Codigo = int.Parse(datos[0]);
            Nombre = datos[1];
        }

        public static Continente CrearModeloBusqueda(int codigo, string nombre)
        {
            var modelo = new Continente();

            modelo.Codigo = codigo;
            modelo.Nombre = nombre;

            return modelo;
        }
    }
}
