﻿

namespace AasanApis.Models
{
    public class TokenResDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Scope { get; set; }
        public string TokenType { get; set; }
        public int ExpireTimesInSecond { get; set; }
        //public string RequestId { get; set; }
    }
}
