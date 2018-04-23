Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting.Native
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Control
Imports System.IO
Imports DevExpress.XtraReports.UI

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub


		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			' Create a report object.
			' Create a report instance, assigned to a Print Tool.
			Dim pt As New ReportPrintTool(New XtraReport1())

			' Generate the report's document. This step is required
			' to activate its PrintingSystem and access it later.
			pt.Report.CreateDocument(False)
			' Override the ExportGraphic command.
			pt.PrintingSystem.AddCommandHandler(New ExportToExcelCommandHandler())

			' Show the report's print preview.
			pt.ShowPreviewDialog()

		End Sub
	End Class

	Public Class ExportToExcelCommandHandler
		Implements ICommandHandler
        Public Overridable Sub HandleCommand(ByVal command As PrintingSystemCommand, ByVal args() As Object, ByVal control As IPrintControl, ByRef handled As Boolean) Implements ICommandHandler.HandleCommand
            If (Not CanHandleCommand(command, control)) Then
                Return
            End If

            Dim report As New XtraReport1()
            Dim myStream As Stream
            report.Parameters("IsExporting").Value = True
            Dim saveFileDialog1 As New SaveFileDialog()

            saveFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                myStream = saveFileDialog1.OpenFile()
                If myStream IsNot Nothing Then
                    report.ExportToXls(myStream)

                    myStream.Close()
                End If
            End If


            ' Set handled to true to avoid the standard exporting procedure to be called.
            handled = True
        End Sub

        Public Overridable Function CanHandleCommand(ByVal command As PrintingSystemCommand, ByVal control As IPrintControl) As Boolean Implements ICommandHandler.CanHandleCommand
            ' This handler is used for the ExportXls command.
            Return command = PrintingSystemCommand.ExportXls
        End Function
	End Class

End Namespace