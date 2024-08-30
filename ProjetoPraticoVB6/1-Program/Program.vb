Imports System
Imports System.IO
Imports Newtonsoft.Json
Imports ProjetoPraticoVB6.Leitor
Imports ProjetoPraticoVB6.Logs
Imports ProjetoPraticoVB6.Pessoa

Module Program
    Sub Main()
        Dim logger As IGeraLog = New Logs.GeraLog()
        logger.Log("Este é um teste de log.")
        Dim filePath As String = "C:\Files"
        Dim leitor As ILeitor = New Leitor.Leitor() ' Usando a interface
        leitor.LerArquivos(filePath)
    End Sub
End Module