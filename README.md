# {API_NAME}

> Robust .NET API development template at IATec, promoting standard practices, efficiency and security. Ideal for scalable, high-performance APIs.

**Current Version:** `2.1.0`

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Technologies and Stack](#technologies-and-stack)
- [Project Structure](#project-structure)
- [Architecture Layers](#architecture-layers)
- [Prerequisites](#prerequisites)
- [How to Run](#how-to-run)
- [Configuration](#configuration)
- [API Documentation (Scalar)](#api-documentation-scalar)
- [Health Checks](#health-checks)
- [API Versioning](#api-versioning)
- [CORS](#cors)
- [Authentication](#authentication)
- [Feature: Assets](#feature-assets)
- [Logging Dispatcher](#logging-dispatcher)
- [External Services (AntiCorruption)](#external-services-anticorruption)
- [Persistence Layer](#persistence-layer)
- [Message Queue Layer](#message-queue-layer)
- [Domain Layer](#domain-layer)
- [CrossCutting Layer](#crosscutting-layer)
- [Test Projects](#test-projects)
- [Docker](#docker)
- [CI/CD](#cicd)
- [Renaming the API](#renaming-the-api)
- [Template Extension Points](#template-extension-points)
- [Contributing](#contributing)
- [Changelog](#changelog)

---

## About the Project

This repository is a **base template / scaffolding project** for creating new .NET APIs following IATec standards. It establishes the correct layer structure, DI wiring, and shared library integration, but **contains minimal business logic implementations** (handlers are placeholders).

### What comes pre-configured

- Clean Architecture / Vertical Slices with **MediatR CQRS**.
- **API Versioning** via `Asp.Versioning.Mvc` (query string `api-version`).
- **Scalar** interactive API documentation (replaces Swagger).
- **Health Checks** with version endpoint.
- **CORS** policy (`AllowAnyOrigin`, `AllowAnyMethod`, `AllowAnyHeader`).
- **FluentValidation** pipeline behavior (validators run before handlers).
- **Exception pipeline behavior** via `IATec.Shared.Behaviors`.
- **Logging dispatcher** sending structured logs to IATec Log Service.
- **Typed HttpClient** for external IATec Log Service integration.
- Integration with internal `IATec.Shared.*` packages.

### What is NOT implemented (placeholder scaffolding)

- All command/query handlers throw `NotImplementedException`.
- `Domain` project contains **zero `.cs` files**.
- `CrossCutting` project contains **zero `.cs` files**.
- `Persistence.DatabaseExtension.AddData()` is **empty**.
- `MessageQueueDependencyInjectionConfig` is **empty**.
- `docker/Dockerfile` and `docker/Local.Dockerfile` are **empty (0 bytes)**.
- Test projects have **no test framework packages** (xUnit, NUnit, MSTest) and **zero tests**.
- No CI/CD pipelines (no `.github/workflows`).

> **Note:** Whenever creating a new API from this template, read the [Renaming the API](#renaming-the-api) section to adjust names and references.

---

## Technologies and Stack

| Technology | Version |
|------------|---------|
| .NET | 10.0 |
| ASP.NET Core | 10.0.8 |
| Scalar.AspNetCore | 2.14.14 |
| Microsoft.AspNetCore.OpenApi | 10.0.8 |
| API Versioning (Asp.Versioning.Mvc) | 10.0.0 |
| Asp.Versioning.Mvc.ApiExplorer | 10.0.0 |
| AspNetCore.HealthChecks.UI.Client | 9.0.0 |
| MediatR | 14.1.0 |
| FluentValidation | 12.1.1 |
| FluentValidation.DependencyInjectionExtensions | 12.1.1 |
| FluentResults | 4.0.0 |
| Microsoft.Extensions.Configuration | 10.0.8 |
| Microsoft.Extensions.Configuration.Binder | 10.0.8 |
| Microsoft.Extensions.DependencyInjection.Abstractions | 10.0.8 |
| Microsoft.Extensions.Http | 10.0.8 |
| Microsoft.Extensions.Options | 10.0.8 |
| IATec.Shared.Api | 1.2.0 |
| IATec.Shared.Application | 2.0.0 |
| IATec.Shared.Domain | 2.0.1 |
| IATec.Shared.HttpClient | 3.0.0 |
| IATec.Shared.Behaviors | 1.3.0 |

> **CSPROJ Settings:** `Nullable=enable`, `ImplicitUsings=enable`, `InvariantGlobalization=false`, `GenerateDocumentationFile=True`.

---

## Project Structure

```
IATec.Standard.Net.Api/
├── src/
│   ├── Api/
│   │   ├── Configurations/
│   │   │   ├── ApiDependencyInjectionConfig.cs
│   │   │   └── Extensions/
│   │   │       ├── CorsPolicyExtension.cs
│   │   │       ├── HealthCheckExtension.cs
│   │   │       ├── MigrationExtensions.cs
│   │   │       ├── OptionsExtension.cs
│   │   │       ├── ScalarExtension.cs
│   │   │       └── VersioningExtension.cs
│   │   ├── Controllers/
│   │   │   └── (empty folder)
│   │   ├── Properties/
│   │   │   └── launchSettings.json
│   │   ├── appsettings.json
│   │   └── Program.cs
│   │
│   ├── Application/
│   │   ├── Configurations/
│   │   │   ├── ApplicationDependencyInjectionConfig.cs
│   │   │   ├── Extensions/
│   │   │   │   ├── MediatorConfig.cs
│   │   │   │   └── ValidatorConfig.cs
│   │   │   └── Factories/
│   │   │       └── ValidatorFactory.cs
│   │   ├── Dispatchers/
│   │   │   └── Logging/
│   │   │       └── LogDispatcher.cs
│   │   └── Features/
│   │       └── Assets/
│   │           ├── Commands/
│   │           │   ├── CreateAssetCommand.cs
│   │           │   └── CreateAssetCommandHandler.cs
│   │           ├── Queries/
│   │           │   ├── CheckIfExistsAssetQuery.cs
│   │           │   └── CheckIfExistsAssetQueryHandler.cs
│   │           └── Validators/
│   │               └── CreateAssetValidator.cs
│   │
│   ├── CrossCutting/
│   │   └── (empty — no .cs files)
│   │
│   ├── Domain/
│   │   └── (empty — no .cs files)
│   │
│   ├── Persistence/
│   │   ├── Configurations/
│   │   │   ├── PersistenceDependencyInjectionConfig.cs
│   │   │   └── Extensions/
│   │   │       └── DatabaseExtension.cs
│   │   └── (empty data access layer)
│   │
│   ├── AntiCorruption/
│   │   ├── Configurations/
│   │   │   ├── AntiCorruptionDependencyInjectionConfig.cs
│   │   │   └── Extensions/
│   │   │       └── LoggingConfig.cs
│   │   └── Services/
│   │       └── Iatec/
│   │           └── LogService.cs
│   │
│   ├── MessageQueue/
│   │   └── Configurations/
│   │       └── MessageQueueDependencyInjectionConfig.cs
│   │
│   ├── Domain.Tests/
│   │   └── Domain.Tests.csproj (empty — no tests, no framework)
│   │
│   └── Application.Tests/
│       └── Application.Tests.csproj (empty — no tests, no framework)
│
├── docker/
│   ├── Dockerfile (empty — 0 bytes)
│   └── Local.Dockerfile (empty — 0 bytes)
│
├── secrets/
│   └── secrets.yml (Kubernetes Secret template)
│
├── .editorconfig (root, empty)
├── IATec.Standard.Net.Api.sln
├── README.md
└── CHANGELOG.md
```

---

## Architecture Layers

### 1. Api (Presentation Layer)

Entrypoint ASP.NET Core Web API. Orchestrates all configurations and maps controllers.

### 2. Application Layer

Contains use cases, MediatR handlers, validators, dispatchers, and factories.

**Mediator Pipeline Behaviors (from `IATec.Shared.Behaviors`):**
1. `ValidatorPipelineBehavior<,>` — runs FluentValidation validators before the handler.
2. `ExceptionPipelineBehavior<,>` — global exception handling wrapper.

### 3. Domain Layer

**Currently empty.** Designed to hold:
- Entities, Value Objects, Aggregates
- Domain events
- Contracts / interfaces
- Pure business rules

### 4. Persistence Layer

**Currently empty scaffolding.** Contains:
- `PersistenceDependencyInjectionConfig.cs` — wires the layer.
- `DatabaseExtension.cs` — **empty method body** (`public static void AddData(...) { }`).

> No ORM (EF Core, Dapper) is referenced. `ConnectionStrings` in `appsettings.json` is empty `{}`.

### 5. AntiCorruption Layer

Adapters for external services. Currently implements:
- **IATec Log Service** (`LogService.cs`) — typed `HttpClient` sending `LogDto` via `POST v1/log`.

### 6. MessageQueue Layer

**Currently empty scaffolding.** `ConfigureMessageQueue()` returns `services` with no registrations.

### 7. CrossCutting Layer

**Currently empty.** Designed for shared behaviors, utilities, or cross-cutting concerns.

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (or compatible higher version)
- (Optional) Docker for building/publishing images
- Editor of your choice (VS, VS Code, Rider)

---

## How to Run

### 1. Clone the repository

```bash
git clone <repository-url>
cd {API_NAME}
```

### 2. Restore packages

```bash
dotnet restore
```

### 3. Run the API

```bash
dotnet run --project src/Api/Api.csproj
```

**Default profile (from `launchSettings.json`):**
- URL: `http://localhost:5015`
- Environment: `Local`
- Auto-opens browser at `/documentation`

---

## Configuration

Settings are located in `src/Api/appsettings.json`.

### What to configure when starting a new API

| Section | Description | Example |
|---------|-------------|---------|
| `TimeZone` | Application time zone | `"America/Sao_Paulo"` |
| `Container.Name` | Deployment container metadata name | `"MyApi-Production"` |
| `Container.ContainerId` | Container identifier | `"my-api-container"` |
| `Logging.LogLevel.Default` | ASP.NET Core log level | `"Debug"`, `"Information"`, `"Warning"` |
| `ConnectionStrings` | Database and service connection strings | `"DefaultConnection": "Server=..."` |

### Typed Options registered in DI

In `OptionsExtension.cs`, the following options are bound from configuration:

| Option Class | Configuration Key | Purpose |
|--------------|-------------------|---------|
| `LogServiceOption` | `LogServiceOption` | URL for IATec Log Service |
| `ContainerOption` | `ContainerOption` | Container metadata for logging dispatcher |

> **Tip:** Add new typed options in `src/Api/Configurations/Extensions/OptionsExtension.cs` for injection via `IOptions<T>`.

### No `appsettings.Development.json`

There is **no** `appsettings.Development.json` file in the project. All configuration currently lives in the base `appsettings.json`.

---

## API Documentation (Scalar)

The project uses **Scalar** (not Swagger) for interactive API documentation.

- **OpenAPI JSON:** `/openapi/v1.json`
- **Scalar UI:** `/documentation`
- **Availability:** Only in non-Production environments (`!app.Environment.IsProduction()`).
- **Theme:** Mars, dark mode, C# HttpClient as default client.

### Authentication in Scalar

The Scalar UI is configured with `AllowAnonymous()`. JWT Bearer security definitions are **not currently configured** in the OpenAPI document (this was removed along with Swashbuckle). If you need authenticated documentation, add `AddSecurityDefinition` / `AddSecurityRequirement` to the `AddOpenApi` configuration.

---

## Health Checks

Endpoint: `GET /_healthcheck/status`

- **VersionHealthCheck** — returns `HealthStatus.Healthy` with the assembly version string.
- Response is formatted via `HealthChecks.UI.Client` (rich JSON with UI metadata).

---

## API Versioning

Configured in `VersioningExtension.cs`:

- **Default version:** `1.0`
- **Assume default when unspecified:** `true`
- **Report API versions:** `true`
- **Version reader:** Query string parameter `api-version`
- **Explorer group format:** `'v'VVV` (e.g., `v1`)

---

## CORS

Configured in `CorsPolicyExtension.cs` with `AllowAnyHeader`, `AllowAnyMethod`, `AllowAnyOrigin`.

**Exposed headers:** `X-Custom-Header`, `Location`, `Content-Disposition`, `Content-Length`.

> ⚠️ **Warning:** `AllowAnyOrigin()` is extremely permissive. Review and restrict before deploying to production.

---

## Authentication

**Currently NOT configured.**

The previous Swagger JWT Bearer setup was removed along with Swashbuckle. To add JWT authentication:

1. Install `Microsoft.AspNetCore.Authentication.JwtBearer`.
2. Configure token validation in `ApiDependencyInjectionConfig.cs` or a new extension method.
3. Add `app.UseAuthentication()` before `app.UseAuthorization()` in `UseApi()`.
4. Add security schemes to the OpenAPI document in `ScalarExtension.cs`.

---

## Feature: Assets

The only implemented feature domain. All handlers are **placeholders** (`NotImplementedException`).

| File | Type | Details |
|------|------|---------|
| `CreateAssetCommand.cs` | `readonly record struct` | `IRequest<Result>` from MediatR + FluentResults |
| `CreateAssetCommandHandler.cs` | Handler | `throw new NotImplementedException()` |
| `CheckIfExistsAssetQuery.cs` | `readonly record struct` | `IRequest<Result<bool>>` |
| `CheckIfExistsAssetQueryHandler.cs` | Handler | `throw new NotImplementedException()` |
| `CreateAssetValidator.cs` | `AbstractValidator<CreateAssetCommand>` | **Empty — no rules defined** |

> The validator is still registered in DI via `AddValidatorsFromAssemblyContaining<CreateAssetValidator>()` and will pass through without validation.

---

## Logging Dispatcher

### `LogDispatcher.cs`

Implements `ILogDispatcher` (from `IATec.Shared.Domain.Contracts.Dispatcher`).

**Constructs a `LogDto` with:**
- `ContainerKey` — from `ContainerOption.Key`
- `Source` — caller-provided
- `Owner` — caller-provided
- `Action` — caller-provided
- `Content` — `object?.ToString() ?? string.Empty`
- `Date` — `DateTime.UtcNow`
- `Id` — `string.Empty`
- `UserId` — `string.Empty`

Then delegates to `ILogService.SendAsync()`.

### `ILogService` implementation

**`LogService.cs`** (AntiCorruption layer):
- Typed `HttpClient` with base address from `LogServiceOption.Url`.
- Sends `POST v1/log` as JSON.
- Logs success/error via `ILogger<LogService>`.
- **Does NOT throw on failure** — errors are caught and logged silently.

---

## External Services (AntiCorruption)

### IATec Log Service

| Config | File |
|--------|------|
| DI Registration | `LoggingConfig.cs` |
| Implementation | `LogService.cs` |
| Contract | `ILogService` (from `IATec.Shared.Domain`) |

---

## Persistence Layer

**Status:** No ORM, no repositories, no DbContext, no migrations. The layer is wired in DI but does nothing.

- `PersistenceDependencyInjectionConfig.cs` — wires the layer.
- `DatabaseExtension.cs` — **empty method body** (`public static void AddData(...) { }`).

> No ORM (EF Core, Dapper) is referenced. `ConnectionStrings` in `appsettings.json` is empty `{}`.

---

## Message Queue Layer

**Status: Completely empty.** `ConfigureMessageQueue()` returns `services` with no registrations. No message queue library referenced.

---

## Domain Layer

**Status: Completely empty.**

The `src/Domain/` directory contains:
- `Domain.csproj` with NuGet references
- `Models/` folder containing only an `.editorconfig` file
- **Zero `.cs` source files**

This is where entities, value objects, contracts, and pure business rules should live.

---

## CrossCutting Layer

**Status: Completely empty.**

The `src/CrossCutting/` directory contains only `CrossCutting.csproj` with references to:
- `IATec.Shared.Behaviors` (1.3.0)
- `MediatR` (14.1.0)

**Zero `.cs` source files.** This layer is referenced by `Application.csproj` but contributes no local code.

---

## Test Projects

| Project | Framework Packages | Test Files | Status |
|---------|-------------------|------------|--------|
| `Domain.Tests` | **None** | 0 | Empty |
| `Application.Tests` | **None** | 0 | Empty |

> `Domain.Tests.csproj` contains `<Compile Remove="Class1.cs"/>` but `Class1.cs` does not exist.

### To add tests

Install a test framework (e.g., xUnit):
```bash
dotnet add src/Domain.Tests package xunit
dotnet add src/Domain.Tests package Microsoft.NET.Test.Sdk
dotnet add src/Domain.Tests package xunit.runner.visualstudio
```

---

## Docker

### `docker/Dockerfile`
**Empty (0 bytes).**

### `docker/Local.Dockerfile`
**Empty (0 bytes).**

### Basic Dockerfile example

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "src/Api/Api.csproj"
RUN dotnet build "src/Api/Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Api/Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
```

---

## CI/CD

**Status: No CI/CD configured.**

- No `.github/` folder.
- No GitHub Actions workflows.
- No Azure DevOps pipelines.
- No Jenkins/GitLab CI files.

The only file in `secrets/` is `secrets.yml`, a **Kubernetes Secret manifest template** with placeholders (`#{deployment_name}#`, `#{namespace}#`).

---

## Renaming the API

> Follow these steps when using this project as a base for a new API.

### 1. Solution file

```bash
mv IATec.Standard.Net.Api.sln {API_NAME}.sln
```

### 2. Assembly and namespaces

Update `Api.csproj` if desired:
```xml
<AssemblyName>{API_NAME}.Api</AssemblyName>
<RootNamespace>{API_NAME}.Api</RootNamespace>
```

Run a **Replace All** in `src/` to adjust namespaces:
| From | To (example) |
|------|--------------|
| `namespace Api;` | `namespace MyProject.Api;` |
| `namespace Application;` | `namespace MyProject.Application;` |

Or keep simplified namespaces (`Api`, `Application`, `Domain`, etc.).

### 3. Scalar / OpenAPI title

In `src/Api/Configurations/Extensions/ScalarExtension.cs`, update:
```csharp
document.Info = new() { Title = "{API_NAME}", Version = "v1", ... };
options.WithTitle($"{{API_NAME}} - {environment.EnvironmentName}")
```

### 4. README and CHANGELOG

Replace all `{API_NAME}` placeholders with the actual project name.

### 5. Version

Update `<Version>` in `Api.csproj` to `1.0.0` for the new project.

---

## Template Extension Points

This project is an **intentional scaffold/template**. The following items are **structural placeholders** — not bugs or missing features. Each represents an extension point where a new API project should add its own implementation.

| # | Extension Point | Location                          | Purpose |
|---|----------------|-----------------------------------|---------|
| 1 | `NotImplementedException` handlers | `Application/Features/Assets/`    | Example command/query structure — replace with real business logic |
| 2 | Empty `Domain` layer | `src/Domain/`                     | Add entities, aggregates, and business rules |
| 3 | Empty `Persistence` layer | `src/Persistence/`                | Add DbContext, repositories, migrations, connection strings |
| 4 | Empty `MessageQueue` layer | `src/MessageQueue/`               | Add producers/consumers (RabbitMQ, Kafka, etc.) |
| 5 | Empty `CrossCutting` layer | `src/CrossCutting/`               | Add shared utilities, constants, or cross-cutting concerns |
| 6 | Empty test projects | `*.Tests/`                        | Add xUnit/NUnit/MSTest and write tests |
| 7 | No CI/CD | Root                              | Add GitHub Actions / Azure DevOps when ready |
| 8 | Empty Dockerfiles | `docker/`                         | Add build/publish steps for containerization |
| 9 | Permissive CORS | `CorsPolicyExtension.cs`          | Restrict origins/methods when deploying to production |
| 10 | No authentication | `ApiDependencyInjectionConfig.cs` | Add JWT/Auth when security requirements are defined |
| 11 | `{API_NAME}` placeholders | `ScalarExtension.cs`, README      | Rename when cloning template |
| 12 | No `appsettings.Development.json` | `src/Api/`                        | Create environment-specific configs as needed |

---

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a branch: `git checkout -b feature/feature-name`.
3. Commit with clear messages following [Conventional Commits](https://www.conventionalcommits.org/).
4. Open a Pull Request for review.

---

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for full release history.
