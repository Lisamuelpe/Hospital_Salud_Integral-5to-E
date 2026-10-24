using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Forms.Data;
using Forms.Models;

namespace Forms.Data.Repositories
{
    public class MedicamentoRepository
    {
        public List<Medicamento> GetAll(string search = "", bool soloStockBajo = false)
        {
            var list = new List<Medicamento>();
            string sql = @"
                SELECT id_medicamento, nombre, presentacion, stock
                FROM medicamentos
                WHERE 1=1";

            var parameters = new List<MySqlParameter>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                sql += " AND (nombre LIKE @search OR presentacion LIKE @search)";
                parameters.Add(new MySqlParameter("@search", "%" + search.Trim() + "%"));
            }
            if (soloStockBajo)
            {
                sql += " AND stock <= 15";
            }
            sql += " ORDER BY stock ASC, nombre ASC;";

            var dt = DbConnection.ExecuteQuery(sql, parameters.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Medicamento
                {
                    IdMedicamento = Convert.ToInt32(row["id_medicamento"]),
                    Nombre = row["nombre"].ToString(),
                    Presentacion = row["presentacion"].ToString(),
                    Stock = Convert.ToInt32(row["stock"])
                });
            }
            return list;
        }

        public Medicamento GetById(int id)
        {
            string sql = "SELECT * FROM medicamentos WHERE id_medicamento = @id LIMIT 1;";
            var dt = DbConnection.ExecuteQuery(sql, new MySqlParameter("@id", id));
            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new Medicamento
            {
                IdMedicamento = Convert.ToInt32(row["id_medicamento"]),
                Nombre = row["nombre"].ToString(),
                Presentacion = row["presentacion"].ToString(),
                Stock = Convert.ToInt32(row["stock"])
            };
        }

        public bool Insert(Medicamento m, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (m.Stock < 0)
                {
                    errorMessage = "El stock no puede ser un número negativo.";
                    return false;
                }

                string sql = "INSERT INTO medicamentos (nombre, presentacion, stock) VALUES (@nom, @pres, @stk);";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@nom", m.Nombre.Trim()),
                    new MySqlParameter("@pres", m.Presentacion.Trim()),
                    new MySqlParameter("@stk", m.Stock));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool Update(Medicamento m, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (m.Stock < 0)
                {
                    errorMessage = "El stock no puede ser un número negativo.";
                    return false;
                }

                string sql = "UPDATE medicamentos SET nombre = @nom, presentacion = @pres, stock = @stk WHERE id_medicamento = @id;";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@nom", m.Nombre.Trim()),
                    new MySqlParameter("@pres", m.Presentacion.Trim()),
                    new MySqlParameter("@stk", m.Stock),
                    new MySqlParameter("@id", m.IdMedicamento));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool Delete(int id, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string checkRecetas = "SELECT COUNT(*) FROM detalle_receta WHERE id_medicamento = @id;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkRecetas, new MySqlParameter("@id", id)));
                if (count > 0)
                {
                    errorMessage = "No se puede eliminar el medicamento porque figura en recetas clínicas emitidas.";
                    return false;
                }

                string sql = "DELETE FROM medicamentos WHERE id_medicamento = @id;";
                DbConnection.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
