using Bol3Ej3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bol1Ej1234
{
    internal class Empleado : Persona
    {
        private double salario;
        public double Salario
        {
            get { return salario; }
            set
            {
                if (value < 600)
                {
                    irpf = 7;
                }
                if (value >= 600 && value <= 3000)
                {
                    irpf = 15;
                }
                if (value > 3000)
                {
                    irpf = 20;
                }
                salario = value;
            }
        }
        private int irpf;
        public int Irpf
        {
            get { return irpf; }
        }

        private string telefono;
        public string Telefono
        {
            get { return "+34 " + telefono; }
            set { telefono = value; }
        }

        public override void mostrar()
        {
            base.mostrar();
            Console.WriteLine("Salario:");
            Console.WriteLine(Salario + "€");
            Console.WriteLine("Irpf:");
            Console.WriteLine(Irpf);
            Console.WriteLine("Telefono:");
            Console.WriteLine(Telefono);
        }

        public void mostrar(int num)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine(base.Nombre);
                    break;
                case 1:
                    Console.WriteLine(base.Apellidos);
                    break;
                case 2:
                    Console.WriteLine(base.Edad);
                    break;
                case 3:
                    Console.WriteLine(base.Dni);
                    break;
                case 4:
                    Console.WriteLine(Salario);
                    break;
                case 5:
                    Console.WriteLine(Irpf);
                    break;
                case 6:
                    Console.WriteLine(Telefono);
                    break;
                default:
                    break;
            }
        }

        public override double hacienda()
        {
            return (Irpf * Salario) / 100;
        }

        public Empleado(string nombre, string apellidos, int edad, string dni, double salario, string telefono)
            : base(nombre, apellidos, edad, dni)
        {
            this.salario = salario;
            this.telefono = telefono;
            this.irpf = 2;
        }

        public Empleado()
            : this(null, null, 0, null, 0, null)
        {
        }
    }

    class BinWriterEmpleado : BinaryWriter
    {
        public BinWriterEmpleado(Stream str) : base(str)
        {

        }

        public void Write(Empleado empleado)
        {
            base.Write(empleado.Nombre);
            base.Write(empleado.Apellidos);
            base.Write(empleado.Dni);
            base.Write(empleado.Edad);
            base.Write(empleado.Salario);
            base.Write(empleado.Telefono);
        }
    }

    class BinReaderEmpleado : BinaryReader
    {
        public BinReaderEmpleado(Stream str) : base(str)
        {
        }

        public Empleado ReadEmpleado()
        {
            Empleado empleado = new Empleado();

            empleado.Nombre = base.ReadString();
            empleado.Apellidos = base.ReadString();
            empleado.Dni = base.ReadString();
            empleado.Edad = base.ReadInt32();
            empleado.Salario = base.ReadDouble();
            empleado.Telefono = base.ReadString();

            return empleado;
        }
    }
}
