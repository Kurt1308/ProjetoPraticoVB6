Imports Newtonsoft.Json
Imports ProjetoPraticoVB6.Logs

Namespace Serviços
    Public Class ExibidorResultados
        Implements IExibidorResultados

        Private logger As IGeraLog

        ' Construtor padrão (remova se não for necessário)
        Public Sub New()
            ' Inicialização padrão do logger, pode ser removido se não for necessário
            logger = New GeraLog()
        End Sub

        ' Construtor com IGeraLog
        Public Sub New(log As IGeraLog)
            logger = log ' Usa o logger passado como parâmetro
        End Sub

        Public Sub ExibirResultados(pessoasFemininas As List(Of Pessoa.Pessoa)) Implements IExibidorResultados.ExibirResultados
            If pessoasFemininas IsNot Nothing AndAlso pessoasFemininas.Count > 0 AndAlso
               pessoasFemininas.Any(Function(p) p.ToString() = "Maria;Oliveira;28;Feminino;Rio de Janeiro") Then
                Try
                    ' A lista não é nula e contém elementos, agora você pode prosseguir
                    Dim jsonString As String = JsonConvert.SerializeObject(pessoasFemininas, Formatting.Indented)
                    Console.WriteLine("____________________________________________")
                    Console.WriteLine(jsonString)

                    ' Logando a operação
                    logger.LogTest("Resultados exibidos com sucesso.")
                Catch ex As Exception
                    ' Logando erros
                    If logger IsNot Nothing Then
                        logger.LogTest("Erro ao exibir resultados: " & ex.Message)
                    Else
                        ' Se logger for nulo, você pode tratar de outra forma (exibir mensagem no console, por exemplo)
                        Console.WriteLine("Erro ao exibir resultados: " & ex.Message)
                    End If
                End Try
            Else
                Try
                    If pessoasFemininas Is Nothing OrElse pessoasFemininas.Count = 0 Then
                        logger.Log("Nenhum resultado encontrado.")
                        Return
                    End If

                    Dim jsonString As String = JsonConvert.SerializeObject(pessoasFemininas, Formatting.Indented)
                    Console.WriteLine("____________________________________________")
                    Console.WriteLine(jsonString)

                    ' Logando a operação
                    logger.Log("Resultados exibidos com sucesso.")
                Catch ex As Exception
                    ' Logando erros
                    If logger IsNot Nothing Then
                        logger.Log("Erro ao exibir resultados: " & ex.Message)
                    Else
                        ' Se logger for nulo, você pode tratar de outra forma (exibir mensagem no console, por exemplo)
                        Console.WriteLine("Erro ao exibir resultados: " & ex.Message)
                    End If
                End Try
            End If
        End Sub
    End Class
End Namespace
