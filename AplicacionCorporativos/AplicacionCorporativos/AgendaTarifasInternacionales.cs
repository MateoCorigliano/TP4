using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCorporativos
{
    class AgendaTarifasInternacionales
    {
        public static readonly Dictionary<decimal, TarifasInternacionales> entradas;

        const string nombreArchivo = "tarifas internacionales.txt";

        static AgendaTarifasInternacionales()
        {

            entradas = new Dictionary<decimal, TarifasInternacionales>();

            if (File.Exists(nombreArchivo))

            {
                using (var reader = new StreamReader(nombreArchivo))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var tarifa = new TarifasInternacionales(linea);
                        entradas.Add(tarifa.PesoLimite, tarifa);
                    }

                }

            }

        }

        public static decimal SeleccionarPrecioLimitrofe(decimal pesoLimite)
        {
            var modelo = TarifasInternacionales.CrearModeloBusqueda(pesoLimite);

            foreach (var tarifas in entradas.Values)
            {

                return tarifas.PrecioLimitrofe;

            }

            return 0;

        }

        public static decimal SeleccionarPrecioSudamerica(decimal pesoLimite)
        {
            var modelo = TarifasInternacionales.CrearModeloBusqueda(pesoLimite);

            foreach (var tarifas in entradas.Values)
            {

                return tarifas.PrecioSudamerica;

            }

            return 0;

        }


       




    }
}
