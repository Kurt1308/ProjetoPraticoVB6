Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProjetoPraticoVB6
Imports ProjetoPraticoVB6.Logs
Imports ProjetoPraticoVB6.Serviços
Imports System.Collections.Generic ' Certifique-se de incluir isso

Namespace ModuloTestes
    <TestClass>
    Public Class ExibidorResultadosTests
        <TestMethod>
        Public Sub TestarExibirResultados()
            ' Arrange
            Dim logger As IGeraLog = New Logs.GeraLog()
            Dim exibidor As IExibidorResultados = New ExibidorResultados(logger)
            Dim pessoas As New List(Of ProjetoPraticoVB6.Pessoa.Pessoa)() ' Ajuste conforme necessário

            ' Adicionar uma pessoa para teste
            Dim pessoa As New ProjetoPraticoVB6.Pessoa.Pessoa() ' Ajuste conforme necessário
            pessoa.Nome = "Maria"
            pessoa.Sobrenome = "Oliveira"
            pessoa.Idade = 28
            pessoa.Sexo = "Feminino"
            pessoa.Cidade = "Rio de Janeiro"

            pessoas.Add(pessoa)

            ' Act
            exibidor.ExibirResultados(pessoas)

            ' Assert
            ' Aqui você pode adicionar asserções para verificar se o resultado foi exibido corretamente
        End Sub
    End Class
End Namespace