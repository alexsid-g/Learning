# Asynchronous Programming
- Intro
- Using async await
- Significance of async programming
- Creating and debugging

## Fundamentals of Async
It allows tasks to run independently of the main workflow.
Async mark method as async, await pauses execution of calling method.

Common cases are:
- I/O operations
- Network requests
- Improving application resposiveness

### Benifits
- Non-blocking operations
- Improved performance (run in tasks in parallel)
- Improved resource usage (scale efficiently during peak times)
- Better integration with backend services (transfer data from multiple sources)

### Async challenges
1. Managing Concurrency
    - Code cannot cause conflicts (data concurrency)
    - Code cannot delay dependent code (deadlock)
2. Debugging difficulties
    - Harder to trace errors (many tasks in main flow)
3. Maintaining code readability
    - Difficult to know what operations are happening
    - Difficult to keep track an order of operations

## Practical usings of async programming
- Multiple API calls
- Process large amount of data in chunks
- Improve UI responsiveness

## Debugging Async Code
Technics:
- Use breakpoints
- Inspecting tasks (its state)
- Error handling

Tools:
- Use debugger extensions
    - Put a breakpoint
    - Inspect value of variable
- Use Task Explorer extensions
    - Model an manage tasks
- Use Logpoint 
    - Logs variable values and messages to console
- Use call stack tool (track sequuence of method calls)



