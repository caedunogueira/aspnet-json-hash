using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace AspNetJsonHash.Api.JsonHashes;

internal class SHA256Json<T>
{
    internal string Compute(T customObject)
    {
        var json = JsonSerializer.Serialize(customObject);
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(json));
        var hashText = new StringBuilder();

        for (var i = 0; i < hash.Length; i++)
            hashText.Append($"{hash[i]:X2}");

        return hashText.ToString();
    }
}
