using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCorporativos
{
    class AgendaServicios
    {
        private static readonly Dictionary<int, Servicio> entradas;

        const string nombreArchivo = "servicios.txt";

        //constructor:

        static AgendaServicios()
        {

            entradas = new Dictionary<int, Servicio>();

            if (File.Exists(nombreArchivo))

            {
                using (var reader = new StreamReader(nombreArchivo))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var servicio = new Servicio(linea);
                        entradas.Add(servicio.Trackeo, servicio);
                    }

                }

            }

        }

        public static void Agregar(Servicio servicio)
        {
            entradas.Add(servicio.Trackeo, servicio);
            Grabar();
        }



        public static Servicio Seleccionar()
        {
            var modelo = Servicio.CrearModeloBusqueda();

            foreach (var servicio in entradas.Values)
            {
                if (servicio.CoincideCon(modelo))
                {
                    return servicio;
                }
            }
            Console.WriteLine("No se ha encontrado el servicio");
            return null;
        }

        public static void Seleccionar2(int nroCliente)
        {
            var modelo = Servicio.ModeloBusqueda2(nroCliente);

            bool encontre = false;

            foreach (var servicio in entradas.Values)
            {
               
                    Console.WriteLine($"Nro Trackeo:{servicio.Trackeo}\n" +
                        $"Estado: {servicio.Estado}\n" +
                        $"Fecha: {servicio.Fecha}\n");
                    encontre = true;
                
            }

            if (encontre == false)
            {
                Console.WriteLine("No se encontraron registros");
            }
        }

        public static void Grabar()
        {
            using (var writer = new StreamWriter(nombreArchivo, append: false))
            {

                foreach (var servicio in entradas.Values)
                {
                    var linea = servicio.ObtenerLineaDatos();
                    writer.WriteLine(linea);
                }

            }

        }
    }
}
