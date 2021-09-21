namespace AEDHub.Modules.Practical_Activities.BankCustomerControlSystem
{
    partial class BankCustomerControlSystem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelRegistry = new DevExpress.XtraEditors.SidePanel();
            this.panelCash = new DevExpress.XtraEditors.SidePanel();
            this.panelServices = new DevExpress.XtraEditors.SidePanel();
            this.panelClients = new DevExpress.XtraEditors.SidePanel();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnFloat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRegistry
            // 
            this.panelRegistry.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRegistry.Location = new System.Drawing.Point(0, 23);
            this.panelRegistry.Name = "panelRegistry";
            this.panelRegistry.Size = new System.Drawing.Size(529, 188);
            this.panelRegistry.TabIndex = 0;
            this.panelRegistry.Text = "sidePanel1";
            // 
            // panelCash
            // 
            this.panelCash.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCash.Location = new System.Drawing.Point(0, 211);
            this.panelCash.Name = "panelCash";
            this.panelCash.Size = new System.Drawing.Size(238, 179);
            this.panelCash.TabIndex = 2;
            this.panelCash.Text = "sidePanel1";
            // 
            // panelServices
            // 
            this.panelServices.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelServices.Location = new System.Drawing.Point(306, 211);
            this.panelServices.Name = "panelServices";
            this.panelServices.Size = new System.Drawing.Size(223, 179);
            this.panelServices.TabIndex = 3;
            this.panelServices.Text = "sidePanel2";
            // 
            // panelClients
            // 
            this.panelClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClients.Location = new System.Drawing.Point(238, 211);
            this.panelClients.Name = "panelClients";
            this.panelClients.Size = new System.Drawing.Size(68, 179);
            this.panelClients.TabIndex = 4;
            this.panelClients.Text = "sidePanel3";
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnFloat});
            this.barManager1.MaxItemId = 1;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFloat)});
            this.bar1.Text = "Tools";
            // 
            // btnFloat
            // 
            this.btnFloat.Caption = "Ventanas emergentes";
            this.btnFloat.Id = 0;
            this.btnFloat.Name = "btnFloat";
            this.btnFloat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnFloat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(529, 23);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 390);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(529, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 23);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 367);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(529, 23);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 367);
            // 
            // BankCustomerControlSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelClients);
            this.Controls.Add(this.panelServices);
            this.Controls.Add(this.panelCash);
            this.Controls.Add(this.panelRegistry);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "BankCustomerControlSystem";
            this.Size = new System.Drawing.Size(529, 390);
            this.Load += new System.EventHandler(this.BankCustomerControlSystem_Load);
            this.Enter += new System.EventHandler(this.BankCustomerControlSystem_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SidePanel panelRegistry;
        private DevExpress.XtraEditors.SidePanel panelCash;
        private DevExpress.XtraEditors.SidePanel panelServices;
        private DevExpress.XtraEditors.SidePanel panelClients;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnFloat;
    }
}
