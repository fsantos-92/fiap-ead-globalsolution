using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.GlobalSolution.Models
{
    [Table("TB_FB_PRONTO_TRABALHO")]
    public class PontoTrabalho
    {
        [HiddenInput, Column("Id")]
        public int PontoTrabalhoId { get; set; }

        [Column("ds_nome")]
        public string Nome { get; set; }

        [Required,Column("ds_endereco")]
        public string? Endereco { get; set; }

        public IList<MotoristaPontoTrabalho> MotoristaPontoTrabalhos { get; set; }
    }
}
