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
        Queue<string> CashClients = new Queue<string>();
        Queue<string> ServicesClients = new Queue<string>();
        ASSISTED_CLIENTS AssistedClients = new ASSISTED_CLIENTS();
        public DisplayForm()
        {
            InitializeComponent();
            RefreshData();
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            try
            {
                Timer MyTimer = new Timer();
                MyTimer.Interval = (30 * 1000); // 45 mins
                MyTimer.Tick += new EventHandler(MyTimer_Tick);
                MyTimer.Start();
            }
            catch (Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void MyTimer_Tick(object sender, EventArgs e) => RefreshData();

        public void RefreshData()
        {
            try
            {
                var queryAssistedClients = RealtimeDatabase.AssistedClients;
                var queryCashClients = RealtimeDatabase.CashClients;
                var queryServiceClients = RealtimeDatabase.ServicesClients;

                if (queryAssistedClients != AssistedClients)
                {
                    AssistedClients = queryAssistedClients;
                    lblServiceClient.Text = AssistedClients.Services;
                    lblCashClient.Text = AssistedClients.Cash;
                };
                

                if(queryCashClients != CashClients)
                {
                    gcCashClients.DataSource = null;
                    gcCashClients.DataSource = CashClients = queryCashClients;
                }

                if(queryServiceClients != ServicesClients)
                {
                    gcServicesClients.DataSource = null;
                    gcServicesClients.DataSource = ServicesClients = queryServiceClients;
                }
            }
            catch(Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
