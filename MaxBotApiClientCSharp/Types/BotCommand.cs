namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Команда, поддерживаемая ботом
    /// </summary>
    public class BotCommand
    {
        /// <summary>
        /// Название команды
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание команды
        /// </summary>
        public string Description { get; set; }
    }
}