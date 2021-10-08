using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        /// <summary>
        ///Referencia al contexto del Paciente
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        ///Modelo constructor utiliza
        /// Inyección de dependencia para indicar el contexto a utilizat
        /// </summary>
        ///<param name="appContext"></param>//
        public RepositorioPaciente(AppContext appContext)
        {
            _appContext = appContext;
        }

        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;
        }

        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            if(pacienteEncontrado != null)
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.Familiar = paciente.Familiar;
                pacienteEncontrado.Enfermera = paciente.Enfermera;
                pacienteEncontrado.Medico = paciente.Medico;
                pacienteEncontrado.Historia = paciente.Historia;
                pacienteEncontrado.SignosVitales = paciente.SignosVitales;
                _appContext.SaveChanges();
            }
            return pacienteEncontrado;
        }

        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if(pacienteEncontrado == null)
                return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();
        }

        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
        {
            return _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
        }

        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return _appContext.Pacientes;
        }

        Medico IRepositorioPaciente.AsignarMedico(int idPaciente, int idMedico)
        { 
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            { 
                var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
                if (medicoEncontrado != null)
                { pacienteEncontrado.Medico = medicoEncontrado;
                _appContext.SaveChanges();
                }
            return medicoEncontrado;
        }
        return null;
        }

        IEnumerable<Paciente> IRepositorioPaciente.GetPacientesporGenero(int generoFiltro)
        {
            Genero genero = generoFiltro == 0 ? Genero.Masculino : Genero.Femenino;
            return _appContext.Pacientes.Where(p => p.Genero == genero).ToList();
        }

        IEnumerable<Paciente> IRepositorioPaciente.GetPacientesCorazon()
        {
            return _appContext.Pacientes
                                .Where(p => p.SignosVitales.Any(s => TipoSigno.FrecuenciaCardica == s.Signo && s.Valor >=90) )
                                .ToList();
        }
    }
}