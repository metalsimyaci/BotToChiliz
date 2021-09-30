namespace BotToChiliz.Domain.DataAccess.EntityFramework.Utils
{
    internal record Constants
    {
        public const string SCHEME_NAME = "BotToChilizApp";
        
        public const int CURRENCY_CODE_MAX_LENGTH = 16;
        public const int CURRENCY_NAME_MAX_LENGTH = 256;
        public const int CURRENCY_DEFINITION_MAX_LENGTH = 512;
        
        public const int LOG_LEVEL_MAX_LENGTH = 128;
        
        public const int WORKER_NAME_MAX_LENGTH = 64;

        public const int WORKER_ORDER_KEY_LENGTH = 128;
    }
}