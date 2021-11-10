using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AplicacionCorporativos
{
    class Servicio
    {

        //atributos

        public int Trackeo { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string DomicilioOrigen { get; set; }
        public string LocalidadOrigen { get; set; }
        public string ProvinciaOrigen { get; set; }
        public string RegionOrigen { get; set; }
        public string PaisOrigen { get; set; } //siempre sera Argentina
        public string DomicilioDestino { get; set; }
        public string LocalidadDestino { get; set; }
        public string ProvinciaDestino { get; set; }
        public string RegionDestino { get; set; }
        public string PaisDestino { get; set; }
        //TODO: Propiedad Calculada del costo
        public decimal Costo { get; set; }
        public bool Urgente { get; set; }
        public bool EntregaPuerta { get; set; }
        public bool RetiroPuerta { get; set; }
        public decimal Peso { get; set; }
        public decimal ValorDeclarado { get; set; }

        /*
        public string TituloEntrada
            {
                get
                {
                    return $"{Apellido} , {Nombre} , {Dni} ";
                }
            }
         */
        //constuctores
        public Servicio()
        {

        }

        public Servicio(string linea)
        {

            var datos = linea.Split(';');
            Trackeo = int.Parse(datos[0]);
            Estado = datos[1];
            DomicilioOrigen = datos[2];
            LocalidadOrigen = datos[3];
            ProvinciaOrigen = datos[4];
            RegionOrigen = datos[5];
            PaisOrigen = datos[6];
            DomicilioDestino = datos[7];
            LocalidadDestino = datos[8];
            ProvinciaDestino = datos[9];
            RegionDestino = datos[10];
            PaisDestino = datos[11];
            Costo = decimal.Parse(datos[12]);
            Urgente = bool.Parse(datos[13]);
            EntregaPuerta = bool.Parse(datos[14]);
            RetiroPuerta = bool.Parse(datos[15]);
            Peso = decimal.Parse(datos[16]);
            Fecha = DateTime.Parse(datos[17]);
            ValorDeclarado = decimal.Parse(datos[18]);

        }
        //fin constructores
           
        public string ObtenerLineaDatos()
        {
            return $"{Trackeo} ; {Estado} ; {DomicilioOrigen};{LocalidadOrigen};{ProvinciaOrigen};{RegionOrigen};{PaisOrigen};{DomicilioDestino};{LocalidadDestino};{ProvinciaDestino};{RegionDestino};{PaisDestino} ; {Costo} ; {Urgente} ; {EntregaPuerta} ; {RetiroPuerta} ; {Peso} ; {Fecha} ; {ValorDeclarado}";
        }

        /*
        public static Servicio GenerarTrackeo()
        {
            var numero = 0;
            var salida = numero + 1;

          // return salida ;
        }
        */


        public static Servicio IngresarNuevo()
        {
            var servicio = new Servicio();

            
            servicio.Trackeo = new Random().Next(50000000, 99999999); //TODO buscar un metodo mas prolijo de trackeo
            // TODO servicio.Estado = Metodo a definir

            servicio.DomicilioOrigen = IngresoTexto("Por favor ingrese Domicilio de Origen");
            servicio.LocalidadOrigen = IngresoTexto("Por favor ingrese Localidad de Origen");
            servicio.ProvinciaOrigen = IngresoTexto("Por favor ingrese Provincia de Origen");//TODO ver de establecer una base con provincias disponibles y validar
            servicio.RegionOrigen = IngresoTexto("Por favor ingrese Region de Origen");//TODOver si hay logica para autodeterminar la region segun provincia
            servicio.PaisOrigen = "ARGENTINA";
            servicio.DomicilioDestino = IngresoTexto("Por favor ingrese Domicilio de Destino");
            servicio.LocalidadDestino = IngresoTexto("Por favor ingrese Localidad de Destino");
            servicio.ProvinciaDestino = IngresoTexto("Por favor ingrese Provincia de Destino");
            servicio.RegionDestino = IngresoTexto("Por favor ingrese Region de Destino");
            servicio.PaisDestino = IngresoTexto("Por favor ingrese Pais de Destino");
            //TODO : ver tambien de establecer la region del pais fuera de argentina ya que afecta al costo: puede ser limitorfe, america latina, america del norte, europa, asia
            servicio.Peso = IngresarDecimal("Ingrese el peso");

            //TODO servicio.Urgente = IngresarBool(""); ver de establecer un metodo o dejar la validacion individual de abajo

            bool salir = false;
            do
            {
                

                Console.WriteLine("Por favor determine si el servicio es o no Urgente");
                Console.WriteLine("1 - Urgente");
                Console.WriteLine("2 - No Urgente");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        servicio.Urgente = true;
                        salir = true;
                        break;



                    case "2":
                        servicio.Urgente = false;
                        salir = true;
                        break;


                    default:
                        Console.WriteLine("No ha ingresado una opcion correcta");
                        break;

                }

            } while (!salir);
            //TODO servicio.EntregaSucursal = IngresarBool(""); ver de establecer un metodo o dejar la validacion individual de abajo

            bool salir2 = false;
            do
            {


                Console.WriteLine("Por favor determine si se entrega Puerta o Sucursal");
                Console.WriteLine("1 - Puerta");
                Console.WriteLine("2 - Sucursal");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        servicio.EntregaPuerta = true;
                        salir2 = true;
                        break;
                        



                    case "2":
                        servicio.EntregaPuerta = false;
                        salir2 = true;
                        break;


                    default:
                        Console.WriteLine("No ha ingresado una opcion correcta");
                        break;

                }

            } while (!salir2);

            //TODO servicio.RetiroSucursal = IngresarBool(""); ver de establecer un metodo o dejar la validacion individual de abajo

            bool salir3 = false;
            do
            {


                Console.WriteLine("Por favor determine si el retiro es por Puerta o Sucursal");
                Console.WriteLine("1 - Puerta");
                Console.WriteLine("2 - Sucursal");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        servicio.RetiroPuerta = true;
                        salir3 = true;
                        break;



                    case "2":
                        servicio.RetiroPuerta = false;
                        salir3 = true;
                        break;


                    default:
                        Console.WriteLine("No ha ingresado una opcion correcta");
                        break;

                }

            } while (!salir3);

            servicio.Fecha = DateTime.Now;
            servicio.ValorDeclarado = IngresarDecimal("Ingrese el valor declarado");

        

            //comienzo logica para calcular costo

            //primero valido en que rango de peso se encuentra luego la distancia de entrega

            //peso hasta 500gr:

            if (servicio.Peso < 1) //TODO: ver por que no deja utilizar el operador '<' cuando es decimal, sino vamos a tener que utilizar INT y que ingresen gramos
            {
                if(servicio.PaisDestino == servicio.PaisOrigen)
                { 
                    if(servicio.RegionDestino == servicio.RegionOrigen)
                    {
                        if(servicio.ProvinciaDestino == servicio.ProvinciaOrigen)
                        {
                            if(servicio.LocalidadDestino == servicio.LocalidadOrigen)
                            {
                                servicio.Costo = servicio.Costo + 10;
                            }
                            else
                            {
                                servicio.Costo = servicio.Costo + 20;
                            }
                        }
                        else
                        {
                            servicio.Costo = servicio.Costo + 30;
                        }
                    }
                    else
                    {
                        servicio.Costo = servicio.Costo + 40;
                    }

                }
                else
                {
                    //TODO: aqui se deberia contemplar el calculo para servicios internacionales
                }

            }

            //peso hasta 10kg
            if (servicio.Peso < 10 && servicio.Peso >= 1) 
            {
                if (servicio.PaisDestino == servicio.PaisOrigen)
                {
                    if (servicio.RegionDestino == servicio.RegionOrigen)
                    {
                        if (servicio.ProvinciaDestino == servicio.ProvinciaOrigen)
                        {
                            if (servicio.LocalidadDestino == servicio.LocalidadOrigen)
                            {
                                servicio.Costo = servicio.Costo + 10;
                            }
                            else
                            {
                                servicio.Costo = servicio.Costo + 20;
                            }
                        }
                        else
                        {
                            servicio.Costo = servicio.Costo + 30;
                        }
                    }
                    else
                    {
                        servicio.Costo = servicio.Costo + 40;
                    }

                }
                else
                {
                    //TODO: aqui se deberia contemplar el calculo para servicios internacionales
                }

            }

            //peso hasta 20kg
            if (servicio.Peso < 20 && servicio.Peso >= 10)
            {
                if (servicio.PaisDestino == servicio.PaisOrigen)
                {
                    if (servicio.RegionDestino == servicio.RegionOrigen)
                    {
                        if (servicio.ProvinciaDestino == servicio.ProvinciaOrigen)
                        {
                            if (servicio.LocalidadDestino == servicio.LocalidadOrigen)
                            {
                                servicio.Costo = servicio.Costo + 10;
                            }
                            else
                            {
                                servicio.Costo = servicio.Costo + 20;
                            }
                        }
                        else
                        {
                            servicio.Costo = servicio.Costo + 30;
                        }
                    }
                    else
                    {
                        servicio.Costo = servicio.Costo + 40;
                    }

                }
                else
                {
                    //TODO: aqui se deberia contemplar el calculo para servicios internacionales
                }

            }

            //peso hasta 30kg
            if (servicio.Peso < 30 && servicio.Peso >= 20)
            {
                if (servicio.PaisDestino == servicio.PaisOrigen)
                {
                    if (servicio.RegionDestino == servicio.RegionOrigen)
                    {
                        if (servicio.ProvinciaDestino == servicio.ProvinciaOrigen)
                        {
                            if (servicio.LocalidadDestino == servicio.LocalidadOrigen)
                            {
                                servicio.Costo = servicio.Costo + 10;
                            }
                            else
                            {
                                servicio.Costo = servicio.Costo + 20;
                            }
                        }
                        else
                        {
                            servicio.Costo = servicio.Costo + 30;
                        }
                    }
                    else
                    {
                        servicio.Costo = servicio.Costo + 40;
                    }

                }
                else
                {
                    //TODO: aqui se deberia contemplar el calculo para servicios internacionales
                }

            }

            if (servicio.Urgente == true)
            {
                servicio.Costo = servicio.Costo + 10;
            }
            if (servicio.EntregaPuerta == true)
            {
                servicio.Costo = servicio.Costo + 10;
            }
            if (servicio.RetiroPuerta == true)
            {
                servicio.Costo = servicio.Costo + 10;
            }


            return servicio;
        }

        /*
        public void Mostrar()
        {
            Console.WriteLine($"DNI: {Dni}");
            Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}");
            Console.WriteLine($"Fecha Nacimietno: {FechaNacimiento:dd/MM/yyyy}");

        }

        */

      

        

        public static Servicio CrearModeloBusqueda()
        {
                var modelo = new Servicio();

                modelo.Trackeo = IngresarEntero("Por favor ingrese el nro de trackeo");
               

                return modelo;
        }

        private static int IngresarEntero(string titulo)
        {

            Console.WriteLine(titulo);

            do
            {
                var ingreso = Console.ReadLine();

                if (string.IsNullOrEmpty(ingreso))
                {
                    Console.WriteLine("El ingreso no debe ser vacio");
                    continue;
                }

                if (!Int32.TryParse(ingreso, out var salida))
                {
                    Console.WriteLine("El dato ingresado es incorrecto, ingrese nuevamente");
                    continue;
                }

                if (salida <= 0)
                {
                    Console.WriteLine("El valor ingresado debe ser mayor a cero");
                    continue;
                }

                return salida;

            } while (true);
        }


        private static decimal IngresarDecimal(string titulo)
        {

            Console.WriteLine(titulo);

            do
            {
                var ingreso = Console.ReadLine();

                if (string.IsNullOrEmpty(ingreso))
                {
                    Console.WriteLine("El ingreso no debe ser vacio");
                    continue;
                }

                if (!decimal.TryParse(ingreso, out var salida))
                {
                    Console.WriteLine("El dato ingresado es incorrecto, ingrese nuevamente");
                    continue;
                }

                if (salida <= 0)
                {
                    Console.WriteLine("El valor ingresado debe ser mayor a cero");
                    continue;
                }

                return salida;

            } while (true);
        }

        private static string IngresoTexto(string titulo, bool permiteNumeros = false)
        {
            string ingreso;
            do
            {

                Console.WriteLine(titulo);

                ingreso = Console.ReadLine();
                

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar un valor");
                    continue;
                }

                if (permiteNumeros && !ingreso.Any(Char.IsDigit))
                {
                    Console.WriteLine("El valor ingresado debe contener numeros");
                    continue;
                }

                string ingreso1 = ingreso.ToUpper();
                return ingreso1;
            } while (true);

           

        }
        

    }
}

