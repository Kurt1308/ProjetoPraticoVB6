Imports Newtonsoft.Json

Namespace Serviços
    Public Class ExibidorResultados
        Implements IExibidorResultados

        Public Sub ExibirResultados(pessoasFemininas As List(Of Pessoa.Pessoa)) Implements IExibidorResultados.ExibirResultados
            Dim jsonString As String = JsonConvert.SerializeObject(pessoasFemininas, Formatting.Indented)
            Console.WriteLine("____________________________________________")
            Console.WriteLine(jsonString)
        End Sub
    End Class
End Namespace