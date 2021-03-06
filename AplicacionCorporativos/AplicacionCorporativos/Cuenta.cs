using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCorporativos
{
    class Cuenta
    {
        public int NroCliente { get; set; }
        public int NroFactura { get; set; }
        public decimal Saldo { get; set; }
        public string Estado { get; set; }

        public Cuenta()
        {

        }

        public Cuenta(string linea)
        {
            var datos = linea.Split(';');
            NroCliente = int.Parse(datos[0]);
            NroFactura = int.Parse(datos[1]);
            Saldo = decimal.Parse(datos[2]);
            Estado = datos[3];
        }

        public static Cuenta CrearModeloBusqueda(int nroCliente)
        {
            var modelo = new Cuenta();


            modelo.NroCliente = nroCliente;


            return modelo;
        }

        public static Cuenta CrearModeloBusqueda2(int nroCliente, string estado)
        {
            var modelo = new Cuenta();


            modelo.NroCliente = nroCliente;
            modelo.Estado = estado;


            return modelo;
        }

        public bool CoincideCon(Cuenta modelo)
        {
            if (modelo.NroCliente != 0 && NroCliente != modelo.NroCliente)
            {
                return false;
            }

            return true;
        }


        public bool CoincideCon2(Cuenta modelo2)
        {
            //modelo.NroCliente != 0 && NroCliente != modelo.NroCliente && 
            if (Estado != modelo2.Estado || NroCliente != modelo2.NroCliente)
            {
                return false;
            }

            return true;
        }



    }
}
