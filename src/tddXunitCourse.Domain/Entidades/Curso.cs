using tddXunitCourse.Domain.Enums;

namespace tddXunitCourse.Domain.Entidades;

public class Curso
{
    public int Id { get; set; } 
    public string Nome { get; set; } = string.Empty;    
    public string Descricao { get; set; } = string.Empty;
    public PublicoAlvoEnum PublicoAlvo { get; set; }
    public int CargaHoraria { get; set; } 
    public double Preco { get; set; } 
    public bool Ativo { get; set; }

    public Curso(string nome, string descricao, int cargaHoraria, PublicoAlvoEnum publicoAlvo, double preco, bool ativo)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentNullException(nameof(nome), "O nome do curso não pode ser nulo ou vazio.");

        if (cargaHoraria <= 0)
            throw new ArgumentException("A carga horária deve ser maior que zero.", nameof(cargaHoraria));

        if (preco < 0)
            throw new ArgumentException("O preço do curso não pode ser negativo.", nameof(preco));

        Nome = nome;
        Descricao = descricao;
        CargaHoraria = cargaHoraria;
        PublicoAlvo = publicoAlvo;
        Preco = preco;
        Ativo = ativo;
    }

    public Curso(Curso curso)
    {
        if (string.IsNullOrWhiteSpace(curso.Nome))
            throw new ArgumentNullException(nameof(curso.Nome), "O nome do curso não pode ser nulo ou vazio.");

        if (curso.CargaHoraria <= 0)
            throw new ArgumentException("A carga horária deve ser maior que zero.", nameof(curso.CargaHoraria));

        if (curso.Preco < 0)
            throw new ArgumentException("O preço do curso não pode ser negativo.", nameof(curso.Preco));

        Nome = curso.Nome;
        Descricao = curso.Descricao;
        CargaHoraria = curso.CargaHoraria;
        PublicoAlvo = curso.PublicoAlvo;
        Preco = curso.Preco;
        Ativo = curso.Ativo;
    }
}
