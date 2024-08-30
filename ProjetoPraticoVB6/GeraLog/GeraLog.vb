Imports System
Imports System.IO

Namespace Logs
    Public Class GeraLog
        Implements IGeraLog

        Private logFilePath As String

        Public Sub New()
            Try
                ' Define o caminho do diretório de log
                Dim logDirectory As String = "C:\Files\Logs"
                ' Cria o nome do arquivo de log com a data atual formatada
                Dim logFileName As String = $"log_{DateTime.Now:yyyy-MM-dd}.txt"
                logFilePath = Path.Combine(logDirectory, logFileName)

                ' Cria o diretório se não existir
                If Not Directory.Exists(logDirectory) Then
                    Directory.CreateDirectory(logDirectory)
                End If
            Catch ex As Exception
                Console.WriteLine("Erro ao inicializar o logger: " & ex.Message)
            End Try
        End Sub

        Public Sub Log(message As String) Implements IGeraLog.Log
            Try
                ' Adiciona a mensagem de log com a data e hora atual
                Dim logMessage As String = $"{DateTime.Now}: {message}{Environment.NewLine}*********************{Environment.NewLine}"
                File.AppendAllText(logFilePath, logMessage)
            Catch ex As Exception
                Console.WriteLine("Erro ao escrever no log: " & ex.Message)
            End Try
        End Sub
    End Class
End Namespace