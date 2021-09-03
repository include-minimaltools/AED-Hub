using AEDHub.Modules.Practical_Activities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AEDHub
{
    public partial class MdiMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        Information ucInformation = new Information() { Dock = DockStyle.Fill };

        EmploymentRecord ucEmployment = new EmploymentRecord() { Dock = DockStyle.Fill };
        AcademyRecord ucAcademy = new AcademyRecord() { Dock = DockStyle.Fill };
        ProjectsRecord ucProject = new ProjectsRecord() { Dock = DockStyle.Fill };
        CreditRecord ucCredit = new CreditRecord() { Dock = DockStyle.Fill };

        public MdiMain()
        {
            InitializeComponent();
        }

        private void MdiMain_Load(object sender, EventArgs e)
        {
            Container.Controls.Add(ucInformation);
            Container.Controls.Add(ucAcademy);
            Container.Controls.Add(ucEmployment);
            Container.Controls.Add(ucCredit);
            Container.Controls.Add(ucProject);
        }

        private void AceAcademyRecord_Click(object sender, EventArgs e)
        {
            ucAcademy.BringToFront();
        }

        private void AceEmploymentRecord_Click(object sender, EventArgs e)
        {
            ucEmployment.BringToFront();
        }

        private void AceCreditRecord_Click(object sender, EventArgs e)
        {
            ucCredit.BringToFront();
        }

        private void AceProjectsRecord_Click(object sender, EventArgs e)
        {
            ucProject.BringToFront();
        }

        private void BbiInformation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucInformation.BringToFront();
        }
    }
}
