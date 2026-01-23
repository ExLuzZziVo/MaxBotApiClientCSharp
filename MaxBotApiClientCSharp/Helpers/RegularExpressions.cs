namespace MaxBotApiClientCSharp.Helpers
{
    public static class RegularExpressions
    {
        public const string ChatLinkExpression = "@?[a-zA-Z]+[a-zA-Z0-9-_]*";

        public const string MessageIdExpression = "[a-zA-Z0-9_\\-]+";

        public const string CallbackIdExpression = "^(?!\\s*$).+";
    }
}