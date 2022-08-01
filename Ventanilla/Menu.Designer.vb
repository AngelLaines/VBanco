<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DepositoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RetiroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RetiroToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaMovimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DepositoToolStripMenuItem, Me.MovimientosToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(371, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DepositoToolStripMenuItem
        '
        Me.DepositoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RetiroToolStripMenuItem, Me.RetiroToolStripMenuItem1})
        Me.DepositoToolStripMenuItem.Name = "DepositoToolStripMenuItem"
        Me.DepositoToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.DepositoToolStripMenuItem.Text = "Actividad"
        '
        'RetiroToolStripMenuItem
        '
        Me.RetiroToolStripMenuItem.Name = "RetiroToolStripMenuItem"
        Me.RetiroToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.RetiroToolStripMenuItem.Text = "Deposito"
        '
        'RetiroToolStripMenuItem1
        '
        Me.RetiroToolStripMenuItem1.Name = "RetiroToolStripMenuItem1"
        Me.RetiroToolStripMenuItem1.Size = New System.Drawing.Size(121, 22)
        Me.RetiroToolStripMenuItem1.Text = "Retiro"
        '
        'MovimientosToolStripMenuItem
        '
        Me.MovimientosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConsultaMovimientosToolStripMenuItem})
        Me.MovimientosToolStripMenuItem.Name = "MovimientosToolStripMenuItem"
        Me.MovimientosToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.MovimientosToolStripMenuItem.Text = "Movimientos"
        '
        'ConsultaMovimientosToolStripMenuItem
        '
        Me.ConsultaMovimientosToolStripMenuItem.Name = "ConsultaMovimientosToolStripMenuItem"
        Me.ConsultaMovimientosToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ConsultaMovimientosToolStripMenuItem.Text = "Consulta Movimientos"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'FrmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 263)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DepositoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RetiroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RetiroToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MovimientosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaMovimientosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
