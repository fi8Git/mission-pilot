# 00 — Project Brief

## Project name

MissionPilot

## One-liner

A local-first .NET / Blazor application that helps freelance developers manage mission opportunities, score job fit, prepare tailored application messages, and track follow-ups without scraping or automating third-party platforms.

## Context

The project starts from a real freelance need: finding a new mission efficiently while keeping a professional and ethical process.

The user is a freelance .NET / Blazor developer and wants an application that supports the mission search workflow:

- centralizing opportunities;
- evaluating fit quickly;
- preparing customized messages;
- tracking recruiter interactions;
- choosing the right CV version;
- planning follow-ups;
- keeping a clean history of the search process.

The project is public on GitHub and must also serve as a professional portfolio artifact.

## Product intent

MissionPilot should be useful as a personal productivity tool and credible as a public open-source .NET project.

The repository should demonstrate:

- clear product thinking;
- clean .NET architecture;
- Blazor skills;
- security awareness;
- CI/CD with GitHub Actions;
- GHAS-oriented configuration;
- quality documentation;
- responsible automation.

## Core principles

1. Local-first.
2. Human-in-the-loop.
3. No scraping.
4. No automated outbound messaging.
5. No real personal data in the public repository.
6. Simple before complex.
7. Test business rules.
8. Public repository quality from day one.

## Problem statement

Freelance mission search is repetitive and difficult to track.

A developer often has to:

- inspect many opportunities;
- identify which ones are worth answering;
- adapt messages for each recruiter;
- remember which CV was sent;
- track follow-ups;
- avoid wasting time on poor-fit missions;
- keep a professional tone across platforms.

Without a structured workflow, opportunities are lost, follow-ups are forgotten, and the search process becomes reactive.

## Target users

### Primary user

A freelance developer looking for a mission and wanting a structured local workflow.

### Secondary users

- freelance consultants;
- technical contractors;
- developers transitioning to freelance;
- candidates who want to manage opportunities without a cloud CRM.

## Initial target persona

A senior .NET / Blazor freelance developer looking for technical, senior, or referent technical missions.

## MVP outcome

The MVP should allow the user to:

1. create a mission opportunity manually;
2. describe the mission context and stack;
3. score the opportunity;
4. recommend the right CV profile;
5. generate a draft message;
6. track the application status;
7. plan follow-ups;
8. view a dashboard of current opportunities.

## Success criteria

The MVP is successful if:

- it can be used daily during a real mission search;
- it reduces manual message rewriting;
- it helps prioritize high-fit opportunities;
- it prevents missed follow-ups;
- the repository looks credible to a recruiter;
- the code remains understandable and maintainable.

## Constraints

- Public repository.
- No real personal data committed.
- No scraping.
- No automated LinkedIn activity.
- Local data storage by default.
- No mandatory cloud dependency.
- Keep the first version small.

## Initial technology choices

- .NET 10
- Blazor Web App
- EF Core
- SQLite
- xUnit
- GitHub Actions
- CodeQL
- Dependabot
- Dependency Review
- Secret scanning / push protection where available

## Out of scope for MVP

- automatic LinkedIn integration;
- scraping job boards;
- automated email sending;
- cloud synchronization;
- multi-user authentication;
- billing/subscription features;
- complex AI agent workflows;
- mobile application;
- browser extension.

## Future possibilities

- local AI with Ollama;
- IMAP email import;
- CSV import/export;
- calendar reminders;
- analytics dashboard;
- reusable message template library;
- anonymized demo mode for portfolio presentation.
