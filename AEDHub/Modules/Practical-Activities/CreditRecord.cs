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
    public partial class CreditRecord : XtraUserControl
    {
        DEBTOR[] database;
        int n = 0;

        public CreditRecord()
        {
            InitializeComponent();
        }

        #region Events
        private void GvDebts_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmActions.ShowPopup(MousePosition);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            lcInput.Visible = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            Array.Resize(ref database, n + 1);

            InsertOrUpdateDebtor(n);
            n++;
            gcDebts.DataSource = database.ToList();
            MinorBubble();
            CleanForm();
            lcInput.Visible = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            CleanForm();
            lcInput.Visible = false;
        }

        private void BbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lcInput.Visible = true;
        }

        private void BbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id =(int) gvDebts.GetFocusedRowCellValue("Id");

            for (int i = 0; i < n; i++)
            {
                if (database[i].Id == id)
                {
                    LoadProject(database[i]);
                    break;
                }
            }
            lcInput.Visible = true;
        }
        #endregion

        #region Methods
        private void InsertOrUpdateDebtor(int index)
        {
            database[index] = new DEBTOR()
            {
                 Id = int.Parse(txtId.Text),
                 IdCard = txtIdCard.Text,
                 Address = txtAddress.Text,
                 Debt = Double.Parse(txtDebt.Text),
                 LastName = txtLastNames.Text,
                 Name = txtNames.Text,
                 Phone = txtPhone.Text,
                 isPay = cbStatus.EditValue.Equals("Pagada")
            };
        }

        private bool ValidateForm()
        {
            try
            {
                if (string.IsNullOrEmpty(txtAddress.Text) ||
                    string.IsNullOrEmpty(txtDebt.Text) ||
                    string.IsNullOrEmpty(txtId.Text) ||
                    string.IsNullOrEmpty(txtIdCard.Text) ||
                    string.IsNullOrEmpty(txtLastNames.Text) ||
                    string.IsNullOrEmpty(txtNames.Text) ||
                    string.IsNullOrEmpty(txtPhone.Text) ||
                    string.IsNullOrEmpty(cbStatus.Text))
                    throw new Exception("Debe rellenar todos los campos para continuar");


                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CleanForm()
        {
            txtAddress.Text = txtDebt.Text = txtId.Text = txtIdCard.Text = txtLastNames.Text = txtNames.Text = txtPhone.Text = string.Empty;
        }

        private void MinorBubble()
        {
            for (int i = 1; i < n; i++)
                for (int j = n - 1; j > 0; j--)
                    if (database[j - 1].Id > database[j].Id)
                        InvertPosition(j, j - 1);
        }

        private void InvertPosition(int pos1, int pos2)
        {
            var temp = database[pos1];
            database[pos1] = database[pos2];
            database[pos2] = temp;
        }

        private void RgFilter_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataTable((char)(rgFilter.EditValue));
        }

        private void LoadDataTable(char filter)
        {
            if (database == null)
                return;

            switch (filter)
            {
                case 'P':
                    gcDebts.DataSource = database.Where(x => x.isPay).ToList();
                    gvDebts.RefreshData();
                    break;
                case 'N':
                    gcDebts.DataSource = database.Where(x => !x.isPay).ToList();
                    break;
                case 'A':
                default:
                    gcDebts.DataSource = database.ToList();
                    break;
            }
        }

        private void LoadProject(DEBTOR debtor)
        {
            txtAddress.Text = debtor.Address;
            txtDebt.Text = debtor.Debt.ToString();
            txtId.Text = debtor.Id.ToString();
            txtIdCard.Text = debtor.IdCard;
            txtLastNames.Text = debtor.LastName;
            txtNames.Text = debtor.Name;
            txtPhone.Text = debtor.Phone;
        }
        #endregion

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int id = (int)gvDebts.GetFocusedRowCellValue("Id");

                for (int i = 0; i < n; i++)
                    if (database[i].Id == id)
                    {
                        for (int j = i; j < n - 1; j++)
                            database[j] = database[j + 1];

                        break;
                    }

                n--;

                if (n == 0)
                    database = null;
                else
                    Array.Resize(ref database, n);

                gcDebts.DataSource = null;
                gcDebts.DataSource = database.ToList();
            }
            catch
            {
                XtraMessageBox.Show("No hay un registro que editar, intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
