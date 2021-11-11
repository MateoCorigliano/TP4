using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCorporativos
{
    class AgendaUsuarios
    {
        private static readonly Dictionary<int, Usuarios> entradas;

        const string nombreArchivo = "usuarios.txt";

        //constructor:

        static AgendaUsuarios()
        {

            entradas = new Dictionary<int, Usuarios>();

            if (File.Exists(nombreArchivo))

            {
                using (var reader = new StreamReader(nombreArchivo))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var usuarios = new Usuarios(linea);
                        entradas.Add(usuarios.Dni, usuarios);
                    }

                }

            }

        }

        



        public static Usuarios Seleccionar()
        {
            var modelo = Usuarios.CrearModeloBusqueda();

            foreach (var usuarios in entradas.Values)
            {
                if (usuarios.CoincideCon(modelo))
                {
                    return usuarios;
                }
            }
            Console.WriteLine("No se ha encontrado el usuario ingresado");
            return null;
        }

        
      
    }
}
