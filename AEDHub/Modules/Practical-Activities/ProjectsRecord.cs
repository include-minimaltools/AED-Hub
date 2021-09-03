using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AEDHub.Models;

namespace AEDHub.Modules.Practical_Activities
{
    public partial class ProjectsRecord : XtraUserControl
    {
        PROJECT[] database;
        int n = 0;

        public ProjectsRecord()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            CleanForm();
            lcInput.Visible = false;
        }

        private void GvProjects_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmActions.ShowPopup(MousePosition);
        }

        private void BbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string idCard = gvProjects.GetFocusedRowCellValue("IdCard").ToString();

                foreach (var project in database)
                {
                    if (project.IdCard == idCard)
                    {
                        LoadProject(project);
                        break;
                    }
                }
                lcInput.Visible = true;
            }
            catch
            {
                XtraMessageBox.Show("No hay un registro que editar, intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lcInput.Visible = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            Array.Resize(ref database, n + 1);

            InsertOrSaveProject(n);
            CleanForm();
            n++;
            lcInput.Visible = false;
        }

        private void InsertOrSaveProject(int index)
        {
            database[index] = new PROJECT()
            {
                ProjectName = txtName.Text,
                Score = int.Parse(txtScore.Text),
                DateLimit = dtLimit.DateTime,
                DateSent = dtSent.DateTime,
                IdCard = txtIdCard.Text,
                Name = txtStudentName.Text,
                LastName = txtStudentLastName.Text
            };

            gcProjects.DataSource = database.ToList();
        }

        private void CleanForm()
        {
            txtIdCard.Text = txtName.Text = txtStudentLastName.Text = txtStudentName.Text = dtLimit.Text = dtSent.Text = txtScore.Text = string.Empty;
        }

        private bool ValidateForm()
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdCard.Text) ||
                    string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtStudentLastName.Text) ||
                    string.IsNullOrEmpty(txtStudentName.Text) ||
                    string.IsNullOrEmpty(dtLimit.Text) ||
                    string.IsNullOrEmpty(dtSent.Text) || 
                    string.IsNullOrEmpty(txtScore.Text))
                    throw new Exception("Por favor, rellene todos los campos para continuar");

                if (int.Parse(txtScore.Text) > 100 || int.Parse(txtScore.Text) < 0)
                    throw new Exception("Por favor, ingrese una nóta válida");

                foreach(var project in database)
                    if (project.IdCard == txtIdCard.Text)
                        throw new Exception("El carnet ingresado ya posee un trabajo asignado, puede editar dicho usuario o ingresar un carnet que no esté en la base de datos.");

                return true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LoadProject(PROJECT project)
        {
            txtIdCard.Text = project.IdCard;
            txtName.Text = project.ProjectName;
            txtScore.Text = project.Score.ToString();
            txtStudentLastName.Text = project.LastName;
            txtStudentName.Text = project.Name;
            dtLimit.DateTime = project.DateLimit;
            dtSent.DateTime = project.DateSent;
        }
    }
}
