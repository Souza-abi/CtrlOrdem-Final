using System.ComponentModel.DataAnnotations;

namespace CtrlOrdem.Models;

public class Cliente
{
    [Key]
    public int ClienteID { get; set; }

    [Display(Name = "Nome ou Razão Social")]
    [Required(ErrorMessage = "Informe o Nome ou a Razão Social")]
    [MaxLength(150)]
    public string? NomeCompleto { get; set; }

    [Display(Name = "CPF ou CNPJ")]
    [Required(ErrorMessage = "Informe o CPF ou CNPJ")]
    [MaxLength(18)]
    public string? CPFCNPJ { get; set; }

    [Display(Name = "Nascimento/Abertura")]
    [Required(ErrorMessage = "Informe a Data Nascimento ou Data de Abertura")]
    [DataType(DataType.Date)]
    public DateTime? DataNA { get; set; } // Data de Nascimento ou Abetura

    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione um Sexo válido.")]
    public string? Sexo { get; set; }

    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione um Estado Civil válido.")]

    [Display(Name = "Estado Civil")]
    public string? EstadoCivil { get; set; }

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
    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione um Estado válido.")]
    [MaxLength(02)]
    public string? UF { get; set; }

    [Required(ErrorMessage = "Informe o CEP")]
    [MaxLength(09)]
    public string? CEP { get; set; }

    [Display(Name = "Data do Cadastro")]
    [Required(ErrorMessage = "Informe a Data do Cadastro")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

    public DateTime DataCadastro { get; set; } = DateTime.Now;

    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione um Status válido.")]
    public string? Status { get; set; }

    [Display(Name = "Observação")]
    public string? Observacao { get; set; }

    [Display(Name = "Contato")]
    [MaxLength(100)]
    [StringLength(200)]
    public string? Contato { get; set; } // Para casos de clientes corporativos ou emergências

    [Display(Name = "Preferencia de Contato")]

    [RegularExpression("^(?!Selecione...).*$", ErrorMessage = "Selecione um Tipo de Contato válido.")]
    public string? TipoContato { get; set; } // Contato Telefone, e-mail


}