Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProjetoPraticoVB6
Imports ProjetoPraticoVB6.Leitor
Imports ProjetoPraticoVB6.Logs
Imports System.IO

Namespace ModuloTestes
    <TestClass>
    Public Class LeitorTests
        <TestMethod>
        Public Sub TestarLerArquivos()
            ' Arrange
            Dim logger As IGeraLog = New Logs.GeraLog()
            Dim leitor As ILeitor = New ProjetoPraticoVB6.Leitor.Leitor()
            Dim filePath As String = "C:\Files\PastaTeste" ' Alterar para um caminho válido
            Dim logDirectoryPath As String = "C:\Files\PastaTeste\LogTest" ' Caminho do diretório de log
            Dim currentDate As String = DateTime.Now.ToString("yyyy-MM-dd")
            Dim logFileName As String = "log_" & currentDate & ".txt" ' Nome do arquivo com extensão
            Dim logFilePath As String = Path.Combine(logDirectoryPath, logFileName) ' Combina caminho e nome do arquivo

            ' Act
            leitor.LerArquivos(filePath)

            ' Chamar o método que cria o log
            logger.LogTest(logFilePath)

            ' Esperar um momento ou verificar se o arquivo foi realmente criado
            Threading.Thread.Sleep(1000) ' Espera 1 segundo

            Assert.IsTrue(File.Exists(logFilePath), "O arquivo de log não foi criado.")

            ' Opcional: Verificar o conteúdo do log
            Dim logContent As String = File.ReadAllText(logFilePath)
            Assert.IsTrue(logContent.Contains("Resultados exibidos com sucesso"), "O log não contém a mensagem esperada.")
            Assert.IsTrue(logContent.Contains("Identificado arquivo do modulo de testes"), "O log não contém a mensagem esperada.")
            Assert.IsTrue(logContent.Contains("Iniciando processamento arquivo do modulo de testes arquivo.txt."), "O log não contém a mensagem esperada.")
            Assert.IsTrue(logContent.Contains("Criando pessoa: Maria Oliveira."), "O log não contém a mensagem esperada.")
            Assert.IsTrue(logContent.Contains("Finalizando processamento arquivo do modulo de testes arquivo.txt."), "O log não contém a mensagem esperada.")
            Assert.IsTrue(logContent.Contains("Diretório encontrado: C:\Files\PastaTeste"), "O log não contém a mensagem esperada.")
            Assert.IsTrue(logContent.Contains("Identificado arquivo do modulo de testes"), "O log não contém a mensagem esperada.")
            Assert.IsTrue(logContent.Contains("Criando pessoa: Maria Oliveira."), "O log não contém a mensagem esperada.")
        End Sub
    End Class
End Namespace