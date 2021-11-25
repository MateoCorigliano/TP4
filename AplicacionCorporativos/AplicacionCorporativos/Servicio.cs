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
        public string PaisOrigen { get; set; }
        public string DomicilioDestino { get; set; }
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
        public int Continente { get; set; }


       
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
        
        public static Servicio IngresarNuevo()
        {
            var servicio = new Servicio();

            servicio.Trackeo = new Random().Next(50000000, 99999999); 
            servicio.Estado = "INICIADA"; //EL ESTADO SERA ACTUALIZADO POR UNA APLICACION LOGISTICA EXTERNA A ESTA APLICACION

            //DATOS DE ORIGEN

            servicio.DomicilioOrigen = IngresoTexto("Por favor ingrese Domicilio y altura de Origen", false, "domicilo origen");
            servicio.LocalidadOrigen = IngresoTexto("Por favor ingrese Localidad de Origen", false, "localidad origen");
            servicio.ProvinciaOrigen = Provincias("origen");
            servicio.RegionOrigen = AgendaProvincias.EstablecerRegion(servicio.ProvinciaOrigen);
            servicio.PaisOrigen = "ARGENTINA"; //SOLO SALEN SERVICIOS DESDE ARGENTINA PUEDE VARIAR SOLO EL DESTINO

            //DATOS DE DESTINO

            servicio.PaisDestino = EstablecerPais();
            servicio.DomicilioDestino = IngresoTexto("Por favor ingrese Domicilio y altura de Destino", true, servicio.DomicilioOrigen);

            if (servicio.PaisDestino == "ARGENTINA")
            {
                servicio.LocalidadDestino = IngresoTexto("Por favor ingrese Localidad de Destino", false, "localidad destino");
                servicio.ProvinciaDestino = Provincias("destino");
                servicio.RegionDestino = AgendaProvincias.EstablecerRegion(servicio.ProvinciaDestino);
            }

            if (servicio.PaisDestino != "ARGENTINA")
            {
                servicio.LocalidadDestino = "CABA";
                servicio.ProvinciaDestino = "CABA";
                servicio.RegionDestino = "METROPOLITANA";
            }

            //PESO, TIP0S DE SERVICIO, FECHA Y VALOR

            servicio.Peso = IngresarPeso("Ingrese el peso expresado en gramos hasta 30000");

            servicio.Urgente = ServiciosSiNo("urgente");
            servicio.RetiroPuerta = ServiciosSiNo("retiro");
            servicio.EntregaPuerta = ServiciosSiNo("entrega");

            servicio.Fecha = DateTime.Now;
            servicio.ValorDeclarado = IngresarDecimal("Ingrese el valor declarado");
            servicio.ClienteAsociado = ConsultaClienteAsociado();



            //comienzo logica para calcular costo

            //primero valido en que rango de peso se encuentra luego la distancia de entrega

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

            if (servicio.PaisOrigen != servicio.PaisDestino)
            {
                int codigoCont = AgendaPaises.TraerContinenteDestino(servicio.PaisDestino);
                //servicios internacionales

                if (codigoCont == 1 && (servicio.PaisDestino == "BRASIL" || servicio.PaisDestino == "URUGUAY" || servicio.PaisDestino == "BOLIVIA" || servicio.PaisDestino == "CHILE" || servicio.PaisDestino == "PARAGUAY"))
                {
                    decimal precio = ConsultaTarifaLimitrofe(servicio.Peso);
                    servicio.Costo = servicio.Costo + precio;
                }

                else if (codigoCont == 1)
                {
                    decimal precio = ConsultaTarifaSudamerica(servicio.Peso);
                    servicio.Costo = servicio.Costo + precio;
                }

                else if (codigoCont == 2)
                {
                    decimal precio = ConsultaTarifaAmericaNorte(servicio.Peso);
                    servicio.Costo = servicio.Costo + precio;
                }

                else if (codigoCont == 3)
                {
                    decimal precio = ConsultaTarifaEuropa(servicio.Peso);
                    servicio.Costo = servicio.Costo + precio;
                }

                else if (codigoCont == 5)
                {
                    decimal precio = ConsultaTarifaAsia(servicio.Peso);
                    servicio.Costo = servicio.Costo + precio;
                }
            }

            if (servicio.Urgente == true)
            {
                decimal cargo = ConsultaCargoUrgente(servicio.Urgente);
                decimal tope = ConsultaTopeUrgente(servicio.Urgente);
                decimal recargo = (servicio.Costo * (1 + (cargo / 100))) - servicio.Costo ;

                if (recargo > tope)
                {
                    servicio.Costo = servicio.Costo + tope;
                }
                else
                {
                  servicio.Costo = servicio.Costo + recargo;
                }

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

        private static decimal ConsultaTarifaAmericaNorte(int pesoLimite)
        {
            decimal precio = AgendaTarifasInternacionales.SeleccionarPrecioAmericaNorte(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaEuropa(int pesoLimite)
        {
            decimal precio = AgendaTarifasInternacionales.SeleccionarPrecioEuropa(pesoLimite);
            return precio;
        }

        private static decimal ConsultaTarifaAsia(int pesoLimite)
        {
            decimal precio = AgendaTarifasInternacionales.SeleccionarPrecioAsia(pesoLimite);
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
            bool seguir = true;
            int nroCliente = 0;
            
            do
            {
                var usuario = AgendaUsuarios.Seleccionar(); //

                if (usuario != null)
                {
                    nroCliente = usuario.ClienteAsociado;  //
                    seguir = false;
                    //
                   
                }

            } while (seguir);

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

                if (salida <= 0 || salida > 30000)
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

        private static string IngresoTexto(string titulo, bool domicilioDestino, string dato, bool permiteNumeros = false)
        {
            string ingreso;
            do
            {
                Console.WriteLine(titulo);

                ingreso = Console.ReadLine();
                string ingreso1 = ingreso.ToUpper();

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

                if (domicilioDestino == true && ingreso1 == dato)
                {
                    Console.WriteLine("No puede ingresar como destino la misma dirección de origen");
                    continue;
                }

                return ingreso1;

            } while (true);

        }

        private static string Provincias(string origenODestino)
        {
            Console.WriteLine("");
            Console.WriteLine("Por favor ingrese la provincia de " + origenODestino);
            Console.WriteLine("");
            AgendaProvincias.MostrarProvincias();
            int codigoProv = AgendaProvincias.IngresarOpcion();
            string provincia = AgendaProvincias.SeleccionarProvincia(codigoProv);
            return provincia;
        }

        public static string EstablecerPais()
        {
            Console.WriteLine("\n Por favor, elija un continente de destino\n");
            AgendaContinentes.MostrarContinentes();
            int codigoCont = AgendaContinentes.IngresarOpcion();
            Console.Clear();
            Console.WriteLine("Ingrese el país de destino");
            AgendaPaises.MostrarPaises(codigoCont);
            int codigoPais = AgendaPaises.IngresarOpcion(codigoCont);
            string paisDestino = AgendaPaises.EstablecerPais(codigoPais);
            return paisDestino;
        }

        private static bool ServiciosSiNo(string tipoServicio)
        {
            if (tipoServicio == "urgente")
            {
                Console.WriteLine("Por favor determine si el servicio es o no Urgente");
                Console.WriteLine("1 - Urgente");
                Console.WriteLine("2 - No Urgente");
            }

            if (tipoServicio == "entrega")
            {
                Console.WriteLine("Por favor determine si se entrega Puerta o Sucursal");
                Console.WriteLine("1 - Puerta");
                Console.WriteLine("2 - Sucursal");
            }

            if (tipoServicio == "retiro")
            {
                Console.WriteLine("Por favor determine si el retiro es por Puerta o Sucursal");
                Console.WriteLine("1 - Puerta");
                Console.WriteLine("2 - Sucursal");
            }

            bool salir = false;
            do
            {
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        return true;

                    case "2":
                        return false;

                    default:
                        Console.WriteLine("No ha ingresado una opcion correcta");
                        break;
                }

            } while (!salir);

            return false;
        }

    }
}

