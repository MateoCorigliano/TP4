using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCorporativos
{
    class TarifasAdicionales
    {

        public bool Bool { get; set; }
        public decimal CargoUrgente { get; set; }
        public decimal TopeUrgente { get; set; }
        public decimal CargoRetiro { get; set; }
        public decimal CargoEntrega { get; set; }

        public TarifasAdicionales()
        {

        }

        public TarifasAdicionales(string linea)
        {
            var datos = linea.Split(';');
            CargoUrgente = decimal.Parse(datos[0]);
            TopeUrgente = decimal.Parse(datos[1]);
            CargoRetiro = decimal.Parse(datos[2]);
            CargoEntrega = decimal.Parse(datos[3]);

        }


        public static TarifasAdicionales CrearModeloBusqueda(bool entrada)
        {
            var modelo = new TarifasAdicionales();

            modelo.Bool = entrada;


            return modelo;
        }





        /*
    public bool CoincideCon(TarifasNacionales modelo)
    {
        if (modelo.NroCliente != 0 && NroCliente != modelo.NroCliente)
        {
            return false;
        }

        return true;
    }
    */
    }
}
