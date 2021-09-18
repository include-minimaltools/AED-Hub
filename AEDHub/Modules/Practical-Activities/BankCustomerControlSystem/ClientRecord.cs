using AEDHub.Tools;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AEDHub.Modules.Practical_Activities.BankCustomerControlSystem
{
    public partial class ClientRecord : XtraForm
    {
        BankCustomerControlSystem MainForm;
        public ClientRecord(BankCustomerControlSystem MainForm)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            this.MainForm = MainForm;
        }

        private void BtnAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtClient.Text))
                    return;

                if((char)rgService.EditValue == 'C')
                    Global.CashClients.Enqueue(txtClient.Text);
                else
                    Global.ServicesClients.Enqueue(txtClient.Text);

                txtClient.Text = string.Empty;

                MainForm.RefreshDisplay();
            }
            catch (Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    BtnAddClient_Click(sender, e);
            }
            catch(Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
