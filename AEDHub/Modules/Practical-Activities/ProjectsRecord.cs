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

        #region Event
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

                for (int i = 0; i < n; i++)
                    if (database[i].IdCard == idCard)
                    {
                        LoadProject(database[i]);
                        break;
                    }
                    
                lcInput.Visible = true;
            }
            catch
            {
                XtraMessageBox.Show("No hay un registro que editar, intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string idCard = gvProjects.GetFocusedRowCellValue("IdCard").ToString();

                for (int i = 0; i < n; i++)
                    if (database[i].IdCard == idCard)
                    {
                        for(int j = i; j < n - 1; j++)
                            database[j] = database[j + 1];

                        break;
                    }

                n--;

                if (n == 0)
                    database = null;
                else
                    Array.Resize(ref database, n);

                gcProjects.DataSource = null;
                gcProjects.DataSource = database.ToList();
            }
            catch
            {
                XtraMessageBox.Show("No hay un registro que editar, intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CleanForm();
            lcInput.Visible = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            int index = GetIndex();

            if (index < 0)
            {
                Array.Resize(ref database, n + 1);
                InsertOrUpdateProject(n);
                n++;
            }
            else
                InsertOrUpdateProject(index);
            
            CleanForm();
            MinorBubble();
            gcProjects.DataSource = database.ToList();
            lcInput.Visible = false;
        }

        private void CeOnlyLate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gcProjects.DataSource = ceOnlyLate.Checked ? database.Where(x => x.isSentLate).ToList() : database.ToList();
                gcProjects.RefreshDataSource();
            }
            catch
            {
                XtraMessageBox.Show("Ha ocurrido un error al obtener los proyectos entregados tardemente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            CleanForm();
            lcInput.Visible = true;
        }
        #endregion

        #region Methods
        private void InsertOrUpdateProject(int index)
        {
            database[index] = new PROJECT()
            {
                ProjectName = txtName.Text,
                Score = int.Parse(txtScore.Text),
                DateLimit = dtLimit.DateTime,
                DateSent = dtSent.DateTime,
                IdCard = txtIdCard.Text,
                Name = txtStudentName.Text,
                LastName = txtStudentLastName.Text,
                isSentLate = dtLimit.DateTime < dtSent.DateTime
            };
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

        private void MinorBubble()
        {
            for (int i = 1; i < n; i++)
                for (int j = n - 1; j > 0; j--)
                    if (database[j - 1].DateSent > database[j].DateSent)
                        InvertPosition(j, j - 1);
        }

        private void InvertPosition(int pos1, int pos2)
        {
            var temp = database[pos1];
            database[pos1] = database[pos2];
            database[pos2] = temp;
        }

        private int GetIndex()
        {
            for (int i = 0; i < n; i++)
                if (database[i].IdCard == txtIdCard.Text)
                    return i;
            return -1;
        }
        #endregion
    }
}