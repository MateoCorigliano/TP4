using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCorporativos
{
    class Program
    {
        static void Main(string[] args)
        {
            //MENU CONSOLA
            bool salir = false;
            do
            {
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("--------------");
                Console.WriteLine("1 - ALTA");
                Console.WriteLine("2 - MODIFICAR");
                Console.WriteLine("3 - BAJA");
                Console.WriteLine("4 - BUSCAR");
                Console.WriteLine("9 - SALIR");

                Console.WriteLine("Ingrese una opcion y presione [enter]");
                var opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Alta();
                        break;

                    case "2":
                        Modificar();
                        break;

                    case "3":
                        Baja();
                        break;

                    case "4":
                        Buscar();
                        break;

                    case "9":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("No ha ingresado una opcion correcta");
                        break;


                }

            } while (!salir);

        }

        private static void Alta()
        {
            //alta nueva persona
            var persona = Persona.IngresarNueva();
            Agenda.Agregar(persona);
        }

        private static void Baja()
        {
            var persona = Agenda.Seleccionar();
            if (persona == null)
            {
                return;
            }
            persona.Mostrar();
            Console.WriteLine($"Se procedera a dar de baja a: {persona.TituloEntrada}. Esta ud seguro? (S/N)");
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.S)
            {
                Agenda.Baja(persona);
                Console.WriteLine($"{persona.TituloEntrada} ha sido dada de baja");
            }
        }

        private static void Modificar()
        {
            var persona = Agenda.Seleccionar();
            if (persona == null)
            {
                return;
            }
            persona.Mostrar();
            persona.Modificar();

        }

        public static void Buscar()
        {
            var persona = Agenda.Seleccionar();
            if (persona != null)
            {
                persona.Mostrar();
            }
        }
    }
    }
}
