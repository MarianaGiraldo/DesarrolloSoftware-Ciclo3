using System;
using System.Collections.Generic;
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
            AddPacienteConSignos();
            ListarPacientesCorazon();
            //ListarPacientePorGenero(0);
            // AddPacienteConSignos();
            //AddSignosVitales(1);
            // AddPaciente();
            //BuscarPaciente(1);
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

        private static void AddPacienteConSignos()
        {
            var paciente = new Paciente{
                Nombre = "Carmensa",
                Apellidos = "Gomez",
                NumeroTelefono = "3016589764",
                Genero = Genero.Femenino,
                Direccion = "Calle 94 No 7-11",
                Longitud = 5.07062F,
                Latitud = 75.52290F,
                Ciudad = "Cali",
                FechaNacimiento = new DateTime(1984, 04, 12),
                SignosVitales = new List<SignoVital> {
                    new SignoVital{FechaHora = new DateTime (2021, 10, 06, 22, 05, 00), Valor = 36, Signo = TipoSigno.TemperaturaCorporal},
                    new SignoVital{FechaHora = new DateTime (2021, 10, 06, 22, 05, 00), Valor = 95, Signo = TipoSigno.SaturacionOxigeno},
                    new SignoVital{FechaHora = new DateTime (2021, 10, 06, 22, 05, 00), Valor = 95, Signo = TipoSigno.FrecuenciaCardica}
                }
            };
            _repoPaciente.AddPaciente(paciente);
        }

        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos);
        }

        private static void AsignarMedico()
        {
            var medico = _repoPaciente.AsignarMedico(1, 2);
            Console.WriteLine(medico.Nombre + " " + medico.Apellidos);
        }
        
        private static void AddSignosVitales(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            if (paciente != null)
            {
                if (paciente.SignosVitales != null)
                {
                    paciente.SignosVitales.Add(new SignoVital{FechaHora = new DateTime (2021, 10, 06, 10, 05, 00), Valor = 36, Signo = TipoSigno.TemperaturaCorporal});
                }else
                {
                    paciente.SignosVitales = new List<SignoVital> {
                        new SignoVital{FechaHora = new DateTime (2021, 10, 06, 22, 05, 00), Valor = 36, Signo = TipoSigno.TemperaturaCorporal}
                    };
                }
                _repoPaciente.UpdatePaciente(paciente);
            }
        }

        private static void ListarPacientePorGenero(int genero)
        {
            var pacientesG = _repoPaciente.GetPacientesporGenero(genero);
            foreach (Paciente p in pacientesG)
            {
                Console.WriteLine(p.Nombre + " " + p.Apellidos);
            }
        }

        private static void ListarPacientesCorazon()
        {
            var pacientesH = _repoPaciente.GetPacientesCorazon();
            foreach (Paciente p in pacientesH)
            {
                Console.WriteLine(p.Nombre + " " + p.Apellidos);
            }
        }
    }
}
