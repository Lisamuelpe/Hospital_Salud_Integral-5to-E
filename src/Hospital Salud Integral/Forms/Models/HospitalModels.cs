using System;

namespace Forms.Models
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
    }

    public class Especialidad
    {
        public int IdEspecialidad { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string NombreDepartamento { get; set; }
    }

    public class Servicio
    {
        public int IdServicio { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public string NombreDepartamento { get; set; }
    }

    public class Medico
    {
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Licencia { get; set; }
        public string Telefono { get; set; }
        public string NombreEspecialidad { get; set; }

        public string NombreCompleto => $"Dr(a). {Nombre} {Apellido}";
    }

    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";
        public int Edad
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
    }

    public class Cita
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; } // 'Programada', 'Confirmada', 'Atendida', 'Cancelada', 'No asistió'
        public string MotivoCancelacion { get; set; }

        // Auxiliares
        public string NombrePaciente { get; set; }
        public string DocumentoPaciente { get; set; }
        public string NombreMedico { get; set; }
        public string NombreServicio { get; set; }
        public decimal CostoServicio { get; set; }
    }

    public class Consulta
    {
        public int IdConsulta { get; set; }
        public int IdCita { get; set; }
        public string Diagnostico { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaConsulta { get; set; }

        // Auxiliares
        public string NombrePaciente { get; set; }
        public string DocumentoPaciente { get; set; }
        public string NombreMedico { get; set; }
        public string Servicio { get; set; }
        public DateTime FechaHoraCita { get; set; }
    }

    public class Medicamento
    {
        public int IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public string Presentacion { get; set; }
        public int Stock { get; set; }

        public string EstadoStock
        {
            get
            {
                if (Stock <= 0) return "Agotado";
                if (Stock <= 15) return "Stock Bajo";
                return "Normal";
            }
        }
    }

    public class DetalleReceta
    {
        public int IdConsulta { get; set; }
        public int IdMedicamento { get; set; }
        public string NombreMedicamento { get; set; }
        public string PresentacionMedicamento { get; set; }
        public string Dosis { get; set; }
        public int DuracionDias { get; set; }
        public string Detalles { get; set; }
    }
}
