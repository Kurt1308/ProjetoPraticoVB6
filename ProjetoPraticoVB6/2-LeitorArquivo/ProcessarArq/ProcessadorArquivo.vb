Imports System.IO
Imports ProjetoPraticoVB6.Logs

Namespace Serviços
    Public Class ProcessadorArquivo
        Implements IProcessadorArquivo

        Private logger As IGeraLog

        Public Sub New(logger As IGeraLog)
            Me.logger = logger
        End Sub

        Public Function ProcessarArquivo(inputFile As String, ByRef contadorTotal As Integer) As List(Of Pessoa.Pessoa) Implements IProcessadorArquivo.ProcessarArquivo
            If Path.GetFileName(inputFile).Contains("E") Then
                logger.Log($"O arquivo {Path.GetFileName(inputFile)} não será processado porque contém a letra 'E' maiúscula no nome.")
                Return Nothing
            End If

            Dim contadorMasculino As Integer = 0
            Dim contadorFeminino As Integer = 0
            Dim pessoasMasculinas As New List(Of Pessoa.Pessoa)()
            Dim pessoasFemininas As New List(Of Pessoa.Pessoa)()

            Try
                Dim lines() As String = File.ReadAllLines(inputFile)

                logger.Log($"Iniciando processamento arquivo {Path.GetFileName(inputFile)}.")
                For Each line As String In lines
                    Dim pessoa As Pessoa.Pessoa = CriarPessoa(line)
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

                contadorTotal = contadorFeminino + contadorFeminino
                Return pessoasFemininas
            Catch ex As Exception
                logger.Log("Ocorreu um erro ao processar o arquivo " & inputFile & ": " & ex.Message)
                Console.WriteLine("Ocorreu um erro ao processar o arquivo " & inputFile & ": " & ex.Message)
                Return Nothing
            End Try
        End Function

        Private Function CriarPessoa(line As String) As Pessoa.Pessoa
            Dim elements() As String = line.Split(";"c)
            logger.Log($"Criando pessoa: {elements(0).Trim()} {elements(1).Trim()}.")
            If elements.Length < 5 Then Return Nothing ' Verifica se a linha tem elementos suficientes

            Return New Pessoa.Pessoa With {
                .Nome = elements(0).Trim(),
                .Sobrenome = elements(1).Trim(),
                .Idade = Convert.ToInt32(elements(2).Trim()),
                .Sexo = elements(3).Trim(),
                .Cidade = elements(4).Trim()
            }
        End Function
    End Class
End Namespace

