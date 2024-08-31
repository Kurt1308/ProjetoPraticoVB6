Imports System
Imports System.IO
Imports ProjetoPraticoVB6.Logs
Imports ProjetoPraticoVB6.Pessoa ' Ajuste conforme necessário
Imports ProjetoPraticoVB6.Serviços ' Ajuste conforme necessário

Namespace Leitor
    Public Class Leitor
        Implements ILeitor

        ' Campos para construtores
        Private logger As IGeraLog
        Private verificadorDiretorio As IVerificadorDiretorio
        Private exibidorResultados As IExibidorResultados

        ' Inicializa os construtores
        Public Sub New()
            logger = New Logs.GeraLog()
            verificadorDiretorio = New Serviços.VerificadorDiretorio(logger)
            exibidorResultados = New Serviços.ExibidorResultados() ' Inicializa a classe ExibidorResultados
        End Sub

        Public Sub LerArquivos(filePath As String) Implements ILeitor.LerArquivos
            If Not verificadorDiretorio.VerificarDiretorio(filePath) Then Return

            Dim arquivos As String() = Directory.GetFiles(filePath, "*.txt")
            Dim contadorTotal As Integer = 0
            Dim todasPessoasFemininas As New List(Of Pessoa.Pessoa)()

            For Each inputFile As String In arquivos
                Dim pessoasFemininas As List(Of Pessoa.Pessoa) = ProcessarArquivo(inputFile, contadorTotal)
                If pessoasFemininas IsNot Nothing Then
                    todasPessoasFemininas.AddRange(pessoasFemininas)
                End If
            Next

            If contadorTotal = 0 Then
                logger.Log("Nenhum arquivo .txt encontrado ou processado.")
                Console.WriteLine("Nenhum arquivo .txt encontrado ou processado.")
            ElseIf todasPessoasFemininas.Count > 0 Then
                exibidorResultados.ExibirResultados(todasPessoasFemininas) ' Usa a classe ExibidorResultados
            End If
        End Sub

        Public Function ProcessarArquivo(inputFile As String, ByRef contadorTotal As Integer) As List(Of Pessoa.Pessoa) Implements ILeitor.ProcessarArquivo
            If Path.GetFileName(inputFile).Contains("E") Then
                logger.Log($"O arquivo {Path.GetFileName(inputFile)} não será processado porque contém a letra 'E' maiúscula no nome.")
                Return Nothing
            End If

            Dim contador As Integer = 0
            Dim contadorMasculino As Integer = 0
            Dim contadorFeminino As Integer = 0
            Dim pessoasMasculinas As New List(Of Pessoa.Pessoa)()
            Dim pessoasFemininas As New List(Of Pessoa.Pessoa)()

            Try
                Dim lines() As String = File.ReadAllLines(inputFile)

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
                        contador += 1
                    End If
                Next

                contadorTotal += contador
                Return pessoasFemininas
            Catch ex As Exception
                logger.Log("Ocorreu um erro ao processar o arquivo " & inputFile & ": " & ex.Message)
                Console.WriteLine("Ocorreu um erro ao processar o arquivo " & inputFile & ": " & ex.Message)
                Return Nothing
            End Try
        End Function

        Private Function CriarPessoa(line As String) As Pessoa.Pessoa Implements ILeitor.CriarPessoa
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
    End Class
End Namespace
