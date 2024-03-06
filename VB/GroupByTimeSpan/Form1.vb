#Region "usings"
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.XtraReports.UI
#End Region

Namespace GroupByTimeSpan
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub
		#Region "createreport"
		Public Function CreateDataGroupingReport() As XtraReport
			' Create a report, and bind it to a data source.
			Dim report As New XtraReport()

			Dim sqlDataSource As SqlDataSource = New SqlDataSource(New SQLiteConnectionParameters() With {
				.FileName = "nwind.db",
				.Password = Nothing
			})
			Dim queryOrders As SelectQuery = SelectQueryFluentBuilder.AddTable("Orders").SelectAllColumnsFromTable().Filter("[OrderDate] > #2016-01-01#").Build("Orders")
			sqlDataSource.Queries.Add(queryOrders)
			sqlDataSource.Fill()

			report.DataSource = sqlDataSource
			report.DataMember = "Orders"

			' Create a Detail band, and add it to the report.
			Dim detailBand As New DetailBand()
			detailBand.Height = 20
			report.Bands.Add(detailBand)

			' Create a Group Header band, and add it to the report.
			Dim ghBand As New GroupHeaderBand()
			ghBand.Height = 20
			report.Bands.Add(ghBand)

			' Create a calculated field, and add it to the collection.
			Dim calcField As New CalculatedField(report.DataSource, report.DataMember)
			calcField.Name = "calcDayOfWeek"
			calcField.FieldType = FieldType.None
			calcField.Expression = "GetDayOfWeek([OrderDate])"
			report.CalculatedFields.Add(calcField)

			' Specify the calculated field as a grouping basis.
			Dim groupField As New GroupField()
			groupField.FieldName = "calcDayOfWeek"
			ghBand.GroupFields.Add(groupField)

			' Create two data-bound labels and add them to the related report bands.
			Dim ghLabel As New XRLabel()
			ghLabel.DataBindings.Add("Text", report.DataSource, "Orders.OrderDate", "{0:dddd}")
			ghLabel.BackColor = Color.SteelBlue
			ghLabel.ForeColor = Color.White
			ghBand.Controls.Add(ghLabel)

			Dim detailLabel As New XRLabel()
			detailLabel.DataBindings.Add("Text", report.DataSource, "Orders.OrderDate", "{0:MM/dd/yyyy}")
			detailLabel.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Value
			detailLabel.ProcessDuplicatesMode = ProcessDuplicatesMode.Suppress
			detailLabel.LeftF = 20
			detailBand.Controls.Add(detailLabel)

			Return report
		End Function
		#End Region
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a report grouped by days of week, 
			' and show its print preview.
			Dim report As XtraReport = CreateDataGroupingReport()
			report.SaveLayoutToXml("test.repx")
			report.ShowPreview()

		End Sub

	End Class
End Namespace
