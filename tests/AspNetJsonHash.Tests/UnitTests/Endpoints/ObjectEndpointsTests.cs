using AspNetJsonHash.Api.Endpoints;
using AspNetJsonHash.Api.JsonHashes;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;

namespace AspNetJsonHash.Tests.UnitTests.Endpoints;

public class ObjectEndpointsTests
{
    [Fact]
    public async Task GivenObject_WhenCreateMyObject_ThenReturnCreatedResult()
    {
        var myObject = new { Name = "Leandro Yuri Joaquim Rodrigues" };
        var jsonHash = Substitute.For<IJsonHash<dynamic>>();

        var endpointResult = await ObjectEndpoints.CreateMyObject(myObject, jsonHash);

        endpointResult.Should().BeOfType<Created<dynamic>>();
    }

    [Theory]
    [InlineData("6314107265BFA86D104F6C632F36364164DC39637891C6B1C324712D312B0334")]
    [InlineData("6314107265BFA86D104F6C632F36364164DC39637891C6B1C324712D312B0335")]
    [InlineData("6314107265BFA86D104F6C632F36364164DC39637891C6B1C324712D312B0336")]
    public async Task GivenObject_WhenCreateMyObject_ThenReturnItsRoute(string expectedHash)
    {
        var myObject = new { Name = "Leandro Yuri Joaquim Rodrigues" };
        var jsonHash = Substitute.For<IJsonHash<dynamic>>();

        jsonHash.ComputeAsync(myObject).Returns(expectedHash);

        var endpointResult = await ObjectEndpoints.CreateMyObject(myObject, jsonHash);

        endpointResult.Location.Should().Be($"/objects/{expectedHash}");
    }
}
