namespace BotToChiliz.Domain.DataAccess.EntityFramework.Configuration
{
    internal struct Constants
    {
        public const string DB_SCHEME_NAME = "BotToChilizApp";

        public const string EMAIL_REGEX_PATTERN = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string PHONE_NUMBER_REGEX_PATTERN = @"^(?:(?:(\+90|0\s*)?(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?$";

        public const int CURRENCY_CODE_MAX_LENGTH = 16;
        public const int CURRENCY_NAME_MAX_LENGTH = 256;
        public const int CURRENCY_DEFINITION_MAX_LENGTH = 512;
    }
}