Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI

Namespace WindowsApplication1
	Partial Public Class XtraReport1
		Inherits DevExpress.XtraReports.UI.XtraReport
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub xrLabel3_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)

		End Sub

		Private Sub xrTableCell3_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles xrTableCell3.BeforePrint
			Dim isExporting As Boolean = Convert.ToBoolean(Me.Parameters("IsExporting").Value)
			Dim cell As XRTableCell = CType(sender, XRTableCell)
			If isExporting Then
				cell.BackColor = Color.Green
			Else
				cell.BackColor = Color.Yellow
			End If
		End Sub

	End Class
End Namespace
