Imports Newtonsoft.Json
Imports ProjetoPraticoVB6.Logs

Namespace Serviços
    Public Class ExibidorResultados
        Implements IExibidorResultados

        Private logger As IGeraLog

        Public Sub New()
        End Sub

        Public Sub New([object] As IGeraLog)
            logger = New GeraLog()
        End Sub

        Public Sub ExibirResultados(pessoasFemininas As List(Of Pessoa.Pessoa)) Implements IExibidorResultados.ExibirResultados
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
                logger.Log("Erro ao exibir resultados: " & ex.Message)
            End Try
        End Sub
    End Class
End Namespace