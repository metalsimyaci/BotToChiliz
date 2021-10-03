namespace BotToChiliz.Infrastructure.Adapter.Configuration
{
    public class ChilizClientConfiguration
    {
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public string BaseAddress { get; set; } = "Https://api.chiliz.net/";
    }
}