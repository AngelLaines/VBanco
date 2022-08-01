Imports System.Data
Imports System.Data.OleDb
Public Class dtConsultaDeMovimientos

    Public CodigoBuscado As String
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        FrmMenu.Show()
        Me.Close()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If txtIdCliente.Text = 0 Then
            MsgBox("falta id del cliente")
        Else
            Try
                Dim sentSQL As String
                Dim Conexion As New OleDbConnection()
                sentSQL = "Select * from Movimientos where idcliente=" & txtIdCliente.Text
                Conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta) 'para bd de office 2007 y 2010
                Dim ObjDataSet As New DataSet()
                Dim objAdap As New OleDbDataAdapter(sentSQL, Conexion)
                Dim MiConsulta As New DataTable()
                ' consulta
                Conexion.Open()
                objAdap.Fill(ObjDataSet)
                DtConsulta.DataSource = ObjDataSet.Tables(0)
                Conexion.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString())
            End Try

        End If
    End Sub

    Private Sub DtConsulta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtConsulta.CellContentClick
      
    End Sub
End Class