# How to group (sort) a report by days of week


<p>This is an example of applying a <strong>grouping by a time span</strong> to a report at design time.</p><p>In particular, it shows how to group data by <strong>days of the week</strong>, and the same idea works for a <strong>grouping by a month</strong>. In short, this requires creating a  <a href="http://devexpress.com/Help/Content.aspx?help=XtraReports&document=CustomDocument4813.htm">calculated field</a>, which, with the help of built-in date-time functions, returns a zero-based index of the day of the week. Then, a band's grouping criteria is set to this calculated field. Finally, the required data field is represented in the Group Header band, and the required formatting is applied to it.</p><p>See also: <br />
- <a href="https://www.devexpress.com/Support/Center/p/E1650">How to group data</a>;<br />
- <a href="https://www.devexpress.com/Support/Center/p/E1282">How to count the number of groups in a report</a>;<br />
- <a href="https://www.devexpress.com/Support/Center/p/E787">How to implement custom grouping (group by Year and Month)</a>;<br />
- <a href="https://www.devexpress.com/Support/Center/p/E810">How to insert page numbers for groups</a>.</p>

<br/>


