using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_De_Progra2
{
    internal class clsMenu
    {
        private List<ClsEmpleados> empleados = new List<ClsEmpleados>();

        // Menu principal

        public void MostrarMenu()
        {
            Console.WriteLine("***** Bienvenido al Sistema de Recursos Humanos *****\n ");
            Console.WriteLine("Seleccione la opcion necesaria\n");
            Console.WriteLine("1. Agregar Nuevo Empleado");
            Console.WriteLine("2. Consultar Empleado");
            Console.WriteLine("3. Modificar Empleado");
            Console.WriteLine("4. Borrar Empleado");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Salir");
            Console.WriteLine("");
        }

        public void AgregarEmpleadoNuevo()
        {
            // agregar un nuevo empleado
            Console.WriteLine("Ingrese los datos del empleado\n");
            Console.Write("Cedula: ");
            string cedula = Console.ReadLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Direccion: ");
            string direccion = Console.ReadLine();
            Console.Write("Telefono: ");
            string telefono = Console.ReadLine();
            Console.Write("Salario: ");
            Console.Write("");
            double salario = Convert.ToDouble(Console.ReadLine());

            ClsEmpleados empleado = new ClsEmpleados(cedula, nombre, direccion, telefono, salario);
            empleados.Add(empleado);
            Console.WriteLine("\nEl empleado que agrego se agrego correctamente\n");

        }

        public void ConsultarEmpleado()
        {
            // Metodo para consultar empleados
            Console.WriteLine("**** Empleados consultados ****");
            foreach (var empleado in empleados)
            {
                Console.WriteLine($"Cedula: {empleado.Cedula}| Nombre: {empleado.Nombre}| Direccion: {empleado.Direccion}| Telefono: {empleado.Telefono}| Salario: {empleado.Salario}");
            }
        }

        public void ModificarEmpleado()
        {
            //Metodo para modificar un empleado
            Console.WriteLine("Ingrese el numero de cedula que desea modificar: ");
            string cedula = Console.ReadLine();
            ClsEmpleados empleado = empleados.Find(e => e.Cedula == cedula);

            if (empleado != null)
            {
                Console.WriteLine("Ingrese los datos nuevos del empleado");
                Console.WriteLine("Cual es el Nombre: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Cual es su Direccion: ");
                string direccion = Console.ReadLine();
                Console.WriteLine("Cual es su Telefono: ");
                string telefono = Console.ReadLine();
                Console.WriteLine("De cuanto es su Salario: ");
                double salario = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("El empleado se ha modificado con exito");
            }
            else
            {
                Console.WriteLine("El empleado que usted consultó no se ha encontrado");
            }
        }

        public void BorrarEmpleado()
        {
            // Metodo para borar un empelado
            Console.WriteLine("Ingrese el numero de cedula del empleado que desea borrar: ");
            string cedula = Console.ReadLine();
            ClsEmpleados empleado = empleados.Find(e => e.Cedula == cedula);

            if (empleado != null)
            {
                empleados.Remove(empleado);
                Console.WriteLine("\nEl empleado se ha Eliminado Correctamente\n");
            }
            else
            {
                Console.WriteLine("El empleado no se ha encontrado");
            }
        }

        public void InicializarArreglos()
        {
            // Metodo para inicializar arreglos
            empleados.Clear();
            Console.WriteLine("Arreglos Inicializados");
        }

        public void Reportes()
        {
            // Metodo para los reportes
            int opcion;

            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("***** Reportes de empleados *****\n");
                Console.WriteLine("1. Consultar empleados por Numero de Cedula");
                Console.WriteLine("2. Lista de empleados Ordenados por nombre");
                Console.WriteLine("3. Calcular y mostrar el promedio de salarios");
                Console.WriteLine("4. Calcular y mostrar el salario mas alto y el mas bajo");
                Console.WriteLine("5. Regresar el menu Principal");
                Console.WriteLine("*** Selecciona una opción correcta ***\n");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ConsultarEmpleadosPorCedula();
                        break;

                    case 2:
                        ListaEmpleadosOrdenadosPorNombre();
                        break;

                    case 3:
                        CalcularPromedioDeSalario();
                        break;

                    case 4:
                        CalcularSalarioMasAltoYMasBajo();
                        break;

                    case 5:
                        break;

                    default:
                        Console.WriteLine("La opcion que usted seleccionó es Invalida");
                        break;
                }

            } while (opcion != 5);
        }

        private void ConsultarEmpleadosPorCedula()
        {
            // Metodo privado para consultar empleado cedula

            Console.WriteLine("Ingrese el numero de cedula que desea consultar: ");
            string cedula = Console.ReadLine();
            ClsEmpleados empleado = empleados.Find(e => e.Cedula == cedula);

            if (empleado != null)
            {
                Console.WriteLine($"Cedula: {empleado.Cedula}, Nombre: {empleado.Nombre}, Direccion: {empleado.Direccion}. Telefono: {empleado.Telefono}, Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("El empleado que consultó no se ha encontrado");
            }
        }

        private void ListaEmpleadosOrdenadosPorNombre()
        {
            List<ClsEmpleados> empleadosOrdenados = empleados.OrderBy(e => e.Cedula).ToList();
            Console.WriteLine("***** Empleados ******");
            foreach (var empleado in empleadosOrdenados)
            {
                Console.WriteLine($"Cedula: {empleado.Cedula}, Nombre: {empleado.Nombre}, Direccion: {empleado.Direccion}. Telefono: {empleado.Telefono}, Salario: {empleado.Salario}");
            }
        }

        private void CalcularPromedioDeSalario()
        {
            // Metodo para calcular el promedio de salario 

            if (empleados.Count > 0)
            {
                double promedio = empleados.Average(e => e.Salario);
                Console.WriteLine($"El promedio de los Salarios es: {promedio}");
            }
            else
            {
                Console.WriteLine("No hay empleados registrados");
            }

        }

        private void CalcularSalarioMasAltoYMasBajo()
        {
            // mostrar el salario mas alto y el mas bajo
            if (empleados.Count > 0)
            {
                double salarioMasAlto = empleados.Max(e => e.Salario);
                double salarioMasBajo = empleados.Min(e => e.Salario);
                Console.WriteLine($"El salario mas alto es: {salarioMasAlto}");
                Console.WriteLine($"El Salario mas Bajo es: {salarioMasBajo}");
            }
            else
            {
                Console.WriteLine("No hay empleados registrados");
            }
        }
    }
}