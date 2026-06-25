# 04 — Security and Repository Governance

## Security posture

MissionPilot is a public repository and must be treated as a professional project from the beginning.

The main security risks are:

- committing secrets;
- committing real recruiter or candidate data;
- committing real CV files;
- adding unsafe automation;
- creating workflows with excessive permissions;
- using vulnerable dependencies;
- leaking personal information through screenshots or demo data.

## Repository rules

### Main branch

The `main` branch should be protected.

Expected rules:

- no direct pushes to `main`;
- pull requests required;
- CI required before merge;
- CodeQL required once configured;
- dependency review required once configured;
- branches should be up to date before merge;
- delete branches after merge.

### Merge strategy

Recommended:

- squash merge for clean history;
- descriptive PR titles;
- small PRs.

### Pull request requirements

A PR should include:

- summary;
- test evidence;
- screenshots for UI changes;
- documentation impact;
- security impact if relevant.

## GitHub security features

Enable repository security features when available:

- Dependency graph;
- Dependabot alerts;
- Dependabot security updates;
- Secret scanning;
- Push protection;
- Code scanning with CodeQL;
- Dependency review on pull requests.

## Secret management

Never commit:

- GitHub tokens;
- API keys;
- email passwords;
- IMAP credentials;
- OAuth secrets;
- private certificates;
- database files containing real data;
- real CV files.

Future local secrets should use:

- environment variables;
- user secrets for development;
- local ignored configuration files.

## Git ignore rules

The repository should ignore:

```text
*.db
*.db-shm
*.db-wal
*.sqlite
*.sqlite3
appsettings.Local.json
appsettings.Development.local.json
.local/
private/
exports/
real-data/
*.pdf
*.docx
```

The PDF/DOCX rule may be relaxed later if the project needs sample documents, but sample documents must be fictional.

## Demo data policy

Demo data must be fictional.

Allowed:

- fake recruiter names;
- fake companies;
- fake job descriptions;
- fake messages;
- fake CV profile labels.

Forbidden:

- real recruiter emails;
- real recruiter names from current search;
- real mission links;
- real personal contact history;
- real salary or negotiation history unless anonymized;
- screenshots from real platforms containing personal data.

## Workflow permissions

GitHub Actions workflows should use least privilege.

Default top-level permissions should be restricted:

```yaml
permissions:
  contents: read
```

Specific jobs may request additional permissions only when needed.

## Dependency governance

Dependencies should be:

- necessary;
- actively maintained;
- compatible with the project license;
- reviewed before adding;
- updated through Dependabot where practical.

Avoid adding large frameworks before the MVP requires them.

## Responsible automation

MissionPilot must not implement:

- LinkedIn scraping;
- automated LinkedIn messaging;
- automated LinkedIn invitations;
- automatic mass applications;
- email spam;
- hidden data collection.

Allowed automation:

- scoring;
- draft generation;
- reminders;
- local email alert import if explicitly configured;
- user-approved exports.

## Privacy-by-design rules

- Store data locally by default.
- Do not collect telemetry in the MVP.
- Do not send opportunity descriptions to external AI services by default.
- Make demo mode safe for screenshots.
- Keep private runtime data out of the repository.

## Security checklist for releases

Before any public release:

- CI green;
- tests passing;
- CodeQL configured;
- Dependabot configured;
- no secrets in git history;
- demo data reviewed;
- screenshots reviewed;
- README security section up to date;
- `SECURITY.md` present;
- branch protection enabled.

## Incident response

If a secret is committed:

1. revoke the secret immediately;
2. remove it from the repository;
3. rotate credentials;
4. inspect logs for usage;
5. document the incident privately if needed.

If real personal data is committed:

1. remove it immediately;
2. assess exposure;
3. replace with fictional data;
4. review git history handling;
5. strengthen `.gitignore` and contribution rules.
