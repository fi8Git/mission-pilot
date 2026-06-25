# 05 — CI/CD and GHAS

## Goal

The repository should demonstrate professional engineering practices through automated checks and GitHub security features.

The first CI/CD goal is not deployment. The goal is confidence:

- restore;
- build;
- test;
- format check;
- dependency review;
- CodeQL analysis;
- Dependabot alerts and updates;
- secret scanning and push protection.

## Initial workflows

Expected workflows:

```text
.github/workflows/ci.yml
.github/workflows/codeql.yml
.github/workflows/dependency-review.yml
```

Expected configuration:

```text
.github/dependabot.yml
```

## CI workflow

The CI workflow should run on:

- pull requests targeting `main`;
- pushes to `main`.

Initial steps:

1. checkout;
2. setup .NET;
3. restore;
4. build;
5. test;
6. format check.

Example intent:

```yaml
name: CI

on:
  pull_request:
    branches: [ main ]
  push:
    branches: [ main ]

permissions:
  contents: read

jobs:
  build-test:
    runs-on: ubuntu-latest

    steps:
      - uses: actions/checkout@v4

      - uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '10.0.x'

      - name: Restore
        run: dotnet restore

      - name: Build
        run: dotnet build --configuration Release --no-restore

      - name: Test
        run: dotnet test --configuration Release --no-build --verbosity normal

      - name: Format check
        run: dotnet format --verify-no-changes --verbosity diagnostic
```

This workflow may need adjustment when the actual solution is created.

## CodeQL

CodeQL should be enabled for C# analysis.

Expected behavior:

- analyze code on pull requests;
- analyze code on pushes to main;
- report vulnerabilities and code-quality alerts in GitHub code scanning.

CodeQL should remain part of the branch protection checks once stable.

## Dependency Review

Dependency Review should run on pull requests.

Goal:

- detect vulnerable dependency changes before merge;
- make dependency risk visible during review.

## Dependabot

Dependabot should be configured for:

- NuGet packages;
- GitHub Actions.

Expected schedule:

- weekly updates;
- grouped updates if noise becomes too high.

Example intent:

```yaml
version: 2
updates:
  - package-ecosystem: "nuget"
    directory: "/"
    schedule:
      interval: "weekly"

  - package-ecosystem: "github-actions"
    directory: "/"
    schedule:
      interval: "weekly"
```

## GitHub Advanced Security related features

Enable where available:

- CodeQL code scanning;
- secret scanning;
- push protection;
- Dependabot alerts;
- Dependabot security updates;
- Dependency graph.

## Required checks

Once configured, branch protection should require:

- CI build/test;
- CodeQL analysis;
- Dependency Review.

## Formatting

Use:

- `.editorconfig`;
- `dotnet format --verify-no-changes` in CI.

This makes code style visible and professional.

## Test expectations

Every domain/application rule should have tests.

Minimum expected tests after MVP scoring:

- opportunity scoring;
- priority mapping;
- CV recommendation;
- message template rendering;
- follow-up date calculation;
- status transitions.

## Coverage

Coverage is optional at first.

Future enhancement:

- collect coverage;
- publish coverage summary;
- add coverage badge if useful.

## Release workflow

No release workflow is required for MVP.

Possible future release:

- tag version;
- build release artifacts;
- publish portable package;
- attach checksums.

## CI/CD principles

- Keep workflows simple.
- Avoid excessive permissions.
- Fail fast.
- Make errors readable.
- Do not run expensive or unnecessary steps.
- Do not store secrets unless absolutely required.
- Prefer public, well-known actions.

## Manual GitHub settings checklist

After creating the repository, configure:

- default branch: `main`;
- branch protection/ruleset for `main`;
- squash merge enabled;
- delete branches after merge;
- issues enabled;
- discussions optional;
- dependency graph enabled;
- Dependabot alerts enabled;
- Dependabot security updates enabled;
- secret scanning enabled where available;
- push protection enabled where available;
- CodeQL configured.
