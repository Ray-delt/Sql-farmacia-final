Imports MySql.Data
Imports MySql.Data.MySqlClient


Module Conexion
    Public Conex As MySqlConnection
    Sub Conectar()
        Dim Conestr = "Server = localhost; Database = farmacia; Port = 3306; user id = root; password = ;"
        Try
            Conex = New MySqlConnection(Conestr)
            Conex.ConnectionString = Conestr
            Conex.Open()
            MsgBox("Conexion exitosa!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



End Module
