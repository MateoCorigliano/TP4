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
            
            
            Console.WriteLine("");
            Console.WriteLine("APLICACION CLIENTES CORPORATIVOS");
            Console.WriteLine("");

            bool seguir = true;
            int dni;
            string nombre = "";
            int nroCliente = 0;
            string estado = "IMPAGA";

            //VALIDACION USAURIOS REGISTRADOS
            do
            {
                var usuario = AgendaUsuarios.Seleccionar();

                if(usuario != null)
                {
                    dni = usuario.Dni;
                    nombre = usuario.Nombre;
                    nroCliente = usuario.ClienteAsociado;
                    seguir = false;
                }

            } while (seguir);

            Console.Clear();
            Console.WriteLine($"Bienvenid@ {nombre}, su numero de cliente asociado es {nroCliente}");



            //MENU CONSOLA

            bool salir = false;
                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("MENU PRINCIPAL");
                    Console.WriteLine("");
                    Console.WriteLine("1 - Solicitar un servicio de correspondencia o encomienda");
                    Console.WriteLine("2 - Consultar el estado de un servicio");
                    Console.WriteLine("3 - Consultar el estado de cuenta");
                    Console.WriteLine("4 - Finalizar ");
                    Console.WriteLine("Ingrese una opcion y presione [enter]");

                    var opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                        Console.Clear();
                        AltaServicio();
                            break;

                        case "2":
                        Console.Clear();
                        ConsultaServicio();
                            break;
                        
                        case "3":
                        Console.Clear();
                        ConsultaCuenta(nroCliente, estado);
                            break;
                        

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
                string ingreso = Console.ReadLine();
                string opcion = ingreso.ToUpper();          

                if (opcion == "S")
                {
                    AgendaServicios.Agregar(servicio);
                    Console.WriteLine($"El numero de trackeo asociado es: {servicio.Trackeo} ");
                    break;
                }
                if (opcion == "N")
                {
                    break;
                }
                else
                { 
                    Console.WriteLine("Por favor introducir un valor correcto");
                }
            } while (true);
            Console.WriteLine("Pulse una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }



        private static void ConsultaServicio()
        {
            var servicio = AgendaServicios.Seleccionar();
            if (servicio != null)
            {
                Console.Clear();
                servicio.Mostrar();
            }
            Console.WriteLine("Pulse una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }


        private static void ConsultaCuenta(int nroCliente, string estado)
        {
            Console.WriteLine("##########################");
            Console.WriteLine("#                        #");
            Console.WriteLine("# ESTADO DE FACTURACION  #");
            Console.WriteLine("#                        #");
            Console.WriteLine("##########################");
            Console.WriteLine("");
            AgendaCuentas.Seleccionar(nroCliente);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("##########################");
            Console.WriteLine("#                        #");
            Console.WriteLine("#  SERVICIOS PENDIENTES  #");
            Console.WriteLine("#                        #");
            Console.WriteLine("##########################");
            Console.WriteLine("");
            AgendaServicios.Seleccionar2(nroCliente);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("##########################");
            Console.WriteLine("#                        #");
            Console.WriteLine("#      SALDO TOTAL       #");
            Console.WriteLine("#                        #");
            Console.WriteLine("##########################");
            Console.WriteLine("");
            AgendaCuentas.CalculaSaldo(nroCliente, estado);
            Console.WriteLine("");
            Console.WriteLine("Pulse una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        

        

       
    
    
    }

}
