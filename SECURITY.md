# Security Policy

## Supported versions

MissionPilot is currently in early development. Security fixes apply to the `main` branch until the first tagged release.

## Reporting a vulnerability

If you discover a vulnerability, please do not open a public issue containing sensitive details.

For now, report security concerns privately to the repository owner.

## Security principles

MissionPilot is designed as a local-first assistant for freelance mission search. The project must follow these rules:

- no scraping of third-party platforms;
- no automated sending of messages;
- no credentials committed to the repository;
- no real recruiter data committed to the repository;
- no real CV files committed to the repository;
- no personal application history committed to the repository;
- demo data must be fictional and anonymized;
- local files containing private data must be gitignored.

## Secret handling

Secrets must never be stored in source code, documentation examples, tests, screenshots, or committed configuration files.

If future integrations require credentials, they must use local user secrets, environment variables, or a secure local configuration mechanism excluded from Git.

## Public demo data

All demo data must be fictional:

- fake recruiters;
- fake companies;
- fake opportunities;
- fake emails;
- fake messages;
- fake CV profile names.

## Responsible disclosure status

This project is not yet production software. The security model will evolve with the implementation.
