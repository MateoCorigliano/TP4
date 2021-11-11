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
        private static readonly Dictionary<int, Cuenta> entradas;

        const string nombreArchivo = "estado de cuenta.txt";

        //constructor:

        static AgendaCuentas()
        {

            entradas = new Dictionary<int, Cuenta>();

            if (File.Exists(nombreArchivo))

            {
                using (var reader = new StreamReader(nombreArchivo))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var cuenta = new Cuenta(linea);
                        entradas.Add(cuenta.NroCliente, cuenta);
                    }

                }

            }

        }

        public static Cuenta Seleccionar(int nroCliente)
        {
            var modelo = Cuenta.CrearModeloBusqueda(nroCliente);

            foreach (var cuentas in entradas.Values)
            {
                if (cuentas.CoincideCon(modelo))
                {
                    return cuentas;
                }
            }
            Console.WriteLine("No se ha encontrado el usuario ingresado");
            return null;
        }


    }
}

