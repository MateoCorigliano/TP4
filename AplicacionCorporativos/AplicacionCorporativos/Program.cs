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
            //TODO: DATOS QUE DEBEN VENIR DE FUENTES/TXT EXTERNOS, recordar agregar los txt de prueba al proyecto de GitHub en la carpeta bin/debug:
            //ver si es necesario crear una clase para las propiedades y otra para el archivo en lugar de hacer todo en una sola clase
            //PAISES
            //PROVINCIAS
            //LOCALIDADES
            //REGIONES (SUR, CENTRO, NORTE, METROPOLITANA (BS Y CABA))
            //CUADRO TARIFARIO
            //FACTURAS Y SUS SALDOS (CUENTA CORRIENTE)
            //USUARIOS HABILITADOS - OK

            bool seguir = true;
            int dni;
            string nombre = "";
            int nroCliente = 0;

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

            Console.WriteLine($"Bienvenido {nombre}, su numero de cliente asociado es {nroCliente}");



            //MENU CONSOLA

            bool salir = false;
                do
                {
                    Console.WriteLine("MENU PRINCIPAL");
                    Console.WriteLine("--------------");
                    Console.WriteLine("1 - Solicitar un servicio de correspondencia o encomienda");
                    Console.WriteLine("2 - Consultar el estado de un servicio");
                    Console.WriteLine("3 - Consultar el estado de cuenta");
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
                        
                        case "3":
                            ConsultaCuenta(nroCliente);
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
                    break;
                }
                if (opcion == "N")
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


        private static void ConsultaCuenta(int nroCliente)
        {
            AgendaCuentas.Seleccionar(nroCliente);
            
        }
        

        

       
    
    
    }

}
