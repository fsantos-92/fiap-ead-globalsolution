using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.GlobalSolution.Models
{
    [Table("TB_FB_MOTORISTA")]
    public class Motorista
    {
        [HiddenInput, Column("Id")]
        public int MotoristaId { get; set; }

        [Required, Column("Nm_motorista")]
        public string? Nome { get; set; }

        [Column("Nr_cpf")]
        public string? Cpf { get; set; }

        [Required, Column("Nr_cnh")]
        public string? Cnh { get; set; }

        [Required, Column("St_ativo"), DisplayName("Cadastro ativo")]
        public bool IsAtivo { get; set; }

        [Required, Column("Ds_email")]
        public string? Email { get; set; }

        [Required, Column("Ds_senha")]
        public string? Senha { get; set; }

        [Required, Column("Dt_cadastro"), DisplayName("Data de cadastro"), DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public IList<MotoristaPontoTrabalho> MotoristaPontoTrabalhos { get; set; }

        public Telefone Telefone { get; set; }

        public int TelefoneId { get; set; }

        public IList<Veiculo> Veiculos { get; set; }

        public IList<Corrida> Corridas { get; set; }
    }
}
