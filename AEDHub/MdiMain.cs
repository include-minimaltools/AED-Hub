using AEDHub.Modules.Learning_Resources;
using AEDHub.Modules.Learning_Resources.RA8;
using AEDHub.Modules.Practical_Activities;
using System;
using System.Windows.Forms;

namespace AEDHub
{
    public partial class MdiMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MdiMain()
        {
            InitializeComponent();
        }

        private void AceAcademyRecord_Click(object sender, EventArgs e)
        {
            var frm = new FrmAcademyRecord() { Dock = DockStyle.Fill };
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(frm);
            frm.Show();
        }

        private void AceEmploymentRecord_Click(object sender, EventArgs e)
        {
            var frm = new FrmEmploymentRecord() { Dock = DockStyle.Fill };
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(frm);
            frm.Show();
        }

        private void AceCreditRecord_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new CreditRecord() { Dock = DockStyle.Fill });
        }

        private void AceProjectsRecord_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new ProjectsRecord() { Dock = DockStyle.Fill });
        }

        private void BbiInformation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new Presentation() { Dock = DockStyle.Fill });
        }

        private void AceRA2_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new RA2() { Dock = DockStyle.Fill });
        }

        private void AceRA3_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new RA3 { Dock = DockStyle.Fill });
        }

        private void AceRA5_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new RA5 { Dock = DockStyle.Fill });
        }

        private void AceRA6_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new RA6 { Dock = DockStyle.Fill });
        }

        private void AceRA7_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new RA7 { Dock = DockStyle.Fill });
        }

        private void AceRA8_Click(object sender, EventArgs e)
        {
            new RA8().ShowDialog();
        }

        private void AcePresentation_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new Presentation());
        }

        #region Reports
        private void AceRA1GabrielsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Gabriel/RA1.pdf"));
        }

        private void AceRA1MarcelsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Marcel/RA1.pdf"));
        }

        private void AceRA2GabrielsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Gabriel/RA2.pdf"));
        }

        private void AceRA2MarcelsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Marcel/RA1.pdf"));
        }

        private void AceRA3GabrielsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Gabriel/RA3.pdf"));
        }

        private void AceRA3MarcelsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Marcel/RA3.pdf"));
        }

        private void AceRA4GabrielsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Gabriel/RA4.pdf"));
        }

        private void AceRA4MarcelsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Marcel/RA4.pdf"));
        }

        private void AceRA5GabrielsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Gabriel/RA5.pdf"));
        }

        private void AceRA5MarcelsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Marcel/RA5.pdf"));
        }

        private void AceRA6GabrielsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Gabriel/RA6.pdf"));
        }

        private void AceRA6MarcelsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Marcel/RA6.pdf"));
        }

        private void AceRA7GabrielsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Gabriel/RA7.pdf"));
        }

        private void AceRA7MarcelsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Marcel/RA7.pdf"));
        }

        private void AceRA8GabrielsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Gabriel/RA8.pdf"));
        }

        private void AceRA8MarcelsReport_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/Marcel/RA8.pdf"));
        }

        private void AceAP1Report_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/AP1.pdf"));
        }

        private void AceAP2Report_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(new PdfReader("/Reports/AP2.pdf"));
        }
        #endregion
    }
}
