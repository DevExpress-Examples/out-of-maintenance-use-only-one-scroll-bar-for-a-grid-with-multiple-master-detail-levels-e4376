// Developer Express Code Central Example:
// Use only one scroll bar for a grid with multiple master/detail levels.
// 
// A grid containing a number of groups (master), each with a number of lines
// (detail) is a representation of an order which is grouped for readability. When
// a group has a greater number of lines then fits on the screen, a scrollbar is
// added to the detail-view and when there are multiple groups the master-view also
// gets a scrollbar. When the user scrolls through the grid, only the master-view
// is scrolled (unless a row is selected, then only the detail-view is scrolled)
// and it feels like the program is behaving oddly, as half the rows are
// skipped.
// To achieve this goal, we need the GridControl to have a height equal
// to the height of all content placed in a master-view. So, the scrollbar does not
// appear in either the master-view or in the detail-view. To allow scrolling, we
// need to put our GridControl into a XtraScrollableControl and set the
// GridControl.Dock property to DockStyle.Top.
// We created the MyGridControl class
// - a descendant of the GridControl. MyGridControl works with MyGridView views and
// includes the CalcGridHeight() method, which is called when the appearance of the
// Master-View is changed.
// To put MyGridControl in the XtraScrollableContainer,
// use the MyGridControl.InitScrolling() method at runtime.
// Please note that if
// you want to change Bounds or Dock properties of MyGridControl at runtime, change
// similar properties of the MyGridControl.ScrollableContainer control.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4376

using System;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Registrator;

namespace CustomGrid {
	public class MyGridViewInfoRegistrator : GridInfoRegistrator {
		public override string ViewName { get { return "MyGridView"; } }
		public override BaseView CreateView(GridControl grid) { return new MyGridView(grid as GridControl); }
        public override BaseViewInfo CreateViewInfo(BaseView view) { return base.CreateViewInfo(view); }
        public override BaseViewPainter CreatePainter(BaseView view) { return base.CreatePainter(view); }
	}
}
