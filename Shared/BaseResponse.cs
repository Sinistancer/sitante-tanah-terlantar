using System.Text.Json.Serialization;

namespace Blazor.Shared
{
    //NANTI GANTI LEWAT LIB.BASE
    public class BaseResponse
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }

        //[JsonProperty("message")]
        //[JsonPropertyName("message")]
        //public string Message { get; set; }

        [JsonPropertyName("data")]
        public AccessTokenResponse Data { get; set; }

    }
}
