using DevExpress.XtraEditors;
using System;

namespace AEDHub.Modules.Learning_Resources.RA8
{
    public partial class FrmQuery : XtraForm
    {
        public FrmQuery()
        {
            InitializeComponent();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            dgvUniversity.DataSource = Tools.UniversityCatalog;
        }
    }
}
