# AGENTS.md

## What this repo is

A **template/scaffold** for new IATec .NET APIs with MongoDB. Domain logic (`People`, `Assets`) is placeholder — replace it when cloning. Do not treat stub implementations as real feature code.

## Commands

```bash
dotnet restore
dotnet build IATec.Standard.Net.Api.sln
dotnet run --project src/Api/Api.csproj        # http://localhost:5015
dotnet test                                    # succeeds but runs nothing (test projects are empty)
```

## Architecture

Clean Architecture + MediatR CQRS. Startup wires layers in `Program.cs`:

```
ConfigureApi → ConfigureApplication → ConfigureAntiCorruption → ConfigureMessageQueue → ConfigurePersistence
```

Each layer exposes a single `Configure{Layer}(...)` extension on `IServiceCollection`. Never read `IConfiguration` directly in handlers — use `IOptions<T>`.

MediatR pipeline (order matters): `ValidatorPipelineBehavior` → `ExceptionPipelineBehavior` → handler.

## Project boundaries

| Project | Role |
|---|---|
| `src/Api` | Entrypoint, DI wiring, controllers, middleware |
| `src/Application` | MediatR handlers, FluentValidation validators |
| `src/Domain` | Aggregates, entities, value objects |
| `src/Persistence` | MongoDB client + persistence models |
| `src/AntiCorruption` | External service adapters (IATec Log Service HttpClient) |
| `src/CrossCutting` | Holds shared behaviors package; currently no custom code |
| `src/MessageQueue` | Stub — `ConfigureMessageQueue()` is a no-op |
| `src/Domain.Tests` / `src/Application.Tests` | Empty — no test framework installed yet |

## MongoDB quirks

- Global convention pack applied to all types: **camelCase field names** (`FirstName` → `firstName`), **ignore extra elements**.
- `IMongoClient` is **singleton**; `IMongoDatabase` is **scoped**.
- Connection string is built from `appsettings.json` section `MongoDB` (`ServerUrl`, `Port`, `User`, `Password`, `Database`). No credentials → no auth string.
- No migrations framework — `ApplyMigrations()` is an empty stub.
- `PersonPersistence.cs` has stale comments referencing "DynamoDb" — copy-paste artifact, ignore.

## Feature conventions

- Commands and queries are `readonly record struct`, not classes.
- Return types: `Result` or `Result<T>` (FluentResults), never raw exceptions from handlers.
- New features go under `Application/Features/{FeatureName}/Commands/`, `Queries/`, `Validators/`.
- Add one `AbstractValidator<TCommand>` per command even if initially empty.

## API docs

- Scalar (not Swagger/Swashbuckle) at `/documentation`; OpenAPI JSON at `/openapi/v1.json`.
- Only available when `!IsProduction()`.
- `{API_NAME}` placeholder in `ScalarConfiguration.cs` must be replaced when cloning.

## Environment

- Default environment: `Local` (set in `launchSettings.json`).
- No `appsettings.Development.json` — only `appsettings.json` exists.
- `LogServiceOption.Url` must not be empty or startup throws `ArgumentNullException`.

## Namespaces

Flat, matching project names: `Api`, `Application`, `Persistence`, `Domain`, `AntiCorruption`, `MessageQueue`. When renaming the template, do a global replace across `src/`.

## Tests (not yet set up)

Test projects need packages before anything runs:

```bash
dotnet add src/Domain.Tests package xunit
dotnet add src/Domain.Tests package Microsoft.NET.Test.Sdk
dotnet add src/Domain.Tests package xunit.runner.visualstudio
# same for src/Application.Tests
```

No integration test infrastructure exists. MongoDB test fixtures must be built from scratch.

## Known stubs to fill when cloning

- `docker/Dockerfile` and `docker/Local.Dockerfile` are empty.
- `src/MessageQueue/` — `ConfigureMessageQueue()` returns services unchanged.
- `src/CrossCutting/` — no `.cs` files.
- `Application/Features/Assets/` handlers all throw `NotImplementedException`.
- `CreateAssetValidator` has no validation rules.
- CORS is `AllowAnyOrigin` — restrict before production.
- No authentication configured.
