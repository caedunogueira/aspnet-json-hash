using AspNetJsonHash.Api.JsonHashes;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AspNetJsonHash.Api.Endpoints;

internal static class ObjectEndpoints
{
    internal static RouteGroupBuilder MapMyObjectsApi(this RouteGroupBuilder builder)
    {
        builder.MapPost("/", CreateMyObject);

        return builder;
    }

    internal static async Task<Created<dynamic>> CreateMyObject(dynamic myObject, IJsonHash<dynamic> jsonHash)
    {
        var objectHash = await jsonHash.ComputeAsync(myObject);

        return TypedResults.Created<dynamic>($"/objects/{objectHash}", myObject);
    }
}
