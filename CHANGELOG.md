# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [2.1.0] — 2026-05-28

### ADDED
- Comprehensive `README.md` with precise project structure, exact NuGet versions, and detailed layer descriptions.
- `CHANGELOG.md` with categorized release history (`ADDED`, `UPDATED`, `FIXED`, `REMOVED`).
- `AGENTS.md` with build/test commands, architecture patterns, code style guidelines, and file organization for AI coding agents.

---

## [2.0.0] — 2026-05-26

### ADDED
- **Scalar.AspNetCore** (`2.14.14`) replacing Swagger.
- `ScalarExtension.cs` — configures native OpenAPI document generation and Scalar UI at `/documentation`.
- `Microsoft.AspNetCore.OpenApi` (`10.0.8`).
- `Microsoft.Extensions.Options` (`10.0.8`) in Application layer.

### UPDATED
- `IATec.Shared.Application` `1.1.0` → `2.0.0`.
- `IATec.Shared.Domain` `1.2.0` → `2.0.1`.
- `IATec.Shared.HttpClient` `2.1.0` → `3.0.0`.
- `IATec.Shared.Behaviors` `1.2.0` → `1.3.0`.
- `MediatR` `14.0.0` → `14.1.0`.
- `Asp.Versioning.Mvc` and `Asp.Versioning.Mvc.ApiExplorer` `8.1.1` → `10.0.0`.
- `Microsoft.Extensions.Configuration` `10.0.1` → `10.0.8`.
- `Microsoft.Extensions.Configuration.Binder` `10.0.1` → `10.0.8`.
- `Microsoft.Extensions.DependencyInjection.Abstractions` `10.0.1` → `10.0.8`.
- `Microsoft.Extensions.Http` `10.0.1` → `10.0.8`.
- `CreateAssetCommand` converted from `class` to `readonly record struct`.
- `CheckIfExistsAssetQuery` converted from `class` to `readonly record struct`.
- `CreateAssetValidator` simplified to empty class declaration.
- `ApiDependencyInjectionConfig.cs` wired for Scalar instead of Swagger.
- `launchSettings.json` opens `/documentation` instead of `/swagger`.

### FIXED
- `LogDispatcher.cs` — added mandatory fields `Id` and `UserId` to `LogDto`.

### REMOVED
- **Swashbuckle.AspNetCore** (`10.1.0`) and all Swagger configuration (`SwaggerExtension.cs`).
- Swagger JWT Bearer security definitions.

---

## [1.2.0] — 2026-01-20

### ADDED
- `IATec.Shared.Api` (`1.1.0`) → `Api.csproj`.
- `IATec.Shared.Application` (`1.1.0`) → `Application.csproj`.
- `IATec.Shared.Domain` (`1.2.0`) → `Domain.csproj`.
- `IATec.Shared.Behaviors` (`1.2.0`) → `CrossCutting.csproj`.
- `IATec.Shared.HttpClient` (`2.1.0`) → `AntiCorruption.csproj`.
- Feature Assets: `CreateAssetCommand`, `CreateAssetCommandHandler`, `CheckIfExistsAssetQuery`, `CheckIfExistsAssetQueryHandler`, `CreateAssetValidator`.
- `docker/Dockerfile` and `docker/Local.Dockerfile` (empty scaffolding).
- `secrets/secrets.yml` — Kubernetes Secret template.
- `<Folder Include="Controllers\"/>` → `Api.csproj`.
- `GenerateDocumentationFile` → `Api.csproj`.

### UPDATED
- **Target framework:** `net8.0` → `net10.0` across all 7 `.csproj` files (`Api`, `Application`, `Domain`, `Persistence`, `AntiCorruption`, `MessageQueue`, `CrossCutting`).
- `FluentResults` `3.16.0` → `4.0.0` (`Domain.csproj`).
- `FluentValidation` `11.10.0` → `12.1.1` (`Domain.csproj`).
- `FluentValidation.DependencyInjectionExtensions` `11.10.0` → `12.1.1` (`Domain.csproj`).
- `MediatR` `12.4.1` → `14.0.0` (`CrossCutting.csproj`).
- `Asp.Versioning.Mvc` `8.1.0` → `8.1.1` (`Api.csproj`).
- `Asp.Versioning.Mvc.ApiExplorer` `8.1.0` → `8.1.1` (`Api.csproj`).
- `AspNetCore.HealthChecks.UI.Client` `8.0.1` → `9.0.0` (`Api.csproj`).
- `Microsoft.AspNetCore.OpenApi` `8.0.8` → `10.0.1` (`Api.csproj`).
- `Swashbuckle.AspNetCore` `6.8.0` → `10.1.0` (`Api.csproj`).
- `Microsoft.Extensions.DependencyInjection.Abstractions` `8.0.1` → `10.0.1` (`AntiCorruption.csproj`, `MessageQueue.csproj`).
- `Microsoft.Extensions.Http` `8.0.0` → `10.0.1` (`AntiCorruption.csproj`, `Persistence.csproj`).
- `Microsoft.Extensions.Configuration` `8.0.0` → `10.0.1` (`Persistence.csproj`).
- `Microsoft.Extensions.Configuration.Binder` `8.0.2` → `10.0.1` (`Persistence.csproj`).
- `Api.csproj` version corrected: `0.0.1` → `1.1.0`.

### REMOVED
- All domain contracts migrated to shared libs: `IEntity`, `ILogDispatcher`, `ILogService`, `IValidatorGeneric`, `ITransaction`, `IUnitOfWork`, `IReadRepository`, `IWriteRepository`, `IGenericRepositoryQuery`.
- `Entity.cs`, `EntityInt32.cs`, `EntityNullable.cs` from `Domain/SeedWorks` (moved to shared lib).
- `EnumExtension.cs`, `IntExtension.cs`, `ResultExtension.cs`, `StringExtension.cs` from `Domain/Shared/Extensions`.
- `BaseIdentify.cs`, `ContextType.cs`, `LogActionType.cs`, `LogSourceType.cs`, `DefaultErrorMessageKeys.cs`, `StatusCodeMessageKeys.cs`.
- `ContainerOption.cs`, `LogServiceOption.cs`.
- All local `Results/Errors` and `Results/Successes` (`BadRequestFieldsError`, `EmptyFieldError`, `ResourceNotFoundError`, etc.).
- `ValidatorPipelineBehavior.cs` from `CrossCutting` (moved to `IATec.Shared.Behaviors`).
- `ConventionConfiguration.cs`, `ExceptionFilter.cs`, `CustomControllerBase.cs` from `Api`.
- `AssetTypeEnum.cs`, `LogDto.cs`.
- `Microsoft.Extensions.Http` from `Application.csproj`, `CrossCutting.csproj`, `MessageQueue.csproj`, `Domain.Tests.csproj`.

---

## [1.1.0] — 2024-09-23

### ADDED
- `EntityNullable.cs` — base entity with nullable `Id` (`string?`).
- `ServiceUnavailableError.cs` — new domain error.
- `ServiceUnavailableMessageKey` in `DefaultErrorMessageKeys`.

### UPDATED
- `ValidatorPipelineBehavior` — added support for return values in handlers.
- `FluentResults` `3.15.2` → `3.16.0` (`Domain.csproj`, `Persistence.csproj`).
- `FluentValidation` `11.9.1` → `11.10.0` (`Domain.csproj`).
- `FluentValidation.DependencyInjectionExtensions` `11.9.1` → `11.10.0` (`Domain.csproj`).
- `MediatR` `12.2.0` → `12.4.1` (`CrossCutting.csproj`).
- `Microsoft.AspNetCore.OpenApi` `8.0.6` → `8.0.8` (`Api.csproj`).
- `Swashbuckle.AspNetCore` `6.6.2` → `6.8.0` (`Api.csproj`).
- `Microsoft.Extensions.Configuration.Binder` `8.0.1` → `8.0.2` (`Persistence.csproj`).

### REMOVED
- `TransactionFilter.cs` and its registration in `ApiDependencyInjectionConfig.cs`.

---

## [1.0.0] — 2024-05-28

### ADDED
- Solution with 7-layer Clean Architecture: `Api`, `Application`, `Domain`, `Persistence`, `AntiCorruption`, `MessageQueue`, `CrossCutting`.
- MediatR CQRS setup with pipeline behaviors: `ValidatorPipelineBehavior`, `ExceptionPipelineBehavior`.
- FluentValidation integration with `ValidatorFactory` implementing `IValidatorGeneric`.
- Health Checks endpoint (`/_healthcheck/status`) with `VersionHealthCheck`.
- CORS policy (`AllowAnyOrigin`, `AllowAnyMethod`, `AllowAnyHeader`) via `CorsPolicyExtension`.
- API Versioning via query string (`api-version`) via `VersioningExtension`.
- IATec Log Service integrated via typed `HttpClient` in AntiCorruption layer (`LogService.cs`).
- `LogDispatcher` implementing `ILogDispatcher`.
- `appsettings.json` with `TimeZone`, `Container`, `Logging`, and empty `ConnectionStrings`.
- `launchSettings.json` with `http` profile on port `5015`.
- Domain contracts: `IEntity`, `ILogDispatcher`, `ILogService`, `IValidatorGeneric`, `ITransaction`, `IUnitOfWork`, `IReadRepository`, `IWriteRepository`.
- SeedWorks: `Entity`, `EntityInt32`.
- Domain extensions: `EnumExtension`, `IntExtension`, `ResultExtension`, `StringExtension`.
- Results: `BadRequestFieldsError`, `EmptyFieldError`, `InvalidLengthError`, `InvalidMinValueError`, `ResourceNotFoundError`, `CreatedSuccess`, `EmptyResult`, `NoContentSuccess`.
- `ConventionConfiguration.cs`, `ExceptionFilter.cs`, `CustomControllerBase.cs`.
- `AssetTypeEnum.cs`, `LogDto.cs`.
- Empty test projects: `Domain.Tests`, `Application.Tests`.

### REMOVED
- `Microsoft.EntityFrameworkCore` (`8.0.6`), `Microsoft.EntityFrameworkCore.Relational` (`8.0.6`), `Microsoft.EntityFrameworkCore.Tools` (`8.0.6`) from `Api.csproj` and `Persistence.csproj`.
- `Npgsql.EntityFrameworkCore.PostgreSQL` (`8.0.4`) from `Persistence.csproj`.
