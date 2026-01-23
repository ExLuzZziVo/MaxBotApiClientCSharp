namespace MaxBotApiClientCSharp.Types.Users
{
    /// <summary>
    /// Информация о боте
    /// </summary>
    public class BotInfo: UserWithPhoto
    {
        /// <summary>
        /// Команды, поддерживаемые ботом
        /// </summary>
        public BotCommand[] Commands { get; set; }
    }
}