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

        public static decimal SeleccionarPrecioLimitrofe(int pesoLimite)
        {
            var modelo = TarifasInternacionales.CrearModeloBusqueda(pesoLimite);

            foreach (var tarifas in entradas.Values)
            {


                if (tarifas.CoincideCon(modelo))
                {
                    return tarifas.PrecioLimitrofe;
                }

            }

            return 0;

        }

        public static decimal SeleccionarPrecioSudamerica(int pesoLimite)
        {
            var modelo = TarifasInternacionales.CrearModeloBusqueda(pesoLimite);

            foreach (var tarifas in entradas.Values)
            {


                if (tarifas.CoincideCon(modelo))
                {
                    return tarifas.PrecioSudamerica;
                }

            }

            return 0;

        }

        public static decimal SeleccionarPrecioAmericaNorte(int pesoLimite)
        {
            var modelo = TarifasInternacionales.CrearModeloBusqueda(pesoLimite);

            foreach (var tarifas in entradas.Values)
            {


                if (tarifas.CoincideCon(modelo))
                {
                    return tarifas.PrecioAmericaNorte;
                }

            }

            return 0;

        }


        public static decimal SeleccionarPrecioEuropa(int pesoLimite)
        {
            var modelo = TarifasInternacionales.CrearModeloBusqueda(pesoLimite);

            foreach (var tarifas in entradas.Values)
            {


                if (tarifas.CoincideCon(modelo))
                {
                    return tarifas.PrecioEuropa;
                }

            }

            return 0;

        }

        public static decimal SeleccionarPrecioAsia(int pesoLimite)
        {
            var modelo = TarifasInternacionales.CrearModeloBusqueda(pesoLimite);

            foreach (var tarifas in entradas.Values)
            {


                if (tarifas.CoincideCon(modelo))
                {
                    return tarifas.PrecioAsia;
                }

            }

            return 0;

        }



    }
}
