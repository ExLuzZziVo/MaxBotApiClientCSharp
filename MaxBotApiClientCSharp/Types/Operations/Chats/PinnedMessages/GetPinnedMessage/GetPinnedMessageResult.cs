namespace MaxBotApiClientCSharp.Types.Operations.Chats.PinnedMessages.GetPinnedMessage
{
    public class GetPinnedMessageResult
    {
        /// <summary>
        /// Закреплённое сообщение
        /// </summary>
        /// <remarks>
        /// Может быть null, если в чате нет закреплённого сообщения
        /// </remarks>
        public Message Message { get; set; }
    }
}
