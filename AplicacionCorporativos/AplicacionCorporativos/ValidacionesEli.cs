using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCorporativos
{
    class ValidacionesEli
    {
        /*
         private bool ValidarDatos(string dni, string nom, string ape, string fecnac)
        {
            bool flag = true;
            string msj = "";

            msj += ValidarVacio(dni, "DNI");
            msj += ValidarNumero(dni, "DNI");
            if (string.IsNullOrEmpty(msj)) // Si el msj anterior es nulo, valido que no se repita
            {
                msj += ValidarRepeticion(Convert.ToInt32(dni));
            }
            msj += ValidarVacio(nom, "Nombre");
            msj += ValidarMax30(nom, "Nombre");
            msj += ValidarVacio(ape, "Apellido");
            msj += ValidarMax30(nom, "Apellido");
            msj += ValidarVacio(fecnac, "Fecha de Nacimiento");
            msj += ValidarFecha(fecnac, "Fecha de Nacimiento");
            if (!string.IsNullOrEmpty(msj)) // aca pregunto si se acumularon errores
            {
                flag = false;
                Console.WriteLine(msj, "Error en datos.");
            }

            return flag;
        }

        private string ValidarNumero(string valor, string campo)
        {
            string msj;

            if (!int.TryParse(valor, out int salida)) // valido si puedo convertir a int el numero ingresado
            {
                msj = "El campo " + campo + " no es numerico." + System.Environment.NewLine;
            }
            else if (salida <= 0)
            {
                msj = "El campo " + campo + " debe ser positivo." + System.Environment.NewLine;
            }
            else if (valor.Count() != 8)
            {
                msj = "El campo " + campo + " debe tener entre 7 y 8 digitos." + System.Environment.NewLine;
            }
            else // si no hay error, devuelvo un vacio
            {
                msj = "";
            }

            return msj;
        }

        // VALIDAR VACIO
        private string ValidarVacio(string valor, string campo)
        {
            string msj;

            if (string.IsNullOrEmpty(valor))
            {
                msj = "El campo " + campo + " es requerido." + System.Environment.NewLine;
            }
            else
            {
                msj = "";
            }

            return msj;

        }

        // VALIDAR Maximo
        private string ValidarMax30(string valor, string campo)
        {
            string msj;
            
            if (!(valor.Length <= 30))
            {
                msj = "El campo " + campo + " no debe tener mas de 30 caracteres." + System.Environment.NewLine;
            }
            else // si no hay error, devuelvo un vacio
            {
                msj = "";
            }

            return msj;
        }

        // Validar que no se repita
        private string ValidarRepeticion(int dni)
        {
            string msj = "";

            Personas A = BuscarPersona(dni);

            if (A != null)
            {
                msj = "La persona ya se encuentra registrada. " + System.Environment.NewLine;
            }

            return msj;

        }

        private string ValidarFecha(string valor, string campo)
        {
            string msj;

            if (!DateTime.TryParse(valor, out DateTime salida)) // valido si puedo convertir a int el numero ingresado
            {
                msj = "El campo " + campo + " debe tener el formato DD/MM/AAA." + System.Environment.NewLine;
            }
            else if (salida >= DateTime.Now)
            {
                msj = "El campo " + campo + " debe ser una fecha mas antigua a la actual." + System.Environment.NewLine;
            }
            else // si no hay error, devuelvo un vacio
            {
                msj = "";
            }
            return msj;
        } 
         
         */
    }
}
