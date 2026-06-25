using MissionPilot.Domain.Common;

namespace MissionPilot.Domain.Opportunities;

public sealed class Opportunity
{
    public const int TitleMaxLength = 160;
    public const int SourceMaxLength = 80;
    public const int DescriptionMaxLength = 10_000;

    private Opportunity(
        Guid id,
        string title,
        string source,
        string description,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        Title = title;
        Source = source;
        Description = description;
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = createdAtUtc;
        Status = OpportunityStatus.ToAnalyze;
        RemotePolicy = RemotePolicy.Unknown;
    }

    public Guid Id { get; }
    public string Title { get; private set; }
    public string Source { get; private set; }
    public string Description { get; private set; }
    public OpportunityStatus Status { get; private set; }
    public RemotePolicy RemotePolicy { get; private set; }
    public DateOnly? FollowUpDate { get; private set; }
    public DateTimeOffset CreatedAtUtc { get; }
    public DateTimeOffset UpdatedAtUtc { get; private set; }

    public static Opportunity Create(
        string title,
        string source,
        string description,
        DateTimeOffset createdAtUtc)
    {
        string normalizedTitle = NormalizeRequired(title, nameof(title), TitleMaxLength);
        string normalizedSource = NormalizeRequired(source, nameof(source), SourceMaxLength);
        string normalizedDescription = NormalizeRequired(description, nameof(description), DescriptionMaxLength);

        return new(
            Guid.NewGuid(),
            normalizedTitle,
            normalizedSource,
            normalizedDescription,
            createdAtUtc
        );
    }

    public void UpdateCoreInformation(
        string title,
        string source,
        string description,
        DateTimeOffset updatedAtUtc)
    {
        Title = NormalizeRequired(title, nameof(title), TitleMaxLength);
        Source = NormalizeRequired(source, nameof(source), SourceMaxLength);
        Description = NormalizeRequired(description, nameof(description), DescriptionMaxLength);
        UpdatedAtUtc = updatedAtUtc;
    }

    public void ChangeStatus(OpportunityStatus status, DateTimeOffset updatedAtUtc)
    {
        Status = status;
        UpdatedAtUtc = updatedAtUtc;
    }

    public void ChangeRemotePolicy(RemotePolicy remotePolicy, DateTimeOffset updatedAtUtc)
    {
        RemotePolicy = remotePolicy;
        UpdatedAtUtc = updatedAtUtc;
    }

    public void ScheduleFollowUp(DateOnly followUpDate, DateOnly currentDate, DateTimeOffset updatedAtUtc)
    {
        if (followUpDate < currentDate)
            throw new DomainValidationException("Follow-up date cannot be in the past.");

        FollowUpDate = followUpDate;
        UpdatedAtUtc = updatedAtUtc;
    }

    public void ClearFollowUp(DateTimeOffset updatedAtUtc)
    {
        FollowUpDate = null;
        UpdatedAtUtc = updatedAtUtc;
    }

    private static string NormalizeRequired(string value, string fieldName, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainValidationException($"{fieldName} is required.");

        string normalized = value.Trim();

        if (normalized.Length > maxLength)
            throw new DomainValidationException($"{fieldName} cannot exceed {maxLength} characters.");

        return normalized;
    }
}
