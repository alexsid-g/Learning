# Middleware and OpenAPI

Software that works between FE and BE, managing communnication between 2 services.
HTTP Request -> Authentication -> Logging -> Routing -> Application

Built-in:
1. Authentication
    - UseAuthentication()
2. Authorization 
    - UseAuthorization()
3. Logging
    - UseHttpLoggin() (required services.AddHttpLogging(o => {}))
4. UseRouting() - 
5. For exception handling
    - UseExceptionHandler("/Home/Error")
    - UseDeveloperExceptionPage() 

Middleware pipline - set of middleware that process all http-requests.
Request flow: Incoming -> Logging ->  Authentication -> App logic -> Response generation

## Custom middleware
1. Use((context, next) => {})
2. UseWhen((context) => {}, appBuilder => appBuilder.Use(
    (context, next) => {}
));

## Swagger and OpenApi
OpenApi - standard providing blueprint on how an API functions.
[User] -> [API] -> [Response]
1. Standard for API documentation
2. Easear API testing
3. Better team collaboration
4. Easear API maintenance

Main components:
1. AspNetCore.OpenApi
2. Swashbuckle.AspNetCore
- AddEndpointsApiExplorer()
- AddSwaggerGen(); UseSwagger(); UseSwagerUI(); 
- "/swagger/swagger.json", "/swagger/index.html"
- app.MapGet(() => TypedResults.Ok(T))
.WithOpenApi(op => {
    op.Parameter[0].Description = "First parameter";
    op.Summary = "Test api GET method";
    return op;
}).Produces<T>(StatusCodes.OK)
- ExcludeFromDescription()

## Generating API Clients with Swagger
1. Create API spec
2. Serve swagger JSON
3. Generate client code with NSwag
4. Implement client in your app

Use SwaggerClientGenerator class.

## Design middleware
1. Keep middleware lightweight (for complex tasks use background services)
2. Short-circuit pipeline
3. Minimize exception-handling overhead
4. Use async operations
5. Reuse middleware (when possible)
6. Control middleware order

### Securing middleware
1. Validate and sanitize inputs
2. Enforce HTTPS - UseHttpsRedirection()
3. Secure cookies and session data - Cookie.HttpOnly and Cookie.SecurePolicy = Always
4. Handle a12n (authentication) and a11n (authorization) check early
5. Log security events (time, IP, general even description)
6. Handle errors securely (ExceptionHandlerMiddleware to hide technical information)

