namespace Fiap.GlobalSolution.Models
{
    public class MotoristaPontoTrabalho
    {
        public int MotoristaId { get; set; }
        public Motorista Motorista { get; set; }

        public int PontoTrabalhoId { get; set; }
        public PontoTrabalho PontoTrabalho { get; set; }
    }
}
