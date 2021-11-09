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
       public Persona()
       {

       }

        public Persona(string linea)
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
            Fecha = DateTime.Parse(datos[8]);

        }
            //fin constructores

            public string ObtenerLineaDatos()
            {
                return $"{Trackeo} ; {Estado} ; {Origen} ; {Destino}";
            }



            public static Persona IngresarNueva()
            {
                var persona = new Persona();

                Console.WriteLine("Nueva Persona");


                persona.Dni = IngresarDni();
                persona.Apellido = Ingreso("Ingrese el apellido");
                persona.Nombre = Ingreso("Ingrese el nombre");
                persona.FechaNacimiento = IngresarFecha("Ingrese fecha nacimiento");

                return persona;
            }

            public void Modificar()
            {
                Console.WriteLine($"Apellido {Apellido} - S para modificar, otra tecla para continuar");
                var tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.S)
                {
                    Apellido = Ingreso("Ingrese el nuevo apellido");
                }

                Console.WriteLine($"Nombre {Nombre} - S para modificar, otra tecla para continuar");
                tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.S)
                {
                    Nombre = Ingreso("Ingrese el nuevo nombre");
                }

                Console.WriteLine($"Fecha Nacimiento {FechaNacimiento} - S para modificar, otra tecla para continuar");
                tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.S)
                {
                    FechaNacimiento = IngresarFecha("Ingrese la nueva fecha");
                }

                Agenda.Grabar();


            }

            public void Mostrar()
            {
                Console.WriteLine($"DNI: {Dni}");
                Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}");
                Console.WriteLine($"Fecha Nacimietno: {FechaNacimiento:dd/MM/yyyy}");

            }

            public static Persona CrearModeloBusqueda()
            {
                var modelo = new Persona();

                modelo.Dni = IngresarDni(obligatorio: false);
                modelo.Apellido = Ingreso("Ingrese el apellido", obligatorio: false);
                modelo.Nombre = Ingreso("Ingrese el nombre", obligatorio: false);
                modelo.FechaNacimiento = IngresarFecha("Ingrese la fecha", obligatorio: false);

                return modelo;


            }

            public bool CoincideCon(Persona modelo)
            {
                if (modelo.Dni != 0 && Dni != modelo.Dni)
                {
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(modelo.Apellido) && !Apellido.Equals(modelo.Apellido, StringComparison.CurrentCultureIgnoreCase))
                {
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(modelo.Nombre) && !Nombre.Equals(modelo.Nombre, StringComparison.CurrentCultureIgnoreCase))
                {
                    return false;
                }

                if (modelo.FechaNacimiento != DateTime.MinValue && FechaNacimiento != modelo.FechaNacimiento)
                {
                    return false;
                }

                return true;
            }

            private static int IngresarDni(bool obligatorio = true)
            {
                var titulo = "Ingrese dni(entero de 8 cifras)";
                if (!obligatorio)
                {
                    titulo += "o presione [Enter] para continuar";
                }
                Console.WriteLine(titulo);

                do
                {
                    var ingreso = Console.ReadLine();

                    if (!obligatorio && string.IsNullOrEmpty(ingreso))
                    {
                        return 0;
                    }

                    if (!Int32.TryParse(ingreso, out var dni))
                    {
                        Console.WriteLine("El dato ingresado es incorrecto, ingrese nuevamente");
                        continue;
                    }

                    if (dni < 10000000 || dni > 99999999)
                    {
                        Console.WriteLine("El dato ingresado no tiene 8 cifras, ingrese nuevamente");
                        continue;
                    }

                    if (Agenda.Existe(dni) && obligatorio == true)
                    {
                        Console.WriteLine("El dni ya existe actualmente");
                        continue;
                    }

                    return dni;

                } while (true);
            }

            private static string Ingreso(string titulo, bool permiteNumeros = false, bool obligatorio = true)
            {
                string ingreso;
                do
                {

                    Console.WriteLine(titulo);
                    if (!obligatorio)
                    {
                        titulo += "o presione [Enter] para continuar";
                    }

                    ingreso = Console.ReadLine();

                    if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                    {
                        return null;
                    }

                    if (string.IsNullOrWhiteSpace(ingreso))
                    {
                        Console.WriteLine("Debe ingresar un valor");
                        continue;
                    }

                    if (!permiteNumeros && ingreso.Any(Char.IsDigit))
                    {
                        Console.WriteLine("el valor ingresado no debe contener numeros");
                        continue;
                    }

                    //break;
                    return ingreso;
                } while (true);

                //return ingreso;

            }
            // este metodo se realizo para no tener que repetir por ejemplo lo siguiente en el nombre y el apellido
            /*
            Console.WriteLine("Ingrese el nombre");
                do
                {
                    var ingreso = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ingreso))
                    {
                        Console.WriteLine("Debe ingresar un nombre");
                        break;
                    }

                    if (ingreso.Any(Char.IsDigit))
                    {
                        Console.WriteLine("el nombre no debe contener digitos");
                        break;
                    }

                        persona.Nombre = ingreso;

                } while (string.IsNullOrWhiteSpace(persona.Apellido));
                */

            private static DateTime IngresarFecha(string titulo, bool obligatorio = true)
            {
                do
                {
                    if (!obligatorio)
                    {
                        titulo += "o presione [Enter] para continuar";
                    }

                    Console.WriteLine(titulo);
                    var ingreso = Console.ReadLine();

                    if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                    {
                        return DateTime.MinValue;
                    }

                    if (!DateTime.TryParse(ingreso, out var fechaNacimiento))
                    {
                        Console.WriteLine("No es una fecha valida");
                        continue;
                    }

                    if (fechaNacimiento > DateTime.Now)
                    {
                        Console.WriteLine("La fecha debe ser menor a hoy");
                        continue;
                    }

                    return fechaNacimiento;

                } while (true);
            }
        }
    }

