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

        /*public Cuenta(int nroCliente)
        {
            NroCliente = nroCliente;
        }*/

        public Cuenta()
        {

        }

        public Cuenta(string linea)
        {
            var datos = linea.Split(';');
            NroCliente = int.Parse(datos[0]);
            NroFactura = int.Parse(datos[1]);
            Saldo = decimal.Parse(datos[2]);
        }

        public static Cuenta CrearModeloBusqueda(int nroCliente)
        {
            var modelo = new Cuenta();


            modelo.NroCliente = nroCliente;


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

        public void Mostrar()
        {
            Console.WriteLine($"Nro Factura: {NroFactura}");
            Console.WriteLine($"Saldo: {Saldo}");

        }




    }
}
