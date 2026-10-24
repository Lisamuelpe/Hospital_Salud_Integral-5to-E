using System;
using Forms.Models;

namespace Forms.Services
{
    public static class SessionManager
    {
        public static Usuario CurrentUser { get; private set; }
        public static DateTime LastActivityTime { get; private set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static void SetCurrentSession(Usuario usuario)
        {
            CurrentUser = usuario;
            RegisterActivity();
        }

        public static void RegisterActivity()
        {
            LastActivityTime = DateTime.Now;
        }

        public static void ClearSession()
        {
            CurrentUser = null;
        }

        public static bool IsAdmin => 
            CurrentUser != null && 
            string.Equals(CurrentUser.Roles, "Administración", StringComparison.OrdinalIgnoreCase);

        public static bool IsMedico => 
            CurrentUser != null && 
            string.Equals(CurrentUser.Roles, "Médico", StringComparison.OrdinalIgnoreCase);

        public static bool IsRecepcionista => 
            CurrentUser != null && 
            string.Equals(CurrentUser.Roles, "Recepcionista", StringComparison.OrdinalIgnoreCase);

        public static bool CanAccessModule(string module)
        {
            if (CurrentUser == null) return false;
            if (IsAdmin) return true;

            switch (module.ToLowerInvariant())
            {
                case "dashboard":
                case "panel principal":
                case "pacientes":
                case "medicos":
                case "médicos":
                case "departamentos":
                case "servicios":
                case "citas":
                case "perfil":
                    return true;

                case "consultas":
                case "recetas":
                    return IsMedico;

                case "medicamentos":
                    return IsMedico; // Médico L, Recepcionista -

                case "usuarios":
                    return false; // Solo admin

                default:
                    return false;
            }
        }

        public static bool CanPerformAction(string module, char action)
        {
            if (CurrentUser == null) return false;
            action = char.ToUpperInvariant(action);

            if (IsAdmin)
            {
                // Admin L en Consultas y Recetas, el resto C, L, E, X
                if ((module.Equals("consultas", StringComparison.OrdinalIgnoreCase) ||
                     module.Equals("recetas", StringComparison.OrdinalIgnoreCase)) &&
                    (action == 'C' || action == 'E' || action == 'X'))
                {
                    return false;
                }
                return true;
            }

            if (IsMedico)
            {
                if (action == 'L') return CanAccessModule(module);
                if (module.Equals("consultas", StringComparison.OrdinalIgnoreCase) ||
                    module.Equals("recetas", StringComparison.OrdinalIgnoreCase))
                {
                    return action == 'C' || action == 'E';
                }
                if (module.Equals("citas", StringComparison.OrdinalIgnoreCase))
                {
                    return action == 'E'; // Actualizar estado de sus citas
                }
                if (module.Equals("perfil", StringComparison.OrdinalIgnoreCase))
                {
                    return action == 'E';
                }
                return false;
            }

            if (IsRecepcionista)
            {
                if (action == 'L') return CanAccessModule(module);
                if (module.Equals("pacientes", StringComparison.OrdinalIgnoreCase) ||
                    module.Equals("citas", StringComparison.OrdinalIgnoreCase))
                {
                    return action == 'C' || action == 'E';
                }
                if (module.Equals("perfil", StringComparison.OrdinalIgnoreCase))
                {
                    return action == 'E';
                }
                return false;
            }

            return false;
        }
    }
}
