using System;
using System.Data;
using MySql.Data.MySqlClient;
using Forms.Data;

namespace Forms.Data.Repositories
{
    public class DashboardRepository
    {
        public int GetCitasHoyCount(int? idMedico = null)
        {
            string sql = "SELECT COUNT(*) FROM citas WHERE DATE(fecha_hora) = CURDATE()";
            if (idMedico.HasValue) sql += " AND id_medico = @medico";
            var param = idMedico.HasValue ? new[] { new MySqlParameter("@medico", idMedico.Value) } : null;
            return Convert.ToInt32(DbConnection.ExecuteScalar(sql, param));
        }

        public int GetCitasPendientesHoyCount(int? idMedico = null)
        {
            string sql = "SELECT COUNT(*) FROM citas WHERE DATE(fecha_hora) = CURDATE() AND estado IN ('Programada', 'Confirmada')";
            if (idMedico.HasValue) sql += " AND id_medico = @medico";
            var param = idMedico.HasValue ? new[] { new MySqlParameter("@medico", idMedico.Value) } : null;
            return Convert.ToInt32(DbConnection.ExecuteScalar(sql, param));
        }

        public int GetTotalPacientesCount()
        {
            string sql = "SELECT COUNT(*) FROM pacientes;";
            return Convert.ToInt32(DbConnection.ExecuteScalar(sql));
        }

        public int GetMedicamentosStockBajoCount()
        {
            string sql = "SELECT COUNT(*) FROM medicamentos WHERE stock <= 15;";
            return Convert.ToInt32(DbConnection.ExecuteScalar(sql));
        }

        public int GetTotalMedicosCount()
        {
            string sql = "SELECT COUNT(*) FROM medicos;";
            return Convert.ToInt32(DbConnection.ExecuteScalar(sql));
        }

        public DataTable GetAgendaHoy(int? idMedico = null)
        {
            string sql = @"
                SELECT c.id_cita, TIME(c.fecha_hora) AS hora, 
                       CONCAT(p.nombre, ' ', p.apellido) AS paciente, p.telefono,
                       CONCAT(m.nombre, ' ', m.apellido) AS medico,
                       s.nombre AS servicio, c.estado
                FROM citas c
                INNER JOIN pacientes p ON c.id_paciente = p.id_paciente
                INNER JOIN medicos m ON c.id_medico = m.id_medico
                INNER JOIN servicios s ON c.id_servicio = s.id_servicio
                WHERE DATE(c.fecha_hora) = CURDATE()";

            if (idMedico.HasValue)
            {
                sql += " AND c.id_medico = @medico";
            }
            sql += " ORDER BY c.fecha_hora ASC LIMIT 10;";

            var param = idMedico.HasValue ? new[] { new MySqlParameter("@medico", idMedico.Value) } : null;
            return DbConnection.ExecuteQuery(sql, param);
        }
    }
}
