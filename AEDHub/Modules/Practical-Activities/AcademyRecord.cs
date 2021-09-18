﻿using AEDHub.Models;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AEDHub.Modules.Practical_Activities
{
    public partial class AcademyRecord : XtraUserControl
    {
        private STUDENT[] database;
        private int students = 0;

        public AcademyRecord()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            cbOrder.SelectedIndex = 0; 
        }

        #region Events
        private void CbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (students == 0)
                    return;

                LoadDataTable();
            }   
            catch
            {
                MessageBox.Show("Ha ocurrido un error inesperado, contactarse con el desarrollador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateData())
                    return;

                Array.Resize(ref database, students + 1);

                SaveStudent(students);

                Clean();
                LoadDataTable();
                students++;
                CalculateStats();
                MessageBox.Show("Se ha ingresado correctamente el estudiante", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error inesperado, contactarse con el desarrollador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateData())
                    return;

                SaveStudent(GetIndexByIdCard());
                Clean();
                LoadDataTable();
                CalculateStats();
                MessageBox.Show("Se ha actualizado correctamente el estudiante", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error inesperado, contactarse con el desarrollador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = GetIndexByIdCard(); i < students - 1; i++)
                    database[i] = database[i + 1];

                students--;
                database[students] = new STUDENT();


                Clean();
                LoadDataTable();
                CalculateStats();
                MessageBox.Show("Se ha eliminado correctamente el estudiante", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error inesperado, contactarse con el desarrollador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtIdCard_KeyUp(object sender, KeyEventArgs e)
        {
            int index = GetIndexByIdCard();
            if (index >= 0)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnInsert.Enabled = false;
                txtName.Text = database[index].Name;
                txtLastName.Text = database[index].LastName;
                txtFirstPartial.Text = database[index].FirstPartial.ToString();
                txtSecondPartial.Text = database[index].SecondPartial.ToString();
                txtSystematic.Text = database[index].Systematic.ToString();
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnInsert.Enabled = true;
            }
        }
        #endregion

        #region Methods
        private void LoadDataTable()
        {
            switch (cbOrder.SelectedIndex)
            {
                case 0:
                    MajorBubble();
                    break;
                case 1:
                    MinorBubble();
                    break;
                case 2:
                    SignBubble();
                    break;
                case 3:
                    ShakerSort();
                    break;
                case 4:
                    DirectInsert();
                    break;
                case 5:
                    Shell();
                    break;
                default:
                    break;
            }

            dgvStudents.DataSource = database.ToList();
        }

        private void SaveStudent(int index)
        {
            database[index] = new STUDENT()
            {
                IdCard = txtIdCard.Text,
                Name = txtName.Text,
                LastName = txtLastName.Text,
                FirstPartial = int.Parse(txtFirstPartial.Text),
                SecondPartial = int.Parse(txtSecondPartial.Text),
                Systematic = int.Parse(txtSystematic.Text),
                FinalNote = Math.Round(
                    (double)(int.Parse(txtFirstPartial.Text) + int.Parse(txtSecondPartial.Text) + int.Parse(txtSystematic.Text)) / 3
                    , 2)
            };
        }

        private bool ValidateData()
        {
            try
            {
                // Validar campos
                if (string.IsNullOrEmpty(txtIdCard.Text) ||
                    string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtLastName.Text) ||
                    string.IsNullOrEmpty(txtFirstPartial.Text) ||
                    string.IsNullOrEmpty(txtSecondPartial.Text) ||
                    string.IsNullOrEmpty(txtSystematic.Text))
                    throw new Exception("Debe llenar todos los valores para ingresar un nuevo estudiante");

                // Validar enteros en las calificaciones
                if (!txtSecondPartial.Text.All(char.IsNumber) ||
                    !txtFirstPartial.Text.All(char.IsNumber) ||
                    !txtSystematic.Text.All(char.IsNumber)
                    )
                    throw new Exception("Debe ingresar un número para las calificaciones");                

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void Clean()
        {
            txtIdCard.Clear();
            txtName.Clear();
            txtLastName.Clear();
            txtFirstPartial.Clear();
            txtSecondPartial.Clear();
            txtSystematic.Clear();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnInsert.Enabled = true;
        }

        private void CalculateStats()
        {
            STUDENT bestStudent = database[0] == null ? new STUDENT() : database[0];
            double average = 0;
            for (int i = 0; i < students; i++)
            {
                if (i < students - 1)
                    if (database[i].FinalNote > database[i + 1].FinalNote)
                        bestStudent = database[i];
                    else
                        bestStudent = database[i + 1];

                average += database[i].FinalNote / students;
            }

            lblAverage.Text = "Promedio del salón: " + average;
            lblBestStudent.Text = $"Mejor estudiante: {bestStudent.Name} {bestStudent.LastName}";
        }

        private int GetIndexByIdCard()
        {
            string idCard = txtIdCard.Text;

            for(int i = 0; i < students; i++)
                if (database[i].IdCard == idCard)
                    return i;
            return -1;
        }
        #endregion

        #region Sorting Methods
        private void InvertPosition(int pos1, int pos2)
        {
            var temp = database[pos1];
            database[pos1] = database[pos2];
            database[pos2] = temp;
        }

        private void MajorBubble(bool upward = true)
        {
            for (int i = students - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if ((database[j].FinalNote > database[j + 1].FinalNote && upward) || (database[j].FinalNote < database[j + 1].FinalNote && !upward))
                    {
                        InvertPosition(j, j + 1);
                    }
                }
            }
        }

        private void DirectInsert()
        {
            for (int i = 1; i < students; i++)
            {
                var temp = database[i];
                int k = i - 1;

                while ((k >= 0) && (temp.FinalNote < database[k].FinalNote))
                {
                    database[k + 1] = database[k];
                    k--;
                }
                database[k + 1] = temp;
            }
        }

        private void Shell()
        {
            bool hasChange;
            int inta = students;

            while (inta > 0)
            {
                inta = (int)(inta / 2);
                hasChange = true;
                while (hasChange)
                {
                    hasChange = false;
                    for (int i = 0; (i + inta) <= (students - 1); i++)
                    {
                        if (database[i].FinalNote > database[i + inta].FinalNote)
                        {
                            InvertPosition(i, i + inta);
                            hasChange = true;
                        }
                    }
                }
            }
        }

        private void ShakerSort()
        {
            int left = 1, right = students - 1, k = right;

            while (right >= left)
            {
                for (int i = right; i >= left; i--)
                {
                    if (database[i - 1].FinalNote > database[i].FinalNote)
                    {
                        InvertPosition(i - 1, i);
                        k = i;
                    }
                }
                left = k + 1;
                for (int i = left; i <= right; i++)
                {
                    if (database[i - 1].FinalNote > database[i].FinalNote)
                    {
                        InvertPosition(i - 1, i);
                        k = i;
                    }
                }
                right = k - 1;
            }
        }

        private void SignBubble()
        {
            bool isFinish = false;
            for (int i = 0; i < students - 1 && isFinish == false; i++)
            {
                isFinish = true;
                for (int j = 0; j < students - 1; j++)
                {
                    if (database[j].FinalNote > database[j + 1].FinalNote)
                    {
                        InvertPosition(j, j + 1);
                        isFinish = false;
                    }
                }
            }
        }

        private void MinorBubble()
        {
            for (int i = 1; i < students; i++)
            {
                for (int j = students - 1; j > 0; j--)
                {
                    if (database[j - 1].FinalNote > database[j].FinalNote)
                    {
                        InvertPosition(j, j - 1);
                    }
                }
            }
        }
        #endregion
    }
}