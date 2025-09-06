using tddXunitCourse.Domain.Entidades;
using tddXunitCourse.DomainTest._Util;

namespace tddXunitCourse.DomainTest.Cursos;

public class CursoTest
{

    [Fact]
    public void DadoQueDadosSaoValidos_DeveCriarCurso()
    {
        //Arrange
        var cursoEsperado = new
        {
            Nome = "Curso de Testes Unit�rios",
            Descricao = "Aprenda a escrever testes unit�rios eficazes.",
            CargaHoraria = 40,
            Preco = 199.99m,
            Ativo = true
        };

        //Act 
        var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.Preco, cursoEsperado.Ativo);

        //Assert
        AssertExtension.ObjetoEquivalente(cursoEsperado, curso);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DadoQueNomeEInvalido_DeveRetornarExcecao(string nomeInvalido)
    {
        //Arrange
        var cursoEsperado = new
        {
            Nome = "Curso de Testes Unit�rios",
            Descricao = "Aprenda a escrever testes unit�rios eficazes.",
            CargaHoraria = 40,
            Preco = 199.99m,
            Ativo = true
        };

        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Curso(nomeInvalido, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.Preco, cursoEsperado.Ativo))
             .ComMensagem("O nome do curso n�o pode ser nulo ou vazio.");
    }

    [Theory]
    [InlineData(-2)]
    [InlineData(0)]
    [InlineData(null)]
    public void DadoQueCargaHorariaInvalida_DeveRetornarExcecao(int cargaHorariaInvalida)
    {
        //Arrange
        var cursoEsperado = new
        {
            Nome = "Curso de Testes Unit�rios",
            Descricao = "Aprenda a escrever testes unit�rios eficazes.",
            Preco = 199.99m,
            Ativo = true
        };

        //Act
        //Act & Assert
        Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cargaHorariaInvalida, cursoEsperado.Preco, cursoEsperado.Ativo))
             .ComMensagem("A carga hor�ria deve ser maior que zero.");
    }

    [Fact]
    public void DadoQuePrecoInvalido_DeveRetornarExcecao()
    {
        //Arrange
        var cursoEsperado = new
        {
            Nome = "Curso de Testes Unit�rios",
            Descricao = "Aprenda a escrever testes unit�rios eficazes.",
            CargaHoraria = 40,
            Preco = -2,
            Ativo = true
        };

        //Act & Assert
        Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.Preco, cursoEsperado.Ativo))
            .ComMensagem("O pre�o do curso n�o pode ser negativo.");
    }
}