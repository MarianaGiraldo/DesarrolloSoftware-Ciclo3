using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        public static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Entity Framework!");
            // AddPaciente();
            BuscarPaciente(1);
        }

        private static void AddPaciente()
        {
            var paciente = new Paciente{
                Nombre = "Nicolas",
                Apellidos = "Perez",
                NumeroTelefono = "3008317847",
                Genero = Genero.Masculino,
                Direccion = "Calle 4 No 7-11",
                Longitud = 5.07062F,
                Latitud = 75.52290F,
                Ciudad = "Manizales",
                FechaNacimiento = new DateTime(1990, 04, 12)
            };
            _repoPaciente.AddPaciente(paciente);
        }

        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos);
        }
    }
}
