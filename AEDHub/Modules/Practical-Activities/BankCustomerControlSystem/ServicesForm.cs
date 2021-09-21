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
using AEDHub.Firebase;

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
        private void ServicesForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtClient.Text = RealtimeDatabase.AssistedClients.Services;
            }
            catch(Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                var ServicesClients = RealtimeDatabase.ServicesClients;

                if (ServicesClients.Count > 0)
                    txtClient.Text = ServicesClients.Dequeue();
                else
                {
                    txtClient.Text = string.Empty;
                    XtraMessageBox.Show("La fila esta vacía", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                RealtimeDatabase.ServicesClients = ServicesClients;
                var AssistedClients = RealtimeDatabase.AssistedClients;
                AssistedClients.Services = txtClient.Text;
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