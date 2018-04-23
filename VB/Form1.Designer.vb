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
Namespace SingleScrollingGridControl
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.myGridControl1 = New CustomGrid.MyGridControl()
			Me.myGridView1 = New CustomGrid.MyGridView()
			Me.myGridControl2 = New CustomGrid.MyGridControl()
			Me.myGridView6 = New CustomGrid.MyGridView()
			Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
			Me.textEdit2 = New DevExpress.XtraEditors.TextEdit()
			Me.textEdit1 = New DevExpress.XtraEditors.TextEdit()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
			CType(Me.myGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.myGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.myGridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.myGridView6, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.layoutControl1.SuspendLayout()
			CType(Me.textEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' myGridControl1
			' 
			Me.myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.myGridControl1.Location = New System.Drawing.Point(796, 0)
			Me.myGridControl1.MainView = Me.myGridView1
			Me.myGridControl1.Name = "myGridControl1"
			Me.myGridControl1.Size = New System.Drawing.Size(534, 474)
			Me.myGridControl1.TabIndex = 0
			Me.myGridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.myGridView1})
			' 
			' myGridView1
			' 
			Me.myGridView1.GridControl = Me.myGridControl1
			Me.myGridView1.Name = "myGridView1"
			Me.myGridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True
			Me.myGridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
			' 
			' myGridControl2
			' 
			Me.myGridControl2.Location = New System.Drawing.Point(120, 67)
			Me.myGridControl2.MainView = Me.myGridView6
			Me.myGridControl2.Margin = New System.Windows.Forms.Padding(13)
			Me.myGridControl2.Name = "myGridControl2"
			Me.myGridControl2.Size = New System.Drawing.Size(652, 359)
			Me.myGridControl2.TabIndex = 2
			Me.myGridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.myGridView6})
			' 
			' myGridView6
			' 
			Me.myGridView6.GridControl = Me.myGridControl2
			Me.myGridView6.Name = "myGridView6"
			Me.myGridView6.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True
			Me.myGridView6.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
			' 
			' layoutControl1
			' 
			Me.layoutControl1.Controls.Add(Me.textEdit2)
			Me.layoutControl1.Controls.Add(Me.myGridControl2)
			Me.layoutControl1.Controls.Add(Me.textEdit1)
			Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Left
			Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControl1.Name = "layoutControl1"
			Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(596, 243, 250, 350)
			Me.layoutControl1.Root = Me.layoutControlGroup1
			Me.layoutControl1.Size = New System.Drawing.Size(796, 474)
			Me.layoutControl1.TabIndex = 1
			Me.layoutControl1.Text = "layoutControl1"
			' 
			' textEdit2
			' 
			Me.textEdit2.Location = New System.Drawing.Point(108, 12)
			Me.textEdit2.Name = "textEdit2"
			Me.textEdit2.Size = New System.Drawing.Size(676, 20)
			Me.textEdit2.StyleController = Me.layoutControl1
			Me.textEdit2.TabIndex = 5
			' 
			' textEdit1
			' 
			Me.textEdit1.Location = New System.Drawing.Point(120, 430)
			Me.textEdit1.Name = "textEdit1"
			Me.textEdit1.Size = New System.Drawing.Size(652, 20)
			Me.textEdit1.StyleController = Me.layoutControl1
			Me.textEdit1.TabIndex = 4
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.CustomizationFormText = "Root"
			Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlGroup2, Me.layoutControlItem3})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "Root"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(796, 474)
			Me.layoutControlGroup1.Text = "Root"
			Me.layoutControlGroup1.TextVisible = False
			' 
			' layoutControlGroup2
			' 
			Me.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2"
			Me.layoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem1, Me.layoutControlItem2})
			Me.layoutControlGroup2.Location = New System.Drawing.Point(0, 24)
			Me.layoutControlGroup2.Name = "layoutControlGroup2"
			Me.layoutControlGroup2.Size = New System.Drawing.Size(776, 430)
			Me.layoutControlGroup2.Text = "layoutControlGroup2"
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.myGridControl2
			Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
			Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(752, 363)
			Me.layoutControlItem1.Text = "layoutControlItem1"
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(93, 13)
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.textEdit1
			Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
			Me.layoutControlItem2.Location = New System.Drawing.Point(0, 363)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(752, 24)
			Me.layoutControlItem2.Text = "layoutControlItem2"
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(93, 13)
			' 
			' layoutControlItem3
			' 
			Me.layoutControlItem3.Control = Me.textEdit2
			Me.layoutControlItem3.CustomizationFormText = "layoutControlItem3"
			Me.layoutControlItem3.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem3.Name = "layoutControlItem3"
			Me.layoutControlItem3.Size = New System.Drawing.Size(776, 24)
			Me.layoutControlItem3.Text = "layoutControlItem3"
			Me.layoutControlItem3.TextSize = New System.Drawing.Size(93, 13)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1330, 474)
			Me.Controls.Add(Me.myGridControl1)
			Me.Controls.Add(Me.layoutControl1)
			Me.Name = "Form1"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "SingleScrollingGridControl"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.myGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.myGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.myGridControl2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.myGridView6, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.layoutControl1.ResumeLayout(False)
			CType(Me.textEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private myGridControl1 As CustomGrid.MyGridControl
		Private myGridView1 As CustomGrid.MyGridView
		Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
		Private myGridControl2 As CustomGrid.MyGridControl
		Private myGridView6 As CustomGrid.MyGridView
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private textEdit1 As DevExpress.XtraEditors.TextEdit
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
		Private textEdit2 As DevExpress.XtraEditors.TextEdit
		Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
	End Class
End Namespace

