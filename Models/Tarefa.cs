namespace Tarefas.API.Models
{
    public class Tarefa
    {
        //public Tarefa()
        //{
        //    Id = Guid.NewGuid();
        //    DataCadastro = DateTime.Now;
        //    DataConclusao = null;
        //}
        public Guid Id { get; private set;} = Guid.NewGuid();
        public string Nome { get; set; } = "";
        public string Detalhes { get; set; } = "";
        public bool Concluida { get; set; } = false;
        public DateTime DataCadastro { get; private set; } = DateTime.Now;
        public DateTime? DataConclusao { get; private set; } = null;
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; private set; }

        public void ConcluirTarefa()
        {
            Concluida = true;
            DataConclusao = DateTime.Now;
        }
    }
}
