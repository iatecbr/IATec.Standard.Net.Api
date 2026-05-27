# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0] - 2026-05-26

### Added

- Full README template with architecture, configuration, health checks, API documentation, Docker/Kubernetes setup guides, and API renaming checklist.
- `secrets/secrets.yml` as a Kubernetes Secret manifest template with placeholders (`#{deployment_name}#`, `#{namespace}#`).
- `docker/Dockerfile` placeholder (currently empty, to be filled per build pipeline).
- Interactive API documentation via **Scalar.AspNetCore** v2.14.14:
  - OpenAPI JSON endpoint: `/openapi/v1.json`
  - Scalar UI endpoint: `/documentation`
  - Mars theme with forced dark mode
  - Tags expanded and sorted alphabetically
  - Default HTTP client configured as C# HttpClient
  - Title includes environment name (e.g., `{API_NAME} - Local`)
- `ExceptionPipelineBehavior` from `IATec.Shared.Behaviors` registered in MediatR pipeline alongside `ValidatorPipelineBehavior`.
- `Microsoft.Extensions.Options` v10.0.8 added to `Application.csproj`.
- Sample Asset feature stubs:
  - `CreateAssetCommand` and `CreateAssetCommandHandler`
  - `CheckIfExistsAssetQuery` and `CheckIfExistsAssetQueryHandler`
  - `CreateAssetValidator`

### Changed

- **BREAKING:** Replaced `Swashbuckle.AspNetCore` with `Scalar.AspNetCore`. Removed `SwaggerExtension.cs` (69 lines) and all Swagger/Swashbuckle configuration.
- **BREAKING:** Upgraded `IATec.Shared.*` libraries to v2.x/v1.3.x:
  - `IATec.Shared.Application` 1.1.0 → 2.0.0
  - `IATec.Shared.Domain` 1.2.0 → 2.0.1
  - `IATec.Shared.Behaviors` 1.2.0 → 1.3.0
  - `IATec.Shared.HttpClient` 2.1.0 → 3.0.0
- **BREAKING:** Converted Commands and Queries from `sealed class` to `readonly record struct`:
  - `CreateAssetCommand : IRequest<Result>` → `public readonly record struct CreateAssetCommand : IRequest<Result>`
  - `CheckIfExistsAssetQuery : IRequest<Result<bool>>` → `public readonly record struct CheckIfExistsAssetQuery : IRequest<Result<bool>>`
  - `CreateAssetValidator` simplified to `public class CreateAssetValidator : AbstractValidator<CreateAssetCommand> { }` (removed empty constructor body)
- `launchUrl` in `launchSettings.json` changed from `swagger` to `documentation`.
- `Microsoft.Extensions.*` bumped across all projects:
  - `Microsoft.Extensions.DependencyInjection.Abstractions` 10.0.1 → 10.0.8
  - `Microsoft.Extensions.Http` 10.0.1 → 10.0.8
  - `Microsoft.Extensions.Configuration` 10.0.1 → 10.0.8
  - `Microsoft.Extensions.Configuration.Binder` 10.0.1 → 10.0.8
  - `Microsoft.Extensions.Options` 10.0.1 → 10.0.8
- API Versioning packages bumped: `Asp.Versioning.Mvc` 8.1.1 → 10.0.0, `Asp.Versioning.Mvc.ApiExplorer` 8.1.1 → 10.0.0.
- `IATec.Shared.Api` 1.1.0 → 1.2.0.
- `Microsoft.AspNetCore.OpenApi` 10.0.1 → 10.0.8.
- `Api.csproj` version bumped from 1.1.0 to 2.0.0.

### Fixed

- `LogDispatcher.cs`: Changed `Content = content?.ToString()!` to `Content = content?.ToString() ?? string.Empty`, replacing null-forgiving operator with null-coalescing to prevent null reference issues.

### Removed

- `Swashbuckle.AspNetCore` package and all Swagger-related code (`SwaggerExtension.cs`).
- Empty constructor body from `CreateAssetValidator`.

---

## [1.2.0] - 2025-04-29

### Added

- `ValidatorPipelineBehavior` now supports generic return values (not just `Result`).

### Changed

- `ValidatorPipelineBehavior<TRequest, TResponse>` constraint changed from `where TResponse : Result` to `where TResponse : ResultBase, new()`.
- `BuildResponse<TResult>` method now uses `new TResult()` and adds errors via `result.Reasons.AddRange(errorList)` instead of `Result.Fail()`, enabling proper value-type results.

---

## [1.1.0] - 2024-09-23

### Added

- `EntityNullable` seedwork entity (`Domain.SeedWorks`) for nullable key scenarios.
- `ServiceUnavailableError` default error type (`Domain.Shared.Results.Errors.Default`).
- `ServiceUnavailableMessageKey` constant in `DefaultErrorMessageKeys`.

### Changed

- `Microsoft.AspNetCore.OpenApi` 8.0.6 → 8.0.8
- `Swashbuckle.AspNetCore` 6.6.2 → 6.8.0
- `FluentResults` 3.15.2 → 3.16.0
- `FluentValidation` 11.9.1 → 11.10.0
- `FluentValidation.DependencyInjectionExtensions` 11.9.1 → 11.10.0
- `MediatR` 12.2.0 → 12.4.1
- `ApiDependencyInjectionConfig.cs`: Removed `TransactionFilter` registration from MVC filters (kept only `ExceptionFilter`).

### Removed

- `TransactionFilter.cs` deleted from `Api/Configurations/Filters/`.

---

## [1.0.1] - 2024-06-01

### Added

- `Application.Tests` project formally added to `.sln` (corrected GUID).

### Changed

- `MigrationExtensions.cs`: Formatting fix (whitespace).
- `Api.csproj`, `Application.csproj`, `Persistence.csproj`: Version formatting normalization.
- `.sln` file: Updated `Application.Tests` project GUID from `{76597DEE-129E-4A25-904C-015C6ACA9B0F}` to `{2E9E816D-1E41-45C1-95DD-5BC528CF0A9C}`.

### Removed

- `src/Application.Tests/Program.cs` deleted (was a stub Console.WriteLine).
- `Microsoft.EntityFrameworkCore` 8.0.6 from `Api.csproj` and `Persistence.csproj`.
- `Microsoft.EntityFrameworkCore.Relational` 8.0.6 from `Persistence.csproj`.
- `Microsoft.EntityFrameworkCore.Tools` 8.0.6 from `Api.csproj` and `Persistence.csproj`.
- `Npgsql.EntityFrameworkCore.PostgreSQL` 8.0.4 from `Persistence.csproj`.
- `EntityFrameworkOption.cs` from `Persistence/Configurations/Options/`.
- `.editorconfig` from `Persistence/Migrations/` and `Domain/Models/`.

---

## [1.0.0] - 2024-05-28

### Added

- Initial project structure with full layered architecture for .NET 8:
  - **Api** – ASP.NET Core entrypoint with `Program.cs`, `ApiDependencyInjectionConfig.cs`, filters (`ExceptionFilter`, `TransactionFilter`), conventions (`ConventionConfiguration`), `CustomControllerBase`, and configuration extensions (`CorsPolicyExtension`, `HealthCheckExtension`, `MigrationExtensions`, `OptionsExtension`, `SwaggerExtension`, `VersioningExtension`).
  - **Application** – `ApplicationDependencyInjectionConfig.cs`, `MediatorConfig`, `ValidatorConfig`, `ValidatorFactory`, `LogDispatcher`, sample Asset feature stubs.
  - **CrossCutting** – `ValidatorPipelineBehavior` (local implementation).
  - **Domain** – Contracts (`IEntity`, `IReadRepository`, `IWriteRepository`, `IGenericRepositoryQuery`, `IUnitOfWork`, `ITransaction`, `IValidatorGeneric`, `ILogDispatcher`, `ILogService`), seedwork entities (`Entity<T>`, `EntityInt32`, `EntityNullable`), shared extensions (`EnumExtension`, `IntExtension`, `ResultExtension`, `StringExtension`), identifies (`BaseIdentify`, `ContextType`, `LogActionType`, `LogSourceType`), messages (`DefaultErrorMessageKeys`, `StatusCodeMessageKeys`), options (`ContainerOption`, `LogServiceOption`), and error/success result types (`BadRequestFieldsError`, `EmptyFieldError`, `InvalidLengthError`, `InvalidMinValueError`, `ResourceNotFoundError`, `CreatedSuccess`, `EmptyResult`, `NoContentSuccess`).
  - **Persistence** – `PersistenceDependencyInjectionConfig.cs`, `DatabaseExtension`, `EntityFrameworkOption`.
  - **AntiCorruption** – `AntiCorruptionDependencyInjectionConfig.cs`, `LoggingConfig`, `LogService`.
  - **MessageQueue** – `MessageQueueDependencyInjectionConfig.cs` (stub).
  - **Domain.Tests** – Empty test project.
  - **Application.Tests** – Empty test project with `OutputType=Exe`.
- `launchSettings.json` with `http` profile on port `5015`, `launchUrl: swagger`, environment `Local`.
- `appsettings.json` with `TimeZone`, `Container` (Name only), `Logging`, `ConnectionStrings`.
- `.editorconfig`, `.gitignore`, `LICENSE`, `IATec.Standard.Net.Api.sln`.

---

## [0.1.0] - 2024-05-28

### Added

- Repository bootstrap with `LICENSE` and initial `.gitignore` (398 lines).