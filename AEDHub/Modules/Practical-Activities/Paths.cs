using AEDHub.Tools;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AEDHub.Modules.Practical_Activities
{
    public partial class Paths : XtraUserControl
    {
        public Paths()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            RefreshGridControl();
            LoadStatus();
        }

        private void RefreshGridControl()
        {
            gcStack.DataSource = null;
            gcStack.DataSource = Tools.Global.Path.ToList();
        }

        private void LoadStatus()
        {
            if (Directory.Exists(lblPath.Text))
            {
                lblStatus.Text = "Existe";
                lblStatus.ForeColor = Color.LightGreen;
                btnOpenDirectory.Enabled = true;
            }
            else
            {
                lblStatus.Text = "No existe";
                lblStatus.ForeColor = Color.Red;
                btnOpenDirectory.Enabled = false;
            }
        }

        private bool GetIsPath()
        {
            if (txtFolderName.Text.Contains("/") ||
                txtFolderName.Text.Contains("\\") ||
                txtFolderName.Text.Contains("//") ||
                txtFolderName.Text.Contains("\\\\"))
            {
                txtFolderName.Text = txtFolderName.Text.Replace("/", "\\").Replace("//", "\\").Replace("\\\\", "\\"); // Se reemplazan los caracteres que no corresponden a una direccion
                return true;
            }

            return false;
        }

        private void GcStack_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                lblPath.Text = string.Empty;
                Tools.Global.Path.Reverse().ToList().ForEach(x => lblPath.Text += x + '\\');
            }
            catch(Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFolderName.Text) || string.IsNullOrWhiteSpace(txtFolderName.Text))
                    return;

                if (!GetIsPath())
                    Tools.Global.Path.Push(txtFolderName.Text);
                else
                    txtFolderName.Text.Split('\\').ToList().ForEach(x => Tools.Global.Path.Push(x));

                RefreshGridControl();
                LoadStatus();

                if (!btnPop.Enabled)
                    btnPop.Enabled = true;
                txtFolderName.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPop_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Global.Path.Pop();
                if (Tools.Global.Path.Count == 0)
                    btnPop.Enabled = false;
                RefreshGridControl();
                LoadStatus();
            }
            catch (Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOpenDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(lblPath.Text);
            }
            catch (Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtFolderName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    BtnAddFolder_Click(sender, e);
                else if (e.KeyChar == 8 && string.IsNullOrEmpty(txtFolderName.Text) && Tools.Global.Path.Count > 0)
                    BtnPop_Click(sender, e);
            }
            catch (Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtFolderName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Directory.Exists(lblPath.Text + txtFolderName.Text + "/"))
                    txtFolderName.ForeColor = Color.LightGreen;
                else
                    txtFolderName.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                Global.Log.Add(ex);
                XtraMessageBox.Show("Ha ocurrido un error inesperado, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
