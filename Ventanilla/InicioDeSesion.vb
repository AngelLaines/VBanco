
Imports System.Data
Imports System.Data.OleDb
Public Class FrmInicioDeSesion

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If txtUsuario.Text = "" Then
            MsgBox("Falta el dato usuario")
            txtUsuario.Focus()
            Exit Sub
        End If

        If txtContraseña.Text = "" Then
            MsgBox("Falta el dato contraseña")
            txtContraseña.Focus()
            Exit Sub
        End If

        Try
            Dim sentSQL As String
            sentSQL = "SELECT * FROM USUARIOS WHERE USUARIO='" & Trim(txtUsuario.Text) & "' AND CONTRASEÑA='" & Trim(txtContraseña.Text) & "' AND TIPO='VENTANILLA'"


            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta)

            Dim objAdap As New OleDbDataAdapter(sentSQL, conexion)
            Dim MiConsulta As New DataTable() 'consulta

            conexion.Open()
            objAdap.Fill(MiConsulta)

            If (MiConsulta.Rows.Count) = 0 Then
                MessageBox.Show("El nombre de usuario o la contraseña es incorrecto. Intente de nuevo")
                Exit Sub
            Else
                txtTemp.Visible = True

                txtTemp.DataBindings.Add("text", MiConsulta, "idempleado")
                IdEmpActivo = txtTemp.Text
                txtTemp.DataBindings.Clear()
                '****
                txtTemp.Visible = False


            End If

            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Exit Sub
        End Try

        Try

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta)
            Dim sentSQL As String
            sentSQL = "SELECT MAX(NoAcceso) AS MAXIMO FROM ACCESOS"

            Dim MiComando As New OleDbCommand(sentSQL, conexion)

            conexion.Open()

            If IsDBNull(MiComando.ExecuteScalar()) = True Then
                'no hay registros coincidentes
                txtAcceso.Text = "1"
                'txtNumVenta.Text = Format(Now, "ddMMyyyy") & "0001"

            Else
                txtAcceso.Visible = True
                txtAcceso.Text = (MiComando.ExecuteScalar() + 1).ToString
                txtAcceso.Visible = False
                NumAcceso = txtAcceso.Text
            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Exit Sub
        End Try

        Try
            Dim sentSQLInsert As String


            sentSQLInsert = "INSERT INTO ACCESOS(noacceso, idEmpleado, FECHA, HoraEntrada) VALUES(" & txtAcceso.Text & "," & IdEmpActivo & ",'" & Format(Now, "dd/MM/yyyy") & "','" & Format(Now, "hh:mm") & "')"



            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta)

            Dim comando As New OleDbCommand(sentSQLInsert, conexion)

            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()

            frmMenu.Show()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Exit Sub
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        End
    End Sub
End Class
