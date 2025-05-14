/*
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var users = new Dictionary<int, User>(){
    [1] = new User { Id = 1, Name = "User Name 1", Email = ""},
    [2] = new User { Id = 2, Name = "Alex Sid 2", Email = ""},
};
var nextId = 3;

// Minimal API endpoints for Users
app.MapGet("/users", () =>
{
    return Results.Ok(users.Values);
});

app.MapGet("/users/{id:int}", (int id) =>
{
    if (users.TryGetValue(id, out var user))
    {
        return Results.Ok(user);
    }
    return Results.NotFound();
});

app.MapPost("/users", (User user) =>
{
    user.Id = nextId++;
    users[user.Id] = user;
    return Results.Created($"/users/{user.Id}", user);
});

app.MapPut("/users/{id:int}", (int id, User updatedUser) =>
{
    if (users.ContainsKey(id))
    {
        updatedUser.Id = id;
        users[id] = updatedUser;
        return Results.Ok(updatedUser);
    }
    return Results.NotFound();
});

app.MapDelete("/users/{id:int}", (int id) =>
{
    if (users.Remove(id))
    {
        return Results.NoContent();
    }
    return Results.NotFound();
});

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
*/

/////////////////////////
// User class definition
record User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}