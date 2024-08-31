Namespace Leitor
    Public Interface ILeitor
        Sub LerArquivos(filePath As String)
        Function ProcessarArquivo(inputFile As String, ByRef contadorTotal As Integer) As List(Of Pessoa.Pessoa)
        Function CriarPessoa(line As String) As Pessoa.Pessoa
    End Interface
End Namespace
