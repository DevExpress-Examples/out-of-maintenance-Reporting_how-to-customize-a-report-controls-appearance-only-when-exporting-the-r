<!-- default file list -->
*Files to look at*:

* [WindowsApplication1.sln](./CS/WindowsApplication1.sln)
* **[Form1.cs](./CS/WindowsApplication1/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication1/Form1.vb))**
* [XtraReport1.cs](./CS/WindowsApplication1/XtraReport1.cs)
<!-- default file list end -->
# How to customize a report control's appearance only when exporting the report


<p>This example illustrates the capability to update the XRTableCell appearance (BackColor) when exporting the report to Excel format.<br />
To accomplish this task, a custom ExportToExcelCommandHandler handler is used instead of the standard PrintingSystemCommand.ExportXls command in the Print Preview form.</p>

<br/>


