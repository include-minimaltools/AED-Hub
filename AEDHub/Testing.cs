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
using System.Threading;
using DevExpress.XtraWaitForm;
using DevExpress.Utils;

namespace AEDHub
{
    public partial class Testing : DevExpress.XtraEditors.XtraUserControl
    {
        WaitForm1 a = new WaitForm1();
        public Testing()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            new WaitDialogForm().Show();
        }
    }
}
