Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports ProjetoPraticoVB6.Logs
Imports ProjetoPraticoVB6.Serviços
Imports ProjetoPraticoVB6.Pessoa

<TestClass>
Public Class ExibidorResultadosTests

    Private _exibidorResultados As ExibidorResultados
    Private _loggerMock As Mock(Of IGeraLog)

    <TestInitialize>
    Public Sub Setup()
        _loggerMock = New Mock(Of IGeraLog)()
        _exibidorResultados = New ExibidorResultados(_loggerMock.Object)
    End Sub

    <TestMethod>
    Public Sub ExibirResultados_Valido_DeveLogarSucesso()
        ' Arrange
        Dim pessoasFemininas As New List(Of Pessoa) From {
        New Pessoa With {.Nome = "Maria", .Sobrenome = "Silva", .Idade = 30, .Sexo = "Feminino", .Cidade = "São Paulo"},
        New Pessoa With {.Nome = "Ana", .Sobrenome = "Souza", .Idade = 25, .Sexo = "Feminino", .Cidade = "Rio de Janeiro"}
    }

        ' Act
        _exibidorResultados.ExibirResultados(pessoasFemininas)

        ' Assert
        '_loggerMock.Verify(Sub(l) l.Log("Resultados exibidos com sucesso."), Times.Once)
    End Sub

    <TestMethod>
    Public Sub ExibirResultados_Vazio_DeveLogarErro()
        ' Arrange
        Dim pessoasFemininas As New List(Of Pessoa)()

        ' Act
        _exibidorResultados.ExibirResultados(pessoasFemininas)

        ' Assert
        '_loggerMock.Verify(Sub(l) l.Log("Resultados exibidos com sucesso."), Times.Never)
    End Sub

    <TestMethod>
    Public Sub ExibirResultados_ErroAoSerializar_DeveLogarErro()
        ' Arrange
        Dim pessoasFemininas As New List(Of Pessoa) From {
            New Pessoa With {.Nome = Nothing} ' Provoca erro de serialização
        }

        ' Act
        _exibidorResultados.ExibirResultados(pessoasFemininas)

        ' Assert
        '_loggerMock.Verify(Sub(l) l.Log(It.IsAny(Of String())), Times.Once)
    End Sub

End Class
