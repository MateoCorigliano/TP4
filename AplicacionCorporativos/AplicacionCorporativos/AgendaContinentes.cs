using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCorporativos
{
    class AgendaContinentes
    {
        public static readonly Dictionary<int, Continente> entradas;
        const string nombreArchivo = "continentes.txt";

        static AgendaContinentes()
        {
            entradas = new Dictionary<int, Continente>();
            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var continente = new Continente(linea);
                        entradas.Add(continente.Codigo, continente);
                    }
                }
            }
        }

        public static void MostrarContinentes()
        {
            foreach (var continente in entradas.Values)
            {
                Console.WriteLine($"{continente.Codigo} - {continente.Nombre}");
            }
        }

        public static int IngresarOpcion()
        {
            do
            {
                var ingreso = Console.ReadLine();

                if (string.IsNullOrEmpty(ingreso))
                {
                    Console.WriteLine("El ingreso no debe ser vacio");
                    continue;
                }

                if (!Int32.TryParse(ingreso, out var salida))
                {
                    Console.WriteLine("El dato ingresado es incorrecto, ingrese nuevamente");
                    continue;
                }

                if (!entradas.ContainsKey(salida))
                {
                    Console.WriteLine("No ingresó una opción correcta");
                    continue;
                }

                return salida;

            } while (true);
        }
    }
}
