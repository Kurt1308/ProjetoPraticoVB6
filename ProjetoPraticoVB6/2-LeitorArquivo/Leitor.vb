Imports System
Imports System.IO
Imports Newtonsoft.Json
Imports ProjetoPraticoVB6.Logs ' Linha para importar o namespace de logs

Namespace Leitor
    Public Class Leitor
        Implements ILeitor

        Private logger As IGeraLog ' Campo para o logger

        Public Sub New()
            logger = New Logs.GeraLog() ' Inicializa o logger no construtor
        End Sub

        Public Sub LerArquivos(filePath As String) Implements ILeitor.LerArquivos

            If Not VerificarDiretorio(filePath) Then Return

            Dim arquivos As String() = Directory.GetFiles(filePath, "*.txt")
            Dim contadorTotal As Integer = 0

            For Each inputFile As String In arquivos
                If Not ProcessarArquivo(inputFile, contadorTotal) Then
                    Continue For
                End If
            Next

            If contadorTotal = 0 Then
                logger.Log("Nenhum arquivo .txt encontrado ou processado.")
                Console.WriteLine("Nenhum arquivo .txt encontrado ou processado.")
            End If
        End Sub
        Public Function VerificarDiretorio(filePath As String) As Boolean Implements ILeitor.VerificarDiretorio
            If Not Directory.Exists(filePath) Then
                logger.Log("O diretório não foi encontrado: " & filePath)
                Console.WriteLine("O diretório não foi encontrado: " & filePath)
                Return False
            End If
            Return True
        End Function

        Public Function ProcessarArquivo(inputFile As String, ByRef contadorTotal As Integer) As Boolean Implements ILeitor.ProcessarArquivo
            If Path.GetFileName(inputFile).Contains("E") Then
                logger.Log($"O arquivo {Path.GetFileName(inputFile)} não será processado porque contém a letra 'E' maiúscula no nome.")
                Return False
            End If

            Dim contador As Integer = 0
            Dim contadorMasculino As Integer = 0
            Dim contadorFeminino As Integer = 0
            Dim pessoasMasculinas As New List(Of Pessoa.Pessoa)()
            Dim pessoasFemininas As New List(Of Pessoa.Pessoa)()

            Try
                Dim lines() As String = File.ReadAllLines(inputFile)

                For Each line As String In lines
                    Dim pessoa As Pessoa.Pessoa = ILeitor_CriarPessoa(line)
                    If pessoa IsNot Nothing Then
                        If String.Equals(pessoa.Sexo, "Masculino", StringComparison.OrdinalIgnoreCase) Then
                            contadorMasculino += 1
                            pessoasMasculinas.Add(pessoa)
                        ElseIf String.Equals(pessoa.Sexo, "Feminino", StringComparison.OrdinalIgnoreCase) Then
                            contadorFeminino += 1
                            pessoasFemininas.Add(pessoa)
                        End If
                        contador += 1
                    End If
                Next

                ExibirResultados(inputFile, contador, contadorMasculino, contadorFeminino, pessoasFemininas)
                contadorTotal += contador
                Return True
            Catch ex As Exception
                logger.Log("Ocorreu um erro ao processar o arquivo " & inputFile & ": " & ex.Message)
                Console.WriteLine("Ocorreu um erro ao processar o arquivo " & inputFile & ": " & ex.Message)
                Return False
            End Try
        End Function
        Private Function ILeitor_CriarPessoa(line As String) As Pessoa.Pessoa Implements ILeitor.CriarPessoa
            Dim elements() As String = line.Split(";"c)
            If elements.Length < 5 Then Return Nothing ' Verifica se a linha tem elementos suficientes

            Return New Pessoa.Pessoa With {
        .Nome = elements(0).Trim(),
        .Sobrenome = elements(1).Trim(),
        .Idade = Convert.ToInt32(elements(2).Trim()),
        .Sexo = elements(3).Trim(),
        .Cidade = elements(4).Trim()
            }
        End Function
        Public Sub ExibirResultados(inputFile As String, contador As Integer, contadorMasculino As Integer, contadorFeminino As Integer, pessoasFemininas As List(Of Pessoa.Pessoa)) Implements ILeitor.ExibirResultados
            Dim jsonString As String = JsonConvert.SerializeObject(pessoasFemininas, Formatting.Indented)
            Console.WriteLine("____________________________________________")
            Console.WriteLine($"Arquivo: {Path.GetFileName(inputFile)}")
            Console.WriteLine("Total de linhas do arquivo: " & "****" & contador & "****")
            Console.WriteLine("Total de linhas processadas: " & "****" & contadorFeminino & "****")
            Console.WriteLine("Total de linhas não processadas: " & "****" & contadorMasculino & "****")
            Console.WriteLine(jsonString)
            logger.Log("Arquivo processado: " & inputFile)
        End Sub
    End Class
End Namespace