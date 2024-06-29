Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports RJCodeAdvance
Imports MySql.Data
Imports MySql.Data.MySqlClient




Public Class Form1

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click


    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RjButton1_Click(sender As Object, e As EventArgs) Handles RjButton1.Click

        If (RjTextBox1.Texts = "" Or RjTextBox2.Texts = "") Then
            MsgBox("Faltan datos")
        Else
            Dim comando = New MySqlCommand("SELECT * FROM usuarios WHERE username = '" + RjTextBox1.Texts + "';", Conex)
            Dim resultado = comando.ExecuteReader
            resultado.Read()
            If (resultado.HasRows) Then

                'Dim comand = New MySqlCommand("SELECT * FROM usuarios WHERE password = '" + RjTextBox2.Texts + "';", Conex)
                ' Dim key = comand.ExecuteReader
                ' key.Read()
                If (resultado("username") = RjTextBox1.Texts And resultado("password") = RjTextBox2.Texts) Then

                    MsgBox("Bienvenido " + resultado("fullname") + "! ")

                    Me.Hide()
                    resultado.Close()
                    Principal.Show()

                Else
                    MsgBox("Password incorrecta! ")

                End If



            Else
                MsgBox("usuario no encontrado")

            End If
            resultado.Close()


        End If

    End Sub

    Private Sub RjTextBox1__TextChanged(sender As Object, e As EventArgs) Handles RjTextBox1._TextChanged, RjTextBox2._TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Conectar()

    End Sub

    Private Sub RjButton2_Click(sender As Object, e As EventArgs) Handles RjButton2.Click
        Me.Hide()
        registrar.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel2_Paint_1(sender As Object, e As PaintEventArgs)


    End Sub
End Class
