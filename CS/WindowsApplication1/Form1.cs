using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Control;
using System.IO;

namespace WindowsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private void simpleButton1_Click(object sender, EventArgs e) {
            // Create a report object.
            XtraReport1 report = new XtraReport1();

            // Generate the report's document. This step is required
            // to activate its PrintingSystem and access it later.
            report.CreateDocument();

            // Override the ExportGraphic command.
            report.PrintingSystem.AddCommandHandler(new ExportToExcelCommandHandler());

            // Show the report's print preview.
            report.ShowPreview();

        }
    }

    public class ExportToExcelCommandHandler : ICommandHandler {
        public virtual void HandleCommand(PrintingSystemCommand command, object[] args, PrintControl control, ref bool handled) {
            if (!CanHandleCommand(command, control))
                return;

            XtraReport1 report = new XtraReport1();
            Stream myStream;
            report.Parameters["IsExporting"].Value = true;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                if ((myStream = saveFileDialog1.OpenFile()) != null) {
                    report.ExportToXls(myStream);

                    myStream.Close();
                }
            } 


            // Set handled to true to avoid the standard exporting procedure to be called.
            handled = true;
        }

        public virtual bool CanHandleCommand(PrintingSystemCommand command, PrintControl control) {
            // This handler is used for the ExportXls command.
            return command == PrintingSystemCommand.ExportXls;
        }
    }

}