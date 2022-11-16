using Bol3Ej3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bol1Ej1234
{
    internal class Directivo : Persona
    {
        public string Departamento { set; get; }
        private double beneficio;
        public double Beneficio
        {
            get { return beneficio; }
        }
        private int personasCargo;
        public int PersonasCargo
        {
            get { return personasCargo; }
            set
            {
                if (value <= 10)
                {
                    beneficio = 2.0;
                }
                if (value > 10 && value < 50)
                {
                    beneficio = 3.5;
                }
                if (value >= 50)
                {
                    beneficio = 4.0;
                }
                personasCargo = value;
            }
        }
        private double PastaGanada;
        public static Directivo operator --(Directivo directivo)
        {
            if (directivo.beneficio > 0)
            {
                directivo.beneficio -= 1;
            }
            return directivo;
        }

        public override void mostrar()
        {
            base.mostrar();
            Console.WriteLine("Nombre del departamento:");
            Console.WriteLine(Departamento);
            Console.WriteLine("Beneficios:");
            Console.WriteLine(Beneficio + "€");
            Console.WriteLine("Personas a cargo:");
            Console.WriteLine(PersonasCargo);
        }
        public override void escribir()
        {
            base.escribir();
            Console.WriteLine("Nombre del departamento:");
            this.Departamento = Console.ReadLine();
            Console.WriteLine("Beneficios:");
            this.beneficio = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Personas a cargo:");
            this.personasCargo = Convert.ToInt32(Console.ReadLine());
        }

        public override double hacienda()
        {
            return 0.3 * PastaGanada;
        }

        public double ganarPasta(double beneficiosEmpresa)
        {
            if (beneficiosEmpresa <= 0)
            {
                Directivo directivoAux = this;
                directivoAux--;
                PastaGanada = 0;
                return 0;
            }
            else
            {
                PastaGanada = (beneficiosEmpresa * (beneficio / 100));
                return PastaGanada;
            }
        }

        public Directivo(string nombre, string apellidos, int edad, string dni, string departamento, int personasCargo, int pastaGanada, int beneficio)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
            this.Dni = dni;
            this.Departamento = departamento;
            this.personasCargo = personasCargo;
            this.PastaGanada = pastaGanada;
            this.beneficio = beneficio;
        }   

        public Directivo()
        {
            this.Nombre = "Jimmy";
            this.Apellidos = "Fernández";
            this.Edad = 19;
            this.Dni = "21116255R";
            this.Departamento = "DAM";
            this.personasCargo = 20;
            this.PastaGanada = 3000;
            this.beneficio = 2;
        }
    }

    class BinWriterDirectivo : BinaryWriter
    {
        public BinWriterDirectivo(Stream str) : base(str)
        {

        }

        public void Write(Directivo directivo)
        {
            base.Write(directivo.Nombre);
            base.Write(directivo.Apellidos);
            base.Write(directivo.Dni);
            base.Write(directivo.Edad);
            base.Write(directivo.PersonasCargo);
        }
    }

    class BinReaderDirectivo : BinaryReader
    {
        public BinReaderDirectivo(Stream str) : base(str)
        {
        }

        public Directivo ReadDirectivo()
        {
            Directivo directivo = new Directivo();

            directivo.Nombre = base.ReadString();
            directivo.Apellidos = base.ReadString();
            directivo.Dni = base.ReadString();
            directivo.Edad = base.ReadInt32();
            directivo.PersonasCargo = base.ReadInt32();

            return directivo;
        }
    }
}
