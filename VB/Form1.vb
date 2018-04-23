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
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraLayout
Imports System.Drawing

Namespace SingleScrollingGridControl
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			myGridControl1.InitScrolling()
			myGridControl2.InitScrollingInLayout(layoutControlItem1)

			Dim master As Integer = 20
			Dim child1 As Integer = 16
			Dim list As New BindingList(Of MyObject)()
			For i As Integer = 0 To master - 1
				Dim childList As New BindingList(Of Child)()
				For j As Integer = 0 To child1 - 1
					Dim index As Integer = i * child1 + j
					Dim ch As New Child(index, "Name " & index.ToString())
					childList.Add(ch)
				Next j
				Dim obj As New MyObject(i, "Name " & i.ToString(), childList)
				list.Add(obj)
			Next i
			myGridControl2.DataSource = list
			myGridControl1.DataSource = list
		End Sub

	End Class
	Friend Class MyObject
		Private children_Renamed As BindingList(Of Child)
		Private name_Renamed As String
		Private id_Renamed As Integer

		Public Property ID() As Integer
			Get
				Return id_Renamed
			End Get
			Set(ByVal value As Integer)
				id_Renamed = value
			End Set
		End Property

		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				name_Renamed = value
			End Set
		End Property

		Public Sub New(ByVal i As Integer, ByVal n As String, ByVal list As BindingList(Of Child))
			id_Renamed = i
			name_Renamed = n
			Children = list
		End Sub

		Public Property Children() As BindingList(Of Child)
			Get
				Return children_Renamed
			End Get
			Set(ByVal value As BindingList(Of Child))
				children_Renamed = value
			End Set
		End Property
	End Class

	Friend Class Child
		Private name_Renamed As String
		Private id_Renamed As Integer

		Public Property ID() As Integer
			Get
				Return id_Renamed
			End Get
			Set(ByVal value As Integer)
				id_Renamed = value
			End Set
		End Property

		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				name_Renamed = value
			End Set
		End Property

		Public Sub New(ByVal i As Integer, ByVal n As String)
			id_Renamed = i
			name_Renamed = n
		End Sub
	End Class
End Namespace
