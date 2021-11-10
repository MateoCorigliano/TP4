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
        public string Origen { get; set; }
        public string Destino { get; set; }
        //Para hacer: Propiedad Calculada
        public decimal Costo { get; set; }
        public bool Urgente { get; set; }
        public bool EntregaSucursal { get; set; }
        public bool RetiroSucursal { get; set; }
        public decimal Peso { get; set; }
        //propiedad calculada
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
            Origen = datos[2];
            Destino = datos[3];
            Costo = decimal.Parse(datos[4]);
            Urgente = bool.Parse(datos[5]);
            EntregaSucursal = bool.Parse(datos[6]);
            RetiroSucursal = bool.Parse(datos[7]);
            Peso = decimal.Parse(datos[8]);
            Fecha = DateTime.Parse(datos[9]);

        }
        //fin constructores

        public string ObtenerLineaDatos()
        {
            return $"{Trackeo} ; {Estado} ; {Origen} ; {Destino} ; {Costo} ; {Urgente} ; {EntregaSucursal} ; {RetiroSucursal} ; {Peso} ; {Fecha}";
        }

        public void GenerarTrackeo()
        {
            throw new NotImplementedException();
        }



        public static Servicio IngresarNuevo()
        {
            var servicio = new Servicio();

            //servicio.Trackeo = GenerarTrackeo();
            //servicio.Estado = Ingreso("Ingrese el apellido");
            servicio.Origen = IngresoTexto("Ingrese el origen de pedido");
            servicio.Destino = IngresoTexto("Ingrese el destino de pedido");
            servicio.Peso = IngresarDecimal("Ingrese el peso");
            //servicio.Urgente = MetodoDefinir();
            //servicio.EntregaSucursal = MetodoDefinir();
            //servicio.RetiroSucursal = MetodoDefinir();
            servicio.Fecha = DateTime.Now;

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

                //break;
                return ingreso;
            } while (true);

           

        }
        

    }
}

