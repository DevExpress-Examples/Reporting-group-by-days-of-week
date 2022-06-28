Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI

' ...
Namespace GroupByTimeSpan

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Function CreateDataGroupingReport() As XtraReport
            ' Create a report, and bind it to a data source.
            Dim report As XtraReport = New XtraReport()
            Dim ds As nwindDataSet = New nwindDataSet()
            Call New nwindDataSetTableAdapters.OrdersTableAdapter().Fill(ds.Orders)
            report.DataSource = ds
            report.DataMember = "Orders"
            ' Create a detail band and add it to the report.
            Dim detailBand As DetailBand = New DetailBand()
            detailBand.Height = 20
            report.Bands.Add(detailBand)
            ' Create a group header band and add it to the report.
            Dim ghBand As GroupHeaderBand = New GroupHeaderBand()
            ghBand.Height = 20
            report.Bands.Add(ghBand)
            ' Create a calculated field, and add it to the report's collection
            Dim calcField As CalculatedField = New CalculatedField(report.DataSource, report.DataMember)
            report.CalculatedFields.Add(calcField)
            ' Define its name, field type and expression.
            ' Note that numerous built-in date-time functions are supported.
            calcField.Name = "dayOfWeek"
            calcField.FieldType = FieldType.None
            calcField.Expression = "GetDayOfWeek([OrderDate])"
            ' Define the calculated field as 
            ' a grouping criteria for the group header band.
            Dim groupField As GroupField = New GroupField()
            groupField.FieldName = "dayOfWeek"
            ghBand.GroupFields.Add(groupField)
            ' Create two data-bound labels, and add them to 
            ' the corresponding bands.
            Dim ghLabel As XRLabel = New XRLabel()
            ghLabel.DataBindings.Add("Text", report.DataSource, "OrderDate", "{0:dddd}")
            ghLabel.BackColor = Color.Red
            ghBand.Controls.Add(ghLabel)
            Dim detailLabel As XRLabel = New XRLabel()
            detailLabel.DataBindings.Add("Text", report.DataSource, "OrderDate", "{0:MM/dd/yyyy}")
            detailLabel.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Value
            detailLabel.ProcessDuplicatesMode = ProcessDuplicatesMode.Suppress
            detailBand.Controls.Add(detailLabel)
            Return report
        End Function

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a report grouped by days of week, 
            ' and show its print preview.
            Dim report As XtraReport = CreateDataGroupingReport()
            report.ShowPreview()
        End Sub
    End Class
End Namespace
