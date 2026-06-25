# 10 — Repository Setup Checklist

## Initial repository

- [ ] Create public GitHub repository `mission-pilot`.
- [ ] Add README.md.
- [ ] Add SECURITY.md.
- [ ] Add CONTRIBUTING.md.
- [ ] Add CODE_OF_CONDUCT.md.
- [ ] Add documentation folder.
- [ ] Add `.gitignore`.
- [ ] Add `.editorconfig`.
- [ ] Choose license.

## GitHub settings

- [ ] Default branch is `main`.
- [ ] Disable direct pushes to `main`.
- [ ] Require pull requests before merge.
- [ ] Require status checks before merge.
- [ ] Enable squash merge.
- [ ] Delete branches after merge.

## GitHub security

- [ ] Enable dependency graph.
- [ ] Enable Dependabot alerts.
- [ ] Enable Dependabot security updates.
- [ ] Enable secret scanning if available.
- [ ] Enable push protection if available.
- [ ] Configure CodeQL.
- [ ] Configure Dependency Review.

## Local development

- [ ] Install .NET 10 SDK.
- [ ] Create solution.
- [ ] Add Domain/Application/Infrastructure/Web projects.
- [ ] Add test projects.
- [ ] Configure project references.
- [ ] Run `dotnet build`.
- [ ] Run `dotnet test`.

## Public demo safety

- [ ] Add only fictional demo data.
- [ ] Review screenshots before commit.
- [ ] Do not commit database files.
- [ ] Do not commit real CV files.
- [ ] Do not commit private notes.

## Portfolio readiness

- [ ] README explains the problem clearly.
- [ ] Architecture is documented.
- [ ] CI badge added once workflow exists.
- [ ] Security posture documented.
- [ ] Screenshots added after demo UI exists.
- [ ] Roadmap kept up to date.
