Public Class ClienteDAO

    Public Function Adiciona(ByVal cliente As ClienteTO) As String
        Dim msg As String = "OK"

        Dim cn As New Conexao
        Dim sql As New StringBuilder

        With sql
            .Append("insert into Cliente(")
            .Append("nomeCliente,")
            .Append("cpf,")
            .Append("idade,")
            .Append("sexo,")
            .Append("telefone")
            .Append(")")
            .Append("values")
            .Append("(")
            .Append("'" & cliente.NomeCliente & "',")
            .Append("'" & cliente.Cpf & "',")
            .Append(cliente.Idade & ",")
            .Append("'" & cliente.Sexo & "',")
            .Append("'" & cliente.Telefone & "'")
            .Append(")")
        End With
        Return cn.ExecutaSqlNew(sql.ToString)

    End Function

End Class
