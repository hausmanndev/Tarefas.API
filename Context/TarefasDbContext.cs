using Microsoft.EntityFrameworkCore;
using Tarefas.API.Models;

namespace Tarefas.API.Context
{
    public class TarefasDbContext(DbContextOptions<TarefasDbContext> options) : DbContext(options) // Método Construtor primário
    {
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
