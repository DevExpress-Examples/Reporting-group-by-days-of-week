using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
// ...

namespace GroupByTimeSpan {
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }

        public XtraReport CreateDataGroupingReport() {
            // Create a report, and bind it to a data source.
            XtraReport report = new XtraReport();
            nwindDataSet ds = new nwindDataSet();
            new nwindDataSetTableAdapters.OrdersTableAdapter().Fill(ds.Orders);
            report.DataSource = ds;
            report.DataMember = "Orders";

            // Create a detail band and add it to the report.
            DetailBand detailBand = new DetailBand();
            detailBand.Height = 20;
            report.Bands.Add(detailBand);

            // Create a group header band and add it to the report.
            GroupHeaderBand ghBand = new GroupHeaderBand();
            ghBand.Height = 20;
            report.Bands.Add(ghBand);

            // Create a calculated field, and add it to the report's collection
            CalculatedField calcField = new CalculatedField(report.DataSource, report.DataMember);
            report.CalculatedFields.Add(calcField);

            // Define its name, field type and expression.
            // Note that numerous built-in date-time functions are supported.
            calcField.Name = "dayOfWeek";
            calcField.FieldType = FieldType.None;
            calcField.Expression = "GetDayOfWeek([OrderDate])";

            // Define the calculated field as 
            // a grouping criteria for the group header band.
            GroupField groupField = new GroupField();
            groupField.FieldName = "dayOfWeek";
            ghBand.GroupFields.Add(groupField);
           
            // Create two data-bound labels, and add them to 
            // the corresponding bands.
            XRLabel ghLabel = new XRLabel();
            ghLabel.DataBindings.Add("Text", report.DataSource, "OrderDate", "{0:dddd}");
            ghLabel.BackColor = Color.Red;
            ghBand.Controls.Add(ghLabel);

            XRLabel detailLabel = new XRLabel();
            detailLabel.DataBindings.Add("Text", report.DataSource, "OrderDate", "{0:MM/dd/yyyy}");
            detailLabel.ProcessDuplicates = ValueSuppressType.Suppress;
            detailBand.Controls.Add(detailLabel);

            return report;
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create a report grouped by days of week, 
            // and show its print preview.
            XtraReport report = CreateDataGroupingReport();
            report.ShowPreview();
        }

    }
}