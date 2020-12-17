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
			myGridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Embedded
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

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
