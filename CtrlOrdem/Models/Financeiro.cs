using System.ComponentModel.DataAnnotations;

namespace CtrlOrdem.Models;

public class Financeiro
{
    [Key]
    public int FinanceiroId { get; set; }
    [Display(Name = "Ordem de Serviço")]
    [Required(ErrorMessage = "Informe o Número da Ordem de Serviço")]
    public int OrdemId { get; set; }

    [Display(Name = "Forma de Pagamento")]
    [Required(ErrorMessage = "Informe a Forma de Pagamento")]
    public string? FormaPagto { get; set; }

    [Display(Name = "Condição de Pagamento")]
    [Required(ErrorMessage = "Informe a Condição de Pagamento")]
    public string? CondPagto { get; set; }

    [Display(Name = "Data de Vencimento")]
    [Required(ErrorMessage = "Informe a Data de Vencimento")]
    [DataType(DataType.Date)]
    public DateTime Vencimento { get; set; }

    [Display(Name = "Data de Pagamento")]
    [Required(ErrorMessage = "Informe a Data de Pagamento")]
    [DataType(DataType.Date)]
    public DateTime Pagto { get; set; }

}
