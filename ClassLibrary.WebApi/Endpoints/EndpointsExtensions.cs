namespace ClassLibrary.WebApi.Endpoints;

/// <summary>
/// Extensions useful for work with endponits.
/// </summary>
public static class EndpointsExtensions
{
    /// <summary>
    /// Registeres endpoint in application.
    /// </summary>
    public static WebApplication RegisterEndpoint(this WebApplication app, Action<WebApplication> register)
    {
        register?.Invoke(app);
        return app;
    }
}
