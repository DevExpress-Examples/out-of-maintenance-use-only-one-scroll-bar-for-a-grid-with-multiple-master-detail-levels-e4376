﻿Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
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
            Me.myGridControl1 = New GridControl()
            Me.myGridView1 = New GridView()
            CType(Me.myGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.myGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'myGridControl1
            '
            Me.myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.myGridControl1.Location = New System.Drawing.Point(0, 0)
            Me.myGridControl1.MainView = Me.myGridView1
            Me.myGridControl1.Name = "myGridControl1"
            Me.myGridControl1.Size = New System.Drawing.Size(645, 454)
            Me.myGridControl1.TabIndex = 0
            Me.myGridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.myGridView1})
            '
            'myGridView1
            '
            Me.myGridView1.GridControl = Me.myGridControl1
            Me.myGridView1.Name = "myGridView1"
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(645, 454)
            Me.Controls.Add(Me.myGridControl1)
            Me.Name = "Form1"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "SingleScrollingGridControl"
            CType(Me.myGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.myGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private myGridControl1 As GridControl
        Private myGridView1 As GridView
    End Class
End Namespace

