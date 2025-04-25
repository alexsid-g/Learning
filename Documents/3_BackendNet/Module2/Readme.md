# Apply Building Web APIs with ASP.NET Core
ASP.NET Core is a framework for building WebAPI.
- Cross-platform
- High-performance
- Modular architecture
- Dependency injection
- Routing and middleware
- Security
- Flexible

Benifits:
1. Cost-effective
2. High performance
3. Scalability
4. Maintainability
5. Built-in security

## Build WebAPI
1. Create and setup core files
2. Create new Controllers
3. Define API Endpoint
4. Configure routing
    - Convention-based routing
    - Custom-attribute routing
5. Test API

## Routing
- Static template: "/users", () => "Hello";
- Route parameter: "/users/{id}", (int id) => $"Hello {id}";
- Optional parameter: "users/{id?}", (int? id = 1) => $"Hello {id}";
- Constraints : "/users/{id?:int}", (int? id) => $"Hello {id}";
- Catch-all routes: "/users/{id:int}/{*slug}", (int id, string slug) => $"Hello {id}: {slug}";
- Query paramaters: "/users", (string q, int page) => "Hello"; //  "/users?q=Developer&page=1"

## Dependencies Injection
Dependency is an external component to which one component relies on to perform its tasks.
It can mitigate:
- Tight coupling (loose coupling makes resilient to modifications)
- Hard to maintain (more code in constructors - usual scenario)
- Low performance (creation and complicated reusing)
- Complicate Unit testing

## Testing
Dependency injection allows to do unit testing ensure everything in isolation.
To proceed:
- Setup environment
- Setup mock
- Write Unit test
- Run tests in test runner

## Error Handling
### Use try...catch...finally
### Using Logging
Key scenarious:
1. Issue diagnostic
2. Performance monitoring
3. Security auditing
4. Error tracking
5. User behaviour analysis

Best Practices:
1. Level of details
2. Consistent formatting
3. Log scopes

Configure logging:
1. Define log output location
2. Set log level
3. Configure in application.json or Program.cs
4. Install 3rd party frameworks (Serilog)
5. Create and save logs
6. Test and monitor logging

Built-in logging providers (ASP.NET Core):
- Console (console)
- Debug (any debug output)
- EventLog (windows event-log)


