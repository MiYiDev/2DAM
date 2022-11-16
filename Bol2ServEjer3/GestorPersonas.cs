using Bol1Ej1234;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bol3Ej3
{
    internal class GestorPersonas
    {
        public List<Persona> coleccion = new List<Persona>();


        public GestorPersonas()
        {
            Empleado empleado1 = new Empleado("Curro", "Bellas", 12, "46131233t", 2000, "151355836");
            coleccion.Add(empleado1);
            Directivo directivo = new Directivo();
            coleccion.Add(directivo);
        }

        public int Posicion(int edad)
        {
            int indice = 0;
            if (coleccion.Count != 0)
            {

                for (int i = 0; i < coleccion.Count; i++)
                {
                    if (coleccion[i].Edad < edad)
                    {
                        indice = i;
                    }
                }
            }

            return indice + 1;
        }


        public int Posicion(string apellido)
        {
            foreach (Persona item in coleccion)
            {
                if (apellido == item.Apellidos)
                {
                    return coleccion.IndexOf(item);
                }
            }
            return -1;
        }

        public bool Eliminar(int max, int min = 0)
        {

            if (min < 0 || max > coleccion.Count)
            {
                return false;
            }
            else
            {
                if (coleccion.Count == 0)
                {
                    return false;
                }
                else
                {

                    for (int i = min; i < max; i++)
                    {
                        coleccion.RemoveAt(min);
                    }
                    return true;
                }
            }
        }



    }
}
