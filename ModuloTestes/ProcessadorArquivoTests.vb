Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProjetoPraticoVB6
Imports ProjetoPraticoVB6.Logs
Imports ProjetoPraticoVB6.Serviços

Namespace ModuloTestes
    <TestClass>
    Public Class ProcessadorArquivoTests
        <TestMethod>
        Public Sub TestarProcessarArquivo()
            ' Arrange
            Dim logger As IGeraLog = New Logs.GeraLog()
            Dim pessoaFactory As IPessoaFactory = New PessoaFactory(logger)
            Dim processador As IProcessadorArquivo = New ProcessadorArquivo(logger, pessoaFactory)
            Dim contadorTotal As Integer

            Dim expectedCount As Integer = 1

            ' Act
            Dim resultado As List(Of Pessoa.Pessoa) = processador.ProcessarArquivo("C:\Files\PastaTeste\arquivo.txt", contadorTotal) ' Troque pelo nome de um arquivo válido

            ' Assert
            Assert.IsNotNull(resultado, "O resultado não deve ser nulo.")
            Assert.AreEqual(expectedCount, resultado.Count, "A contagem de resultados não está correta.") ' Substitua expectedCount pelo valor esperado
        End Sub
    End Class
End Namespace