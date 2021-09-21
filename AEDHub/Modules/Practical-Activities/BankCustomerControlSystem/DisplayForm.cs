using AEDHub.Firebase;
using AEDHub.Models;
using AEDHub.Tools;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AEDHub.Modules.Practical_Activities.BankCustomerControlSystem
{
    public partial class DisplayForm : XtraForm
    {
        public DisplayForm()
        {
            InitializeComponent();
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                var AssistedClients = RealtimeDatabase.AssistedClients;
                lblServiceClient.Text = AssistedClients.Services;
                lblCashClient.Text = AssistedClients.Cash;

                gcCashClients.DataSource = null;
                gcCashClients.DataSource = RealtimeDatabase.CashClients;
                gcServicesClients.DataSource = null;
                gcServicesClients.DataSource = RealtimeDatabase.ServicesClients;
            }
            catch(Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
