namespace Identity.Domain.Security
{
    public class TokenConfig
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
        public int Seconds { get; set; }
    }
}
