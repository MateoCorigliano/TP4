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
        //TODO AGREGAR PROPIEDAD ALTURA ORIGEN
        public string LocalidadOrigen { get; set; }
        public string ProvinciaOrigen { get; set; }
        public string RegionOrigen { get; set; }
        public string PaisOrigen { get; set; } //siempre sera Argentina
        public string DomicilioDestino { get; set; }
        //TODO AGREGAR ALTURA DESTINO
        public string LocalidadDestino { get; set; }
        public string ProvinciaDestino { get; set; }
        public string RegionDestino { get; set; }
        public string PaisDestino { get; set; }
        public decimal Costo { get; set; }
        public bool Urgente { get; set; }
        public bool EntregaPuerta { get; set; }
        public bool RetiroPuerta { get; set; }
        public int Peso { get; set; }
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
            Peso = int.Parse(datos[16]);
            Fecha = DateTime.Parse(datos[17]);
            ValorDeclarado = decimal.Parse(datos[18]);
            //TODO: agregar el nro de cliente para traer en el estado de cuenta todos los servicios pendientes del cliente asociado

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

            
            servicio.Trackeo = new Random().Next(50000000, 99999999); 
            servicio.Estado = "RECIBIDO"; //EL ESTADO SERA ACTUALIZADO POR UNA APLICACION LOGISTICA EXTERNA A ESTA APLICACION

            servicio.DomicilioOrigen = IngresoTexto("Por favor ingrese Domicilio y altura de Origen");
            servicio.LocalidadOrigen = IngresoTexto("Por favor ingrese Localidad de Origen");
            servicio.ProvinciaOrigen = IngresoTexto("Por favor ingrese Provincia de Origen");//TODO ver de establecer una base con provincias disponibles y validar
            
            //ESTABLECEMOS REGION SEGUN PROVINCIA
            if(servicio.ProvinciaOrigen == "BUENOS AIRES" || servicio.ProvinciaOrigen == "CABA")
            {
                servicio.RegionOrigen = "METROPOLITANA" ;
            }
            if (servicio.ProvinciaOrigen == "TIERRA DEL FUEGO" || servicio.ProvinciaOrigen == "SANTA CRUZ" || servicio.ProvinciaOrigen == "CHUBUT" || servicio.ProvinciaOrigen == "RIO NEGRO" || servicio.ProvinciaOrigen == "NEUQUEN")
            {
                servicio.RegionOrigen = "SUR";
            }
            if (servicio.ProvinciaOrigen == "LA PAMPA" || servicio.ProvinciaOrigen == "SAN LUIS" || servicio.ProvinciaOrigen == "MENDOZA" || servicio.ProvinciaOrigen == "CORDOBA" || servicio.ProvinciaOrigen == "SANTA FE" )
            {
                servicio.RegionOrigen = "CENTRO";
            }
            if (servicio.ProvinciaOrigen == "ENTRE RIOS" || servicio.ProvinciaOrigen == "CORRIENTES" || servicio.ProvinciaOrigen == "MISIONES" || servicio.ProvinciaOrigen == "CHACO" || servicio.ProvinciaOrigen == "FORMOSA" || servicio.ProvinciaOrigen == "SANTIAGO DEL ESTERO" || servicio.ProvinciaOrigen == "TUCUMAN" || servicio.ProvinciaOrigen == "SALTA" || servicio.ProvinciaOrigen == "JUJUY" || servicio.ProvinciaOrigen == "CATAMARCA" || servicio.ProvinciaOrigen == "LA RIOJA" || servicio.ProvinciaOrigen == "SAN JUAN")
            {
                servicio.RegionOrigen = "NORTE";
            }
            servicio.PaisOrigen = "ARGENTINA"; //SOLO SALEN SERVICIOS DESDE ARGENTINA PUEDE VARIAR SOLO EL DESTINO
            servicio.DomicilioDestino = IngresoTexto("Por favor ingrese Domicilio y altura de Destino");
            servicio.LocalidadDestino = IngresoTexto("Por favor ingrese Localidad de Destino");
            servicio.ProvinciaDestino = IngresoTexto("Por favor ingrese Provincia de Destino");
            if (servicio.ProvinciaDestino == "BUENOS AIRES" || servicio.ProvinciaDestino == "CABA")
            {
                servicio.RegionDestino = "METROPOLITANA";
            }
            if (servicio.ProvinciaDestino == "TIERRA DEL FUEGO" || servicio.ProvinciaDestino == "SANTA CRUZ" || servicio.ProvinciaDestino == "CHUBUT" || servicio.ProvinciaDestino == "RIO NEGRO" || servicio.ProvinciaDestino == "NEUQUEN")
            {
                servicio.RegionDestino = "SUR";
            }
            if (servicio.ProvinciaDestino == "LA PAMPA" || servicio.ProvinciaDestino == "SAN LUIS" || servicio.ProvinciaDestino == "MENDOZA" || servicio.ProvinciaDestino == "CORDOBA" || servicio.ProvinciaDestino == "SANTA FE")
            {
                servicio.RegionDestino = "CENTRO";
            }
            if (servicio.ProvinciaDestino == "ENTRE RIOS" || servicio.ProvinciaDestino == "CORRIENTES" || servicio.ProvinciaDestino == "MISIONES" || servicio.ProvinciaDestino == "CHACO" || servicio.ProvinciaDestino == "FORMOSA" || servicio.ProvinciaDestino == "SANTIAGO DEL ESTERO" || servicio.ProvinciaDestino == "TUCUMAN" || servicio.ProvinciaDestino == "SALTA" || servicio.ProvinciaDestino == "JUJUY" || servicio.ProvinciaDestino == "CATAMARCA" || servicio.ProvinciaDestino == "LA RIOJA" || servicio.ProvinciaDestino == "SAN JUAN")
            {
                servicio.RegionDestino = "NORTE";
            }
            servicio.PaisDestino = IngresoTexto("Por favor ingrese Pais de Destino");
            //TODO : ver tambien de establecer la region del pais fuera de argentina ya que afecta al costo: puede ser limitorfe, america latina, america del norte, europa, asia
            servicio.Peso = IngresarPeso("Ingrese el peso expresado en gramos hasta 30000");


           

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

            if (servicio.Peso < 500) //TODO: utilizo entero, ver por que no deja utilizar el operador '<' cuando es decimal, sino vamos a tener que utilizar INT y que ingresen gramos
            {
                if(servicio.PaisDestino == servicio.PaisOrigen)
                { 
                    if(servicio.RegionDestino == servicio.RegionOrigen)
                    {
                        if(servicio.ProvinciaDestino == servicio.ProvinciaOrigen)
                        {
                            if(servicio.LocalidadDestino == servicio.LocalidadOrigen)
                            {
                                decimal precio = ConsultaTarifaLocal(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                            else
                            {
                                decimal precio = ConsultaTarifaProvincial(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }
                        else
                        {
                            decimal precio = ConsultaTarifaRegional(servicio.Peso);
                            servicio.Costo = servicio.Costo + precio;
                        }
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaNacional(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }

                }
                else
                {
                    //servicios internacionales
                    if(servicio.PaisDestino == "BRASIL" || servicio.PaisDestino == "URUGUAY" || servicio.PaisDestino == "BOLIVIA" || servicio.PaisDestino == "CHILE" || servicio.PaisDestino == "PARAGUAY" )
                    {
                        decimal precio = ConsultaTarifaLimitrofe(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaSudamerica(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }
                }

            }

            //peso hasta 10kg
            if (servicio.Peso < 10000 && servicio.Peso >= 500) 
            {
                if (servicio.PaisDestino == servicio.PaisOrigen)
                {
                    if (servicio.RegionDestino == servicio.RegionOrigen)
                    {
                        if (servicio.ProvinciaDestino == servicio.ProvinciaOrigen)
                        {
                            if (servicio.LocalidadDestino == servicio.LocalidadOrigen)
                            {
                                decimal precio = ConsultaTarifaLocal(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                            else
                            {
                                decimal precio = ConsultaTarifaProvincial(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }
                        else
                        {
                            decimal precio = ConsultaTarifaRegional(servicio.Peso);
                            servicio.Costo = servicio.Costo + precio;
                        }
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaNacional(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }

                }
                else
                {
                    //servicios internacionales
                    if (servicio.PaisDestino == "BRASIL" || servicio.PaisDestino == "URUGUAY" || servicio.PaisDestino == "BOLIVIA" || servicio.PaisDestino == "CHILE" || servicio.PaisDestino == "PARAGUAY")
                    {
                        decimal precio = ConsultaTarifaLimitrofe(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaSudamerica(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }
                }

            }

            //peso hasta 20kg
            if (servicio.Peso < 20000 && servicio.Peso >= 10000)
            {
                if (servicio.PaisDestino == servicio.PaisOrigen)
                {
                    if (servicio.RegionDestino == servicio.RegionOrigen)
                    {
                        if (servicio.ProvinciaDestino == servicio.ProvinciaOrigen)
                        {
                            if (servicio.LocalidadDestino == servicio.LocalidadOrigen)
                            {
                                decimal precio = ConsultaTarifaLocal(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                            else
                            {
                                decimal precio = ConsultaTarifaProvincial(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }
                        else
                        {
                            decimal precio = ConsultaTarifaRegional(servicio.Peso);
                            servicio.Costo = servicio.Costo + precio;
                        }
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaNacional(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }

                }
                else
                {
                    //servicios internacionales
                    if (servicio.PaisDestino == "BRASIL" || servicio.PaisDestino == "URUGUAY" || servicio.PaisDestino == "BOLIVIA" || servicio.PaisDestino == "CHILE" || servicio.PaisDestino == "PARAGUAY")
                    {
                        decimal precio = ConsultaTarifaLimitrofe(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaSudamerica(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }
                }

            }

            //peso hasta 30kg
            if (servicio.Peso <= 30000 && servicio.Peso >= 20000)
            {
                if (servicio.PaisDestino == servicio.PaisOrigen)
                {
                    if (servicio.RegionDestino == servicio.RegionOrigen)
                    {
                        if (servicio.ProvinciaDestino == servicio.ProvinciaOrigen)
                        {
                            if (servicio.LocalidadDestino == servicio.LocalidadOrigen)
                            {
                                decimal precio = ConsultaTarifaLocal(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                            else
                            {
                                decimal precio = ConsultaTarifaProvincial(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }
                        else
                        {
                            decimal precio = ConsultaTarifaRegional(servicio.Peso);
                            servicio.Costo = servicio.Costo + precio;
                        }
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaNacional(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }

                }
                else
                {
                    //servicios internacionales
                    if (servicio.PaisDestino == "BRASIL" || servicio.PaisDestino == "URUGUAY" || servicio.PaisDestino == "BOLIVIA" || servicio.PaisDestino == "CHILE" || servicio.PaisDestino == "PARAGUAY")
                    {
                        decimal precio = ConsultaTarifaLimitrofe(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaSudamerica(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;
                    }
                }

            }

            if (servicio.Urgente == true)
            {


                decimal cargo = ConsultaCargoUrgente(servicio.Urgente);
                servicio.Costo = servicio.Costo + cargo;
               
            }
            if (servicio.EntregaPuerta == true)
            {
                decimal cargo = ConsultaCargoEntrega(servicio.EntregaPuerta);
                servicio.Costo = servicio.Costo + cargo;
            }
            if (servicio.RetiroPuerta == true)
            {
                decimal cargo = ConsultaCargoRetiro(servicio.RetiroPuerta);
                servicio.Costo = servicio.Costo + cargo;
            }


            return servicio;
        }

        private static decimal ConsultaTarifaLocal(decimal pesoLimite)
        {
            decimal precio = AgendaTarifasNacionales.SeleccionarPrecioLocal(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaProvincial(decimal pesoLimite)
        {
            decimal precio = AgendaTarifasNacionales.SeleccionarPrecioProvincial(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaRegional(decimal pesoLimite)
        {
            decimal precio = AgendaTarifasNacionales.SeleccionarPrecioRegional(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaNacional(decimal pesoLimite)
        {
            decimal precio = AgendaTarifasNacionales.SeleccionarPrecioNacional(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaLimitrofe(decimal pesoLimite)
        {
            decimal precio = AgendaTarifasInternacionales.SeleccionarPrecioLimitrofe(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaSudamerica(decimal pesoLimite)
        {
            decimal precio = AgendaTarifasInternacionales.SeleccionarPrecioSudamerica(pesoLimite);
            return precio;
        }

        private static decimal ConsultaCargoUrgente(bool entrada)
        {
            decimal cargo = AgendaTarifasAdicionales.SeleccionarCargoUrgente(entrada);
            return cargo;
        }

        private static decimal ConsultaTopeUrgente(bool entrada)
        {
            decimal cargo = AgendaTarifasAdicionales.SeleccionarTopeUrgente(entrada);
            return cargo;
        }

        private static decimal ConsultaCargoEntrega(bool entrada)
        {
            decimal cargo = AgendaTarifasAdicionales.SeleccionarCargoEntrega(entrada);
            return cargo;
        }

        private static decimal ConsultaCargoRetiro(bool entrada)
        {
            decimal cargo = AgendaTarifasAdicionales.SeleccionarCargoRetiro(entrada);
            return cargo;
        }



        public void Mostrar()
        {
            Console.WriteLine($"Trackeo: {Trackeo}");
            Console.WriteLine($"Estado: {Estado}");

        }

        

        public bool CoincideCon(Servicio modelo)
        {
            if (modelo.Trackeo != 0 && Trackeo != modelo.Trackeo)
            {
                return false;
            }

            

            return true;
        }



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

        private static int IngresarPeso(string titulo)
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

                if (salida <= 0 || salida >= 30000)
                {
                    Console.WriteLine("El valor ingresado debe ser mayor a cero y menor o igual a 30000");
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

