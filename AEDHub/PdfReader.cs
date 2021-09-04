using DevExpress.XtraEditors;
using System.IO;

namespace AEDHub
{
    public partial class PdfReader : XtraUserControl
    {
        public PdfReader(string path)
        {
            InitializeComponent();
            // Debug edition
            pdfViewer.DocumentFilePath = Directory.GetCurrentDirectory().Replace("\\bin\\Debug",string.Empty) + path;
            // Public edition
            //pdfViewer.DocumentFilePath = Directory.GetCurrentDirectory() + path;
        }
    }
}
