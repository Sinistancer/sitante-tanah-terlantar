using System.Text.Json.Serialization;

namespace Blazor.Shared
{
    public class AccessTokenResponse
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
    }
}
