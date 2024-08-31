Imports System
Imports System.IO
Imports ProjetoPraticoVB6.Leitor
Imports ProjetoPraticoVB6.Logs
Imports ProjetoPraticoVB6.Pessoa
Imports ProjetoPraticoVB6.Serviços

Namespace Leitor
    Public Class Leitor
        Implements ILeitor

        Private ReadOnly _logger As IGeraLog
        Private ReadOnly _verificadorDiretorio As IVerificadorDiretorio
        Private ReadOnly _exibidorResultados As IExibidorResultados
        Private ReadOnly _processadorArquivo As IProcessadorArquivo

        Public Sub New(logger As IGeraLog, verificadorDiretorio As IVerificadorDiretorio, exibidorResultados As IExibidorResultados, processadorArquivo As IProcessadorArquivo)
            _logger = logger
            _verificadorDiretorio = verificadorDiretorio
            _exibidorResultados = exibidorResultados
            _processadorArquivo = processadorArquivo
        End Sub

        Public Sub LerArquivos(filePath As String) Implements ILeitor.LerArquivos
            If Not VerificarDiretorio(filePath) Then
                Return
            End If

            Dim arquivos As String() = ObterArquivos(filePath)
            If arquivos.Length = 0 Then
                _logger.Log("Nenhum arquivo .txt encontrado no diretório especificado.")
                Return
            End If

            Dim todasPessoasFemininas As List(Of Pessoa) = ProcessarArquivos(arquivos)

            If todasPessoasFemininas.Count > 0 Then
                _exibidorResultados.ExibirResultados(todasPessoasFemininas)
            Else
                _logger.Log("Nenhuma pessoa feminina encontrada nos arquivos.")
            End If
        End Sub

        Private Function VerificarDiretorio(diretorio As String) As Boolean
            Return _verificadorDiretorio.VerificarDiretorio(diretorio)
        End Function

        Private Function ObterArquivos(diretorio As String) As String()
            Return Directory.GetFiles(diretorio, "*.txt")
        End Function

        Private Function ProcessarArquivos(arquivos As String()) As List(Of Pessoa)
            Dim contadorTotal As Integer = 0
            Dim todasPessoasFemininas As New List(Of Pessoa)()

            For Each arquivo As String In arquivos
                Dim pessoasFemininas As List(Of Pessoa) = _processadorArquivo.ProcessarArquivo(arquivo, contadorTotal)
                If pessoasFemininas IsNot Nothing Then
                    todasPessoasFemininas.AddRange(pessoasFemininas)
                End If
            Next

            Return todasPessoasFemininas
        End Function
    End Class
End Namespace
