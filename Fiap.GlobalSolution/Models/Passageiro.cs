using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.GlobalSolution.Models
{
    [Table("TB_FB_PASSAGEIRO")]
    public class Passageiro
    {
        [HiddenInput, Column("Id")]
        public int PassageiroId { get; set; }

        [Required, Column("Nm_passageiro")]
        public string? Nome { get; set; }

        [Column("Nr_cpf")]
        public string Cpf { get; set; }

        [Required, Column("Nr_rg")]
        public string? Rg { get; set; }

        [Required, Column("Ds_email")]
        public string? Email { get; set; }

        [Required, Column("Ds_senha")]
        public string? Senha { get; set; }

        public IList<Corrida> Corridas { get; set; }
    }
}
