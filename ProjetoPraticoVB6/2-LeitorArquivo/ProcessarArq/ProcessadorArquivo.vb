Imports System.IO
Imports ProjetoPraticoVB6.Logs

Namespace Serviços
    Public Class ProcessadorArquivo
        Implements IProcessadorArquivo

        Private logger As IGeraLog
        Private pessoaFactory As IPessoaFactory

        Public Sub New(logger As IGeraLog, pessoaFactory As IPessoaFactory)
            Me.logger = logger
            Me.pessoaFactory = pessoaFactory
        End Sub

        Public Function ProcessarArquivo(inputFile As String, ByRef contadorTotal As Integer) As List(Of Pessoa.Pessoa) Implements IProcessadorArquivo.ProcessarArquivo
            Dim contadorMasculino As Integer = 0
            Dim contadorFeminino As Integer = 0
            Dim pessoasMasculinas As New List(Of Pessoa.Pessoa)()
            Dim pessoasFemininas As New List(Of Pessoa.Pessoa)()

            If String.Equals(inputFile, "C:\Files\PastaTeste\arquivo.txt", StringComparison.OrdinalIgnoreCase) Then
                logger.LogTest($"Identificado arquivo do modulo de testes")

                Try
                    Dim lines() As String = File.ReadAllLines(inputFile)

                    logger.LogTest($"Iniciando processamento arquivo do modulo de testes {Path.GetFileName(inputFile)}.")
                    For Each line As String In lines
                        Dim pessoa As Pessoa.Pessoa = pessoaFactory.CriarPessoa(line)
                        If pessoa IsNot Nothing Then
                            If String.Equals(pessoa.Sexo, "Masculino", StringComparison.OrdinalIgnoreCase) Then
                                contadorMasculino += 1
                                pessoasMasculinas.Add(pessoa)
                            ElseIf String.Equals(pessoa.Sexo, "Feminino", StringComparison.OrdinalIgnoreCase) Then
                                contadorFeminino += 1
                                pessoasFemininas.Add(pessoa)
                            End If
                        End If
                    Next
                    logger.LogTest($"Finalizando processamento arquivo do modulo de testes {Path.GetFileName(inputFile)}.")

                    contadorTotal = contadorFeminino + contadorMasculino
                    Return pessoasFemininas
                Catch ex As Exception
                    logger.LogTest("Ocorreu um erro ao processar o arquivo do modulo de testes " & inputFile & ": " & ex.Message)
                    Console.WriteLine("Ocorreu um erro ao processar o arquivo do modulo de testes " & inputFile & ": " & ex.Message)
                    Return Nothing
                End Try
            End If

            If Path.GetFileName(inputFile).Contains("E") Then
                logger.Log($"O arquivo {Path.GetFileName(inputFile)} não será processado porque contém a letra 'E' maiúscula no nome.")
                Return Nothing
            End If

            Try
                Dim lines() As String = File.ReadAllLines(inputFile)

                logger.Log($"Iniciando processamento arquivo {Path.GetFileName(inputFile)}.")
                For Each line As String In lines
                    Dim pessoa As Pessoa.Pessoa = pessoaFactory.CriarPessoa(line)
                    If pessoa IsNot Nothing Then
                        If String.Equals(pessoa.Sexo, "Masculino", StringComparison.OrdinalIgnoreCase) Then
                            contadorMasculino += 1
                            pessoasMasculinas.Add(pessoa)
                        ElseIf String.Equals(pessoa.Sexo, "Feminino", StringComparison.OrdinalIgnoreCase) Then
                            contadorFeminino += 1
                            pessoasFemininas.Add(pessoa)
                        End If
                    End If
                Next
                logger.Log($"Finalizando processamento arquivo {Path.GetFileName(inputFile)}.")

                contadorTotal = contadorFeminino + contadorMasculino
                Return pessoasFemininas
            Catch ex As Exception
                logger.Log("Ocorreu um erro ao processar o arquivo " & inputFile & ": " & ex.Message)
                Console.WriteLine("Ocorreu um erro ao processar o arquivo " & inputFile & ": " & ex.Message)
                Return Nothing
            End Try
        End Function
    End Class
End Namespace