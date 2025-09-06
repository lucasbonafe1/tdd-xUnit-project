using tddXunitCourse.Domain.Entidades;
using tddXunitCourse.DomainTest._Builders;
using tddXunitCourse.DomainTest._Util;

namespace tddXunitCourse.DomainTest.Cursos;

public class CursoTest
{
    private readonly CursoBuilder _cursoBuilder;

    public CursoTest()
    {
        _cursoBuilder = CursoBuilder.Novo();
    }

    [Fact]
    public void DadoQueDadosSaoValidos_DeveCriarCurso()
    {
        //Arrange
        var cursoEsperado = _cursoBuilder;

        //Act 
        var cursoCriado = new Curso(cursoEsperado.Build());

        //Assert
        AssertExtension.ObjetoEquivalente(cursoEsperado, cursoCriado);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DadoQueNomeEInvalido_DeveRetornarExcecao(string nomeInvalido)
    {
        //Arrange
        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => _cursoBuilder.ComNome(nomeInvalido).Build())
             .ComMensagem("O nome do curso não pode ser nulo ou vazio.");
    }

    [Theory]
    [InlineData(-2)]
    [InlineData(0)]
    [InlineData(null)]
    public void DadoQueCargaHorariaInvalida_DeveRetornarExcecao(int cargaHorariaInvalida)
    {
        //Arrange
        //Act & Assert
        Assert.Throws<ArgumentException>(() => _cursoBuilder.ComCargaHoraria(cargaHorariaInvalida).Build())
             .ComMensagem("A carga horária deve ser maior que zero.");
    }

    [Theory]
    [InlineData(-2.3)]
    [InlineData(-0.3)]
    [InlineData(-100)]
    public void DadoQuePrecoInvalido_DeveRetornarExcecao(double precoInvalido)
    {
        //Arrange
        //Act & Assert
        Assert.Throws<ArgumentException>(() => _cursoBuilder.ComPreco(precoInvalido).Build())
            .ComMensagem("O preço do curso não pode ser negativo.");
    }
}