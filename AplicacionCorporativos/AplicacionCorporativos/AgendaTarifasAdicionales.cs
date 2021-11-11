using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCorporativos
{
    class AgendaTarifasAdicionales
    {
        public static readonly Dictionary<decimal, TarifasAdicionales> entradas;

        const string nombreArchivo = "tarifas servicios adicionales.txt";

        static AgendaTarifasAdicionales()
        {

            entradas = new Dictionary<decimal, TarifasAdicionales>();

            if (File.Exists(nombreArchivo))

            {
                using (var reader = new StreamReader(nombreArchivo))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var tarifa = new TarifasAdicionales(linea);
                        entradas.Add(tarifa.CargoUrgente, tarifa);
                    }

                }

            }

        }

        public static decimal SeleccionarCargoUrgente(bool entrada)
        {
            var modelo = TarifasAdicionales.CrearModeloBusqueda(entrada);

            foreach (var tarifas in entradas.Values)
            {

                return tarifas.CargoUrgente;

            }

            return 0;

        }

        public static decimal SeleccionarTopeUrgente(bool entrada)
        {
            var modelo = TarifasAdicionales.CrearModeloBusqueda(entrada);

            foreach (var tarifas in entradas.Values)
            {

                return tarifas.TopeUrgente;

            }

            return 0;

        }

        public static decimal SeleccionarCargoEntrega(bool entrada)
        {
            var modelo = TarifasAdicionales.CrearModeloBusqueda(entrada);

            foreach (var tarifas in entradas.Values)
            {

                return tarifas.CargoEntrega;

            }

            return 0;

        }

        public static decimal SeleccionarCargoRetiro(bool entrada)
        {
            var modelo = TarifasAdicionales.CrearModeloBusqueda(entrada);

            foreach (var tarifas in entradas.Values)
            {

                return tarifas.CargoRetiro;

            }

            return 0;

        }


    }
}
