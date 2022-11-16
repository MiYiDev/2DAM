using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol1Ej1234
{
    internal abstract class Persona
    {

        public string Nombre { get; set; }


        public string Apellidos { get; set; }

        private int edad;
        public int Edad
        {
            get { return edad; }
            set
            {
                if (value < 0)
                {
                    edad = 0;
                }
                else
                {
                    edad = value;
                }
            }
        }

        private string dni;
        public string Dni
        {
            get
            {
                string[] d = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
                string letra = "";
                try
                {

                    letra = d[(Convert.ToInt32(dni) % 23) - 1];
                }
                catch (Exception)
                {

                }
                return dni + letra;
            }
            set
            {
                dni = value.Remove(value.Length - 1);
            }
        }

        public Persona(string nombre, string apellidos, int edad, string dni)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
            this.dni = dni;
        }

        public Persona()
            : this("", "", 0, "")
        {
        }

        public virtual void mostrar()
        {
            Console.WriteLine("Nombre:");
            Console.WriteLine(Nombre);
            Console.WriteLine("Apellidos:");
            Console.WriteLine(Apellidos);
            Console.WriteLine("Edad:");
            Console.WriteLine(edad);
            Console.WriteLine("Dni:");
            Console.WriteLine(dni);
        }

        public virtual void escribir()
        {
            this.Nombre = Console.ReadLine();
            this.Apellidos = Console.ReadLine();
            this.Edad = Convert.ToInt32(Console.ReadLine());
            this.Dni = Console.ReadLine();
        }

        public abstract double hacienda();
    }
}
