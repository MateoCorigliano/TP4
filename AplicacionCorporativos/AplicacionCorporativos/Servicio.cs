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
        public string PaisOrigen { get; set; }
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
        public int ClienteAsociado { get; set; }


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
            ClienteAsociado = int.Parse(datos[19]);

        }
        //fin constructores
           
        public string ObtenerLineaDatos()
        {
            return $"{Trackeo} ; {Estado} ; {DomicilioOrigen};{LocalidadOrigen};{ProvinciaOrigen};{RegionOrigen};{PaisOrigen};{DomicilioDestino};{LocalidadDestino};{ProvinciaDestino};{RegionDestino};{PaisDestino} ; {Costo} ; {Urgente} ; {EntregaPuerta} ; {RetiroPuerta} ; {Peso} ; {Fecha} ; {ValorDeclarado} ; {ClienteAsociado}";
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
            servicio.Estado = "INICIADA"; //EL ESTADO SERA ACTUALIZADO POR UNA APLICACION LOGISTICA EXTERNA A ESTA APLICACION

            servicio.DomicilioOrigen = IngresoTexto("Por favor ingrese Domicilio y altura de Origen");
            servicio.LocalidadOrigen = IngresoTexto("Por favor ingrese Localidad de Origen");
            //selecciona la provincia de origen
            bool salir5 = false;
            do
            {

                Console.WriteLine("");
                Console.WriteLine("Por favor ingrese la provincia de origen");
                Console.WriteLine("");
                Console.WriteLine("1 - BUENOS AIRES");
                Console.WriteLine("2 - CABA");
                Console.WriteLine("3 - CATAMARCA");
                Console.WriteLine("4 - CHACO");
                Console.WriteLine("5 - CHUBUT");
                Console.WriteLine("6 - CORDOBA");
                Console.WriteLine("7 - CORRIENTES");
                Console.WriteLine("8 - ENTRE RIOS");
                Console.WriteLine("9 - FORMOSA");
                Console.WriteLine("10 - JUJUY");
                Console.WriteLine("11 - LA PAMPA");
                Console.WriteLine("12 - LA RIOJA");
                Console.WriteLine("13 - MENDOZA");
                Console.WriteLine("14 - MISIONES");
                Console.WriteLine("15 - NEUQUEN");
                Console.WriteLine("16 - RIO NEGRO");
                Console.WriteLine("17 - SALTA");
                Console.WriteLine("18 - SAN JUAN");
                Console.WriteLine("19 - LA RIOJA");
                Console.WriteLine("20 - SAN LUIS");
                Console.WriteLine("21 - SANTA FE");
                Console.WriteLine("22 - SANTIAGO DEL ESTERO");
                Console.WriteLine("23 - TIERRA DEL FUEGO");
                Console.WriteLine("24 - TUCUMAN");
               


                var opcion2 = Console.ReadLine();

                switch (opcion2)
                {
                    case "1":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "BUENOS AIRES";
                        salir5 = true;
                        break;

                    case "2":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "CABA";
                        salir5 = true;
                        break;

                    case "3":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "CATAMARCA";
                        salir5 = true;
                        break;

                    case "4":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "CHACO";
                        salir5 = true;
                        break;

                    case "5":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "CHUBUT";
                        salir5 = true;
                        break;

                    case "6":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "CORDOBA";
                        salir5 = true;
                        break;

                    case "7":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "CORRIENTES";
                        salir5 = true;
                        break;

                    case "8":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "ENTRE RIOS";
                        salir5 = true;
                        break;

                    case "9":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "FORMOSA";
                        salir5 = true;
                        break;

                    case "10":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "JUJUY";
                        salir5 = true;
                        break;

                    case "11":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "LA PAMPA";
                        salir5 = true;
                        break;

                    case "12":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "LA RIOJA";
                        salir5 = true;
                        break;

                    case "13":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "MENDOZA";
                        salir5 = true;
                        break;

                    case "14":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "MISIONES";
                        salir5 = true;
                        break;

                    case "15":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "NEUQUEN";
                        salir5 = true;
                        break;

                    case "16":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "RIO NEGRO";
                        salir5 = true;
                        break;

                    case "17":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "SALTA";
                        salir5 = true;
                        break;

                    case "18":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "SAN JUAN";
                        salir5 = true;
                        break;

                    case "19":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "LA RIOJA";
                        salir5 = true;
                        break;

                    case "20":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "SAN LUIS";
                        salir5 = true;
                        break;

                    case "21":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "SANTA FE";
                        salir5 = true;
                        break;

                    case "22":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "SANTIAGO DEL ESTERO";
                        salir5 = true;
                        break;

                    case "23":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "TIERRA DEL FUEGO";
                        salir5 = true;
                        break;

                    case "24":
                        Console.Clear();
                        servicio.ProvinciaOrigen = "TUCUMAN";
                        salir5 = true;
                        break;





                    default:
                        Console.WriteLine("No ha ingresado una opcion correcta");
                        break;
                }

            } while (!salir5);

           

            //ESTABLECEMOS REGION SEGUN PROVINCIA
            if (servicio.ProvinciaOrigen == "BUENOS AIRES" || servicio.ProvinciaOrigen == "CABA")
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

            //SELECCIONA PAIS DE DESTINO
            bool salir4 = false;
            do
            {

                Console.WriteLine("");
                Console.WriteLine("Por favor ingrese Pais de Destino");
                Console.WriteLine("");
                Console.WriteLine("1 - ARGENTINA");
                Console.WriteLine("2 - BRASIL");
                Console.WriteLine("3 - URUGUAY");
                Console.WriteLine("4 - BOLIVIA");
                Console.WriteLine("5 - CHILE");
                Console.WriteLine("6 - PARAGUAY");
                Console.WriteLine("7 - COLOMBIA");
                Console.WriteLine("8 - PERU");
                Console.WriteLine("9 - ECUADOR");
                Console.WriteLine("10 - VENEZUELA");
                Console.WriteLine("11 - GUYANA");


                var opcion2 = Console.ReadLine();

                switch (opcion2)
                {
                    case "1":
                        Console.Clear();
                        servicio.PaisDestino = "ARGENTINA";
                        salir4 = true;
                        break;

                    case "2":
                        Console.Clear();
                        servicio.PaisDestino = "BRASIL";
                        salir4 = true;
                        break;

                    case "3":
                        Console.Clear();
                        servicio.PaisDestino = "URUGUAY";
                        salir4 = true;
                        break;

                    case "4":
                        Console.Clear();
                        servicio.PaisDestino = "BOLIVIA";
                        salir4 = true;
                        break;

                    case "5":
                        Console.Clear();
                        servicio.PaisDestino = "CHILE";
                        salir4 = true;
                        break;

                    case "6":
                        Console.Clear();
                        servicio.PaisDestino = "PARAGUAY";
                        salir4 = true;
                        break;

                    case "7":
                        Console.Clear();
                        servicio.PaisDestino = "COLOMBIA";
                        salir4 = true;
                        break;

                    case "8":
                        Console.Clear();
                        servicio.PaisDestino = "PERU";
                        salir4 = true;
                        break;

                    case "9":
                        Console.Clear();
                        servicio.PaisDestino = "ECUADOR";
                        salir4 = true;
                        break;

                    case "10":
                        Console.Clear();
                        servicio.PaisDestino = "VENEZUELA";
                        salir4 = true;
                        break;

                    case "11":
                        Console.Clear();
                        servicio.PaisDestino = "GUYANA";
                        salir4 = true;
                        break;




                    default:
                        Console.WriteLine("No ha ingresado una opcion correcta");
                        break;
                }

            } while (!salir4);

            servicio.DomicilioDestino = IngresoTexto("Por favor ingrese Domicilio y altura de Destino");

            if(servicio.PaisDestino == "ARGENTINA")
            { 
            servicio.LocalidadDestino = IngresoTexto("Por favor ingrese Localidad de Destino");

                //ingrso provincia destino
                bool salir6 = false;
                do
                {

                    Console.WriteLine("");
                    Console.WriteLine("Por favor ingrese la Provincia de Destino");
                    Console.WriteLine("");
                    Console.WriteLine("1 - BUENOS AIRES");
                    Console.WriteLine("2 - CABA");
                    Console.WriteLine("3 - CATAMARCA");
                    Console.WriteLine("4 - CHACO");
                    Console.WriteLine("5 - CHUBUT");
                    Console.WriteLine("6 - CORDOBA");
                    Console.WriteLine("7 - CORRIENTES");
                    Console.WriteLine("8 - ENTRE RIOS");
                    Console.WriteLine("9 - FORMOSA");
                    Console.WriteLine("10 - JUJUY");
                    Console.WriteLine("11 - LA PAMPA");
                    Console.WriteLine("12 - LA RIOJA");
                    Console.WriteLine("13 - MENDOZA");
                    Console.WriteLine("14 - MISIONES");
                    Console.WriteLine("15 - NEUQUEN");
                    Console.WriteLine("16 - RIO NEGRO");
                    Console.WriteLine("17 - SALTA");
                    Console.WriteLine("18 - SAN JUAN");
                    Console.WriteLine("19 - LA RIOJA");
                    Console.WriteLine("20 - SAN LUIS");
                    Console.WriteLine("21 - SANTA FE");
                    Console.WriteLine("22 - SANTIAGO DEL ESTERO");
                    Console.WriteLine("23 - TIERRA DEL FUEGO");
                    Console.WriteLine("24 - TUCUMAN");



                    var opcion2 = Console.ReadLine();

                    switch (opcion2)
                    {
                        case "1":
                            Console.Clear();
                            servicio.ProvinciaDestino = "BUENOS AIRES";
                            salir6 = true;
                            break;

                        case "2":
                            Console.Clear();
                            servicio.ProvinciaDestino = "CABA";
                            salir6 = true;
                            break;

                        case "3":
                            Console.Clear();
                            servicio.ProvinciaDestino = "CATAMARCA";
                            salir6 = true;
                            break;

                        case "4":
                            Console.Clear();
                            servicio.ProvinciaDestino = "CHACO";
                            salir6 = true;
                            break;

                        case "5":
                            Console.Clear();
                            servicio.ProvinciaDestino = "CHUBUT";
                            salir6 = true;
                            break;

                        case "6":
                            Console.Clear();
                            servicio.ProvinciaDestino = "CORDOBA";
                            salir6 = true;
                            break;

                        case "7":
                            Console.Clear();
                            servicio.ProvinciaDestino = "CORRIENTES";
                            salir6 = true;
                            break;

                        case "8":
                            Console.Clear();
                            servicio.ProvinciaDestino = "ENTRE RIOS";
                            salir6 = true;
                            break;

                        case "9":
                            Console.Clear();
                            servicio.ProvinciaDestino = "FORMOSA";
                            salir6 = true;
                            break;

                        case "10":
                            Console.Clear();
                            servicio.ProvinciaDestino = "JUJUY";
                            salir6 = true;
                            break;

                        case "11":
                            Console.Clear();
                            servicio.ProvinciaDestino = "LA PAMPA";
                            salir6 = true;
                            break;

                        case "12":
                            Console.Clear();
                            servicio.ProvinciaDestino = "LA RIOJA";
                            salir6 = true;
                            break;

                        case "13":
                            Console.Clear();
                            servicio.ProvinciaDestino = "MENDOZA";
                            salir6 = true;
                            break;

                        case "14":
                            Console.Clear();
                            servicio.ProvinciaDestino = "MISIONES";
                            salir6 = true;
                            break;

                        case "15":
                            Console.Clear();
                            servicio.ProvinciaDestino = "NEUQUEN";
                            salir6 = true;
                            break;

                        case "16":
                            Console.Clear();
                            servicio.ProvinciaDestino = "RIO NEGRO";
                            salir6 = true;
                            break;

                        case "17":
                            Console.Clear();
                            servicio.ProvinciaDestino = "SALTA";
                            salir6 = true;
                            break;

                        case "18":
                            Console.Clear();
                            servicio.ProvinciaDestino = "SAN JUAN";
                            salir6 = true;
                            break;

                        case "19":
                            Console.Clear();
                            servicio.ProvinciaDestino = "LA RIOJA";
                            salir6 = true;
                            break;

                        case "20":
                            Console.Clear();
                            servicio.ProvinciaDestino = "SAN LUIS";
                            salir6 = true;
                            break;

                        case "21":
                            Console.Clear();
                            servicio.ProvinciaDestino = "SANTA FE";
                            salir6 = true;
                            break;

                        case "22":
                            Console.Clear();
                            servicio.ProvinciaDestino = "SANTIAGO DEL ESTERO";
                            salir6 = true;
                            break;

                        case "23":
                            Console.Clear();
                            servicio.ProvinciaDestino = "TIERRA DEL FUEGO";
                            salir6 = true;
                            break;

                        case "24":
                            Console.Clear();
                            servicio.ProvinciaDestino = "TUCUMAN";
                            salir6 = true;
                            break;





                        default:
                            Console.WriteLine("No ha ingresado una opcion correcta");
                            break;
                    }

                } while (!salir6);



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

            }

            
            servicio.Peso = IngresarPeso("Ingrese el peso expresado en gramos hasta 30000");


           
            //SELECCION SERVICIO URGENTE O NO
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
            
            //SELECCION ENTREGA EN PUERTA O SUCURSAL
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

            
            //SELECCION RETIRO EN PUERTA O SUCURSAL
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
            servicio.ClienteAsociado = ConsultaClienteAsociado();



            //comienzo logica para calcular costo

            //primero valido en que rango de peso se encuentra luego la distancia de entrega

            //peso hasta 500gr:

            if (servicio.Peso < 500)
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

                        if ("METROPOLTANA" == servicio.RegionOrigen)
                        {
                            if ("CABA" == servicio.ProvinciaOrigen)
                            {
                                if ("CABA" == servicio.LocalidadOrigen)
                                {
                                    precio = ConsultaTarifaLocal(servicio.Peso);

                                    servicio.Costo = servicio.Costo + precio;
                                }
                                else
                                {
                                    precio = ConsultaTarifaProvincial(servicio.Peso);
                                    servicio.Costo = servicio.Costo + precio;
                                }
                            }
                            else
                            {
                                precio = ConsultaTarifaRegional(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaSudamerica(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;

                        if ("METROPOLTANA" == servicio.RegionOrigen)
                        {
                            if ("CABA" == servicio.ProvinciaOrigen)
                            {
                                if ("CABA" == servicio.LocalidadOrigen)
                                {
                                    precio = ConsultaTarifaLocal(servicio.Peso);

                                    servicio.Costo = servicio.Costo + precio;
                                }
                                else
                                {
                                    precio = ConsultaTarifaProvincial(servicio.Peso);
                                    servicio.Costo = servicio.Costo + precio;
                                }
                            }
                            else
                            {
                                precio = ConsultaTarifaRegional(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }
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

                        if ("METROPOLTANA" == servicio.RegionOrigen)
                        {
                            if ("CABA" == servicio.ProvinciaOrigen)
                            {
                                if ("CABA" == servicio.LocalidadOrigen)
                                {
                                    precio = ConsultaTarifaLocal(servicio.Peso);

                                    servicio.Costo = servicio.Costo + precio;
                                }
                                else
                                {
                                    precio = ConsultaTarifaProvincial(servicio.Peso);
                                    servicio.Costo = servicio.Costo + precio;
                                }
                            }
                            else
                            {
                                precio = ConsultaTarifaRegional(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }
                        else
                        {
                            precio = ConsultaTarifaNacional(servicio.Peso);
                            servicio.Costo = servicio.Costo + precio;
                        }
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaSudamerica(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;

                        if ("METROPOLTANA" == servicio.RegionOrigen)
                        {
                            if ("CABA" == servicio.ProvinciaOrigen)
                            {
                                if ("CABA" == servicio.LocalidadOrigen)
                                {
                                    precio = ConsultaTarifaLocal(servicio.Peso);

                                    servicio.Costo = servicio.Costo + precio;
                                }
                                else
                                {
                                    precio = ConsultaTarifaProvincial(servicio.Peso);
                                    servicio.Costo = servicio.Costo + precio;
                                }
                            }
                            else
                            {
                                precio = ConsultaTarifaRegional(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }
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

                        if ("METROPOLTANA" == servicio.RegionOrigen)
                        {
                            if ("CABA" == servicio.ProvinciaOrigen)
                            {
                                if ("CABA" == servicio.LocalidadOrigen)
                                {
                                    precio = ConsultaTarifaLocal(servicio.Peso);

                                    servicio.Costo = servicio.Costo + precio;
                                }
                                else
                                {
                                    precio = ConsultaTarifaProvincial(servicio.Peso);
                                    servicio.Costo = servicio.Costo + precio;
                                }
                            }
                            else
                            {
                                precio = ConsultaTarifaRegional(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaSudamerica(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;

                        if ("METROPOLTANA" == servicio.RegionOrigen)
                        {
                            if ("CABA" == servicio.ProvinciaOrigen)
                            {
                                if ("CABA" == servicio.LocalidadOrigen)
                                {
                                    precio = ConsultaTarifaLocal(servicio.Peso);

                                    servicio.Costo = servicio.Costo + precio;
                                }
                                else
                                {
                                    precio = ConsultaTarifaProvincial(servicio.Peso);
                                    servicio.Costo = servicio.Costo + precio;
                                }
                            }
                            else
                            {
                                precio = ConsultaTarifaRegional(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }
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

                        if ("METROPOLTANA" == servicio.RegionOrigen)
                        {
                            if ("CABA" == servicio.ProvinciaOrigen)
                            {
                                if ("CABA" == servicio.LocalidadOrigen)
                                {
                                    precio = ConsultaTarifaLocal(servicio.Peso);

                                    servicio.Costo = servicio.Costo + precio;
                                }
                                else
                                {
                                    precio = ConsultaTarifaProvincial(servicio.Peso);
                                    servicio.Costo = servicio.Costo + precio;
                                }
                            }
                            else
                            {
                                precio = ConsultaTarifaRegional(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }
                    }
                    else
                    {
                        decimal precio = ConsultaTarifaSudamerica(servicio.Peso);
                        servicio.Costo = servicio.Costo + precio;

                        if ("METROPOLTANA" == servicio.RegionOrigen)
                        {
                            if ("CABA" == servicio.ProvinciaOrigen)
                            {
                                if ("CABA" == servicio.LocalidadOrigen)
                                {
                                    precio = ConsultaTarifaLocal(servicio.Peso);

                                    servicio.Costo = servicio.Costo + precio;
                                }
                                else
                                {
                                    precio = ConsultaTarifaProvincial(servicio.Peso);
                                    servicio.Costo = servicio.Costo + precio;
                                }
                            }
                            else
                            {
                                precio = ConsultaTarifaRegional(servicio.Peso);
                                servicio.Costo = servicio.Costo + precio;
                            }
                        }

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

        private static decimal ConsultaTarifaLocal(int pesoLimite)
        {
            decimal precio = AgendaTarifasNacionales.SeleccionarPrecioLocal(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaProvincial(int pesoLimite)
        {
            decimal precio = AgendaTarifasNacionales.SeleccionarPrecioProvincial(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaRegional(int pesoLimite)
        {
            decimal precio = AgendaTarifasNacionales.SeleccionarPrecioRegional(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaNacional(int pesoLimite)
        {
            decimal precio = AgendaTarifasNacionales.SeleccionarPrecioNacional(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaLimitrofe(int pesoLimite)
        {
            decimal precio = AgendaTarifasInternacionales.SeleccionarPrecioLimitrofe(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaSudamerica(int pesoLimite)
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

        public static int ConsultaClienteAsociado()
        {

            var usuario = AgendaUsuarios.Seleccionar();

            
            var nroCliente = usuario.ClienteAsociado;

            return nroCliente;
                
            


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

        public static Servicio ModeloBusqueda2(int nroCliente)
        {
            var modelo = new Servicio();

            modelo.ClienteAsociado = nroCliente;


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

