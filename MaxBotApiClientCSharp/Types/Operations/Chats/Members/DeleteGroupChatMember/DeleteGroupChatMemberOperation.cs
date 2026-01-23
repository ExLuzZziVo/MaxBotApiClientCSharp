#region

using System.Text.Json.Serialization;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Chats.Members.DeleteGroupChatMember
{
    public class DeleteGroupChatMemberOperation
    {
        /// <summary>
        /// ID пользователя, которого нужно удалить из чата
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// Флаг, указывающий что пользователь будет заблокирован в чате
        /// </summary>
        /// <remarks>
        /// Применяется только для чатов с публичной или приватной ссылкой. Игнорируется в остальных случаях
        /// </remarks>
        public bool Block { get; set; }
    }
}