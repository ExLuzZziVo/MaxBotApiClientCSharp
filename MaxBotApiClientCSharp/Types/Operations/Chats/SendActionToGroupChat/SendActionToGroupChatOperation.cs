#region

using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Chats.SendActionToGroupChat
{
    public class SendActionToGroupChatOperation
    {
        /// <summary>
        /// Действие, отправляемое участникам чата
        /// </summary>
        public SenderAction Action { get; set; }
    }
}