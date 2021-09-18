using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AEDHub.Tools;

namespace AEDHub.Modules.Practical_Activities.BankCustomerControlSystem
{
    public partial class ServicesForm : XtraForm
    {
        BankCustomerControlSystem MainForm;
        public ServicesForm(BankCustomerControlSystem MainForm)
        {
            InitializeComponent();
            this.MainForm = MainForm;
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.ServicesClients.Count > 0)
                    MainForm.ServiceClient = Global.ServicesClients.Dequeue();
                else
                    MainForm.CashClient = string.Empty;
                txtClient.Text = MainForm.ServiceClient;
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