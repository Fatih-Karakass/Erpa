﻿namespace ErpaHoldingFatihKarakas.Domain.Authentication
{
    public class UserRefreshToken
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
