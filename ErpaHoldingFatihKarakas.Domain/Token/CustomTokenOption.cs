namespace ErpaHoldingFatihKarakas.Domain.Token
{
    public class CustomTokenOption
    {

        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }

        public string SecurityKey { get; set; }
    }
}
