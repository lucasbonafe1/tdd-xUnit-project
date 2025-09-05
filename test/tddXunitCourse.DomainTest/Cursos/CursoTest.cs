using tddXunitCourse.Domain.Entidades;

namespace tddXunitCourse.DomainTest.Cursos;

public class CursoTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void CriarCurso_DadoQueDadosSaoValidos_DeveCriarCurso(string nomeInvalido)
    {
        var cursoEsperado = new
        {
            Nome = "Curso de Testes Unitários",
            Descricao = "Aprenda a escrever testes unitários eficazes.",
            CargaHoraria = 40,
            Preco = 199.99m,
            Ativo = true
        };

        var message = Assert.Throws<ArgumentNullException>(() => new Curso(nomeInvalido, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.Preco, cursoEsperado.Ativo
            )).Message;

    }
}