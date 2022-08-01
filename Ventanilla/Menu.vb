Imports System.Data
Imports System.Data.OleDb
Public Class FrmMenu

    Private Sub FrmMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        
    End Sub

    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Try
            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta)

            Dim SentSQLUpdate As String

            SentSQLUpdate = "Update [accesos] Set HoraSalida='" & Format(Now, "hh:mm") & "' where noacceso=" & NumAcceso

            Dim comando As New OleDbCommand(SentSQLUpdate, conexion)

            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
            End
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub DepositoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepositoToolStripMenuItem.Click

    End Sub

    Private Sub RetiroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetiroToolStripMenuItem.Click
        FrmDeposito.Show()
        Me.Close()
    End Sub

    Private Sub RetiroToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RetiroToolStripMenuItem1.Click
        frmRetiro.Show()
        Me.Close()
    End Sub
    Private Sub ConsultaMovimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaMovimientosToolStripMenuItem.Click

    End Sub

    Private Sub MovimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosToolStripMenuItem.Click
        dtConsultaDeMovimientos.Show()
        Me.Close()
    End Sub
End Class