<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128601139/12.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1290)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
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

