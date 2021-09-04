using DevExpress.XtraEditors;
using System.IO;
using System.Windows.Forms;

namespace AEDHub
{
    public partial class PdfReader : XtraUserControl
    {
        public PdfReader(string path)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            // Debug edition
            pdfViewer.DocumentFilePath = Directory.GetCurrentDirectory().Replace("\\bin\\Debug",string.Empty) + path;
            // Public edition
            //pdfViewer.DocumentFilePath = Directory.GetCurrentDirectory() + path;
        }
    }
}
