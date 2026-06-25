# 03 — Technical Architecture

## Architecture goal

MissionPilot should be simple, explicit, testable, and credible as a public .NET project.

The architecture should avoid unnecessary complexity while keeping clear boundaries between domain logic, application use cases, persistence, and UI.

## Initial solution structure

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

## Project responsibilities

### MissionPilot.Domain

Contains pure business concepts and rules.

Responsibilities:

- entities;
- value objects;
- enums;
- domain services when needed;
- scoring rule models if pure;
- validation rules that do not require infrastructure.

Must not reference:

- EF Core;
- Blazor;
- HTTP;
- database providers;
- file system;
- external APIs.

### MissionPilot.Application

Contains use cases.

Responsibilities:

- commands;
- queries;
- handlers/services;
- DTOs;
- ports/interfaces for infrastructure;
- scoring orchestration;
- CV recommendation orchestration;
- message generation orchestration.

May reference:

- Domain.

Must not reference:

- Infrastructure;
- Web;
- EF Core concrete DbContext;
- Blazor components.

### MissionPilot.Infrastructure

Contains technical implementations.

Responsibilities:

- EF Core DbContext;
- SQLite persistence;
- repositories;
- local configuration persistence;
- file storage if needed;
- future email import;
- future local AI client.

May reference:

- Application;
- Domain.

### MissionPilot.Web

Contains the Blazor UI.

Responsibilities:

- pages;
- components;
- forms;
- validation display;
- dashboard;
- dependency injection composition;
- user interactions.

May reference:

- Application;
- Infrastructure;
- Domain when practical for enums/value display.

## Dependency direction

```text
Web -> Application -> Domain
Web -> Infrastructure -> Application -> Domain
Infrastructure -> Application -> Domain
```

Domain must remain independent.

## MVP persistence

Use SQLite through EF Core.

Reasons:

- local-first use case;
- no server dependency;
- simple setup;
- easy for demo and portfolio;
- enough for a single-user desktop/local web application.

## Database strategy

Initial database objects:

- Opportunities
- Recruiters
- Companies
- CvProfiles
- ApplicationMessages
- FollowUpReminders
- OpportunityScoreResults

Migrations should be committed once persistence starts.

## UI strategy

Initial UI pages:

- Dashboard
- Opportunities
- Opportunity detail
- New opportunity
- Recruiters
- Settings
- About

The UI should be clean and professional, but not overdesigned.

Priority:

1. usable workflow;
2. readable layout;
3. clear statuses and score;
4. easy copy-to-clipboard for messages;
5. demo-friendly screens.

## Domain model draft

### Opportunity

Represents a mission opportunity.

Important behavior:

- update status;
- attach recruiter;
- update scoring result;
- plan next follow-up;
- mark archived;
- mark signed.

### OpportunityStatus

Possible values:

- Draft
- ToAnalyze
- ToApply
- MessagePrepared
- CvSent
- FollowUpJ3
- FollowUpJ7
- CallScheduled
- InProcess
- Rejected
- StandBy
- Signed
- Archived

### OpportunityScore

Represents score value and explanation.

Fields:

- total score;
- priority;
- positive signals;
- negative signals;
- recommended action.

### CvProfile

Represents a logical CV version.

Examples:

- ESN;
- ClientFinalPremium;
- BackendDotNet;
- GenericDotNetBlazor.

### MessageTemplate

Represents a reusable template.

Fields:

- name;
- context;
- content;
- placeholders.

## Application use cases

Initial use cases:

- CreateOpportunity
- UpdateOpportunity
- ListOpportunities
- GetOpportunityDetail
- ScoreOpportunity
- RecommendCvProfile
- GenerateApplicationMessage
- PlanFollowUp
- MarkFollowUpDone
- UpdateOpportunityStatus

## Testing strategy

### Domain tests

Test:

- status transition rules;
- score interpretation;
- priority mapping;
- CV recommendation rules if placed in domain;
- value object validation.

### Application tests

Test:

- opportunity creation;
- scoring use case;
- message generation;
- follow-up planning;
- status updates.

### Infrastructure tests

Test:

- EF Core mappings;
- repository behavior;
- SQLite persistence if needed.

### Web tests

Initial web tests are optional. The first project quality signal should come from domain/application tests and CI.

## Error handling

MVP error handling should be explicit and simple:

- application services return clear result objects;
- validation errors are displayed in the UI;
- unexpected exceptions are logged;
- no stack traces are shown in user-facing pages.

## Configuration

Local configuration should be stored outside source control.

Examples:

- local database path;
- user display name;
- default signature;
- future IMAP settings;
- future local AI endpoint.

## Logging

Use built-in .NET logging.

Log:

- application startup;
- persistence errors;
- scoring failures;
- message generation errors;
- import failures when future imports exist.

Do not log:

- secrets;
- full private messages if avoidable;
- credentials;
- private CV contents.

## Future AI integration

AI is not required for the MVP.

Possible future direction:

- local LLM through Ollama;
- deterministic fallback templates;
- user approval before storing generated text;
- prompt templates versioned in source control;
- no private data sent to third-party services by default.

## Performance expectations

The MVP is single-user and local.

Performance goals:

- fast dashboard loading;
- instant filtering on normal data volumes;
- no long-running operations blocking the UI;
- simple database queries.

## Maintainability expectations

- Small focused classes.
- No business logic hidden in Blazor components.
- No direct EF Core usage in UI pages.
- Explicit names.
- Tests for rules.
- Documentation updated when architectural decisions change.
