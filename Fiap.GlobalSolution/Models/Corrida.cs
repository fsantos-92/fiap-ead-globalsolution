using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.GlobalSolution.Models
{
    [Table("TB_FB_CORRIDA")]
    public class Corrida
    {
        [HiddenInput, Column("Id")]
        public int CorridaId { get; set; }

        [Required, Column("Ds_origem")]
        public string? Origem { get; set; }

        [Required, Column("Ds_destino")]
        public string? Destino { get; set; }

        [Column("Vl_corrida", TypeName = "decimal(8,2)")]
        public decimal Valor { get; set; }

        [Required, Column("Dt_corrida")]
        public DateTime Data { get; set; }

        [Required, Column("st_finalizado"), DisplayName("Finalizada?")]
        public bool isFinalizada { get; set; }

        public Passageiro Passageiro { get; set; }
        public int PassageiroId { get; set; }

        public Motorista Motorista { get; set; }
        public int MotoristaId { get; set; }
    }
}
