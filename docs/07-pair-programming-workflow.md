# 07 — Pair Programming Workflow

## Purpose

This project is built through human pair programming.

The assistant helps with:

- technical design;
- review;
- documentation;
- implementation guidance;
- debugging;
- test strategy;
- refactoring suggestions.

The human developer writes, runs, validates, and commits the code.

## Working style

Use small iterations.

Each iteration should define:

- objective;
- scope;
- files to touch;
- acceptance criteria;
- manual validation steps;
- tests to add or update;
- risks;
- next step.

## Standard iteration format

### 1. Goal

What are we trying to achieve?

### 2. Scope

What is included?

### 3. Out of scope

What must not be touched?

### 4. Implementation plan

Step-by-step coding plan.

### 5. Tests

What must be tested?

### 6. Manual validation

What should be checked locally?

### 7. Review checklist

What should be inspected before commit?

### 8. Commit message

Suggested commit message.

## Preferred sprint size

A sprint should usually be small enough to complete and review in one focused session.

Avoid large changes that mix:

- domain model;
- persistence;
- UI;
- CI;
- documentation;
- security.

## Pair programming rhythm

Recommended rhythm:

1. define the next small slice;
2. write or update tests first when practical;
3. implement the minimal code;
4. run build and tests;
5. review the diff;
6. update docs if needed;
7. commit;
8. decide next slice.

## Review checklist

Before committing:

- Does the code compile?
- Do tests pass?
- Are names clear?
- Is business logic outside Blazor components?
- Is domain logic testable?
- Are dependencies in the right direction?
- Are private files ignored?
- Is documentation updated?
- Are there any secrets?
- Is the change small and focused?

## Definition of done

A change is done when:

- it solves the intended problem;
- tests are added or updated if business logic changed;
- CI would reasonably pass;
- no real private data is introduced;
- documentation is updated when needed;
- the code is understandable by a reviewer.

## Debugging workflow

When something fails, capture:

- command executed;
- full error message;
- relevant file path;
- expected behavior;
- actual behavior;
- recent changes.

Then debug from the smallest reproducible case.

## How to ask for help during implementation

Useful information to provide:

```text
Goal:
Current code:
Error:
Command:
What I expected:
What happened:
Files changed:
```

## Public repository mindset

Because the repository is visible to recruiters:

- avoid half-finished messy commits on main;
- prefer small PRs;
- keep README accurate;
- keep demo data professional;
- keep security settings visible;
- explain trade-offs in docs.
