using DataAccess.Models;
using DataAccess.Repositories;

namespace MinimalAPI.Extensions
{
    public static class MapApis
    {
        public static void MapApi(this WebApplication app)
        {
            app.MapGet("/api/person", async (IPersonRepository personRepo) =>
            {
                var people = await personRepo.GetAll();
                return Results.Ok(people);
            });

            app.MapPost("/api/person", async (IPersonRepository personRepo, Person person) =>
            {
                var result = await personRepo.Add(person);
                if(result)
                    return Results.Ok("Saved successfully");
                return Results.Problem();
            });

            app.MapPut("/api/person", async (IPersonRepository personRepo, Person person) =>
            {
                var result = await personRepo.Update(person);
                if (result)
                    return Results.Ok("Updated successfully");
                return Results.Problem();
            });

            app.MapGet("/api/person/{id}", async (IPersonRepository personRepo, int id) =>
            {
                var person = await personRepo.GetById(id);
                if (person is null)
                    return Results.NotFound();
                return Results.Ok(person);
            });

            app.MapDelete("/api/person/{id}", async (IPersonRepository personRepo, int id) =>
            {
                var person = await personRepo.Delete(id);
                if (person)
                    return Results.Ok("Delete successfully");
                return Results.Problem();
            });
        }
    }
}