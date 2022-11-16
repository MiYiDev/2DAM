using Bol1Ej1234;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol3Ej3
{
    internal class InterfazUsuario
    {

        GestorPersonas gestorPersonas = new GestorPersonas();
        public int option(int limMenos, int limMas)
        {
            bool flag = true;
            int opcion = 0;
            do
            {
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion < limMenos || opcion > limMas)
                    {
                        throw new FormatException();
                    }
                    flag = true;
                }
                catch (Exception e) when (e is FormatException || e is OverflowException)
                {
                    Console.WriteLine("Opcion no valida, introduzca de nuevo");
                    flag = false;
                }
            } while (!flag);
            return opcion;
        }

        public void menu()
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("1.- Insertar nueva persona\n2.- Eliminar personas\n3.- Visualizar todas las personas\n4.- Visualizar una sola persona\n5.- Salir");
                opcion = option(1, 5);
                Console.WriteLine("");
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("1.- Añadir Empleado\n2.- Añadir Directivo");
                        int opcionPersona = option(1, 2);
                        int indice;
                        if (opcionPersona == 1)
                        {
                            Console.WriteLine("Dame el nombre del Empleado");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Dame el apellido del Empleado");
                            string apellido = Console.ReadLine();
                            Console.WriteLine("Dame la edad del Empleado");
                            int edad = option(0, 200);
                            Console.WriteLine("Dame el dni del Empleado");
                            string dni = Console.ReadLine();
                            Console.WriteLine("Dame el salario del Empleado");
                            int salario = option(0, 999999999);
                            Console.WriteLine("Dame el telefono del Empleado");
                            string telefono = Console.ReadLine();
                            Empleado empleado = new Empleado(nombre, apellido, edad, dni, salario, telefono);

                            if(gestorPersonas.coleccion.Count != 0)
                            {
                                indice = gestorPersonas.Posicion(edad);
                                gestorPersonas.coleccion.Insert(indice, empleado);
                            } else
                            {
                                gestorPersonas.coleccion.Add(empleado);
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Dame el nombre del Directivo");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Dame el apellido del Directivo");
                            string apellido = Console.ReadLine();
                            Console.WriteLine("Dame la edad del Directivo");
                            int edad = option(0, 200);
                            Console.WriteLine("Dame el dni del Directivo");
                            string dni = Console.ReadLine();
                            Console.WriteLine("Dame el departamento del Directivo");
                            string departamento = Console.ReadLine();
                            Console.WriteLine("Dame cuantas personas tiene a cargo el Directivo");
                            int personasCargo = option(0, 999999);
                            Console.WriteLine("Dame el beneficio que gana el Directivo");
                            int beneficio = option(0, 999999);
                            Directivo directivo = new Directivo(nombre, apellido, edad, dni, departamento, personasCargo, 0, beneficio);
                            
                            if (gestorPersonas.coleccion.Count != 0)
                            {
                                indice = gestorPersonas.Posicion(edad);
                                gestorPersonas.coleccion.Insert(indice, directivo);
                            }
                            else
                            {
                                gestorPersonas.coleccion.Add(directivo);
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Desde cual quieres borrar?");
                        int primero = option(0, gestorPersonas.coleccion.Count);
                        Console.WriteLine("Hasta cual quieres borrar?");
                        int total = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Estas seguro?");
                        Console.WriteLine("");
                        Console.WriteLine("\t1.- Si\n\t2.- No");
                        int confirmacion = option(1, 2);
                        if (confirmacion == 1)
                        {

                            if (gestorPersonas.Eliminar(total, primero))
                            {
                                Console.WriteLine("Persona eliminada correctamente");
                            }
                            else
                            {
                                Console.WriteLine("Error al eliminar la persona.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cancelando...");
                        }
                        break;
                    case 3:
                        Console.WriteLine("|{4,3}|{3,2}|{0,10}|{1,19}|{2,3}|", "Nombre", "Apellidos", "Edad", "E/D", "I");
                        Console.WriteLine("|===========================================|");
                        for (int i = 0; i < gestorPersonas.coleccion.Count; i++)
                        {
                            Persona persona = gestorPersonas.coleccion[i];
                            Console.WriteLine("|{4,3}|{3,2}|{0,10}|{1,20}|{2,4}|", persona.Nombre.Length >= 9 ? persona.Nombre.Substring(0, 7) + "..." : persona.Nombre, persona.Apellidos.Length >= 19 ? persona.Apellidos.Substring(0, 17) + "..." : persona.Apellidos, persona.Edad, persona.GetType() == typeof(Empleado) ? "E" : "D", i);
                            Console.WriteLine("|-------------------------------------------|");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Dame el apellido de la persona");
                        string apellido2 = Console.ReadLine();
                        for (int i = 0; i < gestorPersonas.coleccion.Count; i++)
                        {
                            Persona persona = gestorPersonas.coleccion[i];
                            if (persona.Apellidos.ToLower().StartsWith(apellido2.ToLower()))
                            {
                                Console.WriteLine("|{3,2}|{0,10}|{1,19}|{2,3}|", "Nombre", "Apellidos", "Edad", "E/D");
                                Console.WriteLine("|=======================================|");
                                Console.WriteLine("|{3,2}|{0,10}|{1,20}|{2,4}|", persona.Nombre.Length >= 9 ? persona.Nombre.Substring(0, 7) + "..." : persona.Nombre, persona.Apellidos.Length >= 19 ? persona.Apellidos.Substring(0, 17) + "..." : persona.Apellidos, persona.Edad, persona.GetType() == typeof(Empleado) ? "E" : "D");
                                Console.WriteLine("|---------------------------------------|");
                                persona.mostrar();
                                if (gestorPersonas.coleccion[i].GetType() == typeof(Directivo))
                                {
                                    Directivo directivo = (Directivo)persona;
                                    directivo.ganarPasta(100);
                                    Console.WriteLine("Pasta ganada 100");
                                }
                            }
                        }

                        break;
                    case 5:
                        Console.WriteLine("Hasta la próxima :)");
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            } while (opcion != 5);
        }

    }
}
