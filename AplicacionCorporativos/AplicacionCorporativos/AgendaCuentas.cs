﻿using System;
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

        public static Cuenta Seleccionar(int nroCliente)
        {
            var modelo = Cuenta.CrearModeloBusqueda(nroCliente);

            foreach (var cuentas in entradas)
            {
                if (cuentas.CoincideCon(modelo))
                {
                    Console.WriteLine($"Nro Factura:{cuentas.NroFactura}\n" +
                        $"Saldo: ${cuentas.Saldo}\n");
                }
            }
            Console.WriteLine("No se ha encontrado el usuario ingresado");
            return null;
        }

    }
}

