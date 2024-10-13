using AspNetJsonHash.Api.JsonHashes;
using FluentAssertions;

namespace AspNetJsonHash.Tests.JsonHashes;

public class SHA256JsonTests
{
    [Fact]
    public async Task GivenObject_WhenComputeHash_ThenReturnItsHashAsSHA256()
    {
        var myObject = new
        {
            Name = "Leandro Yuri Joaquim Rodrigues",
            Age = 41,
            Address = "Rua Furnas",
            Document = "69062468870"
        };
        var expectedHash = "6314107265BFA86D104F6C632F36364164DC39637891C6B1C324712D312B0331";
        var jsonHash = new SHA256Json<dynamic>();

        var hash = await jsonHash.ComputeAsync(myObject);

        hash.Should().Be(expectedHash);
    }
}
