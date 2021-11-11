using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCorporativos
{
    class Usuarios
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public int ClienteAsociado { get; set; }


        public Usuarios(string linea)
        {

            var datos = linea.Split(';');
            Dni = int.Parse(datos[0]);
            Nombre = datos[1];
            ClienteAsociado = int.Parse(datos[2]);
        }

        public Usuarios()
        {
        }

        public bool CoincideCon(Usuarios modelo)
        {
            if (modelo.Dni != 0 && Dni != modelo.Dni)
            {
                return false;
            }



            return true;
        }

        public static Usuarios CrearModeloBusqueda()
        {
            var modelo = new Usuarios();


            modelo.Dni = IngresarEntero("Por favor ingresar el numero de dni autorizado para continuar");


            return modelo;
        }

        private static int IngresarEntero(string titulo)
        {
            //REVISAR
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

    }
}
