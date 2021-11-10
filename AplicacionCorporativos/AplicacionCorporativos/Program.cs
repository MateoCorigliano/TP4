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
            //TODO: DATOS QUE DEBEN VENIR DE FUENTES/TXT EXTERNOS:
            //PAISES
            //PROVINCIAS
            //LOCALIDADES
            //REGIONES (SUR, CENTRO, NORTE, METROPOLITANA (BS Y CABA))
            //CUADRO TARIFARIO
            //FACTURAS Y SUS SALDOS (CUENTA CORRIENTE)
            //USUARIOS HABILITADOS


            //MENU CONSOLA
            //TODO: Queda pendiente validar el ingreso del usuario
            bool salir = false;
            do
            {
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("--------------");
                Console.WriteLine("1 - Solicitar un servicio de correspondencia o encomienda");
                Console.WriteLine("2 - Consultar el estado de un servicio");
                //TODO Console.WriteLine("3 - Consultar el estado de cuenta");
                Console.WriteLine("4 - Finalizar ");
                Console.WriteLine("Ingrese una opcion y presione [enter]");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AltaServicio();
                        break;
                     
                    case "2":
                        ConsultaServicio();
                        break;
                        /*
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

            Console.WriteLine($"El costo total por el servicio es: {servicio.Costo}");

            //confirmacion se servicio:
            
            do
            {
                Console.WriteLine("¿Confirma Operacion de acuerdo a valor generado? Responder S/N");
                char ingreso = char.Parse(Console.ReadLine());
                ingreso = char.ToUpper(ingreso);
               

                if (ingreso == 'S')
                {
                    AgendaServicios.Agregar(servicio);
                    break;
                }
                if (ingreso == 'N')
                {
                    break;
                }
                else { 
                Console.WriteLine("Por favor introducir un valor correcto");
                    
                }
            } while (true);
        }



        private static void ConsultaServicio()
        {
            var servicio = AgendaServicios.Seleccionar();
            if (servicio != null)
            {
                servicio.Mostrar();
            }

        }

        /*
        private static void ConsultaCuenta()
        {
         var persona = Agenda.Seleccionar();
            if (persona != null)
            {
                persona.Mostrar();
            }
            
        }
        */

        

       
    
    
    }

}
