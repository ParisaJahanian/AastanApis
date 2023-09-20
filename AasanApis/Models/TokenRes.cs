﻿using AastanApis.ErrorHandling;
using System.Text.Json.Serialization;

namespace AasanApis.Models
{
    public class TokenRes :ErrorResult
    {
        [JsonPropertyName("access_token")]
        public string AccessToken{ get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("token_typ")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public string ExpireTimesInSeond { get; set; }
    }
}
