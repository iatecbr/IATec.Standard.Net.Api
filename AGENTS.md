# AGENTS.md

This file provides guidance for AI coding agents working in this repository.

## Project Overview

.NET 10 Web API following Clean Architecture / DDD with CQRS (MediatR).

**Layer structure (dependency flow):**
Api → Application → CrossCutting → Domain
Api → Persistence → Domain
Api → AntiCorruption
Api → MessageQueue

## Build Commands

```bash
# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run the API
dotnet run --project src/Api

# Run all tests
dotnet test

# Run a single test project
dotnet test src/Domain.Tests
dotnet test src/Application.Tests

# Run a single test by name
dotnet test --filter "FullyQualifiedName~MyTestMethod"

# Run a single test class
dotnet test --filter "FullyQualifiedName~MyTestClass"
```

No Makefile or CI scripts exist. Docker files are present but empty (`docker/Dockerfile`, `docker/Local.Dockerfile`).

## Architecture & Patterns

### CQRS with MediatR

- Commands/Queries are `readonly record struct` implementing `IRequest<Result>` or `IRequest<Result<T>>`
- Handlers implement `IRequestHandler<TRequest, TResult>`
- Feature-based folder organization: `Features/{Feature}/Commands/`, `Queries/`, `Validators/`
- Dispatchers aggregate related command/query sends

### Error Handling

- Use `FluentResults` (`Result`, `Result<T>`) as return types — never throw exceptions for control flow
- Use try/catch with `ILogger.LogError()` only for external service calls
- Return `Result.Fail(...)` on failure, `Result.Ok(...)` on success

### Dependency Injection

- Each layer exposes a static extension method (`ConfigureX`) on `IServiceCollection`
- Sub-configurations go in `Extensions/` folder per layer
- Use `AddScoped<>` for dispatchers and services
- Use `AddHttpClient<>` for external HTTP services

### Validation

- FluentValidation with custom `ValidatorFactory`
- Validators live in `Features/{Feature}/Validators/`

## Code Style Guidelines

### Formatting

- 4-space indentation
- Allman style braces (opening brace on new line)
- File-scoped namespaces (`namespace X;`)
- One type per file
- Keep files concise

### Naming Conventions

- **PascalCase** for classes, methods, properties, public fields
- **Suffix classes by role:** `*Command`, `*CommandHandler`, `*Query`, `*QueryHandler`, `*Validator`, `*Dispatcher`, `*Service`, `*Extension`, `*Config`
- **DI configuration classes:** `{Layer}DependencyInjectionConfig`
- **Feature folders:** `Features/{FeatureName}/Commands/`, `Queries/`, `Validators/`

### Types

- Nullable reference types enabled — respect nullability annotations
- Use `readonly record struct` for commands and queries (value types)
- Use primary constructors for classes with injected dependencies:
  ```csharp
  public class MyHandler(IService service) : IRequestHandler<MyCommand, Result>
  ```

### Imports

- `using` statements at file top
- Order: System namespaces → third-party → project namespaces
- Implicit usings enabled (no need to import common System namespaces)

### Error Handling

- Return `Result` / `Result<T>` from all command/query handlers
- Never use exceptions for business logic flow control
- Log errors via `ILogger` when catching infrastructure exceptions

## Key Dependencies

| Package | Purpose |
|---------|---------|
| MediatR | CQRS dispatching |
| FluentValidation | Input validation |
| FluentResults | Result pattern (no exceptions) |
| Asp.Versioning.Mvc | API versioning |
| IATec.Shared.* | Internal shared libraries (contracts, behaviors, domain primitives) |

## API Configuration

- API versioning enabled
- CORS configured
- Health checks with UI
- OpenAPI + Scalar for docs (disabled in production)
- Top-level `Program.cs` with fluent DI registration

## Anti-Corruption Layer

External HTTP service calls are wrapped in dedicated service classes in the `AntiCorruption` project.
This isolates external API contracts from the domain model.

## Testing

- Test projects: `Domain.Tests`, `Application.Tests`
- No test framework currently configured (projects are empty scaffolds)
- When adding tests, use xUnit (standard for .NET) with FluentAssertions

## File Organization

```
src/
  Api/
    Controllers/
    Extensions/
    Program.cs
  Application/
    Features/{Feature}/
      Commands/
      Queries/
      Validators/
    Extensions/
  Application.Tests/
  CrossCutting/
    Extensions/
  Domain/
    Contracts/
    Models/
  Domain.Tests/
  Persistence/
    Extensions/
  AntiCorruption/
    Services/
    Extensions/
  MessageQueue/
    Extensions/
```
