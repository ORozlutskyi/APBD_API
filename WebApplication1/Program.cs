using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var animalIdCounter = 1;
var visitIdCounter = 1;

var animals = new List<Animal>();
var visits = new List<Visit>();

animals.Add(new Animal(animalIdCounter++, "Hello", "21", 1, "13"));
animals.Add(new Animal(animalIdCounter++, "Hello2", "21", 1, "13"));
animals.Add(new Animal(animalIdCounter++, "Hello3", "21", 1, "13"));
animals.Add(new Animal(animalIdCounter++, "Hello4", "21", 1, "13"));
visits.Add(new Visit(visitIdCounter++, new DateTime(2024, 4, 8), 1, "Desc", 15));
visits.Add(new Visit(visitIdCounter++, new DateTime(2024, 4, 8), 2, "Desc", 16));
visits.Add(new Visit(visitIdCounter++, new DateTime(2024, 4, 8), 2, "Desc", 17));
visits.Add(new Visit(visitIdCounter++, new DateTime(2024, 4, 8), 3, "Desc", 18));

app.MapGet("/animals", () => animals);

app.MapGet("/animals/{id}", (int id) =>
{
    var animal = animals.FirstOrDefault(a => a.Id == id);
    if (animal == null)
        return Results.NotFound($"Animal with id {id} not found");
    return Results.Ok(animal);
});


app.MapPost("/animals", (Animal animal) =>
{
    animal.Id = animalIdCounter++;
    animals.Add(animal);
    return Results.Created($"/animals/{animal.Id}", animal);
});

app.MapPut("/animals", (Animal ani) =>
{
    var animal = animals.FirstOrDefault(a => a.Id == ani.Id);
    if (animal == null)
        return Results.NotFound($"not found");
    animal.Name = ani.Name;
    animal.Category = ani.Category;
    animal.Weight = ani.Weight;
    animal.Color = ani.Color;
    return Results.Ok(animal);
});

app.MapDelete("/animals/{id}", (int id) =>
{
    var animal = animals.FirstOrDefault(a => a.Id == id);
    if (animal == null)
        return Results.NotFound($"not found");

    animals.Remove(animal);
    return Results.NoContent();
});

app.MapGet("/visits", () => visits);

app.MapGet("visits/{id}", (int id) =>
{
    var animalVisits = visits.Where(vis => vis.Id == id).ToList();
    return Results.Ok(animalVisits);
});

app.MapPost("/visits", (Visit visit) =>
{
    visit.Id = visitIdCounter++;
    visits.Add(visit);
    return Results.Created($"/visits/{visit.Id}", visit);
});

app.Run();

