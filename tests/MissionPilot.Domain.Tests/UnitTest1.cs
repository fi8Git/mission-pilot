namespace MissionPilot.Domain.Tests;

public sealed class MissionPilotProductTests
{
    [Fact]
    public void Name_Should_Be_MissionPilot()
    {
        Assert.Equal("MissionPilot", MissionPilotProduct.Name);
    }
}
