using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace AspNetJsonHash.Api.JsonHashes;

internal class SHA256Json<T> : IJsonHash<T>
{
    public async Task<string> ComputeAsync(T customObject)
    {
        var json = JsonSerializer.Serialize(customObject);
        using var objectStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        var hash = await SHA256.HashDataAsync(objectStream);
        var hashText = new StringBuilder();

        for (var i = 0; i < hash.Length; i++)
            hashText.Append($"{hash[i]:X2}");

        return hashText.ToString();
    }
}