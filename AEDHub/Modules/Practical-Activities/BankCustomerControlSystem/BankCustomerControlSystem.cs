using AEDHub.Tools;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AEDHub.Modules.Practical_Activities.BankCustomerControlSystem
{
    public partial class BankCustomerControlSystem : XtraUserControl
    {
        ClientRecord ClientRecordForm;
        DisplayForm Display;
        CashForm Cash;
        ServicesForm Services;
        bool isFloating = false;

        public BankCustomerControlSystem()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void BankCustomerControlSystem_Load(object sender, EventArgs e)
        {
            WaitDialogForm wdf = new WaitDialogForm("Conectando con la base de datos...", "Firebase");
            try
            {
                CreateForms(false);
                SetPanels();
                ShowForms();
                wdf.Close();
            }
            catch (Exception ex)
            {
                if (wdf.Enabled)
                    wdf.Close();
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFloat_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (isFloating)
                {
                    CloseForms();
                    CreateForms(false);
                    SetPanels();
                    ShowForms();

                    btnFloat.Caption = "Ventanas emergentes";
                    isFloating = false;
                }
                else
                {
                    CleanPanels();
                    CloseForms();
                    CreateForms(true);
                    ShowForms();

                    btnFloat.Caption = "Integrar ventanas";
                    isFloating = true;
                }
            }
            catch(Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void CleanPanels()
        {
            panelCash.Controls.Clear();
            panelRegistry.Controls.Clear();
            panelClients.Controls.Clear();
            panelServices.Controls.Clear();
        }

        private void SetPanels()
        {
            panelCash.Controls.Add(Cash);
            panelRegistry.Controls.Add(ClientRecordForm);
            panelClients.Controls.Add(Display);
            panelServices.Controls.Add(Services);
        }

        private void CloseForms()
        {
            Services.Close();
            Cash.Close();
            Display.Close();
            ClientRecordForm.Close();
        }

        private void ShowForms()
        {
            Services.Show();
            Cash.Show();
            Display.Show();
            ClientRecordForm.Show();
        }

        private void CreateForms(bool isWindow)
        {
            if(isWindow)
            {
                ClientRecordForm = new ClientRecord(this) 
                {
                    TopLevel = true, 
                    Dock = DockStyle.None, 
                    FormBorderStyle = FormBorderStyle.Sizable 
                };
                Display = new DisplayForm() 
                {
                    TopLevel = true,
                    Dock = DockStyle.None,
                    FormBorderStyle = FormBorderStyle.Sizable 
                };
                Cash = new CashForm(this) 
                {
                    TopLevel = true,
                    Dock = DockStyle.None,
                    FormBorderStyle = FormBorderStyle.Sizable
                };
                Services = new ServicesForm(this) 
                {
                    TopLevel = true,
                    Dock = DockStyle.None,
                    FormBorderStyle = FormBorderStyle.Sizable
                };
            }
            else
            {
                ClientRecordForm = new ClientRecord(this) 
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None 
                };
                Display = new DisplayForm() 
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };
                Cash = new CashForm(this) 
                {
                    TopLevel = false,
                     Dock = DockStyle.Fill,
                      FormBorderStyle = FormBorderStyle.None
                };
                Services = new ServicesForm(this) 
                {
                    TopLevel = false,
                     Dock = DockStyle.Fill,
                      FormBorderStyle = FormBorderStyle.None
                };
            }
        }
        public void RefreshDisplay() => Display.RefreshData();
    }
}