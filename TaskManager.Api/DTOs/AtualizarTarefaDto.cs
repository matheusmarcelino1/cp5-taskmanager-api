using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.DTOs;

public class AtualizarTarefaDto
{
    [Required(ErrorMessage = "O título é obrigatório.")]
    [MaxLength(100)]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [MaxLength(500)]
    public string Descricao { get; set; } = string.Empty;

    public bool Concluida { get; set; }
}