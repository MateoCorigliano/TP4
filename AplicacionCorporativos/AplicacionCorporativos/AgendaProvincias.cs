using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCorporativos
{
    class AgendaProvincias
    {

        public static readonly Dictionary<int, Provincia> entradas;
        const string nombreArchivo = "provincias.txt";

        static AgendaProvincias()
        {
            entradas = new Dictionary<int, Provincia>();
            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var provincia = new Provincia(linea);
                        entradas.Add(provincia.Codigo, provincia);
                    }
                }
            }
        }

        public static void MostrarProvincias()
        {
            foreach(var provincia in entradas.Values)
            {
                Console.WriteLine($"{provincia.Codigo} - {provincia.Nombre}");
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

        public static string SeleccionarProvincia(int opcion)
        {
            foreach (var provincia in entradas.Values)
            {
                if (opcion == provincia.Codigo)
                {
                    return provincia.Nombre;
                }
            }
            return "";
        }

        public static string EstablecerRegion(string nombre)
        {
            foreach (var provincia in entradas.Values)
            {
                if (nombre == provincia.Nombre)
                {
                    return provincia.Region;
                }
            }
            return "";
        }
    }
}
