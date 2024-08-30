Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports ProjetoPraticoVB6.Logs

<TestClass>
Public Class GeraLogTests
    <TestMethod>
    Public Sub TestLogCreation()
        Dim logger As New GeraLog()
        Dim logFilePath As String = "C:\Files\Logs\log_" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"

        logger.Log("Teste de log")

        Assert.IsTrue(File.Exists(logFilePath), "O arquivo de log não foi criado.")
        Dim logContents As String = File.ReadAllText(logFilePath)
        Assert.IsTrue(logContents.Contains("Teste de log"), "A mensagem de log não foi encontrada.")
    End Sub
End Class
