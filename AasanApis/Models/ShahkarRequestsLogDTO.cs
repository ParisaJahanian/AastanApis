﻿namespace AasanApis.Models
{
    public sealed class ShahkarRequestsLogDTO
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Scope { get; set; }
        public string TokenType { get; set; }
        public string ExpireTimeInSecond { get; set; }
        public string RequestId { get; set; }
        public string SafeServiceId { get; set; }
    }
}