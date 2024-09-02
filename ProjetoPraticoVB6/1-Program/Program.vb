Imports ProjetoPraticoVB6.Leitor
Imports ProjetoPraticoVB6.Logs

Module Program
    Sub Main()
        Dim logger As IGeraLog = New Logs.GeraLog()
        logger.Log("Este é um teste de log.")
        Dim filePath As String = "C:\Files"
        Dim leitor As ILeitor = New Leitor.Leitor()
        leitor.LerArquivos(filePath)
    End Sub
End Module