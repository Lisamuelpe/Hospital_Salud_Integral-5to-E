using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Modals;
using Forms.Models;
using Forms.Services;

namespace Forms.Controls
{
    public partial class UcCatalogos : UserControl
    {
        private readonly CatalogoRepository _repository = new CatalogoRepository();

        public UcCatalogos()
        {
            InitializeComponent();
        }

        private void UcCatalogos_Load(object sender, EventArgs e)
        {
            AplicarPermisos();
            CargarDepartamentos();
        }

        private void AplicarPermisos()
        {
            bool canEdit = SessionManager.IsAdmin;

            btnNuevoDep.Visible = canEdit;
            btnEditarDep.Visible = canEdit;
            btnEliminarDep.Visible = canEdit;

            btnNuevaEsp.Visible = canEdit;
            btnEditarEsp.Visible = canEdit;
            btnEliminarEsp.Visible = canEdit;

            btnNuevoServ.Visible = canEdit;
            btnEditarServ.Visible = canEdit;
            btnEliminarServ.Visible = canEdit;
        }

        private void tabCatalogos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCatalogos.SelectedTab == tabDepartamentos)
            {
                CargarDepartamentos();
            }
            else if (tabCatalogos.SelectedTab == tabEspecialidades)
            {
                CargarEspecialidades();
            }
            else if (tabCatalogos.SelectedTab == tabServicios)
            {
                CargarServicios();
            }
        }

        #region Departamentos
        public void CargarDepartamentos()
        {
            try
            {
                var list = _repository.GetDepartamentos();
                dgvDepartamentos.DataSource = null;
                dgvDepartamentos.DataSource = list;

                if (dgvDepartamentos.Columns.Count > 0)
                {
                    dgvDepartamentos.Columns["IdDepartamento"].HeaderText = "Código";
                    dgvDepartamentos.Columns["IdDepartamento"].Width = 80;
                    dgvDepartamentos.Columns["Nombre"].HeaderText = "Nombre del Departamento";
                    dgvDepartamentos.Columns["Ubicacion"].HeaderText = "Ubicación en el Hospital";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Departamento GetSelectedDepartamento()
        {
            if (dgvDepartamentos.CurrentRow != null && dgvDepartamentos.CurrentRow.DataBoundItem is Departamento d)
            {
                return d;
            }
            return null;
        }

        private void btnNuevoDep_Click(object sender, EventArgs e)
        {
            if (FrmPromptModal.ShowPrompt("Nuevo Departamento", "Nombre del departamento:", out string nombre))
            {
                if (FrmPromptModal.ShowPrompt("Ubicación", "Ubicación en el hospital (ej. Edificio B, Planta 2):", out string ubicacion))
                {
                    var dep = new Departamento { Nombre = nombre, Ubicacion = ubicacion };
                    if (_repository.InsertDepartamento(dep, out string error))
                    {
                        MessageBox.Show("Departamento registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDepartamentos();
                    }
                    else
                    {
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEditarDep_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedDepartamento();
            if (sel == null)
            {
                MessageBox.Show("Seleccione un departamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FrmPromptModal.ShowPrompt("Editar Departamento", "Nuevo nombre del departamento:", out string nombre, sel.Nombre))
            {
                if (FrmPromptModal.ShowPrompt("Editar Ubicación", "Nueva ubicación:", out string ubicacion, sel.Ubicacion))
                {
                    sel.Nombre = nombre;
                    sel.Ubicacion = ubicacion;
                    if (_repository.UpdateDepartamento(sel, out string error))
                    {
                        MessageBox.Show("Departamento actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDepartamentos();
                    }
                    else
                    {
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEliminarDep_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedDepartamento();
            if (sel == null) return;

            var confirm = MessageBox.Show(
                $"¿Desea eliminar el departamento '{sel.Nombre}'?\nNo se puede eliminar si agrupa especialidades o servicios.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (_repository.DeleteDepartamento(sel.IdDepartamento, out string error))
                {
                    MessageBox.Show("Departamento eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDepartamentos();
                }
                else
                {
                    MessageBox.Show(error, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Especialidades
        public void CargarEspecialidades()
        {
            try
            {
                var list = _repository.GetEspecialidades();
                dgvEspecialidades.DataSource = null;
                dgvEspecialidades.DataSource = list;

                if (dgvEspecialidades.Columns.Count > 0)
                {
                    dgvEspecialidades.Columns["IdEspecialidad"].HeaderText = "Código";
                    dgvEspecialidades.Columns["IdEspecialidad"].Width = 80;
                    dgvEspecialidades.Columns["Nombre"].HeaderText = "Nombre de Especialidad";
                    dgvEspecialidades.Columns["NombreDepartamento"].HeaderText = "Departamento al que Pertenece";
                    dgvEspecialidades.Columns["IdDepartamento"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Especialidad GetSelectedEspecialidad()
        {
            if (dgvEspecialidades.CurrentRow != null && dgvEspecialidades.CurrentRow.DataBoundItem is Especialidad esp)
            {
                return esp;
            }
            return null;
        }

        private void btnNuevaEsp_Click(object sender, EventArgs e)
        {
            var deps = _repository.GetDepartamentos();
            if (deps.Count == 0)
            {
                MessageBox.Show("Primero debe registrar al menos un departamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (FrmPromptModal.ShowPrompt("Nueva Especialidad", "Nombre de la especialidad médica:", out string nombre))
            {
                // Asociar al primer departamento por defecto o pedir
                var esp = new Especialidad { Nombre = nombre, IdDepartamento = deps[0].IdDepartamento };
                if (_repository.InsertEspecialidad(esp, out string error))
                {
                    MessageBox.Show("Especialidad registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarEspecialidades();
                }
                else
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditarEsp_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedEspecialidad();
            if (sel == null) return;

            if (FrmPromptModal.ShowPrompt("Editar Especialidad", "Nombre de la especialidad médica:", out string nombre, sel.Nombre))
            {
                sel.Nombre = nombre;
                if (_repository.UpdateEspecialidad(sel, out string error))
                {
                    MessageBox.Show("Especialidad actualizada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarEspecialidades();
                }
                else
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarEsp_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedEspecialidad();
            if (sel == null) return;

            var confirm = MessageBox.Show(
                $"¿Desea eliminar la especialidad '{sel.Nombre}'?\nNo se puede eliminar si tiene médicos asignados.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (_repository.DeleteEspecialidad(sel.IdEspecialidad, out string error))
                {
                    MessageBox.Show("Especialidad eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarEspecialidades();
                }
                else
                {
                    MessageBox.Show(error, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Servicios
        public void CargarServicios()
        {
            try
            {
                var list = _repository.GetServicios();
                dgvServicios.DataSource = null;
                dgvServicios.DataSource = list;

                if (dgvServicios.Columns.Count > 0)
                {
                    dgvServicios.Columns["IdServicio"].HeaderText = "Código";
                    dgvServicios.Columns["IdServicio"].Width = 80;
                    dgvServicios.Columns["Nombre"].HeaderText = "Nombre del Servicio";
                    dgvServicios.Columns["Costo"].HeaderText = "Costo ($)";
                    dgvServicios.Columns["Costo"].DefaultCellStyle.Format = "N2";
                    dgvServicios.Columns["NombreDepartamento"].HeaderText = "Departamento";
                    dgvServicios.Columns["IdDepartamento"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar servicios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Servicio GetSelectedServicio()
        {
            if (dgvServicios.CurrentRow != null && dgvServicios.CurrentRow.DataBoundItem is Servicio s)
            {
                return s;
            }
            return null;
        }

        private void btnNuevoServ_Click(object sender, EventArgs e)
        {
            var deps = _repository.GetDepartamentos();
            if (deps.Count == 0)
            {
                MessageBox.Show("Debe existir al menos un departamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (FrmPromptModal.ShowPrompt("Nuevo Servicio", "Nombre del servicio clínico:", out string nombre))
            {
                if (FrmPromptModal.ShowPrompt("Costo del Servicio", "Costo en dólares (ej. 35.00):", out string costoStr, "30.00"))
                {
                    if (decimal.TryParse(costoStr, out decimal costo) && costo >= 0)
                    {
                        var s = new Servicio { Nombre = nombre, Costo = costo, IdDepartamento = deps[0].IdDepartamento };
                        if (_repository.InsertServicio(s, out string error))
                        {
                            MessageBox.Show("Servicio registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarServicios();
                        }
                        else
                        {
                            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El costo ingresado no es válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnEditarServ_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedServicio();
            if (sel == null) return;

            if (FrmPromptModal.ShowPrompt("Editar Servicio", "Nombre del servicio:", out string nombre, sel.Nombre))
            {
                if (FrmPromptModal.ShowPrompt("Editar Costo", "Costo:", out string costoStr, sel.Costo.ToString("N2")))
                {
                    if (decimal.TryParse(costoStr, out decimal costo) && costo >= 0)
                    {
                        sel.Nombre = nombre;
                        sel.Costo = costo;
                        if (_repository.UpdateServicio(sel, out string error))
                        {
                            MessageBox.Show("Servicio actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarServicios();
                        }
                        else
                        {
                            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnEliminarServ_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedServicio();
            if (sel == null) return;

            var confirm = MessageBox.Show(
                $"¿Desea eliminar el servicio '{sel.Nombre}'?\nNo se puede eliminar si está asignado a citas.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (_repository.DeleteServicio(sel.IdServicio, out string error))
                {
                    MessageBox.Show("Servicio eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarServicios();
                }
                else
                {
                    MessageBox.Show(error, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
