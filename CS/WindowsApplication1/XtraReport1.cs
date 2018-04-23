using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WindowsApplication1 {
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        public XtraReport1() {
            InitializeComponent();
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            
        }

        private void xrTableCell3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            bool isExporting = Convert.ToBoolean(this.Parameters["IsExporting"].Value);
            XRTableCell cell = (XRTableCell)sender;
            if (isExporting)
                cell.BackColor = Color.Green;
            else
                cell.BackColor = Color.Yellow;
        }

    }
}
