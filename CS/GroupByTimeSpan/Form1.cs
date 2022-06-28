using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;

namespace GroupByTimeSpan {
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }
        public XtraReport CreateDataGroupingReport() {
            // Create a report, and bind it to a data source.
            XtraReport report = new XtraReport();

            SqlDataSource sqlDataSource = new SqlDataSource(
                new SQLiteConnectionParameters() {
                    FileName = "nwind.db",
                    Password = null
                });
            SelectQuery queryOrders = SelectQueryFluentBuilder
                .AddTable("Orders")
                .SelectAllColumnsFromTable()
                .Filter("[OrderDate] > #2016-01-01#")
                .Build("Orders");
            sqlDataSource.Queries.Add(queryOrders);
            sqlDataSource.Fill();

            report.DataSource = sqlDataSource;
            report.DataMember = "Orders";

            // Create a Detail band, and add it to the report.
            DetailBand detailBand = new DetailBand();
            detailBand.Height = 20;
            report.Bands.Add(detailBand);

            // Create a Group Header band, and add it to the report.
            GroupHeaderBand ghBand = new GroupHeaderBand();
            ghBand.Height = 20;
            report.Bands.Add(ghBand);

            // Create a calculated field, and add it to the collection.
            CalculatedField calcField = new CalculatedField(report.DataSource, report.DataMember);
            calcField.Name = "calcDayOfWeek";
            calcField.FieldType = FieldType.None;
            calcField.Expression = "GetDayOfWeek([OrderDate])";
            report.CalculatedFields.Add(calcField);

            // Specify the calculated field as a grouping basis.
            GroupField groupField = new GroupField();
            groupField.FieldName = "calcDayOfWeek";
            ghBand.GroupFields.Add(groupField);

            // Create two data-bound labels and add them to the related report bands.
            XRLabel ghLabel = new XRLabel();
            ghLabel.DataBindings.Add("Text", report.DataSource, "Orders.OrderDate", "{0:dddd}");
            ghLabel.BackColor = Color.SteelBlue;
            ghLabel.ForeColor = Color.White;
            ghBand.Controls.Add(ghLabel);

            XRLabel detailLabel = new XRLabel();
            detailLabel.DataBindings.Add("Text", report.DataSource, "Orders.OrderDate", "{0:MM/dd/yyyy}");
            detailLabel.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Value;
            detailLabel.ProcessDuplicatesMode = ProcessDuplicatesMode.Suppress;
            detailLabel.LeftF = 20;
            detailBand.Controls.Add(detailLabel);

            return report;
        }
        private void button1_Click(object sender, EventArgs e) {
            // Create a report grouped by days of week, 
            // and show its print preview.
            XtraReport report = CreateDataGroupingReport();
            report.SaveLayoutToXml("test.repx");
            report.ShowPreview();

        }

    }
}
