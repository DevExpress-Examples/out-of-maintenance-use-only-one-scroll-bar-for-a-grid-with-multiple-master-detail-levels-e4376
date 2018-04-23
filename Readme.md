# Use only one scroll bar for a grid with multiple master/detail levels.


<p><strong>[UPDATED]</strong>  Starting with <strong>v16.2</strong>, this feature is supported out of the box. Enable it using the <strong>GridView.OptionsDetail.DetailMode</strong> property. Please see the <a href="https://documentation.devexpress.com/#windowsforms/DevExpressXtraGridViewsGridGridOptionsDetail_DetailModetopic">GridOptionsDetail.DetailMode</a> help topic for more information.<br><br>A grid containing a number of groups (master), each with a number of lines (detail) is a representation of an order which is grouped for readability. When a group has a greater number of lines then fits on the screen, a scrollbar is added to the detail-view and when there are multiple groups the master-view also gets a scrollbar. When the user scrolls through the grid, only the master-view is scrolled (unless a row is selected, then only the detail-view is scrolled) and it feels like the program is behaving oddly, as half the rows are skipped.</p>
<p>To achieve this goal, we need the GridControl to have a height equal to the height of all content placed in a master-view. So, the scrollbar does not appear in either the master-view or in the detail-view. To allow scrolling, we need to put our GridControl into a XtraScrollableControl and set the GridControl.Dock property to DockStyle.Top.</p>
<p>We created the MyGridControl class - a descendant of the GridControl. MyGridControl works with MyGridView views and includes the CalcGridHeight() method, which is called when the appearance of the Master-View is changed.</p>
<p>To put MyGridControl in the XtraScrollableContainer, use the MyGridControl.InitScrolling method at runtime. Use the MyGridControl.InitScrollingInLayout method to initialize scrolling in a LayoutControlItem. </p>
<p>Please note that if you want to change Bounds or Dock properties of MyGridControl at runtime, change similar properties of the MyGridControl.ScrollableContainer control.</p>

<br/>


