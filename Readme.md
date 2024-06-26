<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1290)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/GroupByTimeSpan/Form1.cs) (VB: [Form1.vb](./VB/GroupByTimeSpan/Form1.vb))
<!-- default file list end -->
# How to group (sort) a report by days of week


<p>This is an example of applying a <strong>grouping by a time span</strong> to a report at design time.</p><p>In particular, it shows how to group data by <strong>days of the week</strong>, and the same idea works for a <strong>grouping by a month</strong>. In short, this requires creating a  <a href="http://devexpress.com/Help/Content.aspx?help=XtraReports&document=CustomDocument4813.htm">calculated field</a>, which, with the help of built-in date-time functions, returns a zero-based index of the day of the week. Then, a band's grouping criteria is set to this calculated field. Finally, the required data field is represented in the Group Header band, and the required formatting is applied to it.</p><p>See also: <br />
- <a href="https://www.devexpress.com/Support/Center/p/E1650">How to group data</a>;<br />
- <a href="https://www.devexpress.com/Support/Center/p/E1282">How to count the number of groups in a report</a>;<br />
- <a href="https://www.devexpress.com/Support/Center/p/E787">How to implement custom grouping (group by Year and Month)</a>;<br />
- <a href="https://www.devexpress.com/Support/Center/p/E810">How to insert page numbers for groups</a>.</p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-winforms-group-by-days-of-week&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-winforms-group-by-days-of-week&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
