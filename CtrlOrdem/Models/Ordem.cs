using System.ComponentModel.DataAnnotations;

namespace CtrlOrdem.Models;

public class Ordem
{
    [Key]
    public int OrdemId { get; set; }

    public Cliente? Cliente { get; set; }
    [Display(Name = "Cliente")]
    [Required(ErrorMessage = "Informe o Cliente")]
    public int ClienteId { get; set; }

    public Tecnico? Tecnico { get; set; }
    [Display(Name = "Técnico Responsável")]
    [Required(ErrorMessage = "Informe o Técnico Responsável")]
    public int TecnicoId { get; set; }

    [Display(Name = "Data da Abertura")]
    [Required(ErrorMessage = "Informe a Data da Abertura")]
    [DataType(DataType.Date)]
    public DateTime Abertura { get; set; } = DateTime.Now;

    public Servico? Servico { get; set; }
    [Display(Name = "Selecione o Serviço")]
    [Required(ErrorMessage = "Informe o Serviço")]
    public int ServicoId { get; set; }

    [Display(Name = "Procedimento Detalhado")]
    [Required(ErrorMessage = "Informe o Procedimento Detalhado")]
    [MaxLength(200)]
    public string? Procedimento { get; set; }

    [Display(Name = "Quantidade de Horas")]
    [Required(ErrorMessage = "Informe quantidade de horas")]
    public double Tempo { get; set; }

    [Display(Name = "Taxa Adicionais")]
    [Required(ErrorMessage = "Informe a Taxa ou 0,00")]
    public double Taxas { get; set; }

    [Display(Name = "Descontos")]
    [Required(ErrorMessage = "Informe o Desconto ou 0,00")]
    public double Desconto { get; set; }

    [Display(Name = "Observação")]
    public string? Observacao { get; set; }
    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione o Status válido.")]
    public string? Status { get; set; }

}
