namespace MaxBotApiClientCSharp.Types.Operations.Chats
{
    public class ChatsOperationResult
    {
        /// <summary>
        /// Список запрашиваемых чатов
        /// </summary>
        public Chat[] Chats { get; set; }

        /// <summary>
        /// Указатель на следующую страницу запрашиваемых данных
        /// </summary>
        public long? Marker { get; set; }
    }
}