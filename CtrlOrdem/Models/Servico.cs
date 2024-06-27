using System.ComponentModel.DataAnnotations;

namespace CtrlOrdem.Models;

public class Servico
{
    [Key]
    public int ServicoId { get; set; }

    [Display(Name = "Descrição do Serviço")]
    [Required(ErrorMessage = "Informe a Descrição")]
    [MaxLength(200)]
    public string? Descricao { get; set; }
    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione um Categoria válido.")]
    public string? Categoria { get; set; }

    [Display(Name = "Valor Hora")]
    [Required(ErrorMessage = "Informe o Valor Hora")]

    [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
    public double Valor { get; set; }

    [MaxLength(100)]
    public string? Garantia { get; set; }



}
