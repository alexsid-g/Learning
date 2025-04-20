# Introduction

## .NET Ecosystem
.NET is a platform to create apps:
- Cross-patform
- Multiple languages
- Includes a lot of reusable code and tools
- Support web development

## VS Code 
Editor + built-in Git support. Write, test, debug and deploy.
1. Built-in Terminal
2. Extensions (C# Dev Kit)
    - Code completion
    - Copilot
    - Debugging
3. .NET install tools
4. GitHub integration 
5. Azure integration

### VS Code in Workflow (from Start -> Finish)
1. Project setup
2. Manage libraries
3. Track changes
4. Dev Server
5. Write Code
6. Test (Debugging tools)
7. Deployment

## Organizing .NET Project
Best organization practicies
1. Modularization (Divide your code into logical modules or categories: features, layers)
2. Separation of Concerns (Structure your project by separating different functionalities)
|-----------------|-------|--------|----------|
|Lalyers\Features | users | photos | comments |
|-----------------|-------|--------|----------|
| data            |   1.1 |  2.1   | 3.1      |
|-----------------|-------|--------|----------|
| intermidiate    |   1.2 |  2.2   | 3.2      |
|-----------------|-------|--------|----------|
| display         |   1.3 |  2.3   | 3.3      |
|-----------------|-------|--------|----------|

3. File naming
    - Pascal case
    - Camel case
    - Naming conventions
4. Refactoring
    - Clean and organize code
    - Added efficiencies
    - Make maintenance easier
5. Documentation
    - External README
    - Internal comments (everything, nothing, when necessary)
