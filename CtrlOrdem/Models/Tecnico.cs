using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CtrlOrdem.Models;

public class Tecnico
{
    [Key]
    public int TecnicoId { get; set; }

    [Display(Name = "Nome do Técnico")]
    [Required(ErrorMessage = "Informe o Nome do Técnico")]
    [MaxLength(150)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Informe o Número do CPF")]
    [MaxLength(14)]
    public string? CPF { get; set; }

    [Required(ErrorMessage = "Informe o Número do RG")]
    [MaxLength(20)]
    public string? RG { get; set; }

    [Display(Name = "Data Nascimento")]
    [Required(ErrorMessage = "Informe a Data Nascimento")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }
    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione Sexo válido.")]
    public string? Sexo { get; set; }

    [Required(ErrorMessage = "Informe a Nascionalidade")]
    [MaxLength(50)]
    public string? Nacionalidade { get; set; }
    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione Estado Civil válido.")]

    [Display(Name = "Estado Civil")]
    public string? EstadoCivil { get; set; }

    [Display(Name = "Endereço")]
    [Required(ErrorMessage = "Informe o Endereço")]
    [MaxLength(150)]
    public string? Endereco { get; set; }

    [Display(Name = "Número")]
    [Required(ErrorMessage = "Informe o Número")]
    [MaxLength(05)]
    public string? Numero { get; set; }

    [MaxLength(100)]
    public string? Complemento { get; set; }

    [Required(ErrorMessage = "Informe o Bairro")]
    [MaxLength(100)]
    public string? Bairro { get; set; }

    [Required(ErrorMessage = "Informe a Cidade")]
    [MaxLength(100)]
    public string? Cidade { get; set; }

    [Required(ErrorMessage = "Informe a Sigla do Estado")]
    [MaxLength(02)]
    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione Estado válido.")]
    public string? UF { get; set; }

    [Required(ErrorMessage = "Informe o CEP")]
    [MaxLength(09)]
    public string? CEP { get; set; }

    [MaxLength(30)]
    public string? Telefone { get; set; }

    [Required(ErrorMessage = "Informe o Celular")]
    [MaxLength(30)]
    public string? Celular { get; set; }

    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "Informe o E-mail")]
    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; }
    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione Cargo válido.")]
    public string? Cargo { get; set; } // ex.: Técnico de Manutenção, Técnico de Instalação, Supervisor
    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione Departamento válido.")]
    public string? Departamento { get; set; } // ex.: Manutenção, Suporte Técnico

    [Display(Name = "Data Contratação")]
    [Required(ErrorMessage = "Informe a Data da Contratação")]
    [DataType(DataType.Date)]
    public DateTime DataContratacao { get; set; } = DateTime.Now;

    [Display(Name = "Salário")]
    [Required(ErrorMessage = "Informe o Salário")]
    public double Salario { get; set; }
    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione Tipo de Contrato válido.")]

    [Display(Name = "Tipo de Contrato")]
    [Required(ErrorMessage = "Informe o Tipo de Contrato")]
    public string? Tipo { get; set; } // ex.: CLT, PJ, Freelance

    [Display(Name = "Observação")]
    [MaxLength(200)]
    public string? Observacao { get; set; }

}
