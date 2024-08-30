Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports ProjetoPraticoVB6.Leitor

<TestClass>
Public Class LeitorTests
    <TestMethod>
    Public Sub TestLerArquivos_ValidDirectory()
        Dim filePath As String = "C:\Files\Testes"
        Directory.CreateDirectory(filePath)
        File.WriteAllText(Path.Combine(filePath, "test.txt"), "João;Silva;30;Masculino;São Paulo")

        Dim leitor As New Leitor()
        leitor.LerArquivos(filePath)

        ' Aqui você pode adicionar asserções para verificar se o comportamento esperado ocorreu
        ' Por exemplo, verificar se o log foi gerado corretamente ou se as contagens estão corretas.

        Directory.Delete(filePath, True) ' Limpa o diretório de teste
    End Sub

    <TestMethod>
    Public Sub TestLerArquivos_InvalidDirectory()
        Dim leitor As New Leitor()
        leitor.LerArquivos("C:\Files\DiretorioInvalido")

        ' Verifique se o log de erro foi gerado corretamente
    End Sub
End Class
