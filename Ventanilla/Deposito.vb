Imports System.Data
Imports System.Data.OleDb
Public Class FrmDeposito

    Public CodigoBuscado As String

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Try
            Dim SentSQL As String
            SentSQL = "Select * FROM CUENTAS Where IDCliente=" & txtCodigo.Text

            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta) '***para bd de office 2007 2010 

            Dim objAdap As New OleDbDataAdapter(SentSQL, conexion)
            Dim MiConsulta As New DataTable()

            conexion.Open()
            objAdap.Fill(MiConsulta)
            If (MiConsulta.Rows.Count) = 0 Then
                'no hay registros coincidentes.
                MessageBox.Show("el con codigo" & txtCodigo.Text & "no existe. Verifique")
                txtNoCuenta.Clear()

                txtNoCuenta.Clear()
            Else
                'enlazamos de nuevo los controles textbox con el
                'objeto DataTable devuelto.
                txtNoCuenta.Enabled = True
                txtNoCuenta.Enabled = True
                txtNumTarjeta.Enabled = True
                BtnAceptar.Enabled = True

                txtNoCuenta.DataBindings.Add("text", MiConsulta, "NoCuenta")
                CodigoBuscado = txtCodigo.Text
                txtNoCuenta.DataBindings.Clear()

            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
        Try
            Dim SentSQL As String
            SentSQL = "Select nombre,ApellidoMaterno,ApellidoPaterno FROM clientes Where IDCliente=" & txtCodigo.Text

            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta) '***para bd de office 2007 2010 

            Dim objAdap As New OleDbDataAdapter(SentSQL, conexion)
            Dim MiConsulta As New DataTable()

            conexion.Open()
            objAdap.Fill(MiConsulta)
            If IsDBNull(MiConsulta.Rows.Count()) = True Then


                'no hay registros coincidentes.
                MessageBox.Show("el con codigo" & txtCodigo.Text & "no existe. Verifique")
            Else
                'enlazamos de nuevo los controles textbox con el
                'objeto DataTable devuelto.
                txtNoCuenta.Enabled = True
                txtNoCuenta.Enabled = True
                txtNomProp.Enabled = True
                BtnAceptar.Enabled = True

                txtNomProp.DataBindings.Add("text", MiConsulta, "Nombre")
                NomProp = txtNomProp.Text
                txtNomProp.DataBindings.Clear()

                txtNomProp.DataBindings.Add("text", MiConsulta, "ApellidoPaterno")
                NomProp = NomProp & " " & txtNomProp.Text
                txtNomProp.DataBindings.Clear()

                txtNomProp.DataBindings.Add("text", MiConsulta, "ApellidoMaterno")
                NomProp = NomProp & " " & txtNomProp.Text
                txtNomProp.DataBindings.Clear()

            End If
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub txtNombProp_TextChanged(sender As Object, e As EventArgs) Handles txtNoCuenta.TextChanged

    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If txtCantidad.Text = "" Then
            MsgBox("Falta la cantidad del deposito.")
            txtCantidad.Focus()
            Exit Sub
        End If
        Try
            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta)

            Dim sentsql As String
            sentsql = "insert into Movimientos values(" & txtMovimiento.Text & ",'" & Format(Now, "dd/MM/yyyy") & "','" & Format(Now, "hh:mm") & "','Deposito'," & txtCantidad.Text & "," & txtCodigo.Text & "," & txtNoCuenta.Text & "," & IdEmpActivo & ")"

            Dim comando As New OleDbCommand(sentsql, conexion)
            Dim miconsulta As New DataTable

            conexion.Open()
            comando.ExecuteNonQuery()
            MessageBox.Show("El deposito ha sido guardado con exito.", "Guardando deposito...")

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Exit Sub
        End Try
        Try
            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta)

            Dim sentsql As String
            sentsql = "UPDATE CUENTAS SET Saldo=([Saldo]+" & txtCantidad.Text & ") where NOCUENTA=" & txtNoCuenta.Text()

            Dim comando As New OleDbCommand(sentsql, conexion)
            Dim miconsulta As New DataTable

            conexion.Open()
            comando.ExecuteNonQuery()


            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Exit Sub
        End Try

        Try

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta)
            Dim sentSQL As String
            sentSQL = "SELECT MAX(Nomovimiento) AS MAXIMO FROM movimientos"

            Dim MiComando As New OleDbCommand(sentSQL, conexion)

            conexion.Open()

            If IsDBNull(MiComando.ExecuteScalar()) = True Then
                'no hay registros coincidentes
                txtMovimiento.Text = "1"
                'txtNumVenta.Text = Format(Now, "ddMMyyyy") & "0001"

            Else
                txtMovimiento.Text = (MiComando.ExecuteScalar() + 1).ToString
            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Exit Sub
        End Try

        Try
            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta)

            Dim SentSQLinsert As String

            SentSQLinsert = "INSERT INTO [OPERACIONES](OPERACION, QUIEN, [AQUIEN], HORA, NOACCESO) VALUES('DEPOSITO EFECTIVO'," & IdEmpActivo & "," & txtCodigo.Text & ",'" & Format(Now, "hh:mm") & "'," & NumAcceso & ")"
            Dim comando As New OleDbCommand(SentSQLinsert, conexion)

            conexion.Open()
            comando.ExecuteNonQuery()

            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        FrmMenu.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtNoCuenta.Clear()
        txtCantidad.Clear()
        txtCodigo.Clear()
    End Sub

    Private Sub FrmDeposito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta)
            Dim sentSQL As String
            sentSQL = "SELECT MAX(Nomovimiento) AS MAXIMO FROM movimientos"

            Dim MiComando As New OleDbCommand(sentSQL, conexion)

            conexion.Open()

            If IsDBNull(MiComando.ExecuteScalar()) = True Then
                'no hay registros coincidentes
                txtMovimiento.Text = "1"
                'txtNumVenta.Text = Format(Now, "ddMMyyyy") & "0001"

            Else
                txtMovimiento.Text = (MiComando.ExecuteScalar() + 1).ToString
            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Exit Sub
        End Try
    End Sub

    Private Sub BtnBuscar2_Click(sender As Object, e As EventArgs) Handles BtnBuscar2.Click
        Try
            Dim SentSQL As String
            SentSQL = "Select idcliente FROM tarjetas Where notarjeta='" & txtNumTarjeta.Text & "'"

            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta) '***para bd de office 2007 2010 

            Dim objAdap As New OleDbDataAdapter(SentSQL, conexion)
            Dim MiConsulta As New DataTable()

            conexion.Open()
            objAdap.Fill(MiConsulta)
            If (MiConsulta.Rows.Count) = 0 Then
                'no hay registros coincidentes.
                MessageBox.Show("el con codigo" & txtNumTarjeta.Text & "no existe. Verifique")
                txtNoCuenta.Clear()

                txtNoCuenta.Clear()
            Else
                'enlazamos de nuevo los controles textbox con el
                'objeto DataTable devuelto.
                txtNoCuenta.Enabled = True
                txtNoCuenta.Enabled = True
                txtNumTarjeta.Enabled = True
                BtnAceptar.Enabled = True

                txtCodigo.DataBindings.Add("text", MiConsulta, "idcliente")

                CodigoBuscado = txtCodigo.Text
                txtNoCuenta.DataBindings.Clear()

            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Exit Sub
        End Try

        Try
            Dim SentSQL As String
            SentSQL = "Select * FROM CUENTAS Where IDCliente=" & txtCodigo.Text

            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta) '***para bd de office 2007 2010 

            Dim objAdap As New OleDbDataAdapter(SentSQL, conexion)
            Dim MiConsulta As New DataTable()

            conexion.Open()
            objAdap.Fill(MiConsulta)
            If (MiConsulta.Rows.Count) = 0 Then
                'no hay registros coincidentes.
                MessageBox.Show("el con codigo" & txtCodigo.Text & "no existe. Verifique")
                txtNoCuenta.Clear()

                txtNoCuenta.Clear()
            Else
                'enlazamos de nuevo los controles textbox con el
                'objeto DataTable devuelto.
                txtNoCuenta.Enabled = True
                txtNoCuenta.Enabled = True
                txtNumTarjeta.Enabled = True
                BtnAceptar.Enabled = True

                txtNoCuenta.DataBindings.Add("text", MiConsulta, "NoCuenta")
                CodigoBuscado = txtCodigo.Text
                txtNoCuenta.DataBindings.Clear()

            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Exit Sub
        End Try
        Try
            Dim SentSQL As String
            SentSQL = "Select nombre,ApellidoMaterno,ApellidoPaterno FROM clientes Where IDCliente=" & txtCodigo.Text

            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta) '***para bd de office 2007 2010 

            Dim objAdap As New OleDbDataAdapter(SentSQL, conexion)
            Dim MiConsulta As New DataTable()

            conexion.Open()
            objAdap.Fill(MiConsulta)
            If IsDBNull(MiConsulta.Rows.Count()) = True Then


                'no hay registros coincidentes.
                MessageBox.Show("el con codigo" & txtCodigo.Text & "no existe. Verifique")
            Else
                'enlazamos de nuevo los controles textbox con el
                'objeto DataTable devuelto.
                txtNoCuenta.Enabled = True
                txtNoCuenta.Enabled = True
                txtNomProp.Enabled = True
                BtnAceptar.Enabled = True

                txtNomProp.DataBindings.Add("text", MiConsulta, "Nombre")
                NomProp = txtNomProp.Text
                txtNomProp.DataBindings.Clear()

                txtNomProp.DataBindings.Add("text", MiConsulta, "ApellidoPaterno")
                NomProp = NomProp & " " & txtNomProp.Text
                txtNomProp.DataBindings.Clear()

                txtNomProp.DataBindings.Add("text", MiConsulta, "ApellidoMaterno")
                NomProp = NomProp & " " & txtNomProp.Text
                txtNomProp.DataBindings.Clear()

            End If
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Exit Sub
        End Try
    End Sub
End Class