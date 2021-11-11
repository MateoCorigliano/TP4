using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCorporativos
{
    class AgendaTarifasNacionales
    {
        public static readonly Dictionary<decimal,TarifasNacionales> entradas;

        const string nombreArchivo = "tarifas nacionales.txt";

        static AgendaTarifasNacionales()
        {

            entradas = new Dictionary<decimal, TarifasNacionales>();

            if (File.Exists(nombreArchivo))

            {
                using (var reader = new StreamReader(nombreArchivo))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var tarifa = new TarifasNacionales(linea);
                        entradas.Add(tarifa.PesoLimite, tarifa);
                    }

                }

            }

        }

        public static decimal SeleccionarPrecioLocal(int pesoLimite)
        {
            var modelo = TarifasNacionales.CrearModeloBusqueda(pesoLimite);

            foreach (var tarifas in entradas.Values)
            {

                if (tarifas.CoincideCon(modelo))
                {
                    return tarifas.PrecioLocal;
                }
                
                
            }

           return 0;

        }

        public static decimal SeleccionarPrecioProvincial(int pesoLimite)
        {
            var modelo = TarifasNacionales.CrearModeloBusqueda(pesoLimite);

            foreach (var tarifas in entradas.Values)
            {

                if (tarifas.CoincideCon(modelo))
                {
                    return tarifas.PrecioProvincial;
                }

            }

            return 0;

        }

        public static decimal SeleccionarPrecioRegional(int pesoLimite)
        {
            var modelo = TarifasNacionales.CrearModeloBusqueda(pesoLimite);

            foreach (var tarifas in entradas.Values)
            {


                if (tarifas.CoincideCon(modelo))
                {
                    return tarifas.PrecioRegional;
                }

            }

            return 0;

        }

        public static decimal SeleccionarPrecioNacional(int pesoLimite)
        {
            var modelo = TarifasNacionales.CrearModeloBusqueda(pesoLimite);

            foreach (var tarifas in entradas.Values)
            {


                if (tarifas.CoincideCon(modelo))
                {
                    return tarifas.PrecioNacional;
                }

            }

            return 0;

        }






    }
}
