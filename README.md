# 🚀 {API_NAME}

> Base template for .NET API development at IATec, promoting standard practices, efficiency and security.

---

## 📋 Index

- [About the Project](#about-the-project)
- [Technologies and Stack](#technologies-and-stack)
- [Architecture](#architecture)
- [Prerequisites](#prerequisites)
- [How to Run](#how-to-run)
- [Configuration](#configuration)
- [Health Checks](#health-checks)
- [API Documentation (Scalar)](#api-documentation-scalar)
- [Authentication](#authentication)
- [Tests](#tests)
- [Renaming the API](#renaming-the-api)
- [Docker](#docker)
- [Changelog](CHANGELOG.md)
- [Contributing](#contributing)

---

## About the Project

This repository is a **base template** for creating new .NET APIs following IATec standards. It comes pre-configured with:

- Decoupled layered architecture (Api, Application, CrossCutting, Domain, Persistence, AntiCorruption, MessageQueue).
- API versioning via query string (`api-version`).
- Interactive API documentation via **Scalar/OpenAPI** (non-Production environments only).
- Health Check endpoint returning API assembly version.
- CORS configuration with exposed headers.
- Integration with shared libraries (`IATec.Shared.*`).
- Validation via `FluentValidation` and result handling via `FluentResults`.
- MediatR with pipeline behaviors (`ValidatorPipelineBehavior`, `ExceptionPipelineBehavior`) from `IATec.Shared.Behaviors`.
- Logging dispatcher integration with IATec Log Service.
- Sample Asset feature with Command, Query, Validator and Handlers (stub implementations).

> **Note:** Whenever creating a new API from this template, read the [Renaming the API](#renaming-the-api) section to adjust names and references.

---

## Technologies and Stack

| Technology | Version | Source |
|------------|---------|--------|
| .NET | 10.0 | All `.csproj` files |
| Scalar.AspNetCore | 2.14.14 | `Api.csproj` |
| Microsoft.AspNetCore.OpenApi | 10.0.8 | `Api.csproj` |
| API Versioning (Asp.Versioning.Mvc) | 10.0.0 | `Api.csproj` |
| API Versioning (Asp.Versioning.Mvc.ApiExplorer) | 10.0.0 | `Api.csproj` |
| HealthChecks UI Client | 9.0.0 | `Api.csproj` |
| MediatR | 14.1.0 | `CrossCutting.csproj` |
| FluentValidation | 12.1.1 | `Domain.csproj` |
| FluentValidation.DependencyInjectionExtensions | 12.1.1 | `Domain.csproj` |
| FluentResults | 4.0.0 | `Domain.csproj` |
| IATec.Shared.Api | 1.2.0 | `Api.csproj` |
| IATec.Shared.Application | 2.0.0 | `Application.csproj` |
| IATec.Shared.Behaviors | 1.3.0 | `CrossCutting.csproj` |
| IATec.Shared.Domain | 2.0.1 | `Domain.csproj` |
| IATec.Shared.HttpClient | 3.0.0 | `AntiCorruption.csproj` |
| Microsoft.Extensions.DependencyInjection.Abstractions | 10.0.8 | `AntiCorruption.csproj`, `MessageQueue.csproj` |
| Microsoft.Extensions.Http | 10.0.8 | `AntiCorruption.csproj`, `Persistence.csproj` |
| Microsoft.Extensions.Options | 10.0.8 | `Application.csproj` |
| Microsoft.Extensions.Configuration | 10.0.8 | `Persistence.csproj` |
| Microsoft.Extensions.Configuration.Binder | 10.0.8 | `Persistence.csproj` |

---

## Architecture

The project follows a layered organization inside the `src/` folder:

```
src/
├── Api/                        → ASP.NET Core entrypoint (Program, Configs, DI)
│   ├── Configurations/
│   │   ├── ApiDependencyInjectionConfig.cs
│   │   └── Extensions/
│   │       ├── CorsPolicyExtension.cs
│   │       ├── HealthCheckExtension.cs
│   │       ├── MigrationExtensions.cs
│   │       ├── OptionsExtension.cs
│   │       ├── ScalarConfiguration.cs
│   │       └── VersioningExtension.cs
│   ├── Controllers/            → Empty folder (no controllers)
│   └── Properties/
│       └── launchSettings.json
├── Application/                → Use cases, handlers, dispatchers, validators
│   ├── Configurations/
│   │   ├── ApplicationDependencyInjectionConfig.cs
│   │   ├── Extensions/
│   │   │   ├── MediatorConfig.cs
│   │   │   └── ValidatorConfig.cs
│   │   └── Factories/
│   │       └── ValidatorFactory.cs
│   ├── Dispatchers/
│   │   └── Logging/
│   │       └── LogDispatcher.cs
│   └── Features/
│       └── Assets/
│           ├── Commands/
│           │   ├── CreateAssetCommand.cs
│           │   └── CreateAssetCommandHandler.cs
│           ├── Queries/
│           │   ├── CheckIfExistsAssetQuery.cs
│           │   └── CheckIfExistsAssetQueryHandler.cs
│           └── Validators/
│               └── CreateAssetValidator.cs
├── CrossCutting/               → Shared behaviors (via IATec.Shared.Behaviors)
├── Domain/                     → Business logic via IATec.Shared.Domain
├── Persistence/                → Data access (stub)
│   ├── Configurations/
│   │   ├── PersistenceDependencyInjectionConfig.cs
│   │   └── Extensions/
│   │       └── DatabaseExtension.cs
├── AntiCorruption/             → External service adapters
│   ├── Configurations/
│   │   ├── AntiCorruptionDependencyInjectionConfig.cs
│   │   └── Extensions/
│   │       └── LoggingConfig.cs
│   └── Services/
│       └── Iatec/
│           └── LogService.cs
├── MessageQueue/               → Message queue DI placeholder
├── Domain.Tests/               → Domain layer unit tests (empty)
└── Application.Tests/            → Application layer unit tests (empty)
```

> **Note:** The `Domain` layer no longer contains local contracts, entities, or utilities. All domain contracts (`IEntity`, `IReadRepository`, `IWriteRepository`, `ILogDispatcher`, `ILogService`, etc.), seedwork entities (`Entity`, `EntityInt32`, `EntityNullable`), shared options (`LogServiceOption`, `ContainerOption`), and error/success types have been moved to the `IATec.Shared.Domain` NuGet package (v2.0.1) as of the Reset Project (2026-01-20).

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

By default, the application will be available at:
- `http://localhost:5015`
- Environment: `Local`

> The browser will automatically open the Scalar documentation (`/documentation`) on startup due to the `launchSettings.json` profile configuration.
> The exact URL may vary depending on the active launch profile. Check `src/Api/Properties/launchSettings.json` or the console output when starting the project.

---

## Configuration

Settings are located in `src/Api/appsettings.json` (and its environment overrides, such as `appsettings.Development.json`).

**Current structure example:**

```json
{
  "TimeZone": "UTC",
  "Container": {
    "Name": "Vertical-ContextContainerType",
    "ContainerId": "ContainerId"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "ConnectionStrings": {}
}
```

### Configured Options (`IOptions<T>`)

The following typed options are registered in `src/Api/Configurations/Extensions/OptionsExtension.cs` via `IATec.Shared.Domain.Options`:

| Option | Configuration Key | Source |
|--------|------------------|--------|
| `LogServiceOption` | `LogServiceOption.Key` (value `"IATec:Services:Log"`) | `IATec.Shared.Domain` |
| `ContainerOption` | `ContainerOption.Key` (value `"Container"`) | `IATec.Shared.Domain` |

### What to configure when starting a new API

| Section | Description | Example |
|---------|-----------|---------|
| `TimeZone` | Application time zone | `"America/Sao_Paulo"` |
| `Container` | Deployment/container metadata | Adjust `Name` and `ContainerId` according to your environment |
| `Logging` | ASP.NET Core log level | `"Debug"`, `"Information"`, `"Warning"` |
| `ConnectionStrings` | Database and service connection strings | `"DefaultConnection": "Server=..."` |

> **Tip:** Add new configuration sections in `src/Api/Configurations/Extensions/OptionsExtension.cs` for typed injection via `IOptions<T>`.

---

## Health Checks

The project has a health check endpoint that returns API version information:

```
GET /_healthcheck/status
```

Features:
- Returns `Healthy`/`Unhealthy` status.
- Includes the API assembly version (`Assembly.GetEntryAssembly()?.GetName().Version`) in the response body.
- Response in `HealthChecks.UI.Client` visual format (`UIResponseWriter.WriteHealthCheckUIResponse`).

---

## API Documentation (Scalar)

Interactive documentation powered by **Scalar** and native ASP.NET Core **OpenAPI** is available in **non-Production** environments only:

- OpenAPI JSON: `/openapi/v1.json`
- Scalar UI: `/documentation`

### Configured features

- Automatically generated from native `Microsoft.AspNetCore.OpenApi`.
- **Mars theme** with forced dark mode.
- Tags expanded and sorted alphabetically.
- Default HTTP client configured as **C# HttpClient**.
- Title includes environment name (e.g., `{API_NAME} - Local`).
- Anonymous access allowed.

---

## Authentication

The Scalar UI supports sending JWT tokens in the `Authorization` header with the `Bearer` scheme.

To enable actual token validation in the API:
1. Add the desired authentication package (e.g. `Microsoft.AspNetCore.Authentication.JwtBearer`).
2. Configure token validation in `ApiDependencyInjectionConfig.cs` or in a new extension method.
3. Insert `app.UseAuthentication()` before `app.UseAuthorization()` in `UseApi()`.

---

## Tests

The template includes two test projects without any test framework or test cases configured:

| Project | Layer Tested | Framework | Status |
|---------|--------------|-----------|--------|
| `Domain.Tests` | Domain | None configured | Empty |
| `Application.Tests` | Application | None configured | Empty |

> **Note:** These projects were created as placeholders. You need to add a test framework (xUnit, NUnit, MSTest) and write tests.

To run all tests:

```bash
dotnet test
```

---

## Renaming the API

> Whenever using this project as a base for a new API, follow the steps below to adjust names and references. The text `{API_NAME}` used throughout this README acts as a placeholder for the **actual project name** you want to use.

### Step-by-step guide

#### 1. Clone the repository and enter the folder

```bash
git clone <repository-url>
cd {API_NAME}
```

#### 2. Rename the Solution file

```bash
mv IATec.Standard.Net.Api.sln {API_NAME}.sln
```

#### 3. (Optional) Rename `AssemblyName` and `RootNamespace` in `.csproj` files

The current `.csproj` files do **not** explicitly define `AssemblyName` or `RootNamespace`; they inherit from the file name by default. If you rename the project files, the assembly names will update automatically.

If you need explicit control, add the properties:

```xml
<PropertyGroup>
    <AssemblyName>{API_NAME}</AssemblyName>
    <RootNamespace>{API_NAME}</RootNamespace>
</PropertyGroup>
```

#### 4. Adjust C# namespaces

Run a **Replace All** in the `src/` folder for each project layer. Example:

| From | To (example) |
|------|--------------|
| `namespace Api;` | `namespace ProjectName.Api;` |
| `namespace Application;` | `namespace ProjectName.Application;` |
| `namespace Domain;` | `namespace ProjectName.Domain;` |

Or keep simplified namespaces (`Api`, `Domain`, `Application`, etc.) — this is a team preference.

#### 5. Update Scalar title

Open `src/Api/Configurations/Extensions/ScalarConfiguration.cs` and change:

```csharp
document.Info = new()
{
    Title = "{API_NAME}",
```

And also:

```csharp
.WithTitle($"{{API_NAME}} - {environment.EnvironmentName}")
```

#### 6. Update README

Replace **all** occurrences of `{API_NAME}` in this `README.md` with the actual project name.

You can use your editor's `Find & Replace` (usually `Ctrl+Shift+H`) with the following text:

- **Find:** `{API_NAME}`
- **Replace:** `MyNewProjectName`

#### 7. Review and commit

After all changes, run a full build to ensure everything compiles:

```bash
dotnet build
```

Then commit your changes:

```bash
git add .
git commit -m "refactor: rename template API to {API_NAME}"
```

---

### Quick Checklist

Use this checklist to ensure you didn't miss any step:

- [ ] Repository cloned and folder renamed to new API name
- [ ] `.sln` file renamed to `{API_NAME}.sln`
- [ ] (Optional) `AssemblyName`/`RootNamespace` explicitly set in `.csproj` files if needed
- [ ] Namespaces adjusted in source code (`src/`)
- [ ] Scalar `Title` updated in `ScalarConfiguration.cs`
- [ ] All `{API_NAME}` placeholders replaced in `README.md`
- [ ] `dotnet build` runs successfully with zero errors
- [ ] Changes committed to version control

---

## Docker

There is a `docker/Dockerfile` prepared for building the application.

> **Attention:** The Dockerfile is currently **empty** (0 bytes). When creating a new API from this template, fill it according to your build pipeline. Basic example:

```dockerfile
# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY .
RUN dotnet restore "src/Api/Api.csproj"
RUN dotnet build "src/Api/Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Api/Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
```

### Kubernetes Secrets

A `secrets/secrets.yml` file is provided as a template for Kubernetes Secret manifests:

```yaml
apiVersion: v1
kind: Secret
metadata:
  name: secret-#{deployment_name}#
  namespace: #{namespace}#
stringData:
```

Update the placeholders (`#{deployment_name}#`, `#{namespace}#`) and add the required secret values under `stringData:` before applying to your cluster.

---

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a branch for your feature or fix: `git checkout -b feature/feature-name`.
3. Commit your changes with clear messages.
4. Open a Pull Request for review.

---

> **Note:** This is a base template. Feel free to add/remove layers, packages and configurations according to your business domain needs.