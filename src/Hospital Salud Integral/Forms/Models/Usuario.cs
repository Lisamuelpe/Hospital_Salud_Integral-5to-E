using System;

namespace Forms.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Roles { get; set; } // 'Administración', 'Médico', 'Recepcionista'
        public int? IdMedico { get; set; }
        public bool Activo { get; set; }
        public DateTime? UltimoAcceso { get; set; }

        // Campos complementarios
        public string NombreMedico { get; set; }
    }
}
