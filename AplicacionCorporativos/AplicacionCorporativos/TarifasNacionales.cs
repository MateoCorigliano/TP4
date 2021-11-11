using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCorporativos
{
    public class TarifasNacionales
    {

        
        public decimal PesoLimite { get; set; }
        public decimal PrecioLocal{ get; set; }
        public decimal PrecioProvincial { get; set; }
        public decimal PrecioRegional { get; set; }
        public decimal PrecioNacional { get; set; }

        public TarifasNacionales()
        {

        }

        public TarifasNacionales(string linea)
        {
            var datos = linea.Split(';');
            PesoLimite = int.Parse(datos[0]);
            PrecioLocal = decimal.Parse(datos[1]);
            PrecioProvincial = decimal.Parse(datos[2]);
            PrecioRegional = decimal.Parse(datos[3]);
            PrecioNacional = decimal.Parse(datos[4]);

        }
        
        
        public static TarifasNacionales CrearModeloBusqueda(int pesoLimite)
        {
            var modelo = new TarifasNacionales();

            modelo.PesoLimite = pesoLimite;


            return modelo;
        }


        public bool CoincideCon(TarifasNacionales modelo)
        {
            if (PesoLimite < modelo.PesoLimite)
            {
                return false;
            }

            return true;
        }


    }
}
