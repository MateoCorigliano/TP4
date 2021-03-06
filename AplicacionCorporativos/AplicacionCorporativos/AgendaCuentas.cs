using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace AplicacionCorporativos
{
    class AgendaCuentas
    {
        private static readonly List<Cuenta> entradas;

        const string nombreArchivo = "estado de cuenta.txt";

        static AgendaCuentas()
        {

            entradas = new List<Cuenta>();

            if (File.Exists(nombreArchivo))

            {
                using (var reader = new StreamReader(nombreArchivo))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var cuenta = new Cuenta(linea);
                        entradas.Add(cuenta);
                    }

                }

            }

        }

        public static void Seleccionar(int nroCliente)
        {
            var modelo = Cuenta.CrearModeloBusqueda(nroCliente);

            bool encontre = false;

            foreach (var cuentas in entradas)
            {
                if (cuentas.CoincideCon(modelo))
                {
                    Console.WriteLine($"Nro Factura:{cuentas.NroFactura}\n" +
                        $"Saldo: ${cuentas.Saldo}\n" +
                        $"Estado: {cuentas.Estado}\n");
                    encontre = true;
                }
            }

            if (encontre == false)
            {
                Console.WriteLine("No se encontraron registros");
            }
        }

        public static void CalculaSaldo(int nroCliente, string estado)
        {
            var modelo = Cuenta.CrearModeloBusqueda2(nroCliente, estado);
            decimal total = 0;
            bool encontre = false;

            
            foreach (var cuentas in entradas)
            {
                if (cuentas.CoincideCon2(modelo))
                {
                    var saldo = cuentas.Saldo;

                    total = total + saldo;
                    encontre = true;
                }


            }

            Console.WriteLine($"Saldo: ${total}");

            if (encontre == false)
            {
                Console.WriteLine("No se encontraron registros");
            }
        }

    }
}

