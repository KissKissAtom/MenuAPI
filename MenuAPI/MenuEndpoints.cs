using Microsoft.EntityFrameworkCore;
using MenuAPI.Data;
using MenuAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace MenuAPI;

public static class MenuEndpoints
{
    public static void MapMenuEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Menu").WithTags(nameof(Menu));

        group.MapGet("/", async (MenuAPIContext db) =>
        {
            return await db.Menu.ToListAsync();
        })
        .WithName("GetAllMenus")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Menu>, NotFound>> (int id, MenuAPIContext db) =>
        {
            return await db.Menu.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Menu model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetMenuById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Menu menu, MenuAPIContext db) =>
        {
            var affected = await db.Menu
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, menu.Id)
                  .SetProperty(m => m.TypeMenu, menu.TypeMenu)
                  .SetProperty(m => m.NameMenu, menu.NameMenu)
                  .SetProperty(m => m.PhraseMenu, menu.PhraseMenu)
                  .SetProperty(m => m.Intensite, menu.Intensite)
                  .SetProperty(m => m.NameEntree, menu.NameEntree)
                  .SetProperty(m => m.NamePlat, menu.NamePlat)
                  .SetProperty(m => m.NameDessert, menu.NameDessert)
                  .SetProperty(m => m.DescriptionEntree, menu.DescriptionEntree)
                  .SetProperty(m => m.DescriptionPLat, menu.DescriptionPLat)
                  .SetProperty(m => m.DescriptionDessert, menu.DescriptionDessert)
                  .SetProperty(m => m.IngredientsMenu, menu.IngredientsMenu)
                  .SetProperty(m => m.Image, menu.Image)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateMenu")
        .WithOpenApi();

        group.MapPost("/", async (Menu menu, MenuAPIContext db) =>
        {
            db.Menu.Add(menu);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Menu/{menu.Id}",menu);
        })
        .WithName("CreateMenu")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, MenuAPIContext db) =>
        {
            var affected = await db.Menu
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteMenu")
        .WithOpenApi();
    }
}
