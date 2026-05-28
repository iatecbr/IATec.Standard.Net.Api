# AGENTS.md — IATec.Standard.Net.Api

## What this repo is (and is not)

This is a **template/base project** for creating new .NET APIs at IATec. It is **not a functional application** — it is a starting point with architecture, DI wiring, and stub implementations. Controllers, database access, and business logic are intentionally missing.

## Critical architecture facts

- **Domain layer is empty.** All contracts, entities, seedwork, options, and result types live in the `IATec.Shared.Domain` NuGet package (v2.0.1). Do not recreate them locally.
- **No controllers implemented.** `src/Api/Controllers/` is an empty folder. The API launches but has no endpoints beyond health check and Scalar documentation.
- **No database configured.** `DatabaseExtension.cs` and `PersistenceDependencyInjectionConfig.cs` are stubs. EF Core was removed in v1.0.1.
- **No functional tests.** `Domain.Tests` and `Application.Tests` projects exist but have **no test framework or test cases** configured.

## How to run

```bash
dotnet restore
dotnet run --project src/Api/Api.csproj
```

- URL: `http://localhost:5015`
- Environment: `Local` (set in `launchSettings.json`)
- Auto-opens Scalar UI at `/documentation` (not Swagger)
- Health check: `GET /_healthcheck/status` returns assembly version

## API documentation

- **Scalar** (not Swashbuckle) is configured. Available only in non-Production environments.
- OpenAPI JSON: `/openapi/v1.json`
- Scalar UI: `/documentation`
- Configured in `src/Api/Configurations/Extensions/ScalarConfiguration.cs`

## API versioning

- Implemented via **query string**: `?api-version=1.0`
- Default version: `1.0`
- Configured in `src/Api/Configurations/Extensions/VersioningExtension.cs`

## When adding a new feature

1. Create Command/Query in `src/Application/Features/<Feature>/`
2. Create Handler in the same folder
3. Create Validator in `Validators/` subfolder
4. Register in DI via existing configuration files
5. **Do not add local Domain contracts** — use `IATec.Shared.Domain` contracts

## Infrastructure placeholders (empty stubs)

| File | Status | Action needed |
|------|--------|-------------|
| `docker/Dockerfile` | 0 bytes | Fill when needed |
| `secrets/secrets.yml` | Template with placeholders | Update `#{deployment_name}#`, `#{namespace}#`, add values |
| `src/Persistence/Configurations/Extensions/DatabaseExtension.cs` | Empty method | Implement when adding database |

## Log service integration

- `LogDispatcher` sends logs to an external IATec Log Service via HTTP client
- Requires `LogServiceOption.Url` in configuration (key: `IATec:Services:Log`)
- Configured in `src/AntiCorruption/Configurations/Extensions/LoggingConfig.cs`

## Key conventions

- **Simplified namespaces** preferred: `namespace Api;`, `namespace Application;`, etc.
- **Record structs** for Commands/Queries: `public readonly record struct MyCommand : IRequest<Result>;`
- **Pipeline behaviors**: `ValidatorPipelineBehavior` and `ExceptionPipelineBehavior` (both from `IATec.Shared.Behaviors`) are registered in MediatR
- **CORS policy**: `CorsPolicy` allows any origin/method/header with exposed headers (`X-Custom-Header`, `Location`, `Content-Disposition`, `Content-Length`)
- **Migration runner**: `ApplyMigrations()` skips when environment is `Local`

## Verified commands

```bash
# Full build (0 warnings, 0 errors expected)
dotnet build

# Run API
dotnet run --project src/Api/Api.csproj

# Run all tests (will succeed but run nothing — projects are empty)
dotnet test
```

## What to avoid

- Do not add Swashbuckle/Swagger packages — this project uses Scalar
- Do not add EF Core packages to Domain — domain contracts are in `IATec.Shared.Domain`
- Do not expect `docker build` to work without filling the Dockerfile first
- Do not add `AssemblyName`/`RootNamespace` to `.csproj` unless explicitly needed — they inherit from filename by default