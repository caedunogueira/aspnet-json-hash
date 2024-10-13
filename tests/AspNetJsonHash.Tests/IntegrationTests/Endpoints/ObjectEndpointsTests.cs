using AspNetJsonHash.Tests.IntegrationTests.Helpers;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace AspNetJsonHash.Tests.IntegrationTests.Endpoints;

[Collection("Sequential")]
public class ObjectEndpointsTests : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;
    private readonly TestWebApplicationFactory<Program> _factory;

    public ObjectEndpointsTests(TestWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _httpClient = _factory.CreateClient();
    }

    [Fact]
    public async Task PostNewObject()
    {
        var myObject = new
        {
            Name = "Leandro Yuri Joaquim Rodrigues",
            Age = 41,
            Address = "Rua Furnas",
            Document = "69062468870"
        };

        //_httpClient.DefaultRequestHeaders.Clear();
        //_httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        var response = await _httpClient.PostAsJsonAsync("/objects", myObject);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}