Imports System
Imports System.IO
Imports Newtonsoft.Json
Imports ProjetoPraticoVB6.Logs ' Linha para importar o namespace de logs

Namespace Leitor
    Public Class Leitor
        Implements ILeitor

        Public Sub LerArquivos(filePath As String) Implements ILeitor.LerArquivos
            Dim logger As IGeraLog = New Logs.GeraLog() ' Cria uma instância de GeraLog

            ' Verifica se o diretório existe
            If Not Directory.Exists(filePath) Then
                logger.Log("O diretório não foi encontrado: " & filePath) ' Log de erro
                Console.WriteLine("O diretório não foi encontrado: " & filePath)
                Return
            End If

            ' Obtém todos os arquivos .txt no diretório
            Dim arquivos As String() = Directory.GetFiles(filePath, "*.txt")
            Dim contadorTotal As Integer = 0

            ' Processa cada arquivo .txt encontrado
            For Each inputFile As String In arquivos
                If Path.GetFileName(inputFile).Contains("E") Then
                    logger.Log($"O arquivo {Path.GetFileName(inputFile)} não será processado porque contém a letra 'E' maiúscula no nome.")
                    Continue For ' Pula para o próximo arquivo
                End If

                Dim contador As Integer = 0
                Dim contadorMasculino As Integer = 0
                Dim contadorFeminino As Integer = 0
                Dim pessoasMasculinas As New List(Of Pessoa.Pessoa)()
                Dim pessoasFemininas As New List(Of Pessoa.Pessoa)()

                ' Lê o arquivo de texto
                Try
                    Dim lines() As String = File.ReadAllLines(inputFile)

                    For Each line As String In lines
                        Dim elements() As String = line.Split(";"c)
                        Dim pessoa As New Pessoa.Pessoa With {
                            .Nome = elements(0).Trim(),
                            .Sobrenome = elements(1).Trim(),
                            .Idade = Convert.ToInt32(elements(2).Trim()),
                            .Sexo = elements(3).Trim(),
                            .Cidade = elements(4).Trim()
                        }

                        If String.Equals(pessoa.Sexo, "Masculino", StringComparison.OrdinalIgnoreCase) Then
                            contadorMasculino += 1
                            pessoasMasculinas.Add(pessoa)
                        ElseIf String.Equals(pessoa.Sexo, "Feminino", StringComparison.OrdinalIgnoreCase) Then
                            contadorFeminino += 1
                            pessoasFemininas.Add(pessoa)
                        End If

                        contador += 1
                    Next

                    Dim jsonString As String = JsonConvert.SerializeObject(pessoasFemininas, Formatting.Indented)
                    Console.WriteLine("____________________________________________")
                    Console.WriteLine($"Arquivo: {Path.GetFileName(inputFile)}")
                    Console.WriteLine("Total de linhas do arquivo: " & "****" & contador & "****")
                    Console.WriteLine("Total de linhas processadas: " & "****" & contadorFeminino & "****")
                    Console.WriteLine("Total de linhas não processadas: " & "****" & contadorMasculino & "****")
                    Console.WriteLine(jsonString)
                    logger.Log("Arquivo processado: " & inputFile)

                    ' Atualiza o contador total
                    contadorTotal += contador
                Catch ex As Exception
                    logger.Log("Ocorreu um erro ao processar o arquivo " & inputFile & ": " & ex.Message) ' Log de erro
                    Console.WriteLine("Ocorreu um erro ao processar o arquivo " & inputFile & ": " & ex.Message)
                End Try
            Next

            If contadorTotal = 0 Then
                logger.Log("Nenhum arquivo .txt encontrado ou processado.") ' Log de informação
                Console.WriteLine("Nenhum arquivo .txt encontrado ou processado.")
            End If
        End Sub
    End Class
End Namespace