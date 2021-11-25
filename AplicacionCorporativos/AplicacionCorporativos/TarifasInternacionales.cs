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

        public int PesoLimite { get; set; }
        public decimal PrecioLimitrofe { get; set; }
        public decimal PrecioSudamerica { get; set; }
        public decimal PrecioAmericaNorte { get; set; }
        public decimal PrecioEuropa { get; set; }
        public decimal PrecioAsia { get; set; }

        public TarifasInternacionales()
        {

        }

        public TarifasInternacionales(string linea)
        {
            var datos = linea.Split(';');
            PesoLimite = int.Parse(datos[0]);
            PrecioLimitrofe = decimal.Parse(datos[1]);
            PrecioSudamerica = decimal.Parse(datos[2]);
            PrecioAmericaNorte = decimal.Parse(datos[3]);
            PrecioEuropa = decimal.Parse(datos[4]);
            PrecioAsia = decimal.Parse(datos[5]);

        }


        public static TarifasInternacionales CrearModeloBusqueda(int pesoLimite)
        {
            var modelo = new TarifasInternacionales();

            modelo.PesoLimite = pesoLimite;


            return modelo;
        }

        public bool CoincideCon(TarifasInternacionales modelo)
        {
            if (PesoLimite < modelo.PesoLimite)
            {
                return false;
            }

            return true;
        }


    }

}
