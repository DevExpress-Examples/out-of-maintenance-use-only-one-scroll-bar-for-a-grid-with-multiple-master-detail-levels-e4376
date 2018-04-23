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
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using SingleScrollingGridControl;
using System.Drawing;
using DevExpress.XtraLayout;

namespace CustomGrid
{
    public class MyGridControl : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            return CreateView("MyGridView");
        }
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridViewInfoRegistrator());
        }

        public XtraScrollableControl ScrollableContainer = new XtraScrollableControl();

        public MyGridControl()
            : base()
        {
            this.DataSourceChanged += new EventHandler(MyGridControl_DataSourceChanged);
            ScrollableContainer.SetBounds(-10, 0, 10, 10);
            ScrollableContainer.Name = "ScrollControl";
        }

        public void InitScrollingInLayout(LayoutControlItem item)
        {
            if (item.Control == this)
            {
                LayoutControl layout = Parent as LayoutControl;
                layout.BeginUpdate();
                layout.Controls.Remove(this);
                layout.Controls.Add(ScrollableContainer);
                item.Control = ScrollableContainer;
                ScrollableContainer.Controls.Add(this);
                layout.EndUpdate();
                Dock = DockStyle.Top;
                UpdateGridHeight();
                ScrollableContainer.Resize += new EventHandler(ScrollableContainer_Resize);
            }
        }

        public void InitScrolling()
        {
            ScrollableContainer.Parent = Parent;
            ScrollableContainer.SetBounds(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
            int zIndex = this.Parent.Controls.GetChildIndex(this);
            if (Dock != DockStyle.None)
            {
                ScrollableContainer.Dock = Dock;
                ScrollableContainer.Parent.Controls.SetChildIndex(ScrollableContainer, zIndex);
            }
            Parent = ScrollableContainer;
            Dock = DockStyle.Top;
            UpdateGridHeight();
            ScrollableContainer.Resize += new EventHandler(ScrollableContainer_Resize);
        }

        void ScrollableContainer_Resize(object sender, EventArgs e)
        {
            this.Height = this.CalcGridHeight();
        }

        void MyGridControl_DataSourceChanged(object sender, EventArgs e)
        {
            UpdateGridHeight();
        }

        public int CalcGridHeight()
        {
            int height = 0;
            GridViewInfo info = (this.MainView as MyGridView).GetViewInfo() as GridViewInfo;
            height = info.CalcRealViewHeight(new Rectangle(0, 0, this.Width, 100000));
            if (height < ScrollableContainer.Height)
                Dock = DockStyle.Fill;
            else
                Dock = DockStyle.Top;
            return height;
        }

        public void UpdateGridHeight()
        {
            this.Height = CalcGridHeight();
        }
    }
}