namespace MissionPilot.Domain.Opportunities;

public enum OpportunityStatus
{
    Draft = 0,
    ToAnalyze = 1,
    ToApply = 2,
    MessagePrepared = 3,
    CvSent = 4,
    FollowUpJ3 = 5,
    FollowUpJ7 = 6,
    CallScheduled = 7,
    InProcess = 8,
    Rejected = 9,
    StandBy = 10,
    Signed = 11,
    Archived = 12
}
