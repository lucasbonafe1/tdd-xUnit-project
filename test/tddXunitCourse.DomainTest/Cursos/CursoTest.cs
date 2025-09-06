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
            Nome = "Curso de Testes Unitários",
            Descricao = "Aprenda a escrever testes unitários eficazes.",
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
            Nome = "Curso de Testes Unitários",
            Descricao = "Aprenda a escrever testes unitários eficazes.",
            CargaHoraria = 40,
            Preco = 199.99m,
            Ativo = true
        };

        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Curso(nomeInvalido, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.Preco, cursoEsperado.Ativo))
             .ComMensagem("O nome do curso não pode ser nulo ou vazio.");
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
            Nome = "Curso de Testes Unitários",
            Descricao = "Aprenda a escrever testes unitários eficazes.",
            Preco = 199.99m,
            Ativo = true
        };

        //Act
        //Act & Assert
        Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cargaHorariaInvalida, cursoEsperado.Preco, cursoEsperado.Ativo))
             .ComMensagem("A carga horária deve ser maior que zero.");
    }

    [Fact]
    public void DadoQuePrecoInvalido_DeveRetornarExcecao()
    {
        //Arrange
        var cursoEsperado = new
        {
            Nome = "Curso de Testes Unitários",
            Descricao = "Aprenda a escrever testes unitários eficazes.",
            CargaHoraria = 40,
            Preco = -2,
            Ativo = true
        };

        //Act & Assert
        Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.Preco, cursoEsperado.Ativo))
            .ComMensagem("O preço do curso não pode ser negativo.");
    }
}