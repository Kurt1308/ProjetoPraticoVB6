Namespace Leitor
    Public Interface ILeitor
        Sub LerArquivos(filePath As String)
        Function ProcessarArquivo(inputFile As String, ByRef contadorTotal As Integer) As Boolean
        Function CriarPessoa(line As String) As Pessoa.Pessoa
        Sub ExibirResultados(inputFile As String, contador As Integer, contadorMasculino As Integer, contadorFeminino As Integer, pessoasFemininas As List(Of Pessoa.Pessoa))
    End Interface
End Namespace
