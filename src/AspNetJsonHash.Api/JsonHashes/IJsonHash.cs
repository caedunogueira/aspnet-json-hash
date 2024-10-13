namespace AspNetJsonHash.Api.JsonHashes;

internal interface IJsonHash<T>
{
    Task<string> ComputeAsync(T customObject);
}
