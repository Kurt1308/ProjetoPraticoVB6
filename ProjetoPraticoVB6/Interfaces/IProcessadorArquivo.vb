Namespace Serviços
    Public Interface IProcessadorArquivo
        Function ProcessarArquivo(inputFile As String, ByRef contadorTotal As Integer) As List(Of Pessoa.Pessoa)
    End Interface
End Namespace

