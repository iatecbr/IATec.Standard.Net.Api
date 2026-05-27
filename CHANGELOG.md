# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [2.1.0] — 2025-05-27

### 📝 Documentation

#### ADDED
- Comprehensive `README.md` template with precise project structure, exact NuGet versions, and detailed layer descriptions.
- `CHANGELOG.md` file with categorized release history (`ADDED`, `UPDATED`, `FIXED`, `REMOVED`).
- Detailed architecture section documenting all 7 layers (`Api`, `Application`, `Domain`, `Persistence`, `AntiCorruption`, `MessageQueue`, `CrossCutting`).
- "Known Limitations / TODOs" table listing 12 identified gaps (handlers, empty layers, missing auth, CORS, tests, Docker, CI/CD).
- "Renaming the API" step-by-step guide for cloning this template.
- "How to Run" section with exact commands and default URL (`http://localhost:5015`).
- "Configuration" section documenting `appsettings.json`, typed `IOptions<T>`, and what must be configured.
- "Scalar" section replacing the old Swagger documentation.
- "Feature: Assets" section describing the only implemented feature domain (placeholder handlers).
- "Logging Dispatcher" section describing `LogDispatcher` and `LogService`.
- "Test Projects" section documenting that both test projects are empty with no framework packages.
- "Docker" section acknowledging empty Dockerfiles and providing a sample Dockerfile.
- "CI/CD" section documenting absence of pipelines.

---

## [2.0.0] — Previous Release (Breaking Changes)

### ⚠️ Breaking Changes

#### UPDATED
- **API version bumped from `1.1.0` to `2.0.0`** reflecting breaking changes.
- `IATec.Shared.Application` updated from `1.1.0` → `2.0.0`.
- `IATec.Shared.Domain` updated from `1.2.0` → `2.0.1`.
- `IATec.Shared.HttpClient` updated from `2.1.0` → `3.0.0`.
- All `Microsoft.Extensions.*` packages updated from `10.0.1` → `10.0.8`.
  - `Microsoft.Extensions.Configuration`
  - `Microsoft.Extensions.Configuration.Binder`
  - `Microsoft.Extensions.DependencyInjection.Abstractions`
  - `Microsoft.Extensions.Http`
- `MediatR` updated from `14.0.0` → `14.1.0`.
- `Asp.Versioning.Mvc` and `Asp.Versioning.Mvc.ApiExplorer` updated from `8.1.1` → `10.0.0`.
- `IATec.Shared.Behaviors` updated from `1.2.0` → `1.3.0`.

#### FIXED
- `LogDispatcher.cs` — added mandatory fields `Id = string.Empty` and `UserId = string.Empty` to `LogDto` to prevent validation/runtime errors from the shared library contract.

#### REMOVED
- **Swashbuckle.AspNetCore** (`10.1.0`) and all Swagger UI configuration (`SwaggerExtension.cs`).
- Swagger JWT Bearer security definitions from the API documentation.
- `launchUrl` pointing to `swagger` in `launchSettings.json`.

#### ADDED
- **Scalar.AspNetCore** (`2.14.14`) replacing Swagger.
- `ScalarConfiguration.cs` — new extension configuring native `Microsoft.AspNetCore.OpenApi` document generation and Scalar UI at `/documentation` with Mars theme, dark mode, C# HttpClient default.
- `Microsoft.AspNetCore.OpenApi` (`10.0.8`) for native OpenAPI document generation.
- `Microsoft.Extensions.Options` (`10.0.8`) in Application layer.

#### REFACTORED
- `CreateAssetCommand` converted from `class` to `readonly record struct`.
- `CheckIfExistsAssetQuery` converted from `class` to `readonly record struct`.
- `CreateAssetValidator` simplified to empty class declaration (`public class CreateAssetValidator : AbstractValidator<CreateAssetCommand>;`).
- `ApiDependencyInjectionConfig.cs` updated to wire Scalar instead of Swagger.
- `launchSettings.json` updated to open browser at `/documentation` (Scalar endpoint) instead of `/swagger`.

---

## [1.1.0] — Earlier Release

### ADDED
- Initial project scaffolding with Clean Architecture layers.
- MediatR CQRS setup with pipeline behaviors (`ValidatorPipelineBehavior`, `ExceptionPipelineBehavior`).
- FluentValidation integration with `ValidatorFactory` implementing `IValidatorGeneric`.
- Health Checks endpoint (`/_healthcheck/status`) with `VersionHealthCheck`.
- CORS policy (`AllowAnyOrigin`, `AllowAnyMethod`, `AllowAnyHeader`).
- API Versioning via query string (`api-version`).
- IATec Log Service integration via typed `HttpClient` in AntiCorruption layer.
- `LogDispatcher` implementing `ILogDispatcher` from shared library.
- `appsettings.json` with `TimeZone`, `Container`, `Logging`, and empty `ConnectionStrings`.
- `launchSettings.json` with `http` profile on port `5015`.
- `GenerateDocumentationFile` enabled in `Api.csproj`.
- Empty `Domain`, `CrossCutting`, `Persistence`, `MessageQueue` layers as scaffolding.
- Empty `Domain.Tests` and `Application.Tests` projects.
- Empty `docker/Dockerfile` and `docker/Local.Dockerfile`.
- `secrets/secrets.yml` Kubernetes Secret template.

### FIXED
- Various package references and project structure.

---

## [Unreleased]

### Planned
- Implement actual business logic in Asset handlers.
- Add real domain models to `Domain` layer.
- Add database access (EF Core or Dapper) to `Persistence` layer.
- Add message queue producer/consumer implementations.
- Add test framework (xUnit) and write actual tests.
- Fill Dockerfiles with real build/publish steps.
- Add CI/CD pipeline (GitHub Actions or Azure DevOps).
- Add JWT authentication.
- Restrict CORS policy for production.
- Rename `{API_NAME}` placeholders.
