using AEDHub.Tools;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AEDHub.Modules.Practical_Activities.BankCustomerControlSystem
{
    public partial class CashForm : XtraForm
    {
        BankCustomerControlSystem MainForm;

        public CashForm(BankCustomerControlSystem MainForm)
        {
            InitializeComponent();
            this.MainForm = MainForm;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.CashClients.Count > 0)
                    MainForm.CashClient = Global.CashClients.Dequeue();
                else
                    MainForm.CashClient = string.Empty;
                txtClient.Text = MainForm.CashClient;
                MainForm.RefreshDisplay();
            }
            catch(Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
