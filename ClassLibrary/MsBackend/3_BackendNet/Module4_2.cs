/*using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SwaggerApiClient;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapGet("/main", () => TypedResults.Ok("\"Hello\""))
.WithName("Main")
.Produces<string>(contentType: "text/html");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts => {
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        opts.RoutePrefix = string.Empty;
    });
}
app.MapControllers();

//app.Run();
_ = Task.Run(() => app.RunAsync());
await Task.Delay(3000);

var generate = false;
if (generate) {
    var generator = new ClientGenerator();
    await generator.GenerateClient();
    Console.WriteLine("Regenerated");
}
else {
    var http = new HttpClient();
    var client = new GeneratedApiClient(
        "http://localhost:5000", http);

    var result1 = await client.MainAsync();
    Console.WriteLine($"*** MainAsync: {result1}");

    var result2 = await client.GetUserAsync("Test");
    Console.WriteLine($"*** GetUserAsync: {result2.Id}:{result2.Name}");
}
*/



