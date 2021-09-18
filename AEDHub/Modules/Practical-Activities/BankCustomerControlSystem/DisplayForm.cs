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
using AEDHub.Tools;

namespace AEDHub.Modules.Practical_Activities.BankCustomerControlSystem
{
    public partial class DisplayForm : XtraForm
    {
        public DisplayForm()
        {
            InitializeComponent();
        }

        public void RefreshData(string cashClient, string serviceClient)
        {
            try
            {
                lblServiceClient.Text = serviceClient;
                lblCashClient.Text = cashClient;

                gcCashClients.DataSource = null;
                gcCashClients.DataSource = Global.CashClients;
                gcServicesClients.DataSource = null;
                gcServicesClients.DataSource = Global.ServicesClients;
            }
            catch(Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
