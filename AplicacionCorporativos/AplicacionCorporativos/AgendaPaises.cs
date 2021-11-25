using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCorporativos
{
    class AgendaPaises
    {
        public static readonly Dictionary<int, Pais> entradas;
        const string nombreArchivo = "paises.txt";

        static AgendaPaises()
        {
            entradas = new Dictionary<int, Pais>();
            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var pais = new Pais(linea);
                        entradas.Add(pais.CodigoPais, pais);
                    }
                }
            }
        }

        public static void MostrarPaises(int codigoCont)
        {
            foreach (var pais in entradas.Values)
            {
                if (codigoCont == pais.CodigoCont)
                {
                    Console.WriteLine($"{pais.CodigoPais} - {pais.Nombre}");
                }
            }
        }

        public static int IngresarOpcion(int codigoCont)
        {
            Pais paisSeleccionado;
            bool noPais = true;
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

                foreach (var pais in entradas.Values)
                {
                    if (pais.CodigoCont == codigoCont)
                    {
                        if (pais.CodigoPais == salida)
                        {
                            paisSeleccionado = pais;
                            noPais = false;
                        }
                        
                    }
                }

                if (noPais == true)
                {
                    Console.WriteLine("No ingreso una opcion correcta");
                    continue;
                }

                return salida;

            } while (true);
        }

        public static string EstablecerPais(int opcionPais)
        {
            foreach (var pais in entradas.Values)
            {
                if (opcionPais == pais.CodigoPais)
                {
                    return pais.Nombre;
                }
            }
            return "";
        }

        public static int TraerContinenteDestino(string nombrePais)
        {
            foreach (var pais in entradas.Values)
            {
                if (nombrePais == pais.Nombre)
                {
                    return pais.CodigoCont;
                }
            }

            return 0;
        }
    }
}