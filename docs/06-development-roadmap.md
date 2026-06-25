# 06 — Development Roadmap

## Roadmap principles

MissionPilot should be built through small vertical slices.

Each sprint should produce something visible, testable, and reviewable.

The project is developed through pair programming, not through an autonomous coding agent.

## Sprint 0 — Repository and documentation

### Goal

Create a professional public repository foundation.

### Deliverables

- README.md
- SECURITY.md
- CONTRIBUTING.md
- CODE_OF_CONDUCT.md
- docs folder
- project brief
- product vision
- functional specification
- technical architecture
- security and GHAS documentation
- roadmap
- pair programming workflow
- privacy and responsible automation document

### Acceptance criteria

- The project purpose is understandable in less than one minute.
- The responsible automation boundary is explicit.
- The repository looks professional before implementation starts.
- No real private data is present.

## Sprint 1 — .NET solution skeleton

### Goal

Create the technical skeleton.

### Deliverables

- .NET solution
- Domain project
- Application project
- Infrastructure project
- Blazor Web project
- test projects
- `.editorconfig`
- initial CI workflow
- simple home page
- first smoke tests

### Acceptance criteria

- `dotnet restore` passes.
- `dotnet build` passes.
- `dotnet test` passes.
- CI passes on GitHub.
- Project references respect dependency direction.

## Sprint 2 — Opportunity domain model

### Goal

Implement the core opportunity model.

### Deliverables

- Opportunity entity
- OpportunityStatus enum
- Recruiter entity
- Company entity
- CvProfile entity or enum
- FollowUpReminder concept
- domain tests

### Acceptance criteria

- Opportunity can be created with required fields.
- Status is validated.
- Follow-up date can be assigned.
- Domain tests cover core behavior.

## Sprint 3 — Persistence with SQLite

### Goal

Persist opportunities locally.

### Deliverables

- EF Core DbContext
- SQLite configuration
- migrations
- repository or persistence service
- infrastructure tests
- local database ignored by git

### Acceptance criteria

- Opportunity can be saved and loaded.
- Local database files are ignored.
- Migration is committed.
- Tests validate basic persistence.

## Sprint 4 — Blazor opportunity CRUD

### Goal

Create the first usable UI.

### Deliverables

- opportunity list page
- create opportunity page
- opportunity detail page
- edit opportunity flow
- status update
- basic validation
- navigation

### Acceptance criteria

- User can add an opportunity manually.
- User can list opportunities.
- User can edit an opportunity.
- User can update status.
- UI is clean enough for screenshots.

## Sprint 5 — Scoring engine

### Goal

Add transparent opportunity scoring.

### Deliverables

- scoring rules
- positive and negative signals
- score result
- priority mapping
- UI display of score and explanations
- tests

### Acceptance criteria

- User can score an opportunity.
- Score result explains reasoning.
- Priority is clearly displayed.
- Tests cover key rules.

## Sprint 6 — CV recommendation

### Goal

Suggest the best CV profile.

### Deliverables

- CV profile model
- recommendation rules
- UI display
- settings for CV profile descriptions
- tests

### Acceptance criteria

- ESN opportunities recommend ESN CV.
- Direct client opportunities recommend premium client CV.
- Backend-focused opportunities recommend backend CV.
- Recommendation is explainable.

## Sprint 7 — Message templates

### Goal

Generate reusable draft messages.

### Deliverables

- message template model
- deterministic template renderer
- templates for main scenarios
- copy-to-clipboard support
- application message persistence
- tests

### Acceptance criteria

- User can generate a draft message.
- User can edit before copying.
- User can copy message to clipboard.
- No message is sent automatically.

## Sprint 8 — Follow-up board

### Goal

Make follow-ups visible.

### Deliverables

- follow-up date calculation
- dashboard section for due follow-ups
- mark follow-up done
- schedule next follow-up
- status integration

### Acceptance criteria

- J+3 and J+7 follow-ups can be planned.
- Overdue follow-ups are visible.
- User can mark a follow-up as completed.

## Sprint 9 — Recruiter CRM

### Goal

Track recruiter relationships.

### Deliverables

- recruiter list
- recruiter detail
- link opportunities to recruiter
- notes
- contact history summary

### Acceptance criteria

- A recruiter can be created.
- Opportunities can be linked to recruiter.
- Recruiter history is visible.

## Sprint 10 — Portfolio polish

### Goal

Make the repository recruiter-ready.

### Deliverables

- polished README
- screenshots with fictional data
- architecture diagram
- CI badges
- CodeQL badge if available
- roadmap status
- demo seed data

### Acceptance criteria

- README clearly explains value and architecture.
- Screenshots contain no real data.
- CI and security setup are visible.
- A recruiter can understand the project quickly.

## Future sprint candidates

- local AI integration;
- IMAP email alert import;
- CSV export;
- analytics dashboard;
- calendar reminder export;
- dark mode;
- packaging as local desktop app;
- optional MAUI Blazor shell.
