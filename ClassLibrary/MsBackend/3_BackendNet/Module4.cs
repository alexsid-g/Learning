/*var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddHttpLogging(opts =>
{
    opts.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
});

var app = builder.Build();
app.Use(async (ctx, next) =>
{
    Console.WriteLine($"Request: {ctx.Request.Path}");
    await next.Invoke();
    Console.WriteLine($"Status: {ctx.Response.StatusCode}");
});
app.Use(async(ctx, next) =>
{
    var watch = new Stopwatch();
    watch.Start();
    await next.Invoke();
    watch.Stop();
    Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds} ms");
});
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();*/
