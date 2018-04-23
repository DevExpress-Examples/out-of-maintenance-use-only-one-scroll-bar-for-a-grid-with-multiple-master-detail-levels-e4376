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
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors
Imports System.Windows.Forms
Imports SingleScrollingGridControl
Imports System.Drawing
Imports DevExpress.XtraLayout

Namespace CustomGrid
	Public Class MyGridControl
		Inherits GridControl
		Protected Overrides Function CreateDefaultView() As BaseView
			Return CreateView("MyGridView")
		End Function
		Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
			MyBase.RegisterAvailableViewsCore(collection)
			collection.Add(New MyGridViewInfoRegistrator())
		End Sub

		Public ScrollableContainer As New XtraScrollableControl()

		Public Sub New()
			MyBase.New()
			AddHandler DataSourceChanged, AddressOf MyGridControl_DataSourceChanged
			ScrollableContainer.SetBounds(-10, 0, 10, 10)
			ScrollableContainer.Name = "ScrollControl"
		End Sub

		Public Sub InitScrollingInLayout(ByVal item As LayoutControlItem)
			If item.Control Is Me Then
				Dim layout As LayoutControl = TryCast(Parent, LayoutControl)
				layout.BeginUpdate()
				layout.Controls.Remove(Me)
				layout.Controls.Add(ScrollableContainer)
				item.Control = ScrollableContainer
				ScrollableContainer.Controls.Add(Me)
				layout.EndUpdate()
				Dock = DockStyle.Top
				UpdateGridHeight()
				AddHandler ScrollableContainer.Resize, AddressOf ScrollableContainer_Resize
			End If
		End Sub

		Public Sub InitScrolling()
			ScrollableContainer.Parent = Parent
			ScrollableContainer.SetBounds(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height)
			Dim zIndex As Integer = Me.Parent.Controls.GetChildIndex(Me)
			If Dock <> DockStyle.None Then
				ScrollableContainer.Dock = Dock
				ScrollableContainer.Parent.Controls.SetChildIndex(ScrollableContainer, zIndex)
			End If
			Parent = ScrollableContainer
			Dock = DockStyle.Top
			UpdateGridHeight()
			AddHandler ScrollableContainer.Resize, AddressOf ScrollableContainer_Resize
		End Sub

		Private Sub ScrollableContainer_Resize(ByVal sender As Object, ByVal e As EventArgs)
			Me.Height = Me.CalcGridHeight()
		End Sub

		Private Sub MyGridControl_DataSourceChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateGridHeight()
		End Sub

		Public Function CalcGridHeight() As Integer
			Dim height As Integer = 0
			Dim info As GridViewInfo = TryCast((TryCast(Me.MainView, MyGridView)).GetViewInfo(), GridViewInfo)
			height = info.CalcRealViewHeight(New Rectangle(0, 0, Me.Width, 100000))
			If height < ScrollableContainer.Height Then
				Dock = DockStyle.Fill
			Else
				Dock = DockStyle.Top
			End If
			Return height
		End Function

		Public Sub UpdateGridHeight()
			Me.Height = CalcGridHeight()
		End Sub
	End Class
End Namespace