Imports Newtonsoft.Json
Imports ProjetoPraticoVB6.Logs

Namespace Serviços
    Public Class ExibidorResultados
        Implements IExibidorResultados

        Private logger As IGeraLog

        Public Sub New()
            logger = New GeraLog()
        End Sub

        Public Sub ExibirResultados(pessoasFemininas As List(Of Pessoa.Pessoa)) Implements IExibidorResultados.ExibirResultados
            Try
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