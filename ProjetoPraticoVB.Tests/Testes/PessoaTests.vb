Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProjetoPraticoVB6.Pessoa

<TestClass>
Public Class PessoaTests
    <TestMethod>
    Public Sub TestPessoaProperties()
        Dim pessoa As New Pessoa() With {
            .Nome = "João",
            .Sobrenome = "Silva",
            .Idade = 30,
            .Sexo = "Masculino",
            .Cidade = "São Paulo"
        }

        Assert.AreEqual("João", pessoa.Nome)
        Assert.AreEqual("Silva", pessoa.Sobrenome)
        Assert.AreEqual(30, pessoa.Idade)
        Assert.AreEqual("Masculino", pessoa.Sexo)
        Assert.AreEqual("São Paulo", pessoa.Cidade)
    End Sub
End Class
