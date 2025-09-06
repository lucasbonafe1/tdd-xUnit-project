using tddXunitCourse.Domain.Entidades;
using tddXunitCourse.Domain.Enums;

namespace tddXunitCourse.DomainTest._Builders;

public class CursoBuilder
{
    private string _nome = "Informatica básica";
    private string _description = "Curso aprofundado sobre técnicas de informática.";
    private int _cargaHoraria = 80;
    private PublicoAlvoEnum _publicoAlvo = PublicoAlvoEnum.Estudante;
    private double _preco = 400;
    private bool _ativo = true;

    public CursoBuilder ComNome(string nome)
    {
        _nome = nome;
        return this;
    }

    public CursoBuilder ComPreco(double preco)
    {
        _preco = preco;
        return this;
    }

    public CursoBuilder ComCargaHoraria(int cargaHoraria)
    {
        _cargaHoraria = cargaHoraria;
        return this;
    }

    public static CursoBuilder Novo()
    {
        return new CursoBuilder();
    }

    public Curso Build()
    {
        return new Curso(_nome, _description, _cargaHoraria, _publicoAlvo, _preco, _ativo);
    }
}
