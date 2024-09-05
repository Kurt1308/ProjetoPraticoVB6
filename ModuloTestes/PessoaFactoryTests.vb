Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProjetoPraticoVB6
Imports ProjetoPraticoVB6.Logs
Imports ProjetoPraticoVB6.Serviços

Namespace ModuloTestes
    <TestClass>
    Public Class PessoaFactoryTests
        <TestMethod>
        Public Sub TestarCriarPessoa()
            ' Arrange
            Dim logger As IGeraLog = New Logs.GeraLog()
            Dim pessoaFactory As IPessoaFactory = New PessoaFactory(logger)
            Dim linha As String = "Maria;Oliveira;28;Feminino;Rio de Janeiro"

            ' Act
            Dim pessoa As Pessoa.Pessoa = pessoaFactory.CriarPessoa(linha)

            ' Assert
            Assert.IsNotNull(pessoa, "A pessoa não deve ser nula.")
            Assert.AreEqual("Maria", pessoa.Nome, "O nome da pessoa não está correto.")
            Assert.AreEqual("Oliveira", pessoa.Sobrenome, "O sobrenome da pessoa não está correto.")
        End Sub
    End Class
End Namespace
