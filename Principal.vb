Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Principal
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label7.Click

    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaru()
        llenar()

    End Sub
    Public Sub llenaru()
        Dim consulta = New MySqlCommand("SELECT * FROM usuarios;", Conex)
        Dim productos = consulta.ExecuteReader
        While (productos.Read())
            Dim id = productos.GetInt32(0)
            Dim username = productos.GetString(1)
            Dim fullname = productos.GetString(2)
            DataGridView2.Rows.Add(Convert.ToString(id), username, fullname)

        End While
        productos.Close()
    End Sub
    Public Sub llenar()

        Dim consulta = New MySqlCommand("SELECT * FROM productos;", Conex)
        Dim productos = consulta.ExecuteReader
        While (productos.Read())
            Dim codigo = productos.GetInt32(0)
            Dim nombre = productos.GetString(1)
            Dim marca = productos.GetString(2)
            Dim precio = productos.GetInt32(3)
            DataGridView1.Rows.Add(Convert.ToString(codigo), nombre, marca, Convert.ToString(precio))

        End While
        productos.Close()





    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick, DataGridView2.CellContentClick

    End Sub

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form1.Close()
    End Sub

    Private Sub RjTextBox1__TextChanged(sender As Object, e As EventArgs) Handles RjTextBox1._TextChanged
        Dim dato = "%" + RjTextBox1.Texts + "%"
        buscar(dato)

    End Sub

    Private Sub RjTextBox2__TextChanged(sender As Object, e As EventArgs) Handles RjTextBox2._TextChanged, RjTextBox10._TextChanged

    End Sub

    Private Sub RjTextBox3__TextChanged(sender As Object, e As EventArgs) Handles RjTextBox3._TextChanged, RjTextBox9._TextChanged

    End Sub

    Private Sub RjTextBox4__TextChanged(sender As Object, e As EventArgs) Handles RjTextBox4._TextChanged, RjTextBox5._TextChanged, RjTextBox8._TextChanged, RjTextBox7._TextChanged

    End Sub

    Private Sub RjToggleButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RjToggleButton1.CheckedChanged
        If (RjToggleButton1.Checked) Then
            Panel1.Hide()
            Panel2.Hide()
            Panel3.Show()
            Panel4.Show()
        Else

            Panel1.Show()
            Panel2.Show()
            Panel3.Hide()
            Panel4.Hide()

        End If
    End Sub
    'buscando'
    Private Sub buscar(s)
        Dim consulta = New MySqlCommand("SELECT * FROM productos where codigo like '" + s + "' " + "or nombre like '" + s.ToString() + "' " + "or marca like '" + s.ToString() + "' " + "or precio like '" + s + "' ", Conex)
        Dim productos = consulta.ExecuteReader
        DataGridView1.Rows.Clear()

        Try
            While (productos.Read())

                Dim codigo = productos.GetInt32(0)
                Dim nombre = productos.GetString(1)
                Dim marca = productos.GetString(2)
                Dim precio = productos.GetInt32(3)
                DataGridView1.Rows.Add(Convert.ToString(codigo), nombre, marca, Convert.ToString(precio))

            End While

        Catch ex As Exception
            MsgBox("error desconocido o no esta lo que buscas")

        End Try
        productos.Close()

    End Sub
    Private Sub buscar2(s)
        Dim consulta = New MySqlCommand("SELECT * FROM productos where id like '" + s + "' " + "or username like '" + s.ToString() + "' " + "or fullname like '" + s.ToString() + "' ", Conex)
        Dim productos = consulta.ExecuteReader
        DataGridView2.Rows.Clear()

        Try
            While (productos.Read())

                Dim id = productos.GetInt32(0)
                Dim username = productos.GetString(1)
                Dim fullname = productos.GetString(2)

                DataGridView1.Rows.Add(Convert.ToString(id), username, fullname)

            End While

        Catch ex As Exception
            MsgBox("error desconocido o no esta lo que buscas")

        End Try
        productos.Close()

    End Sub
    Private Sub RjTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RjTextBox1.KeyDown
        Dim dato = "%" + RjTextBox1.Texts + "%"
        buscar(dato)

    End Sub

    Private Sub RjTextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles RjTextBox6.KeyDown
        Dim dato = "%" + RjTextBox6.Texts + "%"
        buscar2(dato)
    End Sub

    Private Sub RjButton2_Click(sender As Object, e As EventArgs) Handles RjButton2.Click
        If (RjTextBox10.Texts = "" Or RjTextBox8.Texts = "" Or RjTextBox9.Texts = "" Or RjTextBox7.Texts = "") Then
            MsgBox("Faltan datos")
        Else
            Try
                If (RjTextBox8.Texts = RjTextBox7.Texts) Then
                    Dim comando = New MySqlCommand("INSERT INTO usuarios (username,password,fullname) VALUES ('" + RjTextBox10.Texts + "','" + RjTextBox8.Texts + "','" + RjTextBox9.Texts + "')", Conex)
                    Dim resultado = comando.ExecuteNonQuery 'activa el comando para insertar los datos'
                    MsgBox("Usuario creado ", MsgBoxStyle.Information, " Exito!")
                    RjTextBox10.Texts = ""
                    RjTextBox9.Texts = ""
                    RjTextBox8.Texts = ""
                    RjTextBox7.Texts = ""

                Else
                    MsgBox("Las password no coinciden")
                End If



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub RjButton1_Click(sender As Object, e As EventArgs) Handles RjButton1.Click
        If (RjTextBox2.Texts = "" Or RjTextBox3.Texts = "" Or RjTextBox4.Texts = "" Or RjTextBox5.Texts = "") Then
            MsgBox("Faltan datos")
        Else
            Try

                Dim comando = New MySqlCommand("INSERT INTO productos (codigo,nombre,marca,precio) VALUES ('" + RjTextBox5.Texts + "','" + RjTextBox2.Texts + "','" + RjTextBox3.Texts + "',' " + RjTextBox4.Texts + " ')", Conex)
                    Dim resultado = comando.ExecuteNonQuery 'activa el comando para insertar los datos'
                    MsgBox("Producto creado con ", MsgBoxStyle.Information, " Exito!")
                    RjTextBox5.Texts = ""
                    RjTextBox4.Texts = ""
                    RjTextBox3.Texts = ""
                    RjTextBox2.Texts = ""





            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub RjTextBox6__TextChanged(sender As Object, e As EventArgs) Handles RjTextBox6._TextChanged

    End Sub
End Class