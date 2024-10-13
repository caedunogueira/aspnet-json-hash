using AspNetJsonHash.Api.JsonHashes;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AspNetJsonHash.Api.Endpoints;

internal static class ObjectEndpoints
{
    internal static async Task<Created<dynamic>> CreateMyObject(dynamic myObject, IJsonHash<dynamic> jsonHash)
    {
        var objectHash = await jsonHash.ComputeAsync(myObject);

        return TypedResults.Created($"/objects/{objectHash}", myObject);
    }
}
