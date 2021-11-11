using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCorporativos
{
    class TarifasInternacionales

    {

        //de acuerdo a indicaciones de Andres se acota a paises limitrofes o america latina

        public decimal PesoLimite { get; set; }
        public decimal PrecioLimitrofe { get; set; }
        public decimal PrecioSudamerica { get; set; }

        public TarifasInternacionales()
        {

        }

        public TarifasInternacionales(string linea)
        {
            var datos = linea.Split(';');
            PesoLimite = decimal.Parse(datos[0]);
            PrecioLimitrofe = decimal.Parse(datos[1]);
            PrecioSudamerica = decimal.Parse(datos[2]);

        }


        public static TarifasInternacionales CrearModeloBusqueda(decimal pesoLimite)
        {
            var modelo = new TarifasInternacionales();

            modelo.PesoLimite = pesoLimite;


            return modelo;
        }



    }

}
