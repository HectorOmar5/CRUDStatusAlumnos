using CRUDEstatus.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class Program
    {
       static EstatusAlumno estatusAlumno = new EstatusAlumno();
        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                try
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("============MENU PRINCIPAL============");
                    Console.WriteLine("\t");
                    Console.WriteLine("\t***************************");
                    Console.WriteLine("\t1.- Consultar Todos");
                    Console.WriteLine("\t***************************");
                    Console.WriteLine("\t2.- Consultar Solo Uno");
                    Console.WriteLine("\t***************************");
                    Console.WriteLine("\t3.- Agregar");
                    Console.WriteLine("\t***************************");
                    Console.WriteLine("\t4.- Actualizar");
                    Console.WriteLine("\t***************************");
                    Console.WriteLine("\t5.- Eliminar");
                    Console.WriteLine("\t***************************");
                    Console.WriteLine("\t6.- Terminar");
                    Console.WriteLine("\t***************************");
                    Console.WriteLine("\nSeleccione Una Opción De La Lista");

                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":

                            //estatusAlumno.ObtenerTodos();
                            List<EstatusAlumnosEntity> listalu = estatusAlumno.ObtenerTodos();
                            foreach (EstatusAlumnosEntity ent in listalu)
                            {
                                Console.WriteLine($"id:{ent.id}\tNombre:{ent.nombre}\tClave:{ent.clave}");

                            }
                            break;

                        case "2":
                            Console.WriteLine("Ingrese El ID Del Alumno A Consultar");
                            int idEstatus = int.Parse(Console.ReadLine());
                            estatusAlumno.ConsultarUno(idEstatus);
                            EstatusAlumnosEntity estatusalumno = estatusAlumno.ConsultarUno(idEstatus);
                            Console.WriteLine($"id:{estatusalumno.id}\tNombre:{estatusalumno.nombre}\tClave:{estatusalumno.clave}");
                            break;
                        case "3":
                            Console.WriteLine("Ingrese El Nombre Del Estatus:");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese La Clave Del Estatus:");
                            string clave = Console.ReadLine();
                            estatusAlumno.Agregar(nombre, clave);
                            break;
                        case "4":
                            Console.WriteLine("Ingrese El ID A Actualizar: ");
                            int Estatusid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese El Nombre Del Estatus: ");
                            string nombreEstatus = Console.ReadLine();
                            Console.WriteLine("Ingrese La Clave Del Estatus: ");
                            string claveEstatus = Console.ReadLine();
                            estatusAlumno.Actualizar(Estatusid, nombreEstatus, claveEstatus);
                            break;
                        case "5":
                            Console.WriteLine("Ingrese El ID A Eliminar");
                            int id = int.Parse(Console.ReadLine());
                            estatusAlumno.Eliminar(id);
                            break;
                        case "6":
                            Console.WriteLine("¿Deseas Salir De La Consola? Presiona <ENTER>");
                            Console.WriteLine("\n");
                            salir = true;
                            break;

                    }
                    Console.ReadKey();

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            
        }
    }
}
