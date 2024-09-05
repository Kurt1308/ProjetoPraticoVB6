Imports ProjetoPraticoVB6.Logs

Namespace Serviços
    Public Class PessoaFactory
        Implements IPessoaFactory

        Private logger As IGeraLog

        Public Sub New(logger As IGeraLog)
            Me.logger = logger
        End Sub

        Public Function CriarPessoa(line As String) As Pessoa.Pessoa Implements IPessoaFactory.CriarPessoa
            Dim elements() As String = line.Split(";"c)

            If String.Equals(elements(0).Trim(), "Maria", StringComparison.OrdinalIgnoreCase) Then
                logger.Log($"Criando pessoa: {elements(0).Trim()} {elements(1).Trim()}.")
                If elements.Length < 5 Then Return Nothing ' Verifica se a linha tem elementos suficientes

                Return New Pessoa.Pessoa With {
                .Nome = elements(0).Trim(),
                .Sobrenome = elements(1).Trim(),
                .Idade = Convert.ToInt32(elements(2).Trim()),
                .Sexo = elements(3).Trim(),
                .Cidade = elements(4).Trim()
            }
            Else
                logger.Log($"Criando pessoa: {elements(0).Trim()} {elements(1).Trim()}.")
                If elements.Length < 5 Then Return Nothing ' Verifica se a linha tem elementos suficientes

                Return New Pessoa.Pessoa With {
                .Nome = elements(0).Trim(),
                .Sobrenome = elements(1).Trim(),
                .Idade = Convert.ToInt32(elements(2).Trim()),
                .Sexo = elements(3).Trim(),
                .Cidade = elements(4).Trim()
            }
            End If

        End Function
    End Class
End Namespace
