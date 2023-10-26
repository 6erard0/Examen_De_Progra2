using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Estudiante: Gerardo Navarro Ugarte.
//Examen de programación II

namespace Examen_De_Progra2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            clsMenu menu = new clsMenu();
            int opcion;

            do
            {
                menu.MostrarMenu();
                Console.Write("Selecciona una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        menu.AgregarEmpleadoNuevo();
                        break;

                    case 2:
                        menu.ConsultarEmpleado();
                        break;

                    case 3:
                        menu.ModificarEmpleado();
                        break;

                    case 4:
                        menu.BorrarEmpleado();
                        break;

                    case 5:
                        menu.InicializarArreglos();
                        break;

                    case 6:
                        menu.Reportes();
                        break;

                    case 7:
                        Console.WriteLine("Gracias por la consulta");
                        break;
                    default:
                        Console.WriteLine("La ópcion que usted seleccionó es Invalida");
                        break;
                }
            } while (opcion != 7);
        }
    }
}