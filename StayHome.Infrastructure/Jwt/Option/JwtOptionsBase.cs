namespace Infrastructure.Jwt.Option;

public class JwtOptionsBase
{
    public const string Jwt = "jwt";

    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public TimeSpan Expire { get; set; }

    protected void Configuration(JwtOptionsBase jwt)
    {
        Key = jwt.Key;
        Issuer = jwt.Issuer;
        Audience = jwt.Audience;
    }
}