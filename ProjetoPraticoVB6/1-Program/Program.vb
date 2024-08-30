Imports System
Imports System.IO
Imports Newtonsoft.Json
Imports ProjetoPraticoVB6.Leitor
Imports ProjetoPraticoVB6.Pessoa

Module Program
    Sub Main()
        Dim filePath As String = "C:\Files"
        Dim leitor As New Leitor.Leitor()
        leitor.LerArquivos(filePath)
    End Sub
End Module