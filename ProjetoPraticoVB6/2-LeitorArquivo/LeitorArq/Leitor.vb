﻿Imports System.IO
Imports ProjetoPraticoVB6.Logs
Imports ProjetoPraticoVB6.Serviços

Namespace Leitor
    Public Class Leitor
        Implements ILeitor

        ' Campos para construtores
        Private logger As IGeraLog
        Private verificadorDiretorio As IVerificadorDiretorio
        Private exibidorResultados As IExibidorResultados
        Private processadorArquivo As IProcessadorArquivo
        Private pessoaFactory As IPessoaFactory

        ' Inicializa os construtores
        Public Sub New()
            logger = New Logs.GeraLog()
            verificadorDiretorio = New Serviços.VerificadorDiretorio(logger)
            exibidorResultados = New Serviços.ExibidorResultados()
            pessoaFactory = New Serviços.PessoaFactory(logger) ' Crie a instância da PessoaFactory
            processadorArquivo = New Serviços.ProcessadorArquivo(logger, pessoaFactory) ' Passe a pessoaFactory para o ProcessadorArquivo
        End Sub

        Public Sub LerArquivos(filePath As String) Implements ILeitor.LerArquivos
            If Not verificadorDiretorio.VerificarDiretorio(filePath) Then Return

            'Separação para gerar log de Teste
            If filePath = "C:\Files\PastaTeste" Then
                Dim arquivos As String() = Directory.GetFiles(filePath, "*.txt")
                Dim contadorTotal As Integer = 0
                Dim todasPessoasFemininas As New List(Of Pessoa.Pessoa)()

                For Each inputFile As String In arquivos
                    Dim pessoasFemininas As List(Of Pessoa.Pessoa) = processadorArquivo.ProcessarArquivo(inputFile, contadorTotal)
                    If pessoasFemininas IsNot Nothing Then
                        todasPessoasFemininas.AddRange(pessoasFemininas)
                    End If
                Next

                If contadorTotal = 0 Then
                    logger.LogTest("Nenhum arquivo .txt encontrado ou processado.")
                    Console.WriteLine("Nenhum arquivo .txt encontrado ou processado.")
                ElseIf todasPessoasFemininas.Count > 0 Then
                    exibidorResultados.ExibirResultados(todasPessoasFemininas)
                End If
            Else
                Dim arquivos As String() = Directory.GetFiles(filePath, "*.txt")
                Dim contadorTotal As Integer = 0
                Dim todasPessoasFemininas As New List(Of Pessoa.Pessoa)()

                For Each inputFile As String In arquivos
                    Dim pessoasFemininas As List(Of Pessoa.Pessoa) = processadorArquivo.ProcessarArquivo(inputFile, contadorTotal)
                    If pessoasFemininas IsNot Nothing Then
                        todasPessoasFemininas.AddRange(pessoasFemininas)
                    End If
                Next

                If contadorTotal = 0 Then
                    logger.Log("Nenhum arquivo .txt encontrado ou processado.")
                    Console.WriteLine("Nenhum arquivo .txt encontrado ou processado.")
                ElseIf todasPessoasFemininas.Count > 0 Then
                    exibidorResultados.ExibirResultados(todasPessoasFemininas)
                End If
            End If


        End Sub

    End Class
End Namespace