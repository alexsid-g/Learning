/*
using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.AspNetCore.Diagnostics;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var name = Assembly
        .GetExecutingAssembly()
        .GetName().Name;
    var xmlFile = $"{name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);
});
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();
var users = new ConcurrentDictionary<int, User>(){
    [1] = new User { Id = 1, Name = "User Name 1", Email = ""},
    [2] = new User { Id = 2, Name = "Alex Sid 2", Email = ""},
};
var nextId = 3;

// Add middleware to catch unhandled exceptions
app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext ctx) => {
    var exception = ctx.Features
        .Get<IExceptionHandlerFeature>()?
        .Error;
    return Results.Problem(exception?.Message);
});

app.UseHttpsRedirection();
app.Use(async (x, next) => {
    if (nextId > 3) {
        Console.WriteLine("Middleware: This is a test middleware.");
        throw new Exception("This is a test middleware exception.");
    }
    await next();
});

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
    if (string.IsNullOrWhiteSpace(user.Name) ||
        string.IsNullOrWhiteSpace(user.Email))
    {
        return Results.BadRequest("Name and Email are required.");
    }

    user.Id = nextId++;
    users[user.Id] = user;
    return Results.Created($"/users/{user.Id}", user);
});

app.MapPut("/users/{id:int}", (int id, User updatedUser) =>
{
    if (string.IsNullOrWhiteSpace(updatedUser.Name) ||
        string.IsNullOrWhiteSpace(updatedUser.Email))
    {
        return Results.BadRequest("Name and Email are required.");
    }

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
    if (users.TryRemove(id, out var _))
    {
        return Results.NoContent();
    }
    return Results.NotFound();
});

app.MapGet("/exception", () =>
{
    throw new Exception("This is a test exception.");
});

app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}
else
{
    app.UseHsts();
}
app.Run();

///////////////////////////////////////////////////////////////////////////
// User class definition
record User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
*/