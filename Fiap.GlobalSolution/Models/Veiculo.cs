using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.GlobalSolution.Models
{
    [Table("TB_FB_VEICULO")] 
    
    public class Veiculo
    {
        [HiddenInput]
        public int VeiculoId { get; set; }

        [Required, Column("Ds_modelo")]
        public string? Modelo { get; set; }

        [Required, Column("Ds_ano")]
        public int Ano { get; set; }

        [Required, Column("Ds_cor")]
        public string? Cor { get; set; }

        [Required, Column("Nr_placa")]
        public string? Placa { get; set; }


        public Motorista Motorista { get; set; }
        [HiddenInput]
        public int MotoristaId { get; set; }

    }
}
