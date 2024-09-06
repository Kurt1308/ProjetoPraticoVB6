Imports System.IO

Namespace Logs
    Public Class GeraLog
        Implements IGeraLog

        Private logFilePath As String
        Private logFilePathTest As String

        Public Sub New()
            logFilePath = InitializeLogFile("C:\Files\Logs")
            logFilePathTest = InitializeLogFile("C:\Files\PastaTeste\LogTest")
        End Sub

        Private Function InitializeLogFile(logDirectory As String) As String
            Try
                ' Cria o nome do arquivo de log com a data atual formatada
                Dim logFileName As String = $"log_{DateTime.Now:yyyy-MM-dd}.txt"
                Dim logFilePath As String = Path.Combine(logDirectory, logFileName)

                ' Cria o diretório se não existir
                If Not Directory.Exists(logDirectory) Then
                    Directory.CreateDirectory(logDirectory)
                End If

                Return logFilePath
            Catch ex As Exception
                Console.WriteLine("Erro ao inicializar o logger: " & ex.Message)
                Return String.Empty ' Retorna uma string vazia em caso de erro
            End Try
        End Function

        Public Sub Log(message As String) Implements IGeraLog.Log
            WriteLog(logFilePath, message)
        End Sub

        Public Sub LogTest(message As String) Implements IGeraLog.LogTest
            WriteLog(logFilePathTest, message)
        End Sub

        Private Sub WriteLog(filePath As String, message As String)
            Try
                ' Adiciona a mensagem de log com a data e hora atual
                Dim logMessage As String = $"{DateTime.Now}: {message}{Environment.NewLine}*********************{Environment.NewLine}"
                File.AppendAllText(filePath, logMessage)
            Catch ex As Exception
                Console.WriteLine("Erro ao escrever no log: " & ex.Message)
            End Try
        End Sub
    End Class
End Namespace