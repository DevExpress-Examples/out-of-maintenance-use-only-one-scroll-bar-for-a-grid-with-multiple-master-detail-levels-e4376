' Developer Express Code Central Example:
' Use only one scroll bar for a grid with multiple master/detail levels.
' 
' A grid containing a number of groups (master), each with a number of lines
' (detail) is a representation of an order which is grouped for readability. When
' a group has a greater number of lines then fits on the screen, a scrollbar is
' added to the detail-view and when there are multiple groups the master-view also
' gets a scrollbar. When the user scrolls through the grid, only the master-view
' is scrolled (unless a row is selected, then only the detail-view is scrolled)
' and it feels like the program is behaving oddly, as half the rows are
' skipped.
' To achieve this goal, we need the GridControl to have a height equal
' to the height of all content placed in a master-view. So, the scrollbar does not
' appear in either the master-view or in the detail-view. To allow scrolling, we
' need to put our GridControl into a XtraScrollableControl and set the
' GridControl.Dock property to DockStyle.Top.
' We created the MyGridControl class
' - a descendant of the GridControl. MyGridControl works with MyGridView views and
' includes the CalcGridHeight() method, which is called when the appearance of the
' Master-View is changed.
' To put MyGridControl in the XtraScrollableContainer,
' use the MyGridControl.InitScrolling() method at runtime.
' Please note that if
' you want to change Bounds or Dock properties of MyGridControl at runtime, change
' similar properties of the MyGridControl.ScrollableContainer control.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4376


Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base


Namespace CustomGrid
	Public Class MyGridView
		Inherits GridView
		Public Sub New()
			Me.New(Nothing)

			OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True
			AddHandler MasterRowExpanded, AddressOf MyGridView_MasterRowExpanded
			AddHandler MasterRowCollapsed, AddressOf MyGridView_MasterRowCollapsed
		End Sub
		Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
			MyBase.New(grid)
			Me.VertScrollVisibility = ScrollVisibility.Never
			AddHandler EndGrouping, AddressOf MyGridView_EndGrouping
		End Sub

		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property

		Public Overrides Sub ZoomView()
			MyBase.ZoomView()
			TryCast(Me.GridControl, MyGridControl).UpdateGridHeight()
		End Sub

		Public Overrides Sub NormalView()
			MyBase.NormalView()
			TryCast(Me.GridControl, MyGridControl).UpdateGridHeight()
		End Sub

		Private Sub MyGridView_MasterRowExpanded(ByVal sender As Object, ByVal e As CustomMasterRowEventArgs)
			TryCast(Me.GridControl, MyGridControl).UpdateGridHeight()
		End Sub

		Private Sub MyGridView_MasterRowCollapsed(ByVal sender As Object, ByVal e As CustomMasterRowEventArgs)
			TryCast(Me.GridControl, MyGridControl).UpdateGridHeight()
		End Sub

		Private Sub MyGridView_EndGrouping(ByVal sender As Object, ByVal e As EventArgs)
			TryCast(Me.GridControl, MyGridControl).UpdateGridHeight()
		End Sub
	End Class
End Namespace
