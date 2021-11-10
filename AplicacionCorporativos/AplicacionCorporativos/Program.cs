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
            //TODO: Queda pendiente validar el ingreso del usuario
            bool salir = false;
            do
            {
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("--------------");
                Console.WriteLine("1 - Solicitar un servicio de correspondencia o encomienda");
                //Console.WriteLine("2 - Consultar el estado de un servicio");
                //Console.WriteLine("3 - Consultar el estado de cuenta");
                Console.WriteLine("4 - Finalizar ");
                Console.WriteLine("Ingrese una opcion y presione [enter]");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AltaServicio();
                        break;
                     /*
                    case "2":
                        ConsultaServicio();
                        break;

                    case "3":
                        ConsultaCuenta();
                        break;
                        */

                    case "4":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("No ha ingresado una opcion correcta");
                        break;
                }

            } while (!salir);

        }

        private static void AltaServicio()
        {
            //Da de alta un nuevo servicio al usuario
            var servicio = Servicio.IngresarNuevo();
            AgendaServicios.Agregar(servicio);
        }


        /* Se comenta para completar dsp
         * 
        private static void ConsultaCuenta()
        {
         var persona = Agenda.Seleccionar();
            if (persona != null)
            {
                persona.Mostrar();
            }
            
        }

        private static void ConsultaServicio()
        {
             var persona = Agenda.Seleccionar();
            if (persona != null)
            {
                persona.Mostrar();
            }

        }

       
    }
    */
    }

}
