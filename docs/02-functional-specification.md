# 02 — Functional Specification

## Scope

This document describes the expected behavior of MissionPilot for the first usable local-first version.

## User roles

### Local user

The local user is the owner of the application and the only user in the MVP.

No authentication is required in the first version.

## Main concepts

### Opportunity

A potential freelance mission.

Fields:

- id;
- title;
- company or client name;
- intermediary or ESN name;
- recruiter name;
- source;
- source URL;
- description;
- stack;
- sector;
- location;
- remote policy;
- start date;
- duration;
- TJM;
- experience requirement;
- status;
- score;
- priority;
- recommended CV profile;
- generated message;
- notes;
- created date;
- updated date;
- follow-up date.

### Recruiter

A recruiter, business manager, account manager, or contact person.

Fields:

- id;
- first name;
- last name;
- company;
- role;
- email;
- LinkedIn URL;
- phone;
- notes;
- created date;
- updated date.

### Company

The company associated with an opportunity or recruiter.

Fields:

- id;
- name;
- type;
- website;
- notes.

Company types:

- ESN;
- client final;
- recruitment agency;
- platform;
- unknown.

### CV profile

A logical CV version, not necessarily a stored file.

Initial values:

- ESN;
- ClientFinalPremium;
- BackendDotNet;
- GenericDotNetBlazor.

Fields:

- id;
- name;
- description;
- recommended use case.

### Application message

A generated or manually written draft message.

Fields:

- id;
- opportunity id;
- message type;
- content;
- created date;
- updated date.

Message types:

- first contact;
- answer recruiter asking for CV;
- application message;
- follow-up J+3;
- follow-up J+7;
- decline politely;
- request for mission details.

## Opportunity statuses

Initial statuses:

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

## Dashboard

The dashboard should show:

- total active opportunities;
- opportunities to analyze;
- opportunities to apply to;
- follow-ups due today;
- calls scheduled;
- high-priority opportunities;
- recent activity.

## Opportunity creation

The user can create an opportunity manually.

Required fields for MVP:

- title;
- source;
- description;
- status.

Optional fields:

- recruiter;
- company;
- stack;
- location;
- remote;
- TJM;
- duration;
- start date;
- notes.

## Opportunity list

The user can list opportunities.

The list should display:

- title;
- company or intermediary;
- source;
- status;
- score;
- priority;
- remote;
- TJM;
- next follow-up date.

Useful filters:

- status;
- source;
- score;
- priority;
- remote policy;
- CV profile.

## Opportunity detail

The detail view should allow:

- viewing all fields;
- editing information;
- scoring;
- selecting CV profile;
- generating a message;
- planning follow-up;
- changing status;
- adding notes.

## Scoring

The scoring engine evaluates opportunity fit based on transparent rules.

Initial positive rules:

- +3 if .NET or C# is present;
- +3 if Blazor is present;
- +2 if refonte, modernization, architecture, or maintainability is present;
- +2 if remote or hybrid is compatible;
- +1 if SQL Server or API REST is present;
- +1 if code review, mentoring, documentation, or technical leadership is present.

Initial negative rules:

- -2 if Azure expert is mandatory;
- -3 if Kafka or Cassandra is mandatory;
- -3 if finance de marché is indispensable;
- -3 if advanced multithreading is mandatory;
- -4 if 10+ years is strict;
- -4 if no remote and location is incompatible.

Score interpretation:

- 8 or more: high priority;
- 6 to 7: interesting;
- 4 to 5: low priority;
- 0 to 3: ignore or archive.

The scoring result should explain why the score was assigned.

## CV recommendation

The system recommends a CV profile based on opportunity characteristics.

Rules:

- ESN if the source is an ESN, platform, or technical staffing channel.
- ClientFinalPremium if the contact is direct with a final client or CTO-like role.
- BackendDotNet if the mission focuses on C# backend, API, SQL Server, and no Blazor.
- GenericDotNetBlazor if the opportunity is broad .NET / Blazor.

## Message generation

The system uses deterministic templates in the MVP.

Template inputs:

- recruiter first name;
- opportunity title;
- stack;
- matching strengths;
- availability;
- recommended CV profile;
- remote preference;
- user signature.

Initial templates:

- .NET / Blazor application;
- technical referent / lead application;
- C# backend application;
- response to recruiter asking for CV;
- follow-up J+3;
- follow-up J+7;
- polite decline.

## Follow-up management

The user can plan follow-ups.

Default rules:

- after CV sent: suggest follow-up at J+3;
- after J+3 follow-up: suggest follow-up at J+7;
- after J+7 with no answer: suggest archive or stand-by.

The application should show overdue follow-ups clearly.

## Settings

Initial settings:

- user display name;
- default signature;
- default availability text;
- target TJM;
- minimum acceptable TJM;
- preferred locations;
- preferred remote policy;
- CV profile descriptions.

## Demo mode

The application should include fictional demo data.

Demo data must not include real recruiter names, real companies related to current applications, real messages, or personal private information.

## Acceptance criteria for MVP

- A user can create and edit an opportunity.
- A user can score an opportunity.
- A user can see why the score was assigned.
- A user can see the recommended CV profile.
- A user can generate a message.
- A user can change opportunity status.
- A user can plan and view follow-ups.
- Core rules are covered by tests.
- The app can run locally without external services.
