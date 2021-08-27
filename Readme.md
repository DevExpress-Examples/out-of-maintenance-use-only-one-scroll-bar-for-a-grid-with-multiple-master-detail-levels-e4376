<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128632666/12.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4376)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))**
* [MyGridControl.cs](./CS/GridControlDescendant/MyGridControl.cs) (VB: [MyGridControl.vb](./VB/GridControlDescendant/MyGridControl.vb))
* [MyGridRegistration.cs](./CS/GridControlDescendant/MyGridRegistration.cs) (VB: [MyGridRegistration.vb](./VB/GridControlDescendant/MyGridRegistration.vb))
* [MyGridView.cs](./CS/GridControlDescendant/MyGridView.cs) (VB: [MyGridView.vb](./VB/GridControlDescendant/MyGridView.vb))
<!-- default file list end -->
# Use only one scroll bar for a grid with multiple master/detail levels.


A grid containing a number of groups (master), each with a number of lines (detail) is a representation of an order which is grouped for readability. When a group has a greater number of lines then fits on the screen, a scrollbar is added to the detail-view and when there are multiple groups the master-view also gets a scrollbar. When the user scrolls through the grid, only the master-view is scrolled (unless a row is selected, then only the detail-view is scrolled) and it feels like the program is behaving oddly, as half the rows are skipped.</p>
<p>To achieve this goal, we need the GridControl to have a height equal to the height of all content placed in a master-view. So, the scrollbar does not appear in either the master-view or in the detail-view. To allow scrolling, we need to put our GridControl into a XtraScrollableControl and set the GridControl.Dock property to DockStyle.Top.</p>
<p>We created the MyGridControl class - a descendant of the GridControl. MyGridControl works with MyGridView views and includes the CalcGridHeight() method, which is called when the appearance of the Master-View is changed.</p>
<p>To put MyGridControl in the XtraScrollableContainer, use the MyGridControl.InitScrolling method at runtime. Use the MyGridControl.InitScrollingInLayout method to initialize scrolling in a LayoutControlItem. </p>
<p>Please note that if you want to change Bounds or Dock properties of MyGridControl at runtime, change similar properties of the MyGridControl.ScrollableContainer control.</p>

<br/>


