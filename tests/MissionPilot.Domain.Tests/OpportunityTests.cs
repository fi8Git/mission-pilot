using MissionPilot.Domain.Common;
using MissionPilot.Domain.Opportunities;

namespace MissionPilot.Domain.Tests;

public sealed class OpportunityTests
{
    [Fact]
    public void Create_Should_Initialize_Opportunity_With_Default_State()
    {
        DateTimeOffset now = new(2026, 6, 25, 10, 0, 0, TimeSpan.Zero);

        var opportunity = Opportunity.Create(
            "Développeur Senior .NET/Blazor",
            "LeHibou",
            "Mission de refonte applicative en Blazor.",
            now
        );

        Assert.NotEqual(Guid.Empty, opportunity.Id);
        Assert.Equal("Développeur Senior .NET/Blazor", opportunity.Title);
        Assert.Equal("LeHibou", opportunity.Source);
        Assert.Equal("Mission de refonte applicative en Blazor.", opportunity.Description);
        Assert.Equal(OpportunityStatus.ToAnalyze, opportunity.Status);
        Assert.Equal(RemotePolicy.Unknown, opportunity.RemotePolicy);
        Assert.Null(opportunity.FollowUpDate);
        Assert.Equal(now, opportunity.CreatedAtUtc);
        Assert.Equal(now, opportunity.UpdatedAtUtc);
    }

    [Fact]
    public void Create_Should_Trim_Text_Fields()
    {
        var opportunity = Opportunity.Create(
           "  Mission .NET  ",
           "  LinkedIn  ",
           "  Description  ",
           DateTimeOffset.UtcNow);

        Assert.Equal("Mission .NET", opportunity.Title);
        Assert.Equal("LinkedIn", opportunity.Source);
        Assert.Equal("Description", opportunity.Description);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_Should_Reject_Missing_Title(string title)
    {
        var exception = Assert.Throws<DomainValidationException>(() =>
            Opportunity.Create(
                title,
                "Free-Work",
                "Description",
                DateTimeOffset.UtcNow
            )
        );

        Assert.Equal("title is required.", exception.Message);
    }

    [Fact]
    public void UpdateCoreInformation_Should_Update_Text_Fields_And_Updated_Date()
    {
        DateTimeOffset createdAt = new(2026, 6, 25, 10, 0, 0, TimeSpan.Zero);
        DateTimeOffset updatedAt = createdAt.AddHours(1);

        var opportunity = Opportunity.Create(
            "Initial title",
            "Initial source",
            "Initial description",
            createdAt);

        opportunity.UpdateCoreInformation(
            "Updated title",
            "Updated source",
            "Updated description",
            updatedAt);

        Assert.Equal("Updated title", opportunity.Title);
        Assert.Equal("Updated source", opportunity.Source);
        Assert.Equal("Updated description", opportunity.Description);
        Assert.Equal(updatedAt, opportunity.UpdatedAtUtc);
    }

    [Fact]
    public void ChangeStatus_Should_Update_Status_And_Updated_Date()
    {
        DateTimeOffset createdAt = new(2026, 6, 25, 10, 0, 0, TimeSpan.Zero);
        DateTimeOffset updatedAt = createdAt.AddMinutes(30);

        var opportunity = Opportunity.Create(
            "Mission .NET",
            "Malt",
            "Description",
            createdAt);

        opportunity.ChangeStatus(OpportunityStatus.CvSent, updatedAt);

        Assert.Equal(OpportunityStatus.CvSent, opportunity.Status);
        Assert.Equal(updatedAt, opportunity.UpdatedAtUtc);
    }

    [Fact]
    public void ChangeRemotePolicy_Should_Update_RemotePolicy_And_Updated_Date()
    {
        DateTimeOffset createdAt = new(2026, 6, 25, 10, 0, 0, TimeSpan.Zero);
        DateTimeOffset updatedAt = createdAt.AddMinutes(30);

        var opportunity = Opportunity.Create(
            "Mission .NET",
            "Malt",
            "Description",
            createdAt);

        opportunity.ChangeRemotePolicy(RemotePolicy.Hybrid, updatedAt);

        Assert.Equal(RemotePolicy.Hybrid, opportunity.RemotePolicy);
        Assert.Equal(updatedAt, opportunity.UpdatedAtUtc);
    }

    [Fact]
    public void ScheduleFollowUp_Should_Set_FollowUpDate_And_Update_Date()
    {
        DateTimeOffset createdAt = new(2026, 6, 25, 10, 0, 0, TimeSpan.Zero);
        DateTimeOffset updatedAt = createdAt.AddMinutes(30);
        DateOnly currentDate = new(2026, 6, 25);
        DateOnly followUpDate = new(2026, 6, 28);

        var opportunity = Opportunity.Create(
            "Mission .NET",
            "LinkedIn",
            "Description",
            createdAt);

        opportunity.ScheduleFollowUp(followUpDate, currentDate, updatedAt);

        Assert.Equal(followUpDate, opportunity.FollowUpDate);
        Assert.Equal(updatedAt, opportunity.UpdatedAtUtc);
    }

    [Fact]
    public void ScheduleFollowUp_Should_Reject_Past_Date()
    {
        var opportunity = Opportunity.Create(
            "Mission .NET",
            "LinkedIn",
            "Description",
            DateTimeOffset.UtcNow);

        DateOnly currentDate = new(2026, 6, 25);
        DateOnly pastDate = new(2026, 6, 24);

        var exception = Assert.Throws<DomainValidationException>(() =>
            opportunity.ScheduleFollowUp(
                pastDate,
                currentDate,
                DateTimeOffset.UtcNow));

        Assert.Equal("Follow-up date cannot be in the past.", exception.Message);
    }

    [Fact]
    public void ClearFollowUp_Should_Remove_FollowUpDate_And_Update_Date()
    {
        DateTimeOffset createdAt = new(2026, 6, 25, 10, 0, 0, TimeSpan.Zero);
        DateTimeOffset scheduledAt = createdAt.AddMinutes(10);
        DateTimeOffset clearedAt = createdAt.AddMinutes(20);

        var opportunity = Opportunity.Create(
            "Mission .NET",
            "LinkedIn",
            "Description",
            createdAt);

        opportunity.ScheduleFollowUp(
            new DateOnly(2026, 6, 28),
            new DateOnly(2026, 6, 25),
            scheduledAt);

        opportunity.ClearFollowUp(clearedAt);

        Assert.Null(opportunity.FollowUpDate);
        Assert.Equal(clearedAt, opportunity.UpdatedAtUtc);
    }
}
