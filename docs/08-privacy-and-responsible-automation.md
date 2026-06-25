# 08 — Privacy and Responsible Automation

## Principle

MissionPilot assists the user. It does not replace the user and does not automate interactions in a way that violates third-party platform rules or professional trust.

## Responsible automation boundary

Allowed:

- opportunity scoring;
- CV recommendation;
- draft message generation;
- follow-up reminders;
- local dashboard;
- manual copy-to-clipboard;
- local import from user-authorized sources in future versions;
- fictional demo data.

Not allowed:

- scraping LinkedIn or job boards;
- automated LinkedIn invitations;
- automated LinkedIn messaging;
- automated mass applications;
- hidden email harvesting;
- bypassing platform limitations;
- storing real data in public demo files.

## Human-in-the-loop rule

Every outbound action must be human-approved.

The application may prepare a message, but the user must manually decide:

- whether to send;
- where to send;
- whether to attach a CV;
- whether to follow up;
- whether to decline.

## Data categories

### Public demo data

Safe for repository and screenshots.

Must be fictional.

### Local private data

May include:

- real opportunities;
- recruiter names;
- recruiter contact details;
- messages;
- notes;
- CV profile usage;
- follow-up history.

Must stay local and must not be committed.

### Secrets

May include future credentials for local integrations.

Must never be committed.

## Local storage

MVP data is stored locally.

The user is responsible for:

- backing up local data;
- deleting private data when needed;
- not committing database files.

## Future email import

If email import is added:

- user must explicitly configure it;
- credentials must be stored securely and locally;
- only relevant alert labels/folders should be read;
- imported content should be reviewed before storing;
- no automatic replies should be sent.

## Future AI integration

If local AI is added:

- local-first AI should be preferred;
- deterministic templates must remain available;
- user must approve generated messages;
- prompts should avoid including unnecessary personal data;
- external AI services should be opt-in only, if ever added.

## Screenshot policy

Screenshots in README or docs must use demo mode only.

Before committing screenshots, verify:

- no real recruiter names;
- no real emails;
- no real mission URLs;
- no real CV file names;
- no real phone number;
- no real notes.

## Ethical communication

MissionPilot should improve the quality of communication with recruiters.

Good messages should be:

- honest;
- targeted;
- concise;
- transparent about fit;
- respectful of recruiter time.

MissionPilot should not encourage deceptive claims, fake experience, or spam.
