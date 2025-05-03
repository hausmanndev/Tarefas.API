using Microsoft.EntityFrameworkCore;
using Tarefas.API.Context;
using Tarefas.API.Models;

namespace Tarefas.API.Endpoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndopints(this WebApplication app)
        {
            app.MapGet("/Tarefas", async(TarefasDbContext db) => await db.Tarefas.ToListAsync());

            app.MapGet("/Tarefas/{id}", async (Guid id, TarefasDbContext db) => await db.Tarefas.FindAsync(id)
                is Tarefa tarefa
                ? Results.Ok(tarefa)
                : Results.NotFound()
            );

            app.MapPost("/Tarefas", async (Tarefa tarefa, TarefasDbContext db) =>
            {
                if (tarefa == null) return Results.BadRequest("Requisição inválida!");

                db.Tarefas.Add(tarefa);
                await db.SaveChangesAsync();

                return Results.Created($"/Tarefas/{tarefa.Id}", tarefa);
            });

            app.MapPut("/Tarefas/{id}", async(Guid id, Tarefa tarefaAtualizada, TarefasDbContext db) =>
            {
                var tarefa = await db.Tarefas.FindAsync(id);

                if (tarefa is null) return Results.NotFound();

                tarefa.Nome = tarefaAtualizada.Nome == "" ? tarefa.Nome : tarefaAtualizada.Nome;
                tarefa.Detalhes = tarefaAtualizada.Detalhes == "" ? tarefa.Detalhes : tarefaAtualizada.Detalhes;
                tarefa.Concluida = tarefaAtualizada.Concluida;
                tarefa.CategoriaId = tarefa.CategoriaId;

                await db.SaveChangesAsync();

                return Results.Ok(tarefa);
            });

            app.MapDelete("/Tarefas/{id}", async (Guid id, TarefasDbContext db) =>
            {
                var tarefa = await db.Tarefas.FindAsync(id);

                if (tarefa is null) return Results.NotFound();

                db.Remove(tarefa);

                await db.SaveChangesAsync();

                return Results.Ok("Tarefa deletada com sucesso!");
            });
        }
    }
}
