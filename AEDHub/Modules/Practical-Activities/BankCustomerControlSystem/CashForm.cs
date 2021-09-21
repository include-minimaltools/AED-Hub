using AEDHub.Firebase;
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
        private void CashForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtClient.Text = RealtimeDatabase.AssistedClients.Cash;
            }
            catch (Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                var CashClients = RealtimeDatabase.CashClients;
                if (CashClients.Count > 0)
                    txtClient.Text = CashClients.Dequeue();
                else
                {
                    txtClient.Text = string.Empty;
                    XtraMessageBox.Show("La fila esta vacía", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    

                RealtimeDatabase.CashClients = CashClients;
                var AssistedClients = RealtimeDatabase.AssistedClients;
                AssistedClients.Cash = txtClient.Text;
                RealtimeDatabase.AssistedClients = AssistedClients;
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
