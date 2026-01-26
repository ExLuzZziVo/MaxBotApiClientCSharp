#region

using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Chats
{
    public class ChatMembersOperationResult
    {
        /// <summary>
        /// Список участников чата
        /// </summary>
        public ChatMember[] Members { get; set; }

        /// <summary>
        /// Указатель на следующую страницу запрашиваемых данных
        /// </summary>
        public long? Marker { get; set; }
    }
}