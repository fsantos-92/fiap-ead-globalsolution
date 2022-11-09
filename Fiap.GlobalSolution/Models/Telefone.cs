using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.GlobalSolution.Models
{
    [Table("TB_FB_TELEFONE")]
    public class Telefone
    {
        [HiddenInput, Column("Id")]
        public int TelefoneId { get; set; }

        [Required, Column("Nr_ddd")]
        public string? Ddd { get; set; }

        [Required, Column("Nr_telefone")]
        public string? Numero{ get; set; }

    }
}
