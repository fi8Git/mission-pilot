# 09 — Decision Log

This file records important project decisions.

## Decision 001 — Build a local-first Blazor application

### Status

Accepted

### Context

The project is a personal productivity tool and a public portfolio project. It should be easy to run locally and should demonstrate .NET / Blazor expertise.

### Decision

Use a local-first .NET / Blazor Web App.

### Consequences

- Strong alignment with the developer profile.
- Easy to show as a portfolio project.
- No cloud dependency for MVP.
- Future desktop packaging remains possible.

## Decision 002 — Use SQLite for MVP persistence

### Status

Accepted

### Context

The MVP is single-user and local. A full database server would slow down setup.

### Decision

Use SQLite through EF Core.

### Consequences

- Simple local setup.
- Easy demo.
- Suitable for MVP data volumes.
- Some database features are limited compared to PostgreSQL or SQL Server.

## Decision 003 — No scraping and no automated outbound messaging

### Status

Accepted

### Context

The project should be ethical, professional, and safe for a public repository.

### Decision

MissionPilot will not scrape platforms and will not send automated messages.

### Consequences

- Lower legal/platform risk.
- Better professional positioning.
- User remains in control.
- The product focuses on assistance, not automation abuse.

## Decision 004 — Deterministic templates before AI

### Status

Accepted

### Context

Message generation can be useful without AI. Templates are easier to test and safer for MVP.

### Decision

Use deterministic templates first. Add local AI later only if useful.

### Consequences

- Faster MVP.
- More testable.
- Less privacy risk.
- AI remains optional.

## Decision 005 — Public repository quality from day one

### Status

Accepted

### Context

The repository is visible to recruiters and should demonstrate professional practices.

### Decision

Documentation, CI, security files, and repository governance are part of the initial scope.

### Consequences

- Slightly more work upfront.
- Stronger portfolio impact.
- Cleaner long-term maintenance.

## Decision 006 — Pair programming workflow, no autonomous coding agent

### Status

Accepted

### Context

The developer wants to build the project directly and use the assistant as a pair programming partner.

### Decision

The project documentation and workflow are written for human-led pair programming.

### Consequences

- No autonomous implementation prompts.
- More learning value.
- Better control over code quality.
- The developer remains the author of the implementation.
