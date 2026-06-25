# MissionPilot

MissionPilot is a local-first .NET / Blazor application designed to help freelance developers manage mission opportunities, evaluate job fit, prepare tailored application messages, and track follow-ups without scraping or automating third-party platforms.

The project is intentionally public and professional: it demonstrates clean .NET architecture, pragmatic product thinking, repository security, CI/CD with GitHub Actions, and responsible use of automation.

## Goals

- Centralize freelance mission opportunities.
- Score opportunities according to fit, risk, stack, location, remote policy, and constraints.
- Suggest the most appropriate CV profile for each opportunity.
- Generate draft application messages and follow-up messages.
- Track recruiter interactions and application statuses.
- Keep the human in control of every outbound action.
- Provide a clean open-source repository that can be reviewed by recruiters.

## Non-goals

MissionPilot is not a LinkedIn bot, a scraping tool, a mass-emailing tool, or a candidate-spam platform.

The application must not:
- scrape LinkedIn, Malt, LeHibou, Free-Work, or other third-party platforms;
- send automated LinkedIn invitations;
- send automated LinkedIn messages;
- apply automatically to jobs;
- store real recruiter data in the public repository;
- commit secrets, tokens, private CV files, or personal application history.

## Tech stack

Initial target stack:

- .NET 10
- Blazor Web App
- EF Core
- SQLite
- xUnit
- GitHub Actions
- CodeQL
- Dependabot
- Dependency Review
- GitHub secret scanning / push protection

Possible later additions:

- local AI assistant through Ollama or another local model runtime;
- email import through IMAP, with explicit user configuration;
- export features for CSV or Markdown reports.

## Architecture

The project follows a pragmatic layered architecture:

```text
src/
  MissionPilot.Domain/
  MissionPilot.Application/
  MissionPilot.Infrastructure/
  MissionPilot.Web/

tests/
  MissionPilot.Domain.Tests/
  MissionPilot.Application.Tests/
  MissionPilot.Infrastructure.Tests/
```

The application should remain simple, testable, and easy to understand. The goal is not to over-engineer, but to show clean boundaries and professional practices.

## Documentation

- [Project brief](docs/00-project-brief.md)
- [Product vision](docs/01-product-vision.md)
- [Functional specification](docs/02-functional-specification.md)
- [Technical architecture](docs/03-technical-architecture.md)
- [Security and repository governance](docs/04-security-and-repository-governance.md)
- [CI/CD and GHAS](docs/05-ci-cd-and-ghas.md)
- [Development roadmap](docs/06-development-roadmap.md)
- [Pair programming workflow](docs/07-pair-programming-workflow.md)
- [Privacy and responsible automation](docs/08-privacy-and-responsible-automation.md)
- [Decision log](docs/09-decision-log.md)

## Development principles

- Local-first by default.
- No scraping.
- No automated outbound messages.
- Human validation before every application.
- No real personal or recruiter data committed to the repository.
- Small vertical slices.
- Tests for core domain and application logic.
- Public repository quality from day one.

## Getting started

The implementation will be added incrementally.

Expected future commands:

```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project src/MissionPilot.Web
```

## Repository security

The repository is expected to use:

- protected `main` branch;
- pull requests for all changes;
- GitHub Actions CI;
- CodeQL code scanning;
- Dependabot alerts and updates;
- dependency review on pull requests;
- secret scanning and push protection where available.

## License

License to be decided before first public release.

Recommended options:
- MIT for maximum adoption and simplicity;
- Apache-2.0 if explicit patent grant is desired.
