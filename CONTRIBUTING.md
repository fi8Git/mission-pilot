# Contributing

MissionPilot is primarily developed as a personal open-source portfolio project, but contributions, feedback, and issue reports are welcome.

## Development workflow

- Create a branch from `main`.
- Keep changes focused and small.
- Add or update tests when changing domain or application logic.
- Update documentation when behavior, architecture, security rules, or decisions change.
- Open a pull request with a clear description.
- Ensure CI is green before merge.

## Commit style

Use short, descriptive commits.

Examples:

```text
Add opportunity domain model
Add opportunity scoring rules
Document repository security rules
Fix status transition validation
```

## Pull request expectations

A pull request should explain:

- what changed;
- why it changed;
- how it was tested;
- any relevant trade-offs;
- screenshots if the UI changed.

## Code quality

The project favors:

- readable code over clever code;
- explicit domain concepts;
- small services and handlers;
- simple persistence;
- tests around business rules;
- no premature abstraction.

## Data and privacy

Do not commit:

- real recruiter names;
- real emails;
- real job applications;
- real CV documents;
- screenshots containing personal data;
- API keys, tokens, credentials, or secrets.
