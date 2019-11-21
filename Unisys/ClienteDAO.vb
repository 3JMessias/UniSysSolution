Imports Unisys

Public Class ClienteDAO
    Implements iDAO(Of ClienteTO)

    Public Sub PreecheObj(ByRef Obj As ClienteTO, ByRef id As Integer) Implements iDAO(Of ClienteTO).PreecheObj
        Throw New NotImplementedException()
    End Sub

    Public Function Altera(Obj As ClienteTO) As String Implements iDAO(Of ClienteTO).Altera
        Throw New NotImplementedException()
    End Function

    Public Function Exclui(id As Integer) As String Implements iDAO(Of ClienteTO).Exclui
        Throw New NotImplementedException()
    End Function

    Public Function Lista(texto As String) As DataSet Implements iDAO(Of ClienteTO).Lista
        Throw New NotImplementedException()
    End Function

    Public Function PreecheCombo() As DataSet Implements iDAO(Of ClienteTO).PreecheCombo
        Dim cn As New Conexao
        Dim sql As String = "select idCliente,nomeCliente from Clientes order by nomeCliente"

        Return cn.ExecutaSqlRetorno(sql)
    End Function

    Public Function Adiciona(Obj As ClienteTO) As String Implements iDAO(Of ClienteTO).Adiciona
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
            .Append("'" & Obj.NomeCliente & "',")
            .Append("'" & Obj.Cpf & "',")
            .Append(Obj.Idade & ",")
            .Append("'" & Obj.Sexo & "',")
            .Append("'" & Obj.Telefone & "'")
            .Append(")")
        End With
        Return cn.ExecutaSqlNew(sql.ToString)
    End Function
End Class
