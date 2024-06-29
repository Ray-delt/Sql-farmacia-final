Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class registrar
    Private Sub RjButton2_Click(sender As Object, e As EventArgs)
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub RjButton1_Click(sender As Object, e As EventArgs) Handles RjButton1.Click
        If (RjTextBox1.Texts = "" Or RjTextBox2.Texts = "" Or RjTextBox3.Texts = "" Or RjTextBox4.Texts = "") Then
            MsgBox("Faltan datos")
        Else
            Try
                If (RjTextBox1.Texts = RjTextBox3.Texts) Then
                    Dim comando = New MySqlCommand("INSERT INTO usuarios (username,password,fullname) VALUES ('" + RjTextBox2.Texts + "','" + RjTextBox3.Texts + "','" + RjTextBox4.Texts + "')", Conex)
                    Dim resultado = comando.ExecuteNonQuery 'activa el comando para insertar los datos'
                    MsgBox("Usuario creado ", MsgBoxStyle.Information, " Exito!")
                    RjTextBox1.Texts = ""
                    RjTextBox2.Texts = ""
                    RjTextBox3.Texts = ""
                    RjTextBox4.Texts = ""

                Else
                    MsgBox("Las password no coinciden")
                End If



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label4.Click, Label3.Click, Label2.Click

    End Sub

    Private Sub Cancelar(sender As Object, e As EventArgs)

    End Sub

    Private Sub RjButton2_Click_1(sender As Object, e As EventArgs) Handles RjButton2.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub registrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub registrar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form1.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim comando = New MySqlCommand("SELECT * FROM usuarios;", Conex)
        Dim resultado = comando.ExecuteReader
        While (resultado.Read)
            MsgBox("username: " + resultado("username"))


        End While
        resultado.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub
End Class