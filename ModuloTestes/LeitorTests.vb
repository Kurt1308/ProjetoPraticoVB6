Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProjetoPraticoVB6
Imports ProjetoPraticoVB6.Leitor
Imports ProjetoPraticoVB6.Logs

Namespace ModuloTestes
    <TestClass>
    Public Class LeitorTests
        <TestMethod>
        Public Sub TestarLerArquivos()
            ' Arrange
            Dim logger As IGeraLog = New Logs.GeraLog()
            Dim leitor As ILeitor = New ProjetoPraticoVB6.Leitor.Leitor()
            Dim filePath As String = "C:\Files\PastaTeste" ' Alterar para um caminho válido

            ' Act
            leitor.LerArquivos(filePath)

            ' Assert
            ' Aqui você pode verificar se os logs foram criados ou se o resultado é o esperado
            ' Exemplo: Assert.IsTrue(condição)
        End Sub
    End Class
End Namespace