Imports ProjetoPraticoVB6.Leitor
Imports ProjetoPraticoVB6.Logs

Module Program
    Sub Main()
        Dim logger As IGeraLog = New Logs.GeraLog()
        Dim filePath As String = "C:\Files"
        Dim leitor As ILeitor = New Leitor.Leitor()
        logger.Log("Chamada do leitor na classe Program")
        leitor.LerArquivos(filePath)
        logger.Log("Finalização program")
    End Sub
End Module