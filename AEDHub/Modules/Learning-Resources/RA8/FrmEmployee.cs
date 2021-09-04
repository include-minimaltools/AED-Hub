using AEDHub.Models;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AEDHub.Modules.Learning_Resources.RA8
{
    public partial class FrmEmployee : XtraForm
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void TxtUniversity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Add();
        }

        private void Add()
        {
            if (string.IsNullOrEmpty(txtUniversity.Text))
                return;

            Tools.UniversityCatalog.Add(new UNIVERSITY() { Name = txtUniversity.Text });
            txtUniversity.Clear();
        }
    }
}
