using Tarefas.API.Models;

namespace Tarefas.API.DTO
{
    public class TarefaDTOGet
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public string Concluida { get; set; }
        public string DataCadastro { get; set; }
        public string DataConclusao { get; set; }
        public Categoria Categoria { get; set; }
    }
}
